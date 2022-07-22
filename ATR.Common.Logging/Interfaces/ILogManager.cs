namespace ATR.Common.Logging
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Describe logging properties and methods that must be implemented by a logger.
    /// </summary>
    public interface ILogManager
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether the log manager is initialized and ready to log.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Gets a value indicating whether debug level is enabled for current logger.
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether information level is enabled for current logger.
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether warning level is enabled for current logger.
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether error level is enabled for current logger.
        /// </summary>
        bool IsErrorEnabled { get; }

        #endregion Properties

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
        void Debug(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        int DebugStart([CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        int DebugStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

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
        int DebugStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and stop time measure.
        /// </summary>
        /// <param name="counter">Identifier of counter started.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        void DebugStop(int counter, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

        /// <summary>
        /// Add a log entry at debug level if debug level is activated in current logger and stop time measure.
        /// </summary>
        /// <param name="counter">Identifier of counter started.</param>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        void DebugStop(int counter, string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

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
        void DebugStop(int counter, string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

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
        void Info(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

        /// <summary>
        /// Add a log entry at information level if information level is activated in current logger.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        void Info(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

        /// <summary>
        /// Add a log entry at information level if information level is activated in current logger and start time measure.
        /// </summary>
        /// <param name="label">Message to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <returns>Identifier of counter started.</returns>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        int InfoStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

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
        int InfoStart(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

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
        void InfoStop(int counter, string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

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
        void Warn(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

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
        void Warn(string label, Exception exception, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

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
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error", Justification = "The method name is consistent in this context.")]
        void Error(Exception exception, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error", Justification = "The method name is consistent in this context.")]
        void Error([CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="label">Log message</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error", Justification = "The method name is consistent in this context.")]
        void Error(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "");

        /// <summary>
        /// Add a log entry at error level no matter if error level is activated or not.
        /// </summary>
        /// <param name="label">Message define with composite format items to log.</param>
        /// <param name="lineNumber">Reflection for line number in caller file.</param>
        /// <param name="filePath">Reflection for caller file.</param>
        /// <param name="memberName">Reflection for method in caller file.</param>
        /// <param name="args">Arguments for formated message.</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Use of default parameter values is required for proper use of the caller attributes.")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error", Justification = "The method name is consistent in this context.")]
        void Error(string label, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

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
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error", Justification = "The method name is consistent in this context.")]
        void Error(string label, Exception exception, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", params object[] args);

        #endregion Error methods

        #region Timer methods

        /// <summary>
        /// Starts a stopwatch and returns its identifier.
        /// </summary>
        /// <returns>Identifier of timer started.</returns>
        int StartTimeMeasure();

        /// <summary>
        /// Stops the stopwatch identified by <paramref name="counterId"/> value.
        /// </summary>
        /// <param name="counterId">Identifier of timer to stop.</param>
        void StopTimeMeasure(int counterId);

        #endregion Timer methods

        #region Line builders methods

        /// <summary>
        /// Take the Argument list of Log function and build a message.
        /// For the other objects, toString() is applied to get content information.
        /// </summary>
        /// <param name="args">Arguments to log.</param>
        /// <returns>A string to log.</returns>
        string BuildLine(params object[] args);

        #endregion Line builders methods
    }
}
