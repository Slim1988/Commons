namespace ATR.Common.Extensions
{
    /// <summary>
    /// Extension methods for boolean objects.
    /// </summary>
    public static class BooleanExtension
    {
        #region Constants

        /// <summary>
        /// Defines label to return for a boolean value set to true in extract data result.
        /// </summary>
        private const string ExtractLabelTrue = "Yes";

        /// <summary>
        /// Defines label to return for a boolean value set to false in extract data result.
        /// </summary>
        private const string ExtractLabelFalse = "No";

        #endregion Constants

        #region Public methods for conversions to string in extract context.

        /// <summary>
        /// Converts boolean value to string value for use in extract data context.
        /// </summary>
        /// <param name="value">Boolean value to convert to string value for extract context.</param>
        /// <returns>Current boolean value converted to string value for use extract data context.</returns>
        public static string ToStringExtract(this bool value)
        {
            return value ? ExtractLabelTrue : ExtractLabelFalse;
        }

        /// <summary>
        /// Converts boolean value to string value for use in extract data context.
        /// </summary>
        /// <param name="value">Boolean value to convert to string value for extract context.</param>
        /// <returns>Current boolean value converted to string value for use extract data context.</returns>
        public static string ToStringExtract(this bool? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToStringExtract();
            }

            // If no value defined, consider that value is false.
            return false.ToStringExtract();
        }

        #endregion Public methods for conversions to string in extract context.
    }
}
