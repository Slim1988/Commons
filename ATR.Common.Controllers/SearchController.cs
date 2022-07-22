namespace ATR.Common.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.UI;
    using ATR.Common.Enumerations;
    using ATR.Common.Models;
    using Logging;

    /// <summary>
    /// Search Controller
    /// Specifics models' controller used for search should inherit from this class
    /// </summary>
    /// <typeparam name="TEntity">Generic type for an entity that will inherit of this controller</typeparam>
    /// <typeparam name="TId">Generic type for an entity identifier that will inherit of this controller</typeparam>
    /// <typeparam name="TSearchModel">Generic type for the search model</typeparam>
    public abstract class SearchController<TEntity, TId, TSearchModel> : BaseController<TId>
        where TEntity : class, new()
    {
#pragma warning disable SA1401

        /// <summary>
        /// Crud model
        /// </summary>
        protected CrudModel crudModel = new CrudModel();

#pragma warning restore SA1401

        /// <summary>
        /// GET: <![CDATA[ /Model ]]>
        /// Display Search for Model
        /// </summary>
        /// <returns>View Search for Model</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(this.crudModel);
        }

        /// <summary>
        /// Get the entity's search form view
        /// </summary>
        /// <returns>Return partial view with entity's search form</returns>
        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult GetSearchForm()
        {
            // Check Authorization
            this.CheckAuthorization(ActionType.GetSearch, default(TSearchModel));

            try
            {
                // Initialize the model
                object entity = null;
                entity = this.GetSearchModel();

                if (entity == null)
                {
                    ApplicationException dataNotFoundException = new ApplicationException("Unable to get the search form for " + this.modelName);
                    return this.ManageError(ActionType.GetSearch, dataNotFoundException, ErrorType.DataNotfound);
                }

                // Set the view bag data before displaying the entity details
                this.SetViewBagData();
                return this.PartialView(entity);
            }
            catch (ApplicationException appEx)
            {
                LoggingService.Application.Error(appEx.Message);
                return this.PartialView(appEx.Data["PartialViewError"].ToString());
            }
            catch (Exception ex)
            {
                LoggingService.Application.Error(ex.Message);
                return this.ManageError(ActionType.GetSearch, ex);
            }
        }

        /// <summary>
        /// POST: <![CDATA[ /Model/Search ]]>
        /// Search the results based on the Entity criteria
        /// </summary>
        /// <param name="searchModel">model containing the search criteria</param>
        /// <returns>Operation result as JSON</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(TSearchModel searchModel)
        {
            try
            {
                this.CheckAuthorization(ActionType.SearchData, searchModel);
                if (this.ModelState.IsValid)
                {
                    List<TEntity> listEntity = this.GetSearchResult(searchModel);

                    var jsonResult = this.Json(new { success = true, data = listEntity }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                else
                {
                    return this.ManageError(ActionType.SearchData, null, ErrorType.ModelNotValid);
                }
            }
            catch (Exception ex)
            {
                return this.ManageError(ActionType.SearchData, ex, ErrorType.Default);
            }
        }

        /// <summary>
        /// Get the entity's details view in order to edit
        /// </summary>
        /// <param name="id">The entity's identifier</param>
        /// <returns>Return partial view with entity's details</returns>
        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult GetDetails(TId id)
        {
            // Check Authorization
            this.CheckAuthorization(ActionType.GetDetails, default(TSearchModel));

            try
            {
                // Initialize the model
                object entity = null;
                entity = this.GetDataFromDb(id);

                if (entity == null)
                {
                    ApplicationException dataNotFoundException = new ApplicationException("Unable to get the details of the " + this.modelName + ": object not found in database");
                    return this.ManageError(ActionType.GetDetails, dataNotFoundException, ErrorType.DataNotfound, id);
                }

                // Set the view bag data before displaying the entity details
                this.SetViewBagData();
                return this.PartialView(entity);
            }
            catch (Exception ex)
            {
                return this.ManageError(ActionType.GetDetails, ex);
            }
        }

        /// <summary>
        /// Get the search model
        /// Has to be overridden
        /// </summary>
        /// <returns>The search model</returns>
        protected virtual object GetSearchModel()
        {
            return new { };
        }

        /// <summary>
        /// Get the search results based on the provided entity's search criteria
        /// Has to be overridden
        /// </summary>
        /// <param name="entity">The Entity containing the search criteria</param>
        /// <returns>The list of Entity matching the search criteria</returns>
        protected virtual List<TEntity> GetSearchResult(TSearchModel entity)
        {
            return new List<TEntity>();
        }

        /// <summary>
        /// Get an entity from database
        /// Has to be overrided
        /// </summary>
        /// <param name="id">Identifier of the Model in the database</param>
        /// <returns>Data from database</returns>
        protected virtual object GetDataFromDb(TId id)
        {
            return new { };
        }

        /// <summary>
        /// Set viewBag values
        /// Should be overrided
        /// </summary>
        protected virtual void SetViewBagData()
        {
        }

        /// <summary>
        /// Check if the action is authorized
        /// Should be overrided
        /// </summary>
        /// <param name="actionType">Action Type</param>
        /// <param name="searchModel">The search model</param>
        protected virtual void CheckAuthorization(ActionType actionType, TSearchModel searchModel)
        {
            return;
        }

        /// <summary>
        /// Get the default identifier value
        /// Has to be overrided
        /// </summary>
        /// <returns>The default identifier value</returns>
        protected virtual TId GetDefaultIdentifierValue()
        {
            return default(TId);
        }
    }
}