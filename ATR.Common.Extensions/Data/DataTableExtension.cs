namespace ATR.Common.Extensions.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Extension methods for data table objects.
    /// </summary>
    public static class DataTableExtension
    {
        #region Constants

        /// <summary>
        /// Defines the string used as field or column separator.
        /// </summary>
        private const string FieldSeparator = ";";

        #endregion Constants

        #region Public method to convert data table to list of strings for data extract purpose

        /// <summary>
        /// Converts data table to a list of string.
        /// Each string correspond to a row of the data table.
        /// The first item in the list will be the headers of columns.
        /// </summary>
        /// <param name="value">Boolean value to convert to string value for extract context.</param>
        /// <returns>Current boolean value converted to string value for use extract data context.</returns>
        /// <exception cref="ArgumentNullException">Exception thrown if instance of data table object wasn't set.</exception>
        /// <exception cref="ArgumentException">Exception set if there isn't columns defined for the data table.</exception>
        public static IList<string> ToStringListExtract(this DataTable value)
        {
            #region Check parameters
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Columns == null || value.Columns.Count == 0)
            {
                throw new ArgumentException("No columns defined in data table.", nameof(value));
            }
            #endregion Check parameters

            #region Define locales
            List<string> result = new List<string>();
            #endregion Define locales

            #region Build columns header
            string[] header = value.Columns.Cast<DataColumn>().Select(c => c.Caption).ToArray();
            result.Add(string.Join(FieldSeparator, header));
            #endregion Build columns header

            List<string> rows = value.Rows.Cast<DataRow>().Select(r => string.Join(FieldSeparator, r.ItemArray)).ToList<string>();
            result.AddRange(rows);
            return result;
        }

        #endregion Public method to convert data table to list of strings for data extract purpose
    }
}
