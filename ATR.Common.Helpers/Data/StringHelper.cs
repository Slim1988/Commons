namespace ATR.Common.Helpers.Data
{
    using System;
    using System.Globalization;
    using System.Text;
    using ATR.Common.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Helper class for String.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Convert an object into string
        /// </summary>
        /// <param name="label">label of the object to convert</param>
        /// <param name="objectToConvert">ObjectToConvert</param>
        /// <returns>object converted into string</returns>
        public static string GetStringFromObject(string label, object objectToConvert)
        {
            string returnedString = string.Concat(label, ": ");

            try
            {
                Type objectType = objectToConvert.GetType();
                switch (objectType.ToString())
                {
                    case "System.Int32":
                        returnedString += Convert.ToString(objectToConvert);
                        break;
                    case "System.String":
                        returnedString += objectToConvert.ToString();
                        break;
                    case "System.Int64":
                        returnedString += Convert.ToString(objectToConvert);
                        break;
                    case "System.Boolean":
                        returnedString += objectToConvert.ToString();
                        break;
                    case "System.Object":
                        returnedString += JsonConvert.SerializeObject(objectToConvert, Formatting.Indented);
                        break;
                    default:
                        returnedString += JsonConvert.SerializeObject(objectToConvert, Formatting.Indented);
                        break;
                }
            }
            catch (Exception ex)
            {
                LoggingService.Application.Error(string.Format("Cannot convert {0} parameter", label));
                throw new ApplicationException(string.Format("Cannot convert {0} parameter", label), ex);
            }

            return returnedString;
        }

        /// <summary>
        /// Parse String date to nullable datetime
        /// </summary>
        /// <param name="text">The date</param>
        /// <returns>A datetime?</returns>
        public static DateTime? TryParse(string text)
        {
            DateTime date;
            if (DateTime.TryParse(text, out date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes accent marks from each letter
        /// </summary>
        /// <param name="inputString">the string with accent marks</param>
        /// <returns>the result string without accent marks</returns>
        public static string RemoveDiacritics(string inputString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string normalizedString = inputString.Normalize(NormalizationForm.FormD);
            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
