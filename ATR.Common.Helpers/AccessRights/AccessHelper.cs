namespace ATR.Common.Helpers.AccessRights
{
    using System.Collections.Specialized;
    using System.Configuration;
    using ATR.Common.Enumerations;
    using ATR.Common.Helpers.Data;
    using ATR.Common.Logging;
    using ATR.Common.Models;
    using ATR.Common.Models.Requests;

    public static class AccessHelper
    {
        /// <summary>
        /// Get the url of the AccessDenied Page
        /// </summary>
        /// <returns>URL of the access denied page</returns>
        public static string GetAccessDeniedURL()
        {
            NameValueCollection urlConfiguration = ConfigurationManager.GetSection("urls") as NameValueCollection;
            return string.Concat(urlConfiguration["CurrentApp"], "/AccessDenied");
        }

        /// <summary>
        /// Has User Base Access is used to check default access rules on BO applications
        /// </summary>
        /// <param name="currentUser">The user session model</param>
        /// <returns>An access code</returns>
        public static AccessCode HasUserBaseAccess(UserSessionModel currentUser)
        {
            // Initialize the error message with the user login
            string errorMessage = string.Concat("The user ", currentUser.UserLogin, " (id " + currentUser.IdUser + " / entity id " + currentUser.EntityId + ") can not access: {0}");

            // The user must be validated to have access
            if (!currentUser.IsValidatedStatus)
            {
                LoggingService.Application.Warn(string.Format(errorMessage, "his status is not \"Validated\""));
                return AccessCode.UserNotValidated;
            }

            // The user's entity must be validated to have access
            if (!currentUser.IsEntityValidatedStatus)
            {
                LoggingService.Application.Warn(string.Format(errorMessage, "his entity status is not \"Validated\""));
                return AccessCode.EntityNotValidated;
            }

            // The user's entity must have validated TCU & CGV to have access
            if (!currentUser.IsEntityTcuCgvChecked)
            {
                LoggingService.Application.Warn(string.Format(errorMessage, "his entity does not have TCU & CGV checked"));
                if (currentUser.IsAdministrator)
                {
                    return AccessCode.AdminTcuCgvNotChecked;
                }
                else
                {
                    return AccessCode.EntityTcuCgvNotChecked;
                }
            }

            LoggingService.Application.Info($"The user {currentUser.UserLogin} (id {currentUser.IdUser} / entity id {currentUser.EntityId}) can access");
            return AccessCode.UserHasAccess;
        }

        /// <summary>
        /// Get Access Denied Message By Access Code
        /// </summary>
        /// <param name="user">The user session model</param>
        /// <returns>A message</returns>
        public static string GetAccessDeniedMessageByAccessCode(UserSessionModel user)
        {
            string message = "For further information, please contact your ATRactive administrator(s).";
            NameValueCollection urlConfiguration = ConfigurationManager.GetSection("urls") as NameValueCollection;
            NameValueCollection mailConfiguration = ConfigurationManager.GetSection("mail") as NameValueCollection;

            // User not found in database
            if (user.HasApplicationsAccess == AccessCode.UserNotFound)
            {
                message = "User not found";
            }

            // User non validé
            else if (user.HasApplicationsAccess == AccessCode.UserNotValidated)
            {
                string admins = ApplicationHelper.GetEntityAdministratorsEmail(user);
                message = string.Format(GetAccessDeniedMessageByCode("EF-USR-NOTVALIDATED", "Access denied. Your account has not been validated yet. For further information, please contact your <a href=\"mailto:{0}\" > ATRactive administrator(s): {0}</a>."), admins);
            }

            // Entité du user non validée
            else if (user.HasApplicationsAccess == AccessCode.EntityNotValidated)
            {
                string webmasterEmail = mailConfiguration["WebmasterEmail"];
                message = string.Format(GetAccessDeniedMessageByCode("EF-ENT-NOTVALIDATED", "Access Denied. Your account has not been validated yet. For further information, please contact Webmaster team: <a href=\"mailto:{0}\" > {0}</a>."), webmasterEmail);
            }

            // User non Admin & TCU/CGV non signées
            else if (user.HasApplicationsAccess == AccessCode.EntityTcuCgvNotChecked)
            {
                string admins = ApplicationHelper.GetEntityAdministratorsEmail(user);
                message = string.Format(GetAccessDeniedMessageByCode("EF-ENT-TCUCGV-NOTCHECKED", "CGV and/or TCU have to be signed. Please contact your <a href=\"mailto:{0}\" > ATRactive administrator(s): {0}</a>."), admins);
            }

            // User Admin & TCU/CGV non signées
            else if (user.HasApplicationsAccess == AccessCode.AdminTcuCgvNotChecked)
            {
                message = string.Format(GetAccessDeniedMessageByCode("EF-ADM-TCUCGV-NOTCHECKED", "CGV and/or TCU have to be signed for your company. Please go to My Company page to sign it: <a href=\"{0}\">MyCompany</a>"), string.Concat(urlConfiguration["Mys"], "/MyCompany"));
            }

            // User qui n'a pas accès à l'application(dans le cas où sa compagnie a accès à l'app)
            else if (user.HasApplicationsAccess == AccessCode.ApplicationAccessDeniedForUser)
            {
                string admins = ApplicationHelper.GetEntityAdministratorsEmail(user);
                message = string.Format(GetAccessDeniedMessageByCode("EF-USR-APPDENIED", "Access denied. To ask for access, please contact your <a href=\"mailto:{0}\" > ATRactive administrator(s): {0}</a>."), admins);
            }

            // User qui n'a pas accès à l'application (dans le cas où sa compagnie n'a pas accès à l'app)
            else if (user.HasApplicationsAccess == AccessCode.ApplicationAccessDeniedForEntity)
            {
                string webmasterEmail = mailConfiguration["WebmasterEmail"];
                message = string.Format(GetAccessDeniedMessageByCode("EF-ENT-APPDENIED", "Access Denied. For further information, please contact Webmaster team: <a href=\"mailto:{0}\" > {0}</a>."), webmasterEmail);
            }

            return message;
        }

        /// <summary>
        /// Get Access Denied Message By Code
        /// </summary>
        /// <param name="messageCode">The message code</param>
        /// <param name="defaultMessage">The default message to use if code not found in db</param>
        /// <returns>The message</returns>
        private static string GetAccessDeniedMessageByCode(string messageCode, string defaultMessage)
        {
            // Get the application message for the custom notification if any
            APPLICATIONS_MESSAGES appMessage = DataModelRequests.GetApplicationsMessagesByApplication("AccessDenied", messageCode);
            if (appMessage != null)
            {
                return appMessage.MESSAGE;
            }

            return defaultMessage;
        }
    }
}
