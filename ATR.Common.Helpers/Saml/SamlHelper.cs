namespace ATR.Common.Helpers.Saml
{
    using System.Configuration;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using ATR.Common.Logging;
    using ATR.Common.Models;
    using ATR.Common.Models.Requests;

    public static class SamlHelper
    {
        /// <summary>
        /// Get the user login
        /// </summary>
        /// <returns>The login</returns>
        public static string GetUserLogin()
        {
            string userLogin = string.Empty;

            bool isSamlAuthentication = false;
            bool.TryParse(ConfigurationManager.AppSettings["IsSamlAuthentication"], out isSamlAuthentication);

            if (isSamlAuthentication)
            {
                string samlClaimForUserLogin = ConfigurationManager.AppSettings["SamlClaimForUserLogin"];

                Claim claim = ClaimsPrincipal.Current.Claims.Where(x => x.Type.Equals(samlClaimForUserLogin)).FirstOrDefault();
                if (claim != null && claim.Type.Equals(ClaimTypes.Upn))
                {
                    userLogin = claim.Value.Split('@').ToList().First();
                }
            }
            else
            {
                if (HttpContext.Current.User.Identity == null)
                {
                    LoggingService.Application.Error("The user for the current request is not specified");
                    return userLogin;
                }

                if (string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    LoggingService.Application.Error("The name of the user for the current request is not specified");
                    return userLogin;
                }

                // Get informations of the current user
                userLogin = HttpContext.Current.User.Identity.Name.Split('\\').ToList().Last();
            }

            if (!string.IsNullOrEmpty(userLogin))
            {
                LoggingService.Application.Debug(userLogin);
            }

            return userLogin;
        }

        public static UserSessionModel GetCurrentUserByLogin(string userLogin)
        {
            USERS user = DataModelRequests.GetUserByLoginNameWithEntity(userLogin);

            if (user == null)
            {
                LoggingService.Application.Error("The user specified for the current request cannot be found in the database (" + userLogin + ").");
                return null;
            }

            UserSessionModel currentUser = new UserSessionModel(user);

            return currentUser;
        }
    }
}
