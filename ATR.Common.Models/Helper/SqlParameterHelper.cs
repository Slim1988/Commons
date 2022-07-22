namespace ATR.Common.Models.Helper
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Helper class for SQL parameters build, definition.
    /// </summary>
    public static class SqlParameterHelper
    {
        #region Public Methods

        #region Boolean parameters

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as bit type without data initialization.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <returns>SQL parameter object named <paramref name="name"/>.</returns>
        public static SqlParameter CreateBooleanParameter(string name)
        {
            return CreateParameter(name, SqlDbType.Bit);
        }

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as bit type initialized with <paramref name="data"/>.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <param name="data">Boolean to use for parameter value initialization.</param>
        /// <returns>
        /// SQL parameter object named <paramref name="name"/> initialized with <paramref name="data"/> value.
        /// </returns>
        public static SqlParameter CreateBooleanParameter(string name, bool data)
        {
            SqlParameter result = CreateBooleanParameter(name);
            result.Value = data;
            return result;
        }

        #endregion Boolean parameters

        #region Date time parameters

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as date time type without data initialization.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <returns>SQL parameter object named <paramref name="name"/>.</returns>
        public static SqlParameter CreateDateTimeParameter(string name)
        {
            return CreateParameter(name, SqlDbType.DateTime);
        }

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as date time type initialized with <paramref name="data"/>.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <param name="data">Date time to use for parameter value initialization.</param>
        /// <returns>
        /// SQL parameter object named <paramref name="name"/> initialized with <paramref name="data"/> value.
        /// </returns>
        public static SqlParameter CreateDateTimeParameter(string name, DateTime data)
        {
            SqlParameter result = CreateDateTimeParameter(name);
            result.Value = data;
            return result;
        }

        #endregion Date time parameters

        #region Integer parameters

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as integer type without data initialization.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <returns>SQL parameter object named <paramref name="name"/>.</returns>
        public static SqlParameter CreateIntegerParameter(string name)
        {
            return CreateParameter(name, SqlDbType.Int);
        }

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as integer type initialized with <paramref name="data"/>.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <param name="data">Integer to use for parameter value initialization.</param>
        /// <returns>
        /// SQL parameter object named <paramref name="name"/> initialized with <paramref name="data"/> value.
        /// </returns>
        public static SqlParameter CreateIntegerParameter(string name, int data)
        {
            SqlParameter result = CreateIntegerParameter(name);
            result.Value = data;
            return result;
        }

        #endregion Integer parameters

        #region String parameters

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as Unicode string type with maximum length <paramref name="size" /> without data initialization.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <param name="size">Maximum length of string.</param>
        /// <returns>SQL parameter object named <paramref name="name"/>.</returns>
        public static SqlParameter CreateStringParameter(string name, int size)
        {
            SqlParameter result = CreateParameter(name, SqlDbType.NVarChar);
            result.Size = size;
            return result;
        }

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as Unicode string type with maximum length <paramref name="size" /> initialized with <paramref name="data"/>.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <param name="size">Maximum length of string.</param>
        /// <param name="data">Integer to use for parameter value initialization.</param>
        /// <returns>
        /// SQL parameter object named <paramref name="name"/> initialized with <paramref name="data"/> value.
        /// </returns>
        public static SqlParameter CreateStringParameter(string name, int size, string data)
        {
            SqlParameter result = CreateStringParameter(name, size);
            result.Value = data;
            return result;
        }

        #endregion String parameters

        #region Empty parameter

        /// <summary>
        /// Build a SQL parameter object named <paramref name="name"/> defined as <paramref name="type"/> without data initialization.
        /// </summary>
        /// <param name="name">Name of SQL parameter to build.</param>
        /// <param name="type">Type of parameter to create.</param>
        /// <returns>SQL parameter object named <paramref name="name"/>.</returns>
        public static SqlParameter CreateParameter(string name, SqlDbType type)
        {
            #region Check parameters
            if (string.IsNullOrWhiteSpace(name))
            {
                // TODO: replace hard coded string by a call to nameof method when implemented solution with higher version of Visual Studio.
                throw new ArgumentNullException("name");
            }

            if (!name.StartsWith("@", StringComparison.OrdinalIgnoreCase))
            {
                name = "@" + name;
            }
            #endregion Check parameters

            return new SqlParameter
            {
                ParameterName = name,
                SqlDbType = type
            };
        }

        #endregion Empty parameter

        #endregion Public Methods
    }
}
