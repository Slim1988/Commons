namespace ATR.Common.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.UI;
    using ATR.Common.Enumerations;
    using ATR.Common.Models;
    using CsvHelper;

    /// <summary>
    /// CRUD Controller
    /// Specifics models' controller used for CRUD should inherit from this class
    /// </summary>
    /// <typeparam name="TEntity">Generic type for an entity that will inherit of this controller</typeparam>
    /// <typeparam name="TId">Generic type for an entity identifier that will inherit of this controller</typeparam>
    public abstract class CrudController<TEntity, TId> : BaseController<TId>
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
        /// GET: <![CDATA[ /Model?id= ]]> (with linked Entity)
        /// Display CRUD for Model
        /// </summary>
        /// <param name="id">Identifier of the linked Entity in the database (0 if none)</param>
        /// <returns>View CRUD for Model</returns>
        [HttpGet]
        public ActionResult Index(long id = 0)
        {
            this.crudModel.LinkedEntityId = id;
            return this.View(this.crudModel);
        }

        /// <summary>
        /// GET: <![CDATA[ /Model/GetData ]]>
        /// GET: <![CDATA[ /Model/GetData?id= ]]> (for a specific linked Entity identifier)
        /// </summary>
        /// <param name="id">Identifier of the linked Entity in the database</param>
        /// <returns>Entities data as list in JSON format</returns>
        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult GetData(long id = 0)
        {
            this.CheckAuthorization(ActionType.GetData, this.GetDefaultIdentifierValue(), id);

            try
            {
                var jsonResult = this.Json(new { data = id == 0 ? this.GetDataListFromDb() : this.GetDataListFromDb(id) }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return this.ManageError(ActionType.GetData, ex);
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
            this.CheckAuthorization(ActionType.GetDetails, id);

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
        /// GET: <![CDATA[ /Model/ExportData ]]>
        /// </summary>
        /// <returns>Entities data as list in csv file format</returns>
        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult ExportData()
        {
            try
            {
                string fileName = string.Concat(this.modelNamePlural, ".csv");
                List<TEntity> data = (List<TEntity>)this.GetDataListFromDb();

                using (var stream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(stream, Encoding.UTF8))
                    using (var csv = new CsvWriter(writer))
                    {
                        if (ConfigurationManager.AppSettings["csvDelimiter"] != null)
                        {
                            csv.Configuration.Delimiter = ConfigurationManager.AppSettings["csvDelimiter"];
                        }

                        csv.WriteRecords(data);
                    }

                    return this.File(stream.ToArray(), "text/csv", fileName);
                }
            }
            catch (Exception ex)
            {
                return this.ManageError(ActionType.ExportData, ex);
            }
        }

        /// <summary>
        /// GET: <![CDATA[ /Model/AddWithLinkedEntityId?id= ]]>
        /// GET: <![CDATA[ /Model/AddWithLinkedEntityId?id=&filterId= ]]> (with a filter)
        /// </summary>
        /// <param name="id">Identifier of the linked Entity in the database</param>
        /// <param name="filterId">Identifier of another Entity in the database used as a filter (0 if none)</param>
        /// <returns>Data for an Entity</returns>
        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult AddWithLinkedEntity(long id, object filterId = null)
        {
            // Check Authorization
            this.CheckAuthorization(ActionType.InsertData, this.GetDefaultIdentifierValue(), id);

            try
            {
                // Convert the provided filterId to the matching identifier type
                TId filterIdentifier = this.GetConvertedId(filterId);

                // Set linkedEntityId and filterId in ViewBag
                this.ViewBag.linkedEntityId = id;
                this.ViewBag.filterId = filterIdentifier;

                // Set the viewBag data if any
                this.SetViewBagData();

                // Set the viewBag data for insert action if any
                this.SetViewBagDataForSpecificAction(ActionType.InsertData);

                // View to add a new Entity
                return this.View(this.GetEntityWithFilter());
            }
            catch (Exception ex)
            {
                return this.ManageError(ActionType.InsertData, ex, ErrorType.FormInsert);
            }
        }

        /// <summary>
        /// GET: <![CDATA[ /Model/AddOrEdit ]]> (add)
        /// GET: <![CDATA[ /Model/AddOrEdit/id ]]> (edit)
        /// </summary>
        /// <param name="id">Identifier of the Entity in the database</param>
        /// <param name="linkedEntityId">Identifier of the linked entity in the database</param>
        /// <returns>Data for an Entity</returns>
        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult AddOrEdit(object id, long linkedEntityId = 0)
        {
            try
            {
                // Convert the identifier to the matching identifier type
                TId identifier = this.GetConvertedId(id);

                // Set linkedEntityId and filterId in ViewBag
                this.ViewBag.linkedEntityId = linkedEntityId;
                this.ViewBag.filterId = id;

                // Set the viewBag data if any
                this.SetViewBagData();

                if (identifier.Equals(this.GetDefaultIdentifierValue()))
                {
                    // Set the viewBag data for insert action if any
                    this.SetViewBagDataForSpecificAction(ActionType.InsertData);

                    // Initialize the entity and set its default values if needed
                    TEntity entity = new TEntity();
                    entity = this.SetEntityDefaultValues(entity);

                    // View to add a new Entity
                    return this.View(entity);
                }
                else
                {
                    // Check Authorization
                    this.CheckAuthorization(ActionType.UpdateData, identifier, linkedEntityId);

                    object entity = null;
                    if (linkedEntityId != 0)
                    {
                        entity = this.GetDataFromDbWithFilter(identifier, linkedEntityId);
                    }
                    else
                    {
                        entity = this.GetDataFromDb(identifier);
                    }

                    if (entity == null)
                    {
                        ApplicationException dataNotFoundException = new ApplicationException("Unable to update the " + this.modelName + ": object not found in database");
                        return this.ManageError(ActionType.UpdateData, dataNotFoundException, ErrorType.DataNotfound, identifier);
                    }

                    // Set the viewBag data for edit action if any
                    this.SetViewBagDataForSpecificAction(ActionType.UpdateData);

                    // View to edit an Entity
                    return this.View(entity);
                }
            }
            catch (Exception ex)
            {
                if (this.GetConvertedId(id).Equals(this.GetDefaultIdentifierValue()))
                {
                    return this.ManageError(ActionType.InsertData, ex, ErrorType.FormInsert);
                }
                else
                {
                    return this.ManageError(ActionType.UpdateData, ex, ErrorType.FormUpdate);
                }
            }
        }

        /// <summary>
        /// POST: <![CDATA[ /Model/Add ]]>
        /// Add an Entity
        /// </summary>
        /// <param name="entity">Entity to be added or updated in the database</param>
        /// <returns>Operation result as JSON</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TEntity entity)
        {
            return this.ManageAddOrEdit(entity, ActionType.InsertData);
        }

        /// <summary>
        /// POST: <![CDATA[ /Model/AddOrEdit ]]>
        /// Add or Edit an Entity
        /// </summary>
        /// <param name="entity">Entity to be added or updated in the database</param>
        /// <returns>Operation result as JSON</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(TEntity entity)
        {
            // Set the action type for the action to be done with the entity
            ActionType actionType = ActionType.UpdateData;
            if (this.GetIdFromEntity(entity).Equals(this.GetDefaultIdentifierValue()))
            {
                actionType = ActionType.InsertData;
            }

            return this.ManageAddOrEdit(entity, actionType);
        }

        /// <summary>
        /// Manage the insertion or the update of an entity in database
        /// </summary>
        /// <param name="entity">Entity to be added or updated in the database</param>
        /// <param name="actionType">Type of action to be done</param>
        /// <returns>Operation result as JSON</returns>
        public ActionResult ManageAddOrEdit(TEntity entity, ActionType actionType)
        {
            this.CheckAuthorization(ActionType.UpdateData, this.GetIdFromEntity(entity));

            try
            {
                if (this.ModelState.IsValid)
                {
                    TEntity oldEntity = null;

                    // If the old entity is needed for the add or edit and the action type is an update get the old entity
                    if (this.crudModel.OldEntityOnAddOrEdit && actionType != ActionType.InsertData)
                    {
                        oldEntity = (TEntity)this.GetDataFromDb(this.GetIdFromEntity(entity));
                    }

                    // Check and update the entity if needed before inserting or updating it in database
                    entity = this.CheckAndUpdateEntityBeforeAddOrEdit(entity, oldEntity);

                    // Get the default entity identifier
                    TId id = this.GetDefaultIdentifierValue();

                    // Add or update the entity base on the action type provided
                    if (actionType == ActionType.InsertData)
                    {
                        id = this.AddInDb(entity);
                    }
                    else
                    {
                        id = this.UpdateInDb(entity);
                    }

                    // Do some actions after entity has been added or updated in database
                    this.ManageEntityAfterAddOrEdit(entity, oldEntity);

                    return this.ManageSuccess(actionType, id);
                }
                else
                {
                    return this.ManageError(this.GetIdFromEntity(entity).Equals(this.GetDefaultIdentifierValue()) ? ActionType.InsertData : ActionType.UpdateData, null, ErrorType.ModelNotValid, this.GetIdFromEntity(entity));
                }
            }
            catch (Exception ex)
            {
                return this.ManageError(this.GetIdFromEntity(entity).Equals(this.GetDefaultIdentifierValue()) ? ActionType.InsertData : ActionType.UpdateData, ex, ErrorType.Default, this.GetIdFromEntity(entity));
            }
        }

        /// <summary>
        /// POST: <![CDATA[ /Model/Delete ]]>
        /// Delete an entity
        /// </summary>
        /// <param name="id">Identifier of the entity to be deleted in the database</param>
        /// <param name="linkedEntityId">Identifier of the linked entity to be deleted in the database</param>
        /// <returns>Operation result as JSON</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(object id, long linkedEntityId = 0)
        {
            try
            {
                // Convert the identifier to the matching identifier type
                TId identifier = this.GetConvertedId(id);

                // Check Authorization
                this.CheckAuthorization(ActionType.DeleteData, identifier, linkedEntityId);

                // Check if the entity exists in database
                object entity = null;
                if (linkedEntityId == 0)
                {
                    entity = this.GetDataFromDb(identifier);
                }
                else
                {
                    entity = this.GetDataFromDbWithFilter(identifier, linkedEntityId);
                }

                if (entity == null)
                {
                    ApplicationException dataNotFoundException = new ApplicationException("Unable to delete the " + this.modelName + ": object not found in database");
                    return linkedEntityId == 0 ? this.ManageError(ActionType.DeleteData, dataNotFoundException, ErrorType.DataNotfound, identifier) : this.ManageError(ActionType.DeleteData, dataNotFoundException, ErrorType.DataNotfound);
                }

                if (linkedEntityId == 0)
                {
                    this.DeleteInDb(identifier);
                }
                else
                {
                    this.DeleteInDbWithLinkedEntity(identifier, linkedEntityId);
                }

                return this.ManageSuccess(ActionType.DeleteData);
            }
            catch (Exception ex)
            {
                return linkedEntityId == 0 ? this.ManageError(ActionType.DeleteData, ex, ErrorType.Default, this.GetConvertedId(id)) : this.ManageError(ActionType.DeleteData, ex, ErrorType.Default);
            }
        }

        /// <summary>
        /// Get a list of entities from database
        /// Should be overrided
        /// </summary>
        /// <returns>Data list from database</returns>
        protected virtual object GetDataListFromDb()
        {
            return new { };
        }

        /// <summary>
        /// Get a list of entities from database for a specific linked Entity identifier
        /// Should be overrided
        /// </summary>
        /// <param name="id">Identifier of the linked Entity in the database</param>
        /// <returns>Data list from database</returns>
        protected virtual object GetDataListFromDb(long id)
        {
            return new { };
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
        /// Get an entity from database
        /// Has to be overrided
        /// </summary>
        /// <param name="id">Identifier of the Model in the database</param>
        /// <param name="linkedEntityId">Identifier of the linked entity in the database</param>
        /// <returns>Data from database</returns>
        protected virtual object GetDataFromDbWithFilter(TId id, long linkedEntityId)
        {
            return new { };
        }

        /// <summary>
        /// Get the identifier of an entity
        /// Has to be overrided
        /// </summary>
        /// <param name="entity">Entity model</param>
        /// <returns>Identifier from entity</returns>
        protected virtual TId GetIdFromEntity(TEntity entity)
        {
            return default(TId);
        }

        /// <summary>
        /// Set entity default values after initialization
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity with default values</returns>
        protected virtual TEntity SetEntityDefaultValues(TEntity entity)
        {
            return entity;
        }

        /// <summary>
        /// Check and update entity before Add or Edit in database
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="oldEntity">Entity values before add or edit</param>
        /// <returns>Updated entity</returns>
        protected virtual TEntity CheckAndUpdateEntityBeforeAddOrEdit(TEntity entity, TEntity oldEntity = null)
        {
            return entity;
        }

        /// <summary>
        /// Do some action after entity has been created or updated in database
        /// </summary>
        /// <param name="entity">The entity that have been created or updated in database</param>
        /// <param name="oldEntity">Entity values before add or edit</param>
        protected virtual void ManageEntityAfterAddOrEdit(TEntity entity, TEntity oldEntity = null)
        {
        }

        /// <summary>
        /// Add an entity in database
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>The entity's identifier</returns>
        protected virtual TId AddInDb(TEntity entity)
        {
            using (DBModel db = new DBModel())
            {
                System.Data.Entity.DbSet mySet = db.Set(typeof(TEntity));
                mySet.Add(entity);
                db.SaveChanges();
            }

            return this.GetDefaultIdentifierValue();
        }

        /// <summary>
        /// Update an entity in database
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>The entity's identifier</returns>
        protected virtual TId UpdateInDb(TEntity entity)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return this.GetDefaultIdentifierValue();
        }

        /// <summary>
        /// Delete an entity in database
        /// Has to be overrided
        /// </summary>
        /// <param name="id">Identifier of the entity to remove from the database</param>
        protected virtual void DeleteInDb(TId id)
        {
        }

        /// <summary>
        /// Delete an entity in database
        /// Has to be overrided
        /// </summary>
        /// <param name="id">Identifier of the entity to remove from the database</param>
        /// <param name="linkedEntityId">Identifier of the linked entity in the database</param>
        protected virtual void DeleteInDbWithLinkedEntity(TId id, long linkedEntityId)
        {
        }

        /// <summary>
        /// Set viewBag values
        /// Should be overrided
        /// </summary>
        protected virtual void SetViewBagData()
        {
        }

        /// <summary>
        /// Set viewBag values for a specific action
        /// Should be overrided
        /// </summary>
        /// <param name="actionType">Action Type</param>
        protected virtual void SetViewBagDataForSpecificAction(ActionType actionType)
        {
        }

        /// <summary>
        /// Check if the action is authorized
        /// Should be overrided
        /// </summary>
        /// <param name="actionType">Action Type</param>
        /// <param name="id">Identifier of the entity for which the authorization has to be checked</param>
        /// <param name="linkedEntityId">Identifier of the linked entity for which the authorization has to be checked</param>
        protected virtual void CheckAuthorization(ActionType actionType, TId id, long linkedEntityId = 0)
        {
            return;
        }

        /// <summary>
        /// Get a new entity with a filter set
        /// Should be overrided
        /// </summary>
        /// <returns>Entity</returns>
        protected virtual TEntity GetEntityWithFilter()
        {
            return new TEntity();
        }

        /// <summary>
        /// Convert the identifier to the matching type
        /// Has to be overrided
        /// </summary>
        /// <param name="identifier">Identifier of the entity to be converted</param>
        /// <returns>The converted identifier</returns>
        protected virtual TId GetConvertedId(object identifier)
        {
            return default(TId);
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