namespace ATR.Common.Controllers
{
    using System.Web.Mvc;
    using Models;

    /// <summary>
    /// Error Controller.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// GET: /Error/HttpError
        /// </summary>
        /// <param name="error">Error Model.</param>
        /// <returns>Return view error with error model.</returns>
        public ActionResult HttpError(ErrorViewModel error)
        {
            this.Response.ContentType = "text/html";
            return this.View("Error", error);
        }
    }
}