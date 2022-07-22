namespace ATR.Common.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using ATR.Common.Logging;

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = base.AuthorizeCore(httpContext);

            if (authorize)
            {
                if (HttpContext.Current.Session["CurrentUser"] == null)
                {
                    authorize = false;
                }
            }
            else
            {
                if (HttpContext.Current.Session["CurrentUser"] != null)
                {
                    LoggingService.Application.Debug("User not null in session => authorize");
                    authorize = true;
                }
            }

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            try
            {
                // Retrieve comming url and store in session
                string comingUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                LoggingService.Application.Debug("AbsoluteUri=" + comingUrl);

                HttpContext.Current.Session["ReturnUrl"] = comingUrl;
            }
            catch (System.Exception ex)
            {
                LoggingService.Application.Error(ex);
            }

            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Menu",
                        action = "Redirect"
                    }));
        }
    }
}