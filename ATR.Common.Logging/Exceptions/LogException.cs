namespace ATR.Common.Logging
{
    using System;

    /// <summary>
    /// Exception thrown when there isn't any problem during logging process.
    /// </summary>
    [Serializable]
    public class LogException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogException" /> class.
        /// </summary>
        public LogException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LogException(string message)
            : base(message)
        {
            // Add any type-specific logic.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.
        /// If the innerException parameter is not a null reference, the current exception is raised
        /// in a catch block that handles the inner exception.</param>
        public LogException(string message, Exception innerException)
            : base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogException" /> class.
        /// </summary>
        /// <param name="info">The message that describes the error.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected LogException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
        #endregion Constructors
    }
}
