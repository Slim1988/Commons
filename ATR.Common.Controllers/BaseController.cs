namespace ATR.Common.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ATR.Common.Enumerations;
    using ATR.Common.Extensions;
    using ATR.Common.Logging;
    using ATR.Common.Resources.MessagesResources;
    using Newtonsoft.Json;

    /// <summary>
    /// Base Controller
    /// Other controllers should inherit from this class
    /// </summary>
    /// <typeparam name="TId">Generic type for an entity identifier that will inherit of this controller</typeparam>
    public abstract class BaseController<TId> : Controller
    {
#pragma warning disable SA1401

        /// <summary>
        /// Name of the model
        /// </summary>
        protected string modelName = string.Empty;

        /// <summary>
        /// Name of the model (plural)
        /// </summary>
        protected string modelNamePlural = string.Empty;

        /// <summary>
        /// Formatted warning messages
        /// </summary>
        protected string warningMessage = string.Empty;

        /// <summary>
        /// Formatted success messages
        /// </summary>
        protected string customSuccessMessage = string.Empty;

        /// <summary>
        /// Custom message to send to user
        /// </summary>
        protected string customMessage = string.Empty;

        /// <summary>
        /// Custom information message to send to user
        /// </summary>
        protected string informationMessage = string.Empty;

#pragma warning restore SA1401

        /// <summary>
        /// Controllers error management
        /// </summary>
        /// <param name="actionType">Action type</param>
        /// <param name="ex">Exception</param>
        /// <param name="errorType">Error type</param>
        /// <param name="id">Object id</param>
        /// <returns>ActionResult (Error HTTP response to send)</returns>
        protected ActionResult ManageError(ActionType actionType, Exception ex, ErrorType errorType = ErrorType.Default, TId id = default(TId))
        {
            return this.ManageError(actionType, ex, string.Empty, errorType, id);
        }

        /// <summary>
        /// Controllers error management with custom model name
        /// </summary>
        /// <param name="actionType">Action type</param>
        /// <param name="ex">Exception</param>
        /// <param name="customModelName">Custom model name</param>
        /// <param name="errorType">Error type</param>
        /// <param name="id">Object id</param>
        /// <returns>ActionResult (Error HTTP response to send)</returns>
        protected ActionResult ManageError(ActionType actionType, Exception ex, string customModelName, ErrorType errorType = ErrorType.Default, TId id = default(TId))
        {
            // Define if the error is raised by the application (i.e. business rule)
            bool isApplicationException = false;

            string displayName = string.IsNullOrEmpty(customModelName) ? this.modelName : customModelName;

            // Default error
            string exceptionMessage = ex == null ? string.Empty : ex.Message;
            string errorMessage = string.Concat("(", displayName.FirstCharToUpper(), " Id: ", id == null ? "null" : id.ToString(), ") ", exceptionMessage);

            // Manage application exception to display the exception message in the error popup
            this.Response.StatusCode = 500;
            this.Response.StatusDescription = string.Empty;
            if (ex != null)
            {
                switch (ex.GetType().ToString())
                {
                    case "System.ApplicationException":
                        this.Response.StatusCode = 409;
                        this.Response.StatusDescription = ex.Message.Replace("\r", string.Empty).Replace("\n", "<br />");
                        isApplicationException = true;
                        break;
                    default:
                        break;
                }
            }

            // Set the error message that will be displayed to the user in the error popup if not already set (application exception)
            if (!isApplicationException)
            {
                // Check if it's an Entity Framework error
                try
                {
                    if (ex.Source == "EntityFramework")
                    {
                        if (ex.InnerException.InnerException != null)
                        {
                            this.Response.StatusDescription = ": " + ex.InnerException.InnerException.Message.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("The statement has been terminated.", string.Empty);
                        }
                        else
                        {
                            this.Response.StatusDescription = ": " + ex.InnerException.Message.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("See http://go.microsoft.com/fwlink/?LinkId=472540 for information on understanding and handling optimistic concurrency exceptions.", string.Empty);
                        }
                    }
                }
                catch (Exception checkSourceError)
                {
                    LoggingService.Application.Error("Cannot check the source of the error: ", checkSourceError);
                }

                if (!string.IsNullOrEmpty(this.customMessage))
                {
                    // Display custom message to user instead of default message.
                    this.Response.StatusDescription = this.customMessage;
                }
                else
                {
                    switch (actionType)
                    {
                        case ActionType.GetData:
                        case ActionType.GetDetails:
                            displayName = string.IsNullOrEmpty(customModelName) ? this.modelNamePlural : customModelName;
                            this.Response.StatusDescription = string.Format(Messages.dataLoadError, displayName);
                            errorMessage = string.Concat(string.Format(Messages.dataLoadError, displayName), ": ", ex.Message);
                            break;
                        case ActionType.InsertData:
                            this.Response.StatusDescription = string.Format(Messages.dataInsertError, displayName) + this.Response.StatusDescription;
                            break;
                        case ActionType.UpdateData:
                            this.Response.StatusDescription = string.Format(Messages.dataUpdateError, displayName) + this.Response.StatusDescription;
                            break;
                        case ActionType.DeleteData:
                            this.Response.StatusDescription = string.Format(Messages.dataDeleteError, displayName) + this.Response.StatusDescription;
                            break;
                        case ActionType.GetSearch:
                            this.Response.StatusDescription = string.Format(Messages.dataGetSearchError, displayName) + this.Response.StatusDescription;
                            break;
                        case ActionType.SearchData:
                            this.Response.StatusDescription = string.Format(Messages.dataSearchError, displayName) + this.Response.StatusDescription;
                            break;
                        case ActionType.UploadData:
                            this.Response.StatusDescription = string.Format(Messages.dataUploadError, displayName) + this.Response.StatusDescription;
                            break;
                    }
                }
            }

            // Set the error message that will be logged in the log file and in the console based on the error type
            switch (errorType)
            {
                case ErrorType.DataNotfound:
                    this.Response.StatusCode = 409;
                    errorMessage = string.Format(Messages.dataNotFoundError, displayName, id.ToString());
                    break;
                case ErrorType.FormInsert:
                    errorMessage = string.Concat(string.Format(Messages.formInsertError, displayName), ": ", ex.Message);
                    break;
                case ErrorType.FormUpdate:
                    errorMessage = string.Concat(string.Format(Messages.formUpdateError, displayName, id.ToString()), ": ", ex.Message);
                    break;
                case ErrorType.ModelNotValid:
                    string errorDescription = this.Response.StatusDescription;
                    this.Response.StatusCode = 409;
                    string errors = JsonConvert.SerializeObject(this.ModelState.Values
                        .SelectMany(state => state.Errors)
                        .Select(error => error.ErrorMessage));
                    errorMessage = string.Concat("(", displayName.FirstCharToUpper(), " Id: ", id == null ? "null" : id.ToString(), ") ", Messages.modelNotValid, ": ", errors);
                    this.Response.StatusDescription = string.Concat(errorDescription, ": ", errors);
                    break;
            }

            ex = ex == null ? new InvalidOperationException(errorMessage) : ex;
            LoggingService.Application.Error(errorMessage, ex);

            if (string.IsNullOrEmpty(this.informationMessage))
            {
                return this.Json(new { success = false, message = errorMessage }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Specific case of error we need to transform to an information message
                return this.Json(new { success = false, message = errorMessage, information = this.informationMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Controllers success management
        /// </summary>
        /// <param name="actionType">Action type</param>
        /// <param name="id">Identifier to be return as callback parameter</param>
        /// <returns>ActionResult (Success HTTP response to send)</returns>
        protected ActionResult ManageSuccess(ActionType actionType, TId id = default(TId))
        {
            // Set the success message based on the action type
            string successMessage = string.Empty;

            switch (actionType)
            {
                case ActionType.InsertData:
                    successMessage = string.Format(Messages.dataInsertSuccess, this.modelName.FirstCharToUpper());
                    break;
                case ActionType.UpdateData:
                    successMessage = string.Format(Messages.dataUpdateSuccess, this.modelName.FirstCharToUpper());
                    break;
                case ActionType.DeleteData:
                    successMessage = string.Format(Messages.dataDeleteSuccess, this.modelName.FirstCharToUpper());
                    break;
                case ActionType.UploadData:
                    successMessage = string.Format(Messages.dataUploadSuccess, this.modelName.FirstCharToUpper());
                    break;
            }

            // If there is a custom success message return it
            if (this.customSuccessMessage != string.Empty)
            {
                successMessage = this.customSuccessMessage;
            }

            // If there is a warning message return it added to the success message
            if (this.warningMessage == string.Empty)
            {
                return this.Json(new { success = true, message = successMessage, objectId = id }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(new { success = false, message = string.Concat(successMessage, " ", this.warningMessage), objectId = id }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
