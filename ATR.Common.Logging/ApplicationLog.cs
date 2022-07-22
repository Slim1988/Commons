namespace ATR.Common.Logging
{
    /// <summary>
    /// Application log implementation.
    /// </summary>
    public class ApplicationLog : BaseLog
    {
        #region Private constants

        /// <summary>
        /// Constants that defines application logger name.
        /// </summary>
        /// <remarks>This value shall match value defined in configuration file.</remarks>
        private const string DefaultLoggerName = "ApplicationLog";

        #endregion Private constants

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLog" /> class.
        /// </summary>
        public ApplicationLog()
            : this(DefaultLoggerName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLog" /> class.
        /// </summary>
        /// <param name="name">Name of logger to implement.</param>
        public ApplicationLog(string name)
            : base(name)
        {
            this.NoLineBreak = false;
        }

        #endregion Constructor
    }
}
