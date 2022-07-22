namespace ATR.Common.Helpers.Data
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using ATR.Common.Models;
    using ATR.Common.Models.Requests;

    /// <summary>
    /// Helper class for Application
    /// </summary>
    public static class ApplicationHelper
    {
        /// <summary>
        /// Get a sub code from an application code
        /// </summary>
        /// <param name="applicationCode">The application code containing the sub codes separated by the delimiter</param>
        /// <param name="delimiter">the delimiter of the application code</param>
        /// <param name="prefix">The prefix of the sub code</param>
        /// <returns>The sub code of the application code</returns>
        public static string GetSubCode(string applicationCode, char delimiter, string prefix)
        {
            string result = string.Empty;

            // Split the application code with the delimiter
            string[] codes = applicationCode.Split(delimiter);
            foreach (string code in codes)
            {
                // Check if the prefix exist in the code and get the sub code
                if (code.Length > 0 && code.Contains(prefix))
                {
                    result = code.Substring(code.IndexOf(prefix) + prefix.Length);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Get Applications Message And Solution Concatenation By Application
        /// </summary>
        /// <param name="appMessageMessage">The app message message column</param>
        /// <param name="appMessageSolution">The app message solution column</param>
        /// <returns>A concatenation of message and solution</returns>
        public static string GetApplicationsMessageAndSolutionConcatenation(string appMessageMessage, string appMessageSolution)
        {
            return string.Concat(appMessageMessage, appMessageSolution != null ? string.Concat("<br>", appMessageSolution) : string.Empty);
        }

        /// <summary>
        /// Get webmaster message from applications messages datatable
        /// </summary>
        /// <param name="applicationCodeKey">The key name of application code in web.config file</param>
        /// <param name="messageCode">The message code to retrieve data in applications messages datatable</param>
        /// <returns>A string containing the webmaster message</returns>
        public static string GetWebmasterMessage(string applicationCodeKey, string messageCode)
        {
            string webmasterMessage = string.Empty;

            string applicationCode = ConfigurationManager.AppSettings[applicationCodeKey];
            if (applicationCode != null)
            {
                // Get the application message for the custom notification if any
                APPLICATIONS_MESSAGES appMessage = DataModelRequests.GetApplicationsMessagesByApplication(applicationCode, messageCode);
                if (appMessage != null)
                {
                    webmasterMessage = GetApplicationsMessageAndSolutionConcatenation(appMessage.MESSAGE, appMessage.SOLUTION);
                }
            }
            else
            {
                throw new ApplicationException(string.Format("Error while retrieving the '{0}' property in the Web.config file", applicationCodeKey));
            }

            return webmasterMessage;
        }

        /// <summary>
        /// Get code stored in web.config file. Those codes need to be in appSettings
        /// </summary>
        /// <param name="key">The name of the key where the code are stored</param>
        /// <param name="delimiter">delimiter between codes</param>
        /// <returns>A list of codes</returns>
        public static List<string> GetCodesFromWebConfig(string key, char delimiter)
        {
            try
            {
                List<string> codes = ConfigurationManager.AppSettings[key].Split(delimiter).Select(p => p.Trim()).ToList();
                return codes;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format("Error while retrieving codes from {0} property in the Web.config file", key));
            }
        }

        /// <summary>
        /// Get Entity Administrators Email
        /// </summary>
        /// <param name="user">User Session Model</param>
        /// <returns>The list of admin</returns>
        public static string GetEntityAdministratorsEmail(UserSessionModel user)
        {
            List<USERS> entityAdministrators = DataModelRequests.GetEntityAdministrators(user.EntityId);
            List<string> entityAdministratorsEmail = entityAdministrators.Where(w => w.SUBSCRIPTION_STATUS.ToLower().Equals("validated") && !string.IsNullOrWhiteSpace(w.EMAIL_ADDRESS)).Select(x => x.EMAIL_ADDRESS).Distinct().ToList();

            return string.Join(";", entityAdministratorsEmail);
        }
    }
}
