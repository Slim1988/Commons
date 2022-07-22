namespace ATR.Common.Controllers
{
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Web;
    using System.Web.Mvc;
    using ATR.Common.Enumerations;
    using ATR.Common.Helpers.AccessRights;
    using ATR.Common.Helpers.Saml;
    using ATR.Common.Logging;
    using ATR.Common.Models;

    /// <summary>
    /// Menu Controller
    /// </summary>
    public class MenuController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult Redirect()
        {
            // Get the current context
            HttpContext ctx = System.Web.HttpContext.Current;

            NameValueCollection urlSettings = ConfigurationManager.GetSection("urls") as NameValueCollection;
            string redirectUrl = urlSettings["CurrentApp"];
            if (string.IsNullOrEmpty(redirectUrl))
            {
                LoggingService.Application.Error("Current application URL is not defined or empty (CurrentApp param in web.config file)");
            }

            string comingUrl = ctx.Session["ReturnUrl"] != null ? ctx.Session["ReturnUrl"].ToString() : string.Empty;
            LoggingService.Application.Debug("Redirect comingUrl=" + comingUrl);

            if (!string.IsNullOrEmpty(comingUrl))
            {
                redirectUrl = comingUrl;
            }

            if (ctx.Session["CurrentUser"] == null)
            {
                string userLogin = SamlHelper.GetUserLogin();
                UserSessionModel user = SamlHelper.GetCurrentUserByLogin(userLogin);

                if (user != null)
                {
                    user.HasApplicationsAccess = AccessHelper.HasUserBaseAccess(user);

                    if (user.HasApplicationsAccess != AccessCode.UserHasAccess && !comingUrl.EndsWith("/MyCompany"))
                    {
                        redirectUrl = AccessHelper.GetAccessDeniedURL();
                    }

                    ctx.Session["CurrentUser"] = user;
                    LoggingService.Application.Info($"Current User identified and stored in Session. ({user.UserLogin})");
                }
                else
                {
                    LoggingService.Application.Info("Current User not found in database.");

                    // For unknown users create an empty UserSessionModel
                    user = new UserSessionModel();
                    ctx.Session["CurrentUser"] = user;

                    // Do not display Header & Footer for unknown users
                    this.ViewBag.DisplayHeaderFooter = false;
                    redirectUrl = AccessHelper.GetAccessDeniedURL();
                }
            }

            LoggingService.Application.Info($"Redirect to {redirectUrl}");
            return this.View(new UrlViewModel() { RedirectUrl = redirectUrl });
        }

        /// <summary>
        /// Action result for Header's GenericHeaderFooter
        /// </summary>
        /// <returns>PartialViewResult Header</returns>
        [ChildActionOnly]
        public ActionResult Header()
        {
            // Get current user
            UserSessionModel user = (UserSessionModel)this.Session["CurrentUser"];

            var model = new HeaderViewModel(user);
            return this.PartialView("Header", model);
        }

        /// <summary>
        /// Action result for Footer's GenericHeaderFooter
        /// </summary>
        /// <returns>PartialViewResult Footer</returns>
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return this.PartialView("Footer");
        }

        /// <summary>
        /// Use to log js error
        /// </summary>
        /// <param name="message">Message sent by the client side</param>
        public void LogClientError(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                LoggingService.Application.Warn(message);
            }
        }

        /// <summary>
        /// Get appYuser information
        /// </summary>
        /// <returns>returns informations for appyUser purpose</returns>
        public ActionResult GetappYuserInformation()
        {
            // Get current user
            LoggingService.Application.Info("Start GetappYuserInformation");
            UserSessionModel user = (UserSessionModel)this.Session["CurrentUser"];
            string userId = "undefined";
            string entity = "undefined";
            string businessType = "undefined";

            if (user != null)
            {
                if (user.IsATR())
                {
                    userId = user.IdUser.ToString();
                    entity = "ATR";
                    businessType = "ATR";
                }
                else
                {
                    userId = user.IdUser.ToString();
                    entity = user.EntityName;
                    businessType = user.BusinessTypeName;
                }
            }

            LoggingService.Application.Info($"End of GetappYuserInformation with userId: {userId}, entity: {entity}, businessType: {businessType}");
            return this.Json(new { success = true, userId = userId, entity = entity, businessType = businessType }, JsonRequestBehavior.AllowGet);
        }
    }
}