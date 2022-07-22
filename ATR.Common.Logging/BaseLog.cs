namespace ATR.Common.Logging
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    using log4net;

    /// <summary>
    /// Base class for logs management.<br/>
    /// </summary>
    /// <remarks>
    /// This class is a convenient wrapper for Log4net loggers.<br/>
    /// Methods defined takes a variable number of parameters, making it easy to use.<br/>
    /// The test of logging level is done inside this class and therefore make the code more readable.<br/>
    /// Allowing as many parameters as desired, it's no longer useful to concatenate string in calling code (performance will be improved).<br/>
    /// The parameters will be printed in the order they appear in the calling method.<br/>
    /// Suggested usage is
    /// <ul>
    ///     <li>MethodBase class</li>
    ///     <li>strings or objects that implements ToString() method</li>
    ///     <li>an exception</li>
    /// </ul>
    /// </remarks>
    public class BaseLog : ILogManager
    {
        #region Private constants

        /// <summary>
        /// Constant that defines default label to log on error.
        /// </summary>
        private const string LogErrorDefaultMessage = "An exception has been thrown, please contact your administrator.";

        /// <summary>
        /// Constant that defines layer separator in error log.
        /// </summary>
        private const string LogErrorLayerSeparator = "##Error Layer #";

        /// <summary>
        /// Constant that defines logger crash message.
        /// </summary>
        private const string LoggerCrashMessage = "Error in base log.";

        /// <summary>
        /// Constant that defines value to use between elements in log entry.
        /// </summary>
        private const string LogEntrySeparator = " | ";

        /// <summary>
        /// Constant that defines value to identify or define a line break in log entry.
        /// </summary>
        private const string LogEntryLineBreak = "\r\n";

        /// <summary>
        /// Constant that defines value to identify or define a line break with one indentation in log entry.
        /// </summary>
        private const string LogEntryLineBreakIndented = "\r\n\t";

        #endregion Private constants

        #region Fields

        /// <summary>
        /// Last time measure for this thread. Will be appended in the next log line.
        /// </summary>
        [ThreadStatic]
        private static long lastElapsedTime;

        /// <summary>
        /// Last counter identifier used for this thread.
        /// </summary>
        [ThreadStatic]
        private static int lastTimerId;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLog"/> class with <paramref name="logger"/>.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public BaseLog(ILog logger)
        {
            this.Logger = logger;
            this.ResetLastElapsedTime();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLog" /> class with logger identified by <paramref name="loggerName"/>.
        /// </summary>
        /// <param name="loggerName">Name of the logger to use.</param>
        protected BaseLog(string loggerName)
        {
            this.Logger = LogManager.GetLogger(Assembly.GetCallingAssembly(), loggerName);
            this.ResetLastElapsedTime();
        }

        #endregion Constructor

        #region Properties

        #region ILogManager interface implementation

        /// <summary>
        /// Gets a value indicating whether the log manager is initialized and ready to log.
        /// </summary>
        /// <remarks>
        /// If no appenders is defined in configuration, the log manager will be considered as not initialized.
        /// </remarks>
        public bool IsInitialized
        {
            get
            {
                if (this.Logger == null || this.Logger.Logger == null || this.Logger.Logger.Repository == null)
                {
                    return false;
                }

                return this.Logger.Logger.Repository.GetAppenders().Any();
            }
        }

        /// <summary>
        /// Gets a value indicating whether debug level is enabled for current logger.
        /// </summary>
        public bool IsDebugEnabled
        {
            get
            {
                if (this.Logger == null)
                {
                    return false;
                }

                return this.Logger.IsDebugEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether information level is enabled for current logger.
        /// </summary>
        public bool IsInfoEnabled
        {
            get
            {
                if (this.Logger == null)
                {
                    return false;
                }

                return this.Logger.IsInfoEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether warning level is enabled for current logger.
        /// </summary>
        public bool IsWarnEnabled
        {
            get
            {
                if (this.Logger == null)
                {
                    return false;
                }

                return this.Logger.IsWarnEnabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether error level is enabled for current logger.
        /// </summary>
        public bool IsErrorEnabled
        {
            get
            {
                if (this.Logger == null)
                {
                    return false;
                }

                return this.Logger.IsErrorEnabled;
            }
        }

        #endregion ILogManager interface implementation

        /// <summary>
        /// Gets the logger.
        /// </summary>
        public ILog Logger { get; private set; }

        /// <summary>
        /// Gets the last elapsed time.
        /// </summary>
        protected static long LastElapsedTime
        {
            get
            {
                return lastElapsedTime;
            }
        }

        /// <summary>
        /// Gets the last timer identifier.
        /// </summary>
        protected static int LastTimerId
        {
            get
            {
                return lastTimerId;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether line break will be removed or not from log output.
        /// Default Value: false
        /// </summary>
        protected bool NoLineBreak { get; set; }

        #endregion Properties

        #region Public methods

        #region ILogManager interface implementation

        #region Debug methods

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Debug(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            try
            {
                if (this.IsDebugEnabled)
                {
                    this.Log(LogType.Debug, lineNumber, filePath, memberName, this.BuildLine(Format(label, args)));
                }
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public int DebugStart([CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            return this.DebugStart(string.Empty, lineNumber, filePath, memberName);
        }

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public int DebugStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            this.Debug(label, lineNumber, filePath, memberName);
            return this.StartTimeMeasure();
        }

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public int DebugStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            this.Debug(label, lineNumber, filePath, memberName, args);
            return this.StartTimeMeasure();
        }

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and stop time measure.
        /// </summary>
        /// <param name="counter">Identifier of counter started.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void DebugStop(int counter, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            this.DebugStop(counter, string.Empty, lineNumber, filePath, memberName);
        }

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and stop time measure.
        /// </summary>
        /// <param name="counter">Identifier of counter started.</param>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void DebugStop(int counter, string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            this.StopTimeMeasure(counter);
            this.Debug(label, lineNumber, filePath, memberName);
        }

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and stop time measure.
        /// </summary>
        /// <param name="counter">Identifier of counter started.</param>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void DebugStop(int counter, string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            this.StopTimeMeasure(counter);
            this.Debug(label, lineNumber, filePath, memberName, args);
        }

        #endregion Debug methods

        #region Info methods

        /// <summary>
        /// Add a log entry at information level if information level is activated in current logger.
        /// </summary>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public virtual void Info(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            try
            {
                if (this.IsInfoEnabled)
                {
                    this.Log(LogType.Info, lineNumber, filePath, memberName, this.BuildLine(label));
                }
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        /// <summary>
        /// Add a log entry at information level if information level is activated in current logger.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public virtual void Info(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            try
            {
                if (this.IsInfoEnabled)
                {
                    this.Log(LogType.Info, lineNumber, filePath, memberName, this.BuildLine(Format(label, args)));
                }
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        /// <summary>
        /// Add a log entry at information level if information level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public virtual int InfoStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            this.Info(label, lineNumber, filePath, memberName);
            return this.StartTimeMeasure();
        }

        /// <summary>
        /// Add a log entry at information level if information level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public int InfoStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            this.Info(label, lineNumber, filePath, memberName, args);
            return this.StartTimeMeasure();
        }

        /// <summary>
        /// Add a log entry at information level if information level is activated in current logger and stop time measure.
        /// </summary>
        /// <param name="counter">Identifier of counter started.</param>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public virtual void InfoStop(int counter, string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            this.StopTimeMeasure(counter);
            this.Info(label, lineNumber, filePath, memberName, args);
        }

        #endregion Info methods

        #region Warning methods

        /// <summary>
        /// Add a log entry at warning level if warning level is activated in current logger.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Warn(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            try
            {
                if (this.IsWarnEnabled)
                {
                    this.Log(LogType.Warning, lineNumber, filePath, memberName, this.BuildLine(Format(label, args)));
                }
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        /// <summary>
        /// Add a log entry at warning level if warning level is activated in current logger.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="exception">Exception to add to log</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Warn(string label, Exception exception, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            try
            {
                if (this.IsWarnEnabled)
                {
                    this.Log(LogType.Warning, lineNumber, filePath, memberName, this.BuildLine(Format(label, args), exception));
                }
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        #endregion Warning methods

        #region Error methods

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="exception">Exception object to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Error(Exception exception, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            this.Error(LogErrorDefaultMessage, exception, lineNumber, filePath, memberName, null);
        }

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Error([CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            try
            {
                this.Log(LogType.Error, lineNumber, filePath, memberName, this.BuildLine(args));
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="label">Log message</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Error(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            try
            {
                this.Log(LogType.Error, lineNumber, filePath, memberName, this.BuildLine(label));
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Error(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            try
            {
                this.Log(LogType.Error, lineNumber, filePath, memberName, this.BuildLine(Format(label, args)));
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="exception">Exception to add to log</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        public void Error(string label, Exception exception, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args)
        {
            try
            {
                this.Log(LogType.Error, lineNumber, filePath, memberName, this.BuildLine(Format(label, args), exception));
            }
            catch (LogException ex)
            {
                this.ErrorWithException(ex, LoggerCrashMessage);
            }
        }

        #endregion Error methods

        #region Timer methods

        /// <summary>
        /// Starts a stopwatch and returns its identifier.
        /// </summary>
        /// <returns>Identifier of timer started.</returns>
        public int StartTimeMeasure()
        {
            this.ResetLastElapsedTime();
            lastTimerId = Timer.Start(this);
            return lastTimerId;
        }

        /// <summary>
        /// Stops the stopwatch identified by <paramref name="counterId"/> value.
        /// </summary>
        /// <param name="counterId">Identifier of timer to stop.</param>
        public void StopTimeMeasure(int counterId)
        {
            lastElapsedTime = Timer.Stop(counterId);
        }

        #endregion Timer methods

        #region Line builders methods

        /// <summary>
        /// Take the argument list of log function and build a message.<br/>
        /// For the other objects, ToString() method is applied to get content information.
        /// </summary>
        /// <param name="args">Arguments to log</param>
        /// <returns>A string to log.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "General Exception catching to prevent any logging error to break the application")]
        public virtual string BuildLine(params object[] args)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                bool skipLine = false;

                if (args != null)
                {
                    bool firstItem = true;

                    // Browse all objects to log
                    foreach (object item in args)
                    {
                        if (firstItem)
                        {
                            firstItem = false;
                        }
                        else
                        {
                            // Not first item, add a separator before element
                            sb.Append(LogEntrySeparator);
                        }

                        MethodBase m = item as MethodBase;
                        if (m != null)
                        {
                            sb.Append("[");

                            if (m.DeclaringType != null)
                            {
                                sb.Append(m.DeclaringType.Name);
                            }

                            sb.Append("::");
                            sb.Append(m.Name);
                            sb.Append("]");
                            sb.Append(" ");
                        }
                        else if (!this.ManageException(sb, item as Exception))
                        {
                            string s = item as string;
                            if (s != null && s.Equals(LogEntryLineBreak, StringComparison.OrdinalIgnoreCase))
                            {
                                // Explicitly add a line break
                                skipLine = true;
                            }
                            else if (s != null)
                            {
                                sb.Append(s);
                                sb.Append(" ");
                            }
                            else if (item != null)
                            {
                                sb.Append(item.ToString());
                                sb.Append(" ");
                            }
                            else
                            {
                                sb.Append("null");
                                sb.Append(" ");
                            }
                        }
                    }
                }

                // Add time to end of line if needed
                if (lastElapsedTime > -1)
                {
                    sb.Append(LogEntrySeparator);
                    sb.Append(lastElapsedTime.ToString("0' ms'", CultureInfo.InvariantCulture));
                    this.ResetLastElapsedTime();
                }

                // Add carriage return if asked
                if (skipLine)
                {
                    sb.Append(LogEntryLineBreak);
                }
            }
            catch (Exception e)
            {
                sb.Append("Issue while producing log line :");
                sb.Append(e);
            }

            return sb.ToString();
        }

        #endregion Line builders methods

        #endregion ILogManager interface implementation

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Reset the last elapsed time.
        /// </summary>
        protected void ResetLastElapsedTime()
        {
            lastElapsedTime = -1;
        }

        /// <summary>
        /// Add <paramref name="exception"/> information into <paramref name="builder"/> with adequate format.<br/>
        /// </summary>
        /// <param name="builder">String builder object to update with <paramref name="exception"/> information.</param>
        /// <param name="exception">Exception to add into <paramref name="builder"/>.</param>
        protected virtual void ManageExceptionOutput(StringBuilder builder, Exception exception)
        {
            #region Check parameters

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            #endregion Check parameters

            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}Error : {1} : {2}", LogEntryLineBreakIndented, exception.GetType().Name, exception.Message);
            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}Stack trace : {1}{2}", LogEntryLineBreakIndented, LogEntryLineBreak, exception.StackTrace);

            Exception innerException = exception.InnerException;
            int level = 0;
            bool isInnerException = false;

            #region Display the inner exception tree (max 10 level)

            while (innerException != null && level < 10)
            {
                builder.AppendFormat(CultureInfo.InvariantCulture, "{0}{1}{2}", LogEntryLineBreak, LogErrorLayerSeparator, level);

                if (isInnerException)
                {
                    builder.Append(LogEntryLineBreak);
                }

                if (!string.IsNullOrWhiteSpace(innerException.Source))
                {
                    builder.AppendFormat(CultureInfo.InvariantCulture, "{0}(**SOURCE**){1}{0}", LogEntryLineBreak, innerException.Source);
                }

                builder.AppendFormat(CultureInfo.InvariantCulture, "(**EXCEPTION TYPE**){1}{0}", LogEntryLineBreak, innerException.GetType());
                builder.AppendFormat(CultureInfo.InvariantCulture, "(**MESSAGE**){0}{1}", LogEntryLineBreak, innerException.Message);

                if (!string.IsNullOrWhiteSpace(innerException.StackTrace))
                {
                    builder.AppendFormat(CultureInfo.InvariantCulture, "{0}(**STACKTRACE**){0}{1}{0}", LogEntryLineBreak, innerException.StackTrace);
                }

                innerException = innerException.InnerException;

                if (innerException != null)
                {
                    isInnerException = true;
                }

                level++;
            }

            #endregion Display the inner exception tree (max 10 level)

            builder.Append(LogEntryLineBreakIndented);
        }

        #endregion Protected methods

        #region Static private methods

        /// <summary>
        /// Format a string with the associated arguments.
        /// </summary>
        /// <param name="messageWithFormat">Message to format.</param>
        /// <param name="args">Arguments to include in message.</param>
        /// <returns>Returns well formatted string.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Last level of the Error log")]
        private static string Format(string messageWithFormat, params object[] args)
        {
            string message = null;
            try
            {
                if (messageWithFormat == null)
                {
                    return string.Empty;
                }

                if (args != null && args.Length > 0)
                {
                    message = string.Format(CultureInfo.InvariantCulture, messageWithFormat, args);
                }
                else
                {
                    message = messageWithFormat;
                }
            }
            catch
            {
                message = "Logger error";
            }

            return message;
        }

        /// <summary>
        /// Sets the context log information.
        /// </summary>
        /// <param name="lineNumber">Line number in caller filer.</param>
        /// <param name="filePath">Caller file path.</param>
        /// <param name="memberName">Name of the method that includes caller.</param>
        private static void SetContextLogInformation(int lineNumber, string filePath, string memberName)
        {
            GlobalContext.Properties["class"] = filePath.Substring(filePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            GlobalContext.Properties["method"] = memberName;
            GlobalContext.Properties["line"] = lineNumber.ToString(CultureInfo.InvariantCulture);
            GlobalContext.Properties["pid"] = Process.GetCurrentProcess().Id;
            GlobalContext.Properties["host"] = Environment.MachineName;
            GlobalContext.Properties["login"] = Environment.UserName;
        }

        #endregion Static private methods

        #region Private methods

        /// <summary>
        /// Logs the message according to log type defined.
        /// </summary>
        /// <param name="logType">Log type.</param>
        /// <param name="lineNumber">Line number in caller filer.</param>
        /// <param name="filePath">Caller file path.</param>
        /// <param name="memberName">Name of the method that includes caller.</param>
        /// <param name="message">Message to log</param>
        private void Log(LogType logType, int lineNumber, string filePath, string memberName, string message)
        {
            try
            {
                SetContextLogInformation(lineNumber, filePath, memberName);

                switch (logType)
                {
                    case LogType.Error:
                        this.Logger.Error(message);
                        break;
                    case LogType.Warning:
                        this.Logger.Warn(message);
                        break;
                    case LogType.Info:
                        this.Logger.Info(message);
                        break;
                    case LogType.Debug:
                        this.Logger.Debug(message);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (LogException ex)
            {
                // Check if not a recursive logger crash (sample data connection lost in database storage)
                if (!message.Equals(LoggerCrashMessage, StringComparison.OrdinalIgnoreCase))
                {
                    this.ErrorWithException(ex, LoggerCrashMessage);
                }
            }
        }

        /// <summary>
        /// Treatment for errors with exception.
        /// </summary>
        /// <param name="exception">Exception to add into log.</param>
        /// <param name="label">Message to log.</param>
        private void ErrorWithException(Exception exception, string label)
        {
            try
            {
                this.Log(LogType.Error, 0, string.Empty, string.Empty, this.BuildLine(label, exception));
            }
            catch (LogException ex)
            {
                // Check if not a recursive logger crash (sample data connection lost in database storage)
                if (!label.Equals(LoggerCrashMessage, StringComparison.OrdinalIgnoreCase))
                {
                    this.ErrorWithException(ex, LoggerCrashMessage);
                }
            }
        }

        /// <summary>
        /// Define the process of the management of the exception into the provided string builder.
        /// </summary>
        /// <param name="builder">String builder object to update with <paramref name="exception"/> information.</param>
        /// <param name="exception">Exception to add into <paramref name="builder"/>.</param>
        /// <returns>True if the specified exception is not null, false otherwise.</returns>
        private bool ManageException(StringBuilder builder, Exception exception)
        {
            #region Check parameters

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (exception == null)
            {
                return false;
            }

            #endregion Check parameters

            this.ManageExceptionOutput(builder, exception);

            return true;
        }

        #endregion Private methods
    }
}
