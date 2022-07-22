namespace ATR.Common.Controllers
{
    using System.Web.Mvc;
    using ATR.Common.Models;
    using Helpers.AccessRights;

    /// <summary>
    /// Access Denied Controller
    /// </summary>
    [CustomAuthorize]
    public class AccessDeniedController : BaseController<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessDeniedController"/> class.
        /// </summary>
        public AccessDeniedController()
        {
            this.modelName = "Access Denied";
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>this view</returns>
        public ActionResult Index()
        {
            AccessDeniedViewModel accessDeniedViewModel = new AccessDeniedViewModel();

            try
            {
                // Get current user
                UserSessionModel user = (UserSessionModel)this.Session["CurrentUser"];

                // If the user login is null means taht the user can't be found in database
                if (user.UserLogin == null)
                {
                    // Do not display Header & Footer for unknown users and clear Session
                    this.ViewBag.DisplayHeaderFooter = false;
                    this.Session.Clear();
                    this.Session.Abandon();
                }

                accessDeniedViewModel.AccessCode = user.HasApplicationsAccess;
                accessDeniedViewModel.ErrorMessage = AccessHelper.GetAccessDeniedMessageByAccessCode(user);
            }
            catch (System.Exception)
            {
            }

            return this.View("~/Views/Menu/AccessDenied.cshtml", accessDeniedViewModel);
        }
    }
}