namespace ATR.Common.Logging
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;

    using log4net;
    using log4net.Appender;
    using log4net.Repository;

    /// <summary>
    /// The logging service to use in application.
    /// </summary>
    public static class LoggingService
    {
        #region Properties

        // Define as many logger as needed for the application.
        // In some cases, separated log files are required one for application logs, one for audit purpose i.e. log actions made by users,
        // one for performance logging

        /// <summary>
        /// Gets the log manager to use for application log.
        /// </summary>
        public static ILogManager Application { get; private set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Initializes the <see cref="LoggingService" /> class.
        /// </summary>
        /// <param name="applicationLogger">The log manager to use for application log.</param>
        public static void Initialize(ILogManager applicationLogger)
        {
            Initialize(string.Empty, applicationLogger);
        }

        /// <summary>
        /// Initializes the <see cref="LoggingService" /> class.
        /// </summary>
        /// <param name="logPath">Common log path to use as target folder for all loggers.</param>
        /// <param name="applicationLogger">The log manager to use for application log.</param>
        /// <remarks>
        /// Use of this method suppose that log path in configuration file is defined using property called logpath.
        /// This is useful for example on a heavy client application where user folder depends on application installation.
        /// See example below:
        /// <code>
        /// <file type="log4net.Util.PatternString" value="%property{logpath}\MyFile.log" />
        /// </code>
        /// </remarks>
        public static void Initialize(string logPath, ILogManager applicationLogger)
        {
            #region Define global property indicating the log path - Must be done before loading configuration
            if (string.IsNullOrWhiteSpace(logPath))
            {
                logPath = ".";
            }

            GlobalContext.Properties["logpath"] = logPath;
            #endregion Define global property indicating the log path - Must be done before loading configuration

            log4net.Config.XmlConfigurator.Configure();

            log4net.Util.SystemInfo.NullText = "<empty>"; // change nulls by specific EMPTY string
            GlobalContext.Properties["pid"] = Process.GetCurrentProcess().Id;
            GlobalContext.Properties["thread"] = Thread.CurrentThread.ManagedThreadId;

            Application = applicationLogger;

            // Clean up logs if needed. This method is a workaround of log4net issue with rolling file appender defined as composite.
            CleanUpLogs();
        }

        #endregion Public Methods

        #region Private methods

        /// <summary>
        /// Clean all logs folder and files according to the appenders defined in the repository.
        /// </summary>
        private static void CleanUpLogs()
        {
            // Get log4net repository
            ILoggerRepository repository = LogManager.GetAllRepositories().FirstOrDefault();
            if (repository == null)
            {
                return;
            }

            // Get all appenders
            List<IAppender> appenders = repository.GetAppenders().ToList();

            #region Parse appenders list
            foreach (IAppender item in appenders)
            {
                RollingFileAppender appender = item as RollingFileAppender;

                #region Only composite rolling file appenders are concerned by this specific treatment
                if (appender == null || appender.RollingStyle != RollingFileAppender.RollingMode.Composite)
                {
                    continue;
                }
                #endregion Only composite rolling file appenders are concerned by this specific treatment

                CleanAppender(appender);
            }
            #endregion Parse appenders list
        }

        /// <summary>
        /// Clean log folder according to <paramref name="appender"/> definition.
        /// No exception is thrown even if a data is missing or is not compliant with the treatment. The treatment just stops.
        /// </summary>
        /// <param name="appender">Appender definition that contains all properties.</param>
        private static void CleanAppender(RollingFileAppender appender)
        {
            #region Check parameters
            if (appender == null)
            {
                return;
            }
            #endregion Check parameters

            #region Define locales
            string folder = Path.GetDirectoryName(appender.File);
            string fileName = Path.GetFileName(appender.File);
            string datePattern = appender.DatePattern;
            int max = appender.MaxSizeRollBackups;

            #endregion Define locales

            #region Check properties of appender
            if (!appender.StaticLogFileName)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(folder) || string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(datePattern))
            {
                return;
            }

            if (max <= 0)
            {
                return;
            }
            #endregion Check properties of appender

            // Build file pattern to search - File name followed by date pattern (replacing values by ? character). Adding ".*" to manage case of multiple files in the same day after rolling on size.
            string datePatternConverted = Regex.Replace(datePattern, @"[a-zA-Z]", @"?");
            string filePattern = string.Format(CultureInfo.InvariantCulture, "{0}{1}.*", fileName, datePatternConverted);

            #region Get files from log folder
            DirectoryInfo directory = new DirectoryInfo(folder);
            if (!directory.Exists)
            {
                return;
            }

            List<FileInfo> files = directory.GetFiles(filePattern, SearchOption.TopDirectoryOnly).ToList();
            #endregion Get files from log folder

            #region Parse list of files
            int idx = 0;
            foreach (FileInfo item in files.OrderByDescending(f => f.Name))
            {
                // Increment index value used to keep as many files as defined in appender property
                idx++;

                // If file shall be kept or if file doesn't exists, nothing is done
                if (idx <= @max || !item.Exists)
                {
                    continue;
                }

                // Delete file
                item.Delete();
            }
            #endregion Parse list of files
        }
        #endregion Private methods
    }
    }
