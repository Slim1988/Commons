namespace ATR.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Resources.MessagesResources;

    /// <summary>
    /// Extension methods for string objects.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Format the string of the application version number.
        /// </summary>
        /// <param name="value">String value to format.</param>
        /// <param name="separator">Character separator.</param>
        /// <param name="nbGroup">Integer number of group.</param>
        /// <returns>Current boolean value converted to string value for use extract data context.</returns>
        public static string GetSubGroups(this string value, char separator, int nbGroup)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            List<string> listString = new List<string>();

            string[] valueSplit = value.Split(separator);

            if (valueSplit.Length < nbGroup)
            {
                throw new IndexOutOfRangeException(Messages.numberGroupNotValid);
            }

            try
            {
                listString.AddRange(valueSplit);

                listString.RemoveRange(nbGroup, listString.Count - nbGroup);

                value = string.Join(separator.ToString(), listString);
            }
            catch (Exception)
            {
                throw new Exception(Messages.versionNotValid);
            }

            return value;
        }

        /// <summary>
        /// Uppercase the first char of a string.
        /// </summary>
        /// <param name="value">String to transform.</param>
        /// <returns>String with first char in uppercase.</returns>
        public static string FirstCharToUpper(this string value)
        {
            switch (value)
            {
                case null: throw new ArgumentNullException(nameof(value));
                case "": throw new ArgumentException(string.Format(Messages.empty, nameof(value)));
                default: return value.First().ToString().ToUpper() + value.Substring(1);
            }
        }
    }
}
