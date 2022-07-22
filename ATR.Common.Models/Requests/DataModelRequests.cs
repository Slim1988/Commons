namespace ATR.Common.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using Enumerations;
    using Extensions.Data;
    using Helper;

    /// <summary>
    /// Static class used to provide common request to database
    /// </summary>
    public static class DataModelRequests
    {
        #region ACS_ZONE2

        /// <summary>
        /// Update ACS_ZONE2 By Center
        /// </summary>
        /// <param name="listACS">List of ACS_ZONE2</param>
        /// <param name="strZone"> The support center </param>
        public static void UpdateACSCatalogsByCenter(List<ACS_ZONE2> listACS, string strZone)
        {
            using (SqlConnection connection = new SqlConnection(new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DBModel"].ConnectionString).ProviderConnectionString))
            {
                connection.Open();

                SqlCommand delete = new SqlCommand("DELETE FROM ACS_ZONE2 WHERE ACS_ZONE= @strZone", connection);
                delete.Parameters.AddWithValue("@strZone", strZone);
                delete.ExecuteNonQuery();

                string insertACSQuery = @"INSERT INTO ACS_ZONE2 (
                                            ACS_NUMPN,
                                            ACS_LIB,
                                            ACS_COM,
                                            ACS_NOMFIC,
                                            ACS_PXECHSTD,
                                            ACS_CUR_ECHSTD,
                                            ACS_PXREPSTD,
                                            ACS_CUR_REPSTD,
                                            ACS_PXREPMAJ,
                                            ACS_CUR_REPMAJ,
                                            ACS_PXOVERHAUL,
                                            ACS_CUR_OVERHAUL,
                                            ACS_PXTEST,
                                            ACS_CUR_TEST,
                                            ACS_PXSCRAP,
                                            ACS_CUR_SCRAP,
                                            ACS_ZONE,
                                            ACS_SPT_REPSTD,
                                            ACS_SPT_REPMAJ,
                                            ACS_SPT_OVERHAUL,
                                            ACS_SPT_TEST,
                                            ACS_LEASEDAILYFEE,
                                            ACS_CUR_LEASEDAILYFEE
                                        ) VALUES (
                                            @ACS_NUMPN,
                                            @ACS_LIB,
                                            @ACS_COM,
                                            @ACS_NOMFIC,
                                            @ACS_PXECHSTD,
                                            @ACS_CUR_ECHSTD,
                                            @ACS_PXREPSTD,
                                            @ACS_CUR_REPSTD,
                                            @ACS_PXREPMAJ,
                                            @ACS_CUR_REPMAJ,
                                            @ACS_PXOVERHAUL,
                                            @ACS_CUR_OVERHAUL,
                                            @ACS_PXTEST,
                                            @ACS_CUR_TEST,
                                            @ACS_PXSCRAP,
                                            @ACS_CUR_SCRAP,
                                            @ACS_ZONE,
                                            @ACS_SPT_REPSTD,
                                            @ACS_SPT_REPMAJ,
                                            @ACS_SPT_OVERHAUL,
                                            @ACS_SPT_TEST,
                                            @ACS_LEASEDAILYFEE,
                                            @ACS_CUR_LEASEDAILYFEE
                                        )";

                foreach (ACS_ZONE2 acs_zone2 in listACS)
                {
                    SqlCommand insertACS = new SqlCommand(insertACSQuery, connection);
                    insertACS.Parameters.AddWithValue("@ACS_NUMPN", acs_zone2.ACS_NUMPN.ToString());
                    insertACS.Parameters.AddWithValue("@ACS_ZONE", strZone);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_LIB", acs_zone2.ACS_LIB);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_COM", acs_zone2.ACS_COM);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_NOMFIC", acs_zone2.ACS_NOMFIC);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_PXECHSTD", acs_zone2.ACS_PXECHSTD);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_CUR_ECHSTD", acs_zone2.ACS_CUR_ECHSTD);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_PXREPSTD", acs_zone2.ACS_PXREPSTD);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_CUR_REPSTD", acs_zone2.ACS_CUR_REPSTD);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_PXREPMAJ", acs_zone2.ACS_PXREPMAJ);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_CUR_REPMAJ", acs_zone2.ACS_CUR_REPMAJ);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_PXOVERHAUL", acs_zone2.ACS_PXOVERHAUL);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_CUR_OVERHAUL", acs_zone2.ACS_CUR_OVERHAUL);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_PXTEST", acs_zone2.ACS_PXTEST);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_CUR_TEST", acs_zone2.ACS_CUR_TEST);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_PXSCRAP", acs_zone2.ACS_PXSCRAP);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_CUR_SCRAP", acs_zone2.ACS_CUR_SCRAP);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_SPT_REPSTD", acs_zone2.ACS_SPT_REPSTD);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_SPT_REPMAJ", acs_zone2.ACS_SPT_REPMAJ);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_SPT_OVERHAUL", acs_zone2.ACS_SPT_OVERHAUL);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_SPT_TEST", acs_zone2.ACS_SPT_TEST);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_LEASEDAILYFEE", acs_zone2.ACS_LEASEDAILYFEE);
                    insertACS = AddParameterValueToRequest(insertACS, "@ACS_CUR_LEASEDAILYFEE", acs_zone2.ACS_CUR_LEASEDAILYFEE);

                    insertACS.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Get ACS_ZONE2 By Center and search criteria if any
        /// </summary>
        /// <param name="supportCenter">support center</param>
        /// <param name="pn">P/N number</param>
        /// <param name="keywords">keywords</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of ACS_ZONE matching criteria</returns>
        public static List<ACS_ZONE2> GetCatalogsACSByCenterAndCriterias(string supportCenter, string pn = "", string keywords = "", bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                List<ACS_ZONE2> results = new List<ACS_ZONE2>();
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                IQueryable<ACS_ZONE2> query = db.ACS_ZONE2.Where(x => x.ACS_ZONE == supportCenter);

                if (!string.IsNullOrEmpty(pn))
                {
                    query = query.Where(x => x.ACS_NUMPN.Contains(pn));
                }

                if (!string.IsNullOrEmpty(keywords))
                {
                    query = query.Where(x => x.ACS_LIB.Contains(keywords));
                }

                results = query.ToList();
                return results;
            }
        }
        #endregion ACS_ZONE2

        #region ACS_PDF_FILE

        /// <summary>
        /// Update ACS_PDF_FILE By Center
        /// </summary>
        /// <param name="listPDF">List of ACS_PDF_FILE</param>
        /// <param name="strZone"> The support center code </param>
        public static void UpdateACSPDFFilesByCenter(List<ACS_PDF_FILE> listPDF, string strZone)
        {
            using (SqlConnection connection = new SqlConnection(new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DBModel"].ConnectionString).ProviderConnectionString))
            {
                connection.Open();

                foreach (ACS_PDF_FILE acspdf in listPDF)
                {
                    SqlCommand delete = new SqlCommand("DELETE FROM ACS_PDF_FILE WHERE ACS_ZONE = @strZone AND ACS_FILENAME = @acsfilename", connection);
                    delete.Parameters.AddWithValue("@strZone", strZone);
                    delete.Parameters.AddWithValue("@acsfilename", acspdf.ACS_FILENAME.ToString());
                    delete.ExecuteNonQuery();

                    string insertACSPDFQuery = @"INSERT INTO ACS_PDF_FILE (ACS_FILENAME,ACS_FILESIZE,ACS_FILECONTENT,ACS_ZONE,ACS_DATEMODIF)
                    VALUES (@ACS_FILENAME,@ACS_FILESIZE,@ACS_FILECONTENT,@ACS_ZONE,@ACS_DATEMODIF )";
                    SqlCommand insertACSPDF = new SqlCommand(insertACSPDFQuery, connection);
                    insertACSPDF.Parameters.AddWithValue("@strZone", strZone);
                    insertACSPDF.Parameters.AddWithValue("@ACS_FILENAME", acspdf.ACS_FILENAME.ToString());
                    insertACSPDF.Parameters.AddWithValue("@ACS_FILESIZE", acspdf.ACS_FILESIZE);
                    insertACSPDF.Parameters.AddWithValue("@ACS_FILECONTENT", acspdf.ACS_FILECONTENT);
                    insertACSPDF.Parameters.AddWithValue("@ACS_ZONE", strZone);
                    insertACSPDF.Parameters.AddWithValue("@ACS_DATEMODIF", acspdf.ACS_DATEMODIF);
                    insertACSPDF.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        #endregion ACS_PDF_FILE

        #region APPLICATION

        /// <summary>
        /// Get all applications with their application categories from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of applications with their application categories</returns>
        public static List<APPLICATION> GetAllApplicationsWithApplicationCategory(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.APPLICATION.Include(a => a.APPLICATION_CATEGORY).ToList();
            }
        }

        /// <summary>
        /// Get Application from data model
        /// </summary>
        /// <param name="id">id of the Application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Application data from data model matching the provided id</returns>
        public static APPLICATION GetApplicationById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.APPLICATION.Where(x => x.ID_APPLICATION == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Application by its code from data model
        /// </summary>
        /// <param name="applicationCode">code of the Application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Application data from data model matching the provided application code</returns>
        public static APPLICATION GetApplicationByCode(string applicationCode, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.APPLICATION.Where(x => x.APPLICATION_CODE == applicationCode).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Application by id and remove it from data model
        /// </summary>
        /// <param name="id">The Application id</param>
        public static void DeleteApplicationById(long id)
        {
            using (DBModel db = new DBModel())
            {
                APPLICATION application = db.APPLICATION.Where(x => x.ID_APPLICATION == id).FirstOrDefault();
                db.APPLICATION.Remove(application);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all Applications from data model that are not included in ENTITY_APPLICATION
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Application not included in ENTITY_APPLICATION</returns>
        public static List<APPLICATION> GetAllApplicationsNotIncludedInEntityApplication(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<long> applicationsIds = db.ENTITY_APPLICATION.Where(c => c.FK_ENTITY == idEntity).Select(c => c.FK_APPLICATION).ToList();
                return db.APPLICATION.Where(c => !applicationsIds.Contains(c.ID_APPLICATION)).ToList();
            }
        }

        /// <summary>
        /// Get all Applications from data model that are not included in ENTITY_APPLICATION_ACCESS
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Applications matching the provided entity id</returns>
        public static List<APPLICATION> GetAllApplicationsNotIncludedInEntityApplicationAccess(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<long> applicationsIds = db.ENTITY_APPLICATION_ACCESS.Where(c => c.FK_ENTITY == idEntity).Select(c => c.FK_APPLICATION).ToList();
                return db.APPLICATION.Where(c => !applicationsIds.Contains(c.ID_APPLICATION)).ToList();
            }
        }

        /// <summary>
        /// Get all visible applications from data model for which entity has access
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of visible applications for which entity has access</returns>
        public static List<APPLICATION> GetAllVisibleAndAccessibleApplicationForEntityOrderedByApplicationCode(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                long applicationCategoryVisible = db.APPLICATION_CATEGORY.Where(ac => ac.APPLICATION_CATEGORY1.ToLower().Equals("visible")).Select(ac => ac.ID_APPLICATION_CATEGORY).FirstOrDefault();
                List<long> applicationsIds = db.ENTITY_APPLICATION_ACCESS.Where(c => c.FK_ENTITY == idEntity && c.ACCESS_ALLOWED).Select(c => c.FK_APPLICATION).ToList();
                return db.APPLICATION.Where(a => applicationsIds.Contains(a.ID_APPLICATION) && a.FK_APPLICATION_CATEGORY == applicationCategoryVisible).OrderBy(a => a.APPLICATION_CODE).ToList();
            }
        }

        #endregion APPLICATION

        #region APPLICATION_CATEGORY

        /// <summary>
        /// Get all application categories from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of application categories</returns>
        public static List<APPLICATION_CATEGORY> GetAllApplicationCategories(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.APPLICATION_CATEGORY.ToList();
            }
        }

        /// <summary>
        /// Get Application Category by its identifier from data model
        /// </summary>
        /// <param name="id">id of the Application Category in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Application Category data from data model matching the provided id</returns>
        public static APPLICATION_CATEGORY GetApplicationCategoryById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.APPLICATION_CATEGORY.Where(x => x.ID_APPLICATION_CATEGORY == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Application Category by id and remove it from data model
        /// </summary>
        /// <param name="id">The Application Category id</param>
        public static void DeleteApplicationCategoryById(long id)
        {
            using (DBModel db = new DBModel())
            {
                APPLICATION_CATEGORY applicationCategory = db.APPLICATION_CATEGORY.Where(x => x.ID_APPLICATION_CATEGORY == id).FirstOrDefault();
                db.APPLICATION_CATEGORY.Remove(applicationCategory);
                db.SaveChanges();
            }
        }

        #endregion APPLICATION_CATEGORY

        #region APPLICATIONS_MESSAGES

        /// <summary>
        /// Get all applications messages from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of applications messages</returns>
        public static List<APPLICATIONS_MESSAGES> GetAllApplicationsMessages(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.APPLICATIONS_MESSAGES.ToList();
            }
        }

        /// <summary>
        /// Get Application Message by its identifier from data model
        /// </summary>
        /// <param name="id">id of the Application Message in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Application Message data from data model matching the provided id</returns>
        public static APPLICATIONS_MESSAGES GetApplicationMessageById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.APPLICATIONS_MESSAGES.Where(x => x.ID_APPLICATION_MESSAGE == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Application Message by its application from data model
        /// </summary>
        /// <param name="application">The application</param>
        /// <param name="codeMessage">The code message</param>
        /// <returns>a message according to the application and the code message</returns>
        public static APPLICATIONS_MESSAGES GetApplicationsMessagesByApplication(string application, string codeMessage)
        {
            using (DBModel db = new DBModel())
            {
                return db.APPLICATIONS_MESSAGES.Where(x => (x.APPLICATION == application) && (x.CODE_MESSAGE == codeMessage)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Generate an exception that will be thrown with a message from the ApplicationMessage data-table
        /// </summary>
        /// <param name="applicationCode">The application code</param>
        /// <param name="messageCode">The message code</param>
        /// <param name="listAcknowledgmentsNames">The list of acknowledgment names if any, null otherwise</param>
        /// <returns>The generated Exception</returns>
        public static Exception GenerateExceptionFormApplicationMessage(string applicationCode, string messageCode, List<string> listAcknowledgmentsNames = null)
        {
            APPLICATIONS_MESSAGES applicationMessage = GetApplicationsMessagesByApplication(applicationCode, messageCode);
            string errorMessage = applicationMessage != null ? applicationMessage.MESSAGE : "An error occurred while acknowledging the documents";
            if (listAcknowledgmentsNames != null)
            {
                // Add the list of documents names to the error message
                string listOfApplications = string.Join("; ", listAcknowledgmentsNames);
                errorMessage = string.Concat(errorMessage, "\r\n", listOfApplications);
            }

            return new ApplicationException(errorMessage);
        }

        #endregion APPLICATIONS_MESSAGES

        #region BUSINESS_TYPE

        /// <summary>
        /// Get all business types from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of business types</returns>
        public static List<BUSINESS_TYPE> GetAllBusinessTypes(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.BUSINESS_TYPE.ToList();
            }
        }

        /// <summary>
        /// Get Business Type by its identifier from data model
        /// </summary>
        /// <param name="id">id of the Business Type in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Business Type data from data model matching the provided id</returns>
        public static BUSINESS_TYPE GetBusinessTypeById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.BUSINESS_TYPE.Where(x => x.ID_BUSINESS_TYPE == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Business Type by its code from data model
        /// </summary>
        /// <param name="code">Code of the Business Type in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Business Type data from data model matching the provided Code</returns>
        public static BUSINESS_TYPE GetBusinessTypeByCode(string code, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.BUSINESS_TYPE.Where(x => x.CODE_BUSINESS_TYPE == code).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get business type by id and remove it from data model
        /// </summary>
        /// <param name="id">The currency id</param>
        public static void DeleteBusinessTypeById(long id)
        {
            using (DBModel db = new DBModel())
            {
                BUSINESS_TYPE businessType = db.BUSINESS_TYPE.Where(x => x.ID_BUSINESS_TYPE == id).FirstOrDefault();
                db.BUSINESS_TYPE.Remove(businessType);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all Business Type from data model that are not included in Business Type Menu
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Warehouses that are not included in ENTITES_WAREHOUSES</returns>
        public static List<BUSINESS_TYPE> GetAllBusinessTypesNotIncludedInBusinessTypeMenus(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                // Get all Business Type that are not included in BUSINESS_TYPE_MENUS
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<long> businessTypeIds = db.BUSINESS_TYPE_MENUS.Select(c => c.FK_BUSINESS_TYPE).ToList();
                return db.BUSINESS_TYPE.Where(c => !businessTypeIds.Contains(c.ID_BUSINESS_TYPE)).ToList();
            }
        }

        /// <summary>
        /// Get Business Type by the entity identifier from data model
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Business Type data from data model of the provided entity identifier</returns>
        public static BUSINESS_TYPE GetEntityBusinessTypeByEntityId(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.Where(x => x.ID_ENTITY == idEntity).Include(x => x.BUSINESS_TYPE).Select(x => x.BUSINESS_TYPE).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity Business Type By Entity Code
        /// </summary>
        /// <param name="codeEntity">Entity code</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Business Type data from data model of the provided entity identifier</returns>
        public static BUSINESS_TYPE GetEntityBusinessTypeByEntityCode(string codeEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_NEW_APPLICATIONS.Where(x => x.CODE_ENTITY == codeEntity).Include(x => x.ENTITY.BUSINESS_TYPE).Select(x => x.ENTITY.BUSINESS_TYPE).FirstOrDefault();
            }
        }

        #endregion BUSINESS_TYPE

        #region BUSINESS_TYPE_MENUS

        /// <summary>
        /// Get business types menus matching the provided Business Type
        /// </summary>
        /// <param name="idBusinessType">id of the Business Type</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of business type menus for a specific business type</returns>
        public static List<BUSINESS_TYPE_MENUS> GetMenusByBusinessType(long idBusinessType, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.BUSINESS_TYPE_MENUS.Where(x => x.FK_BUSINESS_TYPE == idBusinessType)
                        .Include(e => e.MENUS)
                        .Include(e => e.BUSINESS_TYPE)
                        .ToList();
            }
        }

        /// <summary>
        /// Add an businessTypeMenu in database
        /// </summary>
        /// <param name="businessTypeMenu">businessTypeMenu to add</param>
        public static void AddBusinessTypeMenuInDb(BUSINESS_TYPE_MENUS businessTypeMenu)
        {
            using (DBModel db = new DBModel())
            {
                db.BUSINESS_TYPE_MENUS.Add(businessTypeMenu);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get business type menu by id and remove it from data model
        /// </summary>
        /// <param name="id">The business type menu id</param>
        public static void DeleteBusinessTypeMenuById(long id)
        {
            using (DBModel db = new DBModel())
            {
                BUSINESS_TYPE_MENUS businessTypeMenu = db.BUSINESS_TYPE_MENUS.Where(x => x.ID_BUSINESS_TYPE_MENUS == id).FirstOrDefault();
                db.BUSINESS_TYPE_MENUS.Remove(businessTypeMenu);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete matching Business Types Menus for a provided Business Type
        /// </summary>
        /// <param name="idBusinessType">The Business Type id</param>
        public static void DeleteBusinessTypeMenuBySpecificBusinessTypeId(long idBusinessType)
        {
            using (DBModel db = new DBModel())
            {
                db.BUSINESS_TYPE_MENUS.RemoveRange(db.BUSINESS_TYPE_MENUS.Where(x => x.FK_BUSINESS_TYPE == idBusinessType));
                db.SaveChanges();
            }
        }

        #endregion BUSINESS_TYPE_MENUS

        #region CONTACT_ATR

        /// <summary>
        /// Get all Contacts ATR with their contact type from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Contacts ATR with their contact types</returns>
        public static List<CONTACTS_ATR> GetAllContactsATRWithContactType(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CONTACTS_ATR.Include(r => r.CONTACT_TYPE).ToList();
            }
        }

        /// <summary>
        /// Get Contacts ATR by its identifier from data model
        /// </summary>
        /// <param name="id">id of the Contact ATR in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Contact ATR data from data model matching the provided id</returns>
        public static CONTACTS_ATR GetContactATRById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CONTACTS_ATR.Where(x => x.ID_CONTACT == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Contact ATR by id and remove it from data model
        /// </summary>
        /// <param name="id">The Contact ATR id</param>
        public static void DeleteContactATRById(long id)
        {
            using (DBModel db = new DBModel())
            {
                CONTACTS_ATR contactATR = db.CONTACTS_ATR.Where(x => x.ID_CONTACT == id).FirstOrDefault();
                db.CONTACTS_ATR.Remove(contactATR);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get the Contacts ATR picture from data model if any, null otherwise
        /// </summary>
        /// <param name="idContactATR">id of the Contact ATR in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The contact ATR Picture if any</returns>
        public static byte[] GetContactAtrPicture(long idContactATR, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CONTACTS_ATR.Where(c => c.ID_CONTACT == idContactATR).Select(c => c.PICTURE).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get all Contacts ATR from data model that are not included in ENTITY_CONTACTS_ATR
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Contacts ATR included in the entity matching the entity id provided</returns>
        public static List<CONTACTS_ATR> GetAllContactsATRNotIncludedInEntity(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<int> contactATRIds = db.ENTITY_CONTACTS_ATR.Where(c => c.FK_ENTITY == idEntity).Select(c => c.FK_CONTACTS_ATR).ToList();
                return db.CONTACTS_ATR.Where(c => !contactATRIds.Contains(c.ID_CONTACT)).ToList();
            }
        }

        /// <summary>
        /// Get the list of Contact ATR matching the provided entity id
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Contact ATR matching the provided entity id</returns>
        public static List<CONTACTS_ATR> GetAllEntityContactATRByEntityId(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<int> listContactATRids = db.ENTITY_CONTACTS_ATR.Where(x => x.FK_ENTITY == idEntity).Select(e => e.FK_CONTACTS_ATR).ToList();
                return db.CONTACTS_ATR.Where(c => listContactATRids.Contains(c.ID_CONTACT)).Include(e => e.CONTACT_TYPE).ToList();
            }
        }

        #endregion CONTACT_ATR

        #region CONTACT_TYPE

        /// <summary>
        /// Get all contact types from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of contact types</returns>
        public static List<CONTACT_TYPE> GetAllContactType(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CONTACT_TYPE.ToList();
            }
        }

        /// <summary>
        /// Get Contact Type from by its identifier data model
        /// </summary>
        /// <param name="id">id of the Contact Type in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Contact Type data from data model matching the provided id</returns>
        public static CONTACT_TYPE GetContactTypeById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CONTACT_TYPE.Where(x => x.ID_CONTACT_TYPE == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Contact Type by id and remove it from data model
        /// </summary>
        /// <param name="id">The Contact Type id</param>
        public static void DeleteContactTypeById(long id)
        {
            using (DBModel db = new DBModel())
            {
                CONTACT_TYPE contactType = db.CONTACT_TYPE.Where(x => x.ID_CONTACT_TYPE == id).FirstOrDefault();
                db.CONTACT_TYPE.Remove(contactType);
                db.SaveChanges();
            }
        }

        #endregion CONTACT_TYPE

        #region COUNTRY

        /// <summary>
        /// Get All Countries from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Countries</returns>
        public static List<COUNTRY> GetAllCountries(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.COUNTRY.ToList();
            }
        }

        /// <summary>
        /// Get Country by its identifier from data model
        /// </summary>
        /// <param name="id">id of the Country in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Country data from data model matching the provided id</returns>
        public static COUNTRY GetCountryById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.COUNTRY.Where(x => x.ID_COUNTRY == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Country by id and remove it from data model
        /// </summary>
        /// <param name="id">The country id</param>
        public static void DeleteCountryById(long id)
        {
            using (DBModel db = new DBModel())
            {
                COUNTRY country = db.COUNTRY.Where(x => x.ID_COUNTRY == id).FirstOrDefault();
                db.COUNTRY.Remove(country);
                db.SaveChanges();
            }
        }

        #endregion COUNTRY

        #region CURRENCIES

        /// <summary>
        /// Get all currencies from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of currencies</returns>
        public static List<CURRENCIES> GetAllCurrencies(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CURRENCIES.ToList();
            }
        }

        /// <summary>
        /// Get Currency by its identifier from data model
        /// </summary>
        /// <param name="id">id of the Currency in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Currency data from data model matching the provided id</returns>
        public static CURRENCIES GetCurrencyById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CURRENCIES.Where(x => x.ID_CURRENCY == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Currency by id and remove it from data model
        /// </summary>
        /// <param name="id">The currency id</param>
        public static void DeleteCurrencyById(long id)
        {
            using (DBModel db = new DBModel())
            {
                CURRENCIES currency = db.CURRENCIES.Where(x => x.ID_CURRENCY == id).FirstOrDefault();
                db.CURRENCIES.Remove(currency);
                db.SaveChanges();
            }
        }

        #endregion CURRENCIES

        #region CRM_ATA

        /// <summary>
        /// Get all CRM ATA from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of CRM ATA</returns>
        public static List<CRM_ATA> GetAllCRMATA(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CRM_ATA.ToList();
            }
        }

        /// <summary>
        /// Get CRM ATA by its identifier from data model
        /// </summary>
        /// <param name="id">id of the CRM ATA in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>CRM ATA data from data model matching the provided id</returns>
        public static CRM_ATA GetCRMATAById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CRM_ATA.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get CRM ATA by id and remove it from data model
        /// </summary>
        /// <param name="id">The CRM ATA id</param>
        public static void DeleteCRMATAById(long id)
        {
            using (DBModel db = new DBModel())
            {
                CRM_ATA crmAta = db.CRM_ATA.Where(x => x.ID == id).FirstOrDefault();
                db.CRM_ATA.Remove(crmAta);
                db.SaveChanges();
            }
        }

        #endregion CRM_ATA

        #region CRM_PORTAL_MANAGEMENT

        /// <summary>
        /// Get all CRM Portal Management from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of CRM Portal Management</returns>
        public static List<CRM_PORTAL_MANAGEMENT> GetAllCRMPortalManagement(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CRM_PORTAL_MANAGEMENT.ToList();
            }
        }

        /// <summary>
        /// Get CRM Portal Management by its identifier from data model
        /// </summary>
        /// <param name="id">id of the CRM Portal Management in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>CRM Portal Management data from data model matching the provided id</returns>
        public static CRM_PORTAL_MANAGEMENT GetCRMPortalManagementById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CRM_PORTAL_MANAGEMENT.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get CRM Portal Management by id and remove it from data model
        /// </summary>
        /// <param name="id">The CRM Portal Management id</param>
        public static void DeleteCRMPortalManagementById(long id)
        {
            using (DBModel db = new DBModel())
            {
                CRM_PORTAL_MANAGEMENT crmPortalManagement = db.CRM_PORTAL_MANAGEMENT.Where(x => x.ID == id).FirstOrDefault();
                db.CRM_PORTAL_MANAGEMENT.Remove(crmPortalManagement);
                db.SaveChanges();
            }
        }

        #endregion CRM_PORTAL_MANAGEMENT

        #region CRM_PORTAL_MESSAGES

        /// <summary>
        /// Get all CRM Portal messages from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of CRM Portal messages</returns>
        public static List<CRM_PORTAL_MESSAGES> GetAllCRMPortalMessages(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CRM_PORTAL_MESSAGES.ToList();
            }
        }

        /// <summary>
        /// Get CRM Portal message by its identifier from data model
        /// </summary>
        /// <param name="id">id of the CRM Portal message in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>CRM Portal message data from data model matching the provided id</returns>
        public static CRM_PORTAL_MESSAGES GetCRMPortalMessageById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CRM_PORTAL_MESSAGES.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get CRM Portal message by id and remove it from data model
        /// </summary>
        /// <param name="id">The CRM Portal message id</param>
        public static void DeleteCRMPortalMessagesById(long id)
        {
            using (DBModel db = new DBModel())
            {
                CRM_PORTAL_MESSAGES crmPortalMessage = db.CRM_PORTAL_MESSAGES.Where(x => x.ID == id).FirstOrDefault();
                db.CRM_PORTAL_MESSAGES.Remove(crmPortalMessage);
                db.SaveChanges();
            }
        }

        #endregion CRM_PORTAL_MESSAGES

        #region CGV_TCU

        /// <summary>
        /// Get all CGV linked to an entity
        /// </summary>
        /// <param name="idEntity">id of the entity</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>A list of ENTITY_CGV according to a specific entity</returns>
        public static List<ENTITY_CGV> GetAllEntityCGV(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY_CGV.Include(ec => ec.CGV).Where(c => c.FK_ENTITY == idEntity).ToList<ENTITY_CGV>();
            }
        }

        /// <summary>
        /// Insert a new record in ENTITY_CGV datatable
        /// </summary>
        /// <param name="entityCGV">record to insert</param>
        public static void AddENTITY_CGV(List<ENTITY_CGV> entityCGV)
        {
            using (DBModel db = new DBModel())
            {
                db.ENTITY_CGV.AddRange(entityCGV);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a CGV in CGV datatable by its ID
        /// </summary>
        /// <param name="id">id of the CGV to delete</param>
        public static void DeleteCGVById(long id)
        {
            using (DBModel db = new DBModel())
            {
                CGV cgv = db.CGV.Where(x => x.ID_CGV == id).FirstOrDefault();
                db.CGV.Remove(cgv);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a ENTITY_CGV in ENTITY_CGV datatable by its ID
        /// </summary>
        /// <param name="id">id of the ENTITY_CGV to delete</param>
        public static void DeleteEntityCgvByCgvId(long id)
        {
            using (DBModel db = new DBModel())
            {
                List<ENTITY_CGV> entityCgvList = db.ENTITY_CGV.Where(x => x.FK_CGV == id).ToList();
                db.ENTITY_CGV.RemoveRange(entityCgvList);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get a CGV by its Id
        /// </summary>
        /// <param name="id">Id of the CGV</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>return a CGV object according to its id</returns>
        public static CGV GetCGVByID(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CGV.Where(c => c.ID_CGV == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get a CGV by its Id, including ENTITY_CGV
        /// </summary>
        /// <param name="id">Id of the CGV</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>return a CGV object according to its id</returns>
        public static CGV GetCGVByIDWithEntityCgv(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CGV.Include(c => c.ENTITY_CGV).Where(c => c.ID_CGV == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get a CGV by its Id, including ENTITY_CGV and ENTITY
        /// </summary>
        /// <param name="id">Id of the CGV</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>return a CGV object according to its id</returns>
        public static CGV GetCGVByIDWithEntityCgvAndEntity(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CGV.Include(c => c.ENTITY_CGV).Include(c => c.ENTITY_CGV.Select(e => e.ENTITY)).Where(c => c.ID_CGV == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get all records from CGV datatable
        /// </summary>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>a list of CGV objects</returns>
        public static List<CGV> GetAllCGV(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.CGV.ToList();
            }
        }

        /// <summary>
        /// Get an entity by its id and include ENTITY_CGV & ENTITY_TCU
        /// </summary>
        /// <param name="id">id of the entity</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>an entity object according to its id</returns>
        public static ENTITY GetEntityByIdWithCGV_TCU(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.Where(x => x.ID_ENTITY == id)
                    .Include(e => e.ENTITY_CGV)
                    .Include(e => e.ENTITY_CGV.Select(c => c.CGV))
                    .Include(e => e.ENTITY_TCU)
                    .Include(e => e.ENTITY_TCU.Select(c => c.TCU))
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Update a record in ENTITY_CGV datatable
        /// </summary>
        /// <param name="entityCGV">object to update</param>
        public static void UpdateEntityCGVInDb(ENTITY_CGV entityCGV)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(entityCGV).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update a record in ENTITY_TCU datatable
        /// </summary>
        /// <param name="entityTCU">object to update</param>
        public static void UpdateEntityTCUInDb(ENTITY_TCU entityTCU)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(entityTCU).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all TCU linked to an entity
        /// </summary>
        /// <param name="idEntity">id of the entity</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>A list of ENTITY_TCU according to a specific entity</returns>
        public static List<ENTITY_TCU> GetAllEntityTCU(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY_TCU.Include(ec => ec.TCU).Where(c => c.FK_ENTITY == idEntity).ToList<ENTITY_TCU>();
            }
        }

        /// <summary>
        /// Insert a new record in ENTITY_TCU datatable
        /// </summary>
        /// <param name="entityTCU">record to insert</param>
        public static void AddENTITY_TCU(List<ENTITY_TCU> entityTCU)
        {
            using (DBModel db = new DBModel())
            {
                db.ENTITY_TCU.AddRange(entityTCU);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a TCU in TCU datatable by its ID
        /// </summary>
        /// <param name="id">id of the TCU to delete</param>
        public static void DeleteTCUById(long id)
        {
            using (DBModel db = new DBModel())
            {
                TCU tcu = db.TCU.Where(x => x.ID_TCU == id).FirstOrDefault();
                db.TCU.Remove(tcu);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a ENTITY_TCU in ENTITY_TCU datatable by its ID
        /// </summary>
        /// <param name="id">id of the ENTITY_TCU to delete</param>
        public static void DeleteEntityTcuByTcuId(long id)
        {
            using (DBModel db = new DBModel())
            {
                List<ENTITY_TCU> entityTcuList = db.ENTITY_TCU.Where(x => x.FK_TCU == id).ToList();
                db.ENTITY_TCU.RemoveRange(entityTcuList);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get a TCU by its Id
        /// </summary>
        /// <param name="id">Id of the TCU</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>return a TCU object according to its id</returns>
        public static TCU GetTCUByID(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.TCU.Where(c => c.ID_TCU == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get a TCU by its Id, including ENTITY_TCU
        /// </summary>
        /// <param name="id">Id of the TCU</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>return a TCU object according to its id</returns>
        public static TCU GetTCUByIDWithEntityTcu(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.TCU.Include(c => c.ENTITY_TCU).Where(c => c.ID_TCU == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get a TCU by its Id, including ENTITY_TCU and ENTITY
        /// </summary>
        /// <param name="id">Id of the TCU</param>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>return a TCU object according to its id</returns>
        public static TCU GetTCUByIDWithEntityTcuAndEntity(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.TCU.Include(c => c.ENTITY_TCU).Include(c => c.ENTITY_TCU.Select(e => e.ENTITY)).Where(c => c.ID_TCU == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get all records from TCU datatable
        /// </summary>
        /// <param name="lazyLoadingEnabled">false by default</param>
        /// <returns>a list of TCU objects</returns>
        public static List<TCU> GetAllTCU(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.TCU.ToList();
            }
        }

        #endregion CGV_TCU

        #region ENTITES_NEW_APPLICATION

        /// <summary>
        /// Add an entity new application in database
        /// </summary>
        /// <param name="entityNewApplication">entity new application to add</param>
        /// <returns>Created entity new application identifier</returns>
        public static long AddEntitesNewApplicationsInDb(ENTITES_NEW_APPLICATIONS entityNewApplication)
        {
            using (DBModel db = new DBModel())
            {
                ENTITES_NEW_APPLICATIONS addedEntityNewApplication = db.ENTITES_NEW_APPLICATIONS.Add(entityNewApplication);
                db.SaveChanges();

                return addedEntityNewApplication.ID_ENTITES_NEW_APPLICATIONS;
            }
        }

        /// <summary>
        /// Update an entity new application in database
        /// </summary>
        /// <param name="entityNewApplication">entity new application to update</param>
        public static void UpdateEntitesNewApplicationsInDb(ENTITES_NEW_APPLICATIONS entityNewApplication)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(entityNewApplication).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get the list of Entity New Application from data model
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Entity New Applications including New Applications matching the entity id provided</returns>
        public static List<ENTITES_NEW_APPLICATIONS> GetEntityNewApplicationsByEntityIdsWithNewApplications(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_NEW_APPLICATIONS.Where(x => x.FK_ENTITY == idEntity)
                      .Include(e => e.NEW_APPLICATIONS)
                      .Include(e => e.NEW_APPLICATIONS.RIGHTS)
                      .ToList();
            }
        }

        /// <summary>
        /// Get Entity New Application from data model thanks to the Entity Id and thanks to the New Application Id
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="idNewApplication">id of the new Application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Entity New Application matching the Entity id and the New Application id provided</returns>
        public static ENTITES_NEW_APPLICATIONS GetEntityNewApplicationByIdEntityAndIdNewApplication(int idEntity, long idNewApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_NEW_APPLICATIONS.Where(x => x.FK_ENTITY == idEntity && x.FK_NEW_APPLICATIONS == idNewApplication)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity New Application from data model thanks to the Entity code and thanks to the New Application Id
        /// </summary>
        /// <param name="codeEntity">Entity code of the Entity in the data model</param>
        /// <param name="idNewApplication">id of the new Application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Entity New Application matching the Entity id and the New Application id provided</returns>
        public static ENTITES_NEW_APPLICATIONS GetEntityNewApplicationByCodeEntityAndIdNewApplication(string codeEntity, long idNewApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_NEW_APPLICATIONS.Where(x => x.CODE_ENTITY == codeEntity && x.FK_NEW_APPLICATIONS == idNewApplication)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity New Application from data model
        /// </summary>
        /// <param name="idEntityNewApplication">id of the Entity New Application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Entity New Application matching the EntityNewApplication id provided</returns>
        public static ENTITES_NEW_APPLICATIONS GetEntityNewApplicationById(long idEntityNewApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_NEW_APPLICATIONS.Where(x => x.ID_ENTITES_NEW_APPLICATIONS == idEntityNewApplication)
                        .Include(e => e.NEW_APPLICATIONS).Include(e => e.NEW_APPLICATIONS.RIGHTS).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity new Application by ids and remove it from data model
        /// </summary>
        /// <param name="idEntity">The entity id</param>
        /// <param name="idNewApplication">The new application id</param>
        public static void DeleteEntitesNewApplicationByIds(int idEntity, int idNewApplication)
        {
            using (DBModel db = new DBModel())
            {
                ENTITES_NEW_APPLICATIONS entityNewApplication = db.ENTITES_NEW_APPLICATIONS
                    .Where(x => x.FK_ENTITY == idEntity && x.FK_NEW_APPLICATIONS == idNewApplication).FirstOrDefault();
                db.ENTITES_NEW_APPLICATIONS.Remove(entityNewApplication);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Entity new Application by id and remove it from data model
        /// </summary>
        /// <param name="idEntitesNewApplications">The entity id</param>
        public static void DeleteEntitesNewApplicationById(long idEntitesNewApplications)
        {
            using (DBModel db = new DBModel())
            {
                ENTITES_NEW_APPLICATIONS entityNewApplication = db.ENTITES_NEW_APPLICATIONS
                    .Where(x => x.ID_ENTITES_NEW_APPLICATIONS == idEntitesNewApplications).FirstOrDefault();
                db.ENTITES_NEW_APPLICATIONS.Remove(entityNewApplication);
                db.SaveChanges();
            }
        }

        #endregion ENTITES_NEW_APPLICATION

        #region ENTITES_RIGHTS

        /// <summary>
        /// Add an ENTITES_RIGHTS in database
        /// </summary>
        /// <param name="entiteRight">ENTITES_RIGHTS to add</param>
        public static void AddEntitesRightsInDatabase(ENTITES_RIGHTS entiteRight)
        {
            using (DBModel db = new DBModel())
            {
                db.ENTITES_RIGHTS.Add(entiteRight);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Entity Right from data model
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="idRight">id of the right in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Entity right data from data model matching the Entity id and the Right id provided</returns>
        public static ENTITES_RIGHTS GetEntitesRightsByIds(int idEntity, long idRight, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_RIGHTS.Where(x => x.FK_ENTITY == idEntity && x.FK_RIGHTS == idRight).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get ENTITES_RIGHTS by ids and remove it from data model
        /// </summary>
        /// <param name="idEntity">The entity id</param>
        /// <param name="idRight">The right id</param>
        public static void DeleteEntitesRightsByIds(long idEntity, long idRight)
        {
            using (DBModel db = new DBModel())
            {
                ENTITES_RIGHTS entityRight = db.ENTITES_RIGHTS.Where(x => x.FK_ENTITY == idEntity && x.FK_RIGHTS == idRight).FirstOrDefault();
                db.ENTITES_RIGHTS.Remove(entityRight);
                db.SaveChanges();
            }
        }

        #endregion ENTITES_RIGHTS

        #region ENTITES_WAREHOUSE

        /// <summary>
        /// Add an entity warehouse in database
        /// </summary>
        /// <param name="entityWarehouse">entity warehouse to add</param>
        public static void AddEntityWarehouseInDb(ENTITES_WAREHOUSE entityWarehouse)
        {
            using (DBModel db = new DBModel())
            {
                db.ENTITES_WAREHOUSE.Add(entityWarehouse);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Gets all entite_warehouse matching the ids
        /// </summary>
        /// <param name="idEntity">entity identifier</param>
        /// <param name="idWarehouse">warehouse identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of entite_warehouse matching the entity id and the warehouse id provided</returns>
        public static List<ENTITES_WAREHOUSE> GetEntiteWarehousesByIds(int idEntity, long idWarehouse, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_WAREHOUSE.Where(e => e.FK_ENTITY == idEntity && e.FK_WAREHOUSE == idWarehouse).ToList();
            }
        }

        /// <summary>
        /// Gets all entite_warehouse (with warehouses included) matching the ids
        /// </summary>
        /// <param name="idEntity">entity identifier</param>
        /// <param name="idWarehouse">warehouse identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of entite_warehouse (warehouses included) matching the entity id and the warehouse id provided</returns>
        public static List<ENTITES_WAREHOUSE> GetEntiteWarehousesByIdsWithWarehouse(int idEntity, long idWarehouse, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_WAREHOUSE.Where(e => e.FK_ENTITY == idEntity && e.FK_WAREHOUSE == idWarehouse)
                    .Include(e => e.WAREHOUSES).ToList();
            }
        }

        /// <summary>
        /// Get the list of Entity Warehouse (with warehouses included) matching the entity id provided
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of entite_warehouse (warehouses included) matching the entity id provided</returns>
        public static List<ENTITES_WAREHOUSE> GetEntityWarehouseByEntityIdsWithWarehouse(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_WAREHOUSE.Where(x => x.FK_ENTITY == idEntity)
                      .Include(e => e.WAREHOUSES)
                      .ToList();
            }
        }

        /// <summary>
        /// Get the list of Entity Default Warehouse (with warehouses included) matching the entity identifier provided
        /// </summary>
        /// <param name="idEntity">Identifier of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of entite_warehouse (warehouses included) matching the entity identifier provided</returns>
        public static List<ENTITES_WAREHOUSE> GetEntityDefaultWarehouseByEntityIdsWithWarehouse(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_WAREHOUSE.Where(x => x.FK_ENTITY == idEntity)
                    .Where(e => e.TYPE_WAREHOUSE == WarehouseType.DefaultWarehouseNew.ToString()
                   || e.TYPE_WAREHOUSE == WarehouseType.DefaultWarehouseSecondHand.ToString()
                   || e.TYPE_WAREHOUSE == WarehouseType.DefaultWarehouseOverhauled.ToString())
                    .Include(e => e.WAREHOUSES)
                    .ToList();
            }
        }

        /// <summary>
        /// Get the Entity Warehouse matching the ids
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="idWarehouse">id of the Warehouse in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Entity data from data model matching the entity id and the warehouse id provided</returns>
        public static ENTITES_WAREHOUSE GetEntitesWarehousesByIds(int idEntity, long idWarehouse, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITES_WAREHOUSE.Where(x => x.FK_ENTITY == idEntity && x.FK_WAREHOUSE == idWarehouse).Include(e => e.WAREHOUSES).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entites_warehouse by ids and remove it from data model
        /// </summary>
        /// <param name="idEntityWarehouse">The entity warehouse id</param>
        public static void DeleteEntitesWarehouseById(long idEntityWarehouse)
        {
            using (DBModel db = new DBModel())
            {
                ENTITES_WAREHOUSE entityWarehouse = db.ENTITES_WAREHOUSE.Where(x => x.ID_ENTITES_WAREHOUSE == idEntityWarehouse).FirstOrDefault();
                db.ENTITES_WAREHOUSE.Remove(entityWarehouse);
                db.SaveChanges();
            }
        }

        #endregion ENTITES_WAREHOUSE

        #region ENTITY

        /// <summary>
        /// Add an entity in database
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>The added entity id</returns>
        public static int AddEntityInDb(ENTITY entity)
        {
            using (DBModel db = new DBModel())
            {
                int idEntity = db.ENTITY.Select(e => e.ID_ENTITY).Max();
                entity.ID_ENTITY = idEntity + 1;
                db.ENTITY.Add(entity);
                db.SaveChanges();
                return entity.ID_ENTITY;
            }
        }

        /// <summary>
        /// Update an entity in database
        /// </summary>
        /// <param name="entity">entity</param>
        public static void UpdateEntityInDb(ENTITY entity)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update entities in database
        /// </summary>
        /// <param name="entities">list of entities</param>
        /// <returns>The list of entities in errors</returns>
        public static List<string> UpdateEntitiesInDb(List<ENTITY> entities)
        {
            List<string> errors = new List<string>();
            string validationError = string.Empty;

            using (DBModel db = new DBModel())
            {
                foreach (ENTITY entity in entities)
                {
                    validationError = string.Empty;

                    try
                    {
                        db.Entry(entity).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            if (((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors != null)
                            {
                                foreach (var item in ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors)
                                {
                                    foreach (var itemError in item.ValidationErrors)
                                    {
                                        validationError += itemError.ErrorMessage;
                                    }
                                }
                            }

                            db.Entry(entity).State = EntityState.Detached;
                        }
                        catch
                        {
                        }

                        errors.Add(entity.COMPANY_NAME + " (" + ex.Message + " " + validationError + ")");
                    }
                }
            }

            return errors;
        }

        /// <summary>
        /// Get the entity logo from data model if any, null otherwise
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The entity logo if any</returns>
        public static byte[] GetEntityLogo(long idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.Where(c => c.ID_ENTITY == idEntity).Select(c => c.ENTITY_LOGO).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity from data model
        /// </summary>
        /// <param name="id">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Entity matching the provided id</returns>
        public static ENTITY GetEntityById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.Where(x => x.ID_ENTITY == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity from data model with support center linked table
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Entity data including support center and matching the provided id</returns>
        public static ENTITY GetEntityByIdWithSupportCenter(long idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.Where(x => x.ID_ENTITY == idEntity)
                    .Include(e => e.SUPPORT_CENTER)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity from data model with all data included
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Entity data from data model with all data included and matching the id provided</returns>
        public static ENTITY GetEntityByIdWithAllDependancies(long idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.Where(x => x.ID_ENTITY == idEntity)
                    .Include(e => e.BUSINESS_TYPE)
                    .Include(e => e.COUNTRY)
                    .Include(e => e.SUPPORT_CENTER)
                    .Include(e => e.TRAINING_CENTER)
                    .Include(e => e.CURRENCIES)
                    .Include(e => e.ENTITY_CONTACTS_ATR)
                    .Include(e => e.USERS)
                    .Include(e => e.ENTITY_APPLICATION.Select(ent => ent.APPLICATION))
                    .Include(e => e.ENTITY_APPLICATION_ACCESS.Select(ent => ent.APPLICATION))
                    .Include(e => e.ENTITES_WAREHOUSE.Select(ent => ent.WAREHOUSES))
                    .Include(e => e.ENTITES_NEW_APPLICATIONS.Select(ent => ent.NEW_APPLICATIONS).Select(newApp => newApp.RIGHTS))
                    .Include(e => e.ENTITY_CONTACTS_ATR.Select(ent => ent.CONTACTS_ATR).Select(c => c.CONTACT_TYPE))
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Get all entities from data model ordered by Company Name
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Entity ordered by Company Name</returns>
        public static List<ENTITY> GetAllEntitiesOrderedByCompanyName(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.OrderBy(e => e.COMPANY_NAME).ToList();
            }
        }

        /// <summary>
        /// Get All entities with their Business Type from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Entity including Business type</returns>
        public static List<ENTITY> GetAllEntitiesWithBusinessType(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY.Include(r => r.BUSINESS_TYPE).ToList();
            }
        }

        /// <summary>
        /// Get all entities having access to new applications from data model ordered by Company Name
        /// </summary>
        /// <param name="newApplicationId"> Id new applications entities to be have access</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Entity ordered by Company Name</returns>
        public static List<ENTITES_NEW_APPLICATIONS> GetEntitiesHavingAccessToNewAppOrderedByCompanyName(long newApplicationId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                // Get the list of entity identifier that has access to the application
                List<ENTITES_NEW_APPLICATIONS> listEntityWithAccess = db.ENTITES_NEW_APPLICATIONS.Where(e => e.FK_NEW_APPLICATIONS == newApplicationId && e.ACCESS && e.CODE_ENTITY != null && !e.CODE_ENTITY.Trim().Equals(string.Empty))
                                                                                                 .Include(ena => ena.ENTITY)
                                                                                                 .Include(ena => ena.ENTITY.BUSINESS_TYPE).ToList();

                // Get the list of valid entity identifier
                return listEntityWithAccess;
            }
        }

        /// <summary>
        /// Check if the ATR code provided is already used in data base
        /// </summary>
        /// <param name="atrCode">ATR code to check</param>
        /// <param name="entityId">Entity Id to check</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>True if the ATR Code is already used, false otherwise</returns>
        public static bool IsATRCodeUsed(string atrCode, int entityId, bool lazyLoadingEnabled = false)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(atrCode))
            {
                using (DBModel db = new DBModel())
                {
                    db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                    ENTITY entity = db.ENTITY.Where(e => e.ATR_CODE.Equals(atrCode) && e.ID_ENTITY != entityId).FirstOrDefault();

                    // If there is an entity, the ATR code is already used
                    if (entity != null)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Check if the company name provided is already used in data base
        /// </summary>
        /// <param name="companyName">Company name to check</param>
        /// <param name="entityId">Entity Id to check</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>True if the company name is already used, false otherwise</returns>
        public static bool IsEntityCompanyNameUsed(string companyName, int entityId, bool lazyLoadingEnabled = false)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(companyName))
            {
                using (DBModel db = new DBModel())
                {
                    db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                    ENTITY entity = db.ENTITY.Where(e => e.COMPANY_NAME.Equals(companyName, StringComparison.InvariantCultureIgnoreCase) && e.ID_ENTITY != entityId).FirstOrDefault();

                    // If there is an entity, the ATR code is already used
                    if (entity != null)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Execute a stored procedure to retrieve entities
        /// </summary>
        /// <param name="idEntity">The entity id, if not provided all entities are returned</param>
        /// <returns>A list of strings containing entities data</returns>
        public static IList<string> ExtractEntities(int idEntity = 0)
        {
            IList<string> result = null;

            using (DBModel db = new DBModel())
            using (SqlCommand query = new SqlCommand())
            using (DataTable table = new DataTable())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                // Define command properties (stored procedure to call, connection...)
                query.CommandText = "usp_extract_entities";
                query.Connection = (SqlConnection)db.Database.Connection;
                query.CommandType = CommandType.StoredProcedure;
                if (idEntity != 0)
                {
                    query.Parameters.Add(SqlParameterHelper.CreateIntegerParameter("entity_id", idEntity));
                }

                // Set command as select command of adapter.
                adapter.SelectCommand = query;

                // Update locale table property.
                table.Locale = CultureInfo.InvariantCulture;

                // Execute adapter select command i.e. execute command defined.
                adapter.Fill(table);

                // Convert table to list of string using extension method defined.
                result = table.ToStringListExtract();
            }

            return result;
        }

        public static IList<string> ExtractEntitiesWithCgvTcuData()
        {
            IList<string> result = null;

            using (DBModel db = new DBModel())
            using (SqlCommand query = new SqlCommand())
            using (DataTable table = new DataTable())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                // Define command properties (stored procedure to call, connection...)
                query.CommandText = "usp_extract_tcu_cgv";
                query.Connection = (SqlConnection)db.Database.Connection;
                query.CommandType = CommandType.StoredProcedure;

                // Set command as select command of adapter.
                adapter.SelectCommand = query;

                // Update locale table property.
                table.Locale = CultureInfo.InvariantCulture;

                // Execute adapter select command i.e. execute command defined.
                adapter.Fill(table);

                // Convert table to list of string using extension method defined.
                result = table.ToStringListExtract();
            }

            return result;
        }

        /// <summary>
        /// Get Entity by id and remove it from data model
        /// </summary>
        /// <param name="idEntity">The entity id</param>
        public static void DeleteEntityById(int idEntity)
        {
            using (DBModel db = new DBModel())
            {
                ENTITY entity = db.ENTITY.Where(x => x.ID_ENTITY == idEntity).FirstOrDefault();
                db.ENTITY.Remove(entity);
                db.SaveChanges();
            }
        }

        #endregion ENTITY

        #region ENTITY_APPLICATION

        /// <summary>
        /// Update an entity application in database
        /// </summary>
        /// <param name="entityApplication">entity application to update</param>
        public static void UpdateEntityApplicationInDb(ENTITY_APPLICATION entityApplication)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(entityApplication).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get the list of Entity Application with applications from data model
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Entity Application (with applications) matching the provided id</returns>
        public static List<ENTITY_APPLICATION> GetEntityApplicationsByEntityIdsWithApplications(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY_APPLICATION.Where(x => x.FK_ENTITY == idEntity).Include(x => x.APPLICATION).ToList();
            }
        }

        /// <summary>
        /// Get Entity Application with applications from data model
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="idApplication">id of the application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Entity (with applications) matching the entity id provided and the application id provided</returns>
        public static ENTITY_APPLICATION GetEntityApplicationByIdsWithApplications(int idEntity, long idApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY_APPLICATION.Where(x => x.FK_ENTITY == idEntity && x.FK_APPLICATION == idApplication).Include(x => x.APPLICATION).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity Application by ids and remove it from data model
        /// </summary>
        /// <param name="idEntity">The entity id</param>
        /// <param name="idApplication">The application id</param>
        public static void DeleteEntityApplicationById(int idEntity, long idApplication)
        {
            using (DBModel db = new DBModel())
            {
                ENTITY_APPLICATION entityApplication = db.ENTITY_APPLICATION
                    .Where(x => x.FK_ENTITY == idEntity && x.FK_APPLICATION == idApplication).FirstOrDefault();
                db.ENTITY_APPLICATION.Remove(entityApplication);
                db.SaveChanges();
            }
        }

        #endregion ENTITY_APPLICATION

        #region ENTITY_APPLICATION_ACCESS

        /// <summary>
        /// Update an entity application access in database
        /// </summary>
        /// <param name="entityApplicationAccess">entity application access to update</param>
        public static void UpdateEntityApplicationAccessInDb(ENTITY_APPLICATION_ACCESS entityApplicationAccess)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(entityApplicationAccess).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get the list of Entity Application Access matching the provided entity id
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Entity Application Access matching the provided entity id</returns>
        public static List<ENTITY_APPLICATION_ACCESS> GetEntityApplicationAccessByEntityIdsWithApplications(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY_APPLICATION_ACCESS.Where(x => x.FK_ENTITY == idEntity).Include(x => x.APPLICATION).ToList();
            }
        }

        /// <summary>
        /// Get Entity Application access matching the provided ids
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="idApplication">id of the application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Entity Application Access matching the entity id and the application id provided</returns>
        public static ENTITY_APPLICATION_ACCESS GetEntityApplicationAccessByIdsWithApplications(int idEntity, long idApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY_APPLICATION_ACCESS.Where(x => x.FK_ENTITY == idEntity && x.FK_APPLICATION == idApplication)
                    .Include(x => x.APPLICATION).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity Application Access by ids and remove it from data model
        /// </summary>
        /// <param name="idEntity">The entity id</param>
        /// <param name="idApplication">The application id</param>
        public static void DeleteEntityApplicationAccessByIds(int idEntity, long idApplication)
        {
            using (DBModel db = new DBModel())
            {
                ENTITY_APPLICATION_ACCESS entityApplicationAccess = db.ENTITY_APPLICATION_ACCESS
                    .Where(x => x.FK_ENTITY == idEntity && x.FK_APPLICATION == idApplication).FirstOrDefault();
                db.ENTITY_APPLICATION_ACCESS.Remove(entityApplicationAccess);
                db.SaveChanges();
            }
        }

        #endregion ENTITY_APPLICATION_ACCESS

        #region ENTITY_CONTACTS_ATR

        /// <summary>
        /// Get the Entity Contact ATR matching the provided ids
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="idContact">id of the contact ATR in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Entity Contact ATR matching the entity id and the contact id provided</returns>
        public static ENTITY_CONTACTS_ATR GetEntityContactATRByIds(int idEntity, int idContact, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.ENTITY_CONTACTS_ATR.Where(x => x.FK_ENTITY == idEntity && x.FK_CONTACTS_ATR == idContact).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Entity Contact ATR by ids and remove it from data model
        /// </summary>
        /// <param name="idEntity">The entity id</param>
        /// <param name="idContact">The contact ATR id</param>
        public static void DeleteEntityContactATRByIds(int idEntity, int idContact)
        {
            using (DBModel db = new DBModel())
            {
                ENTITY_CONTACTS_ATR entityContactATR = db.ENTITY_CONTACTS_ATR
                    .Where(x => x.FK_ENTITY == idEntity && x.FK_CONTACTS_ATR == idContact).FirstOrDefault();
                db.ENTITY_CONTACTS_ATR.Remove(entityContactATR);
                db.SaveChanges();
            }
        }

        #endregion ENTITY_CONTACTS_ATR

        #region FREQUENCIES

        /// <summary>
        /// Get all frequencies with applications
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of frequencies with applications</returns>
        public static List<FREQUENCIES> GetAllFrequenciesWithNewApplications(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.FREQUENCIES.Include(m => m.NEW_APPLICATIONS).ToList();
            }
        }

        /// <summary>
        /// Get all frequencies for the new applications
        /// </summary>
        /// <param name="newApplicationId">The new application identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of frequencies for the new applications</returns>
        public static List<FREQUENCIES> GetAllFrequenciesByNewApplicationId(long newApplicationId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.FREQUENCIES.Where(f => f.FK_NEW_APPLICATIONS == newApplicationId).ToList();
            }
        }

        /// <summary>
        /// Get all frequencies for a new application ordered by their labels
        /// </summary>
        /// <param name="newApplicationId">The new application identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The ordered list of frequencies for the new applications</returns>
        public static List<FREQUENCIES> GetAllFrequenciesByNewApplicationIdOrderedByLabel(long newApplicationId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.FREQUENCIES.Where(f => f.FK_NEW_APPLICATIONS == newApplicationId).OrderBy(f => f.LABEL_FREQUENCY).ToList();
            }
        }

        /// <summary>
        /// Get Frequency matching the provided id
        /// </summary>
        /// <param name="id">id of the frequency in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Frequency matching the provided id</returns>
        public static FREQUENCIES GetFrequencyById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.FREQUENCIES.Where(x => x.ID_FREQUENCY == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Frequency by id and remove it from data model
        /// </summary>
        /// <param name="id">The Frequency id</param>
        public static void DeleteFrequencyById(long id)
        {
            using (DBModel db = new DBModel())
            {
                FREQUENCIES frequency = db.FREQUENCIES.Where(x => x.ID_FREQUENCY == id).FirstOrDefault();
                db.FREQUENCIES.Remove(frequency);
                db.SaveChanges();
            }
        }

        #endregion FREQUENCIES

        #region GSE_ZONE

        /// <summary>
        /// Update GSE Zone by Support Center.
        /// </summary>
        /// <param name="listGSE">List of GSE ZONE.</param>
        /// <param name="strZone">Support Center linked with <paramref name="listGSE"/>.</param>
        public static void UpdateGSECatalogsByCenter(List<GSE_ZONE> listGSE, string strZone)
        {
            using (SqlConnection connection = new SqlConnection(new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DBModel"].ConnectionString).ProviderConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM [GSE_ZONE] WHERE [GSE_ZONE] = @zone";
                SqlCommand command = new SqlCommand(query, connection);
                SqlParameter parameter = new SqlParameter("@zone", strZone);
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();

                // Insert new value for the GSE Zone.
                string insertGSEQuery = @"INSERT INTO GSE_ZONE (
                                            GSE_NUMPN,
                                            GSE_LIB,
                                            GSE_REMARK,
                                            GSE_TEST,
                                            GSE_CALIBRATION,
                                            GSE_TEST_UP_LEASE,
                                            GSE_ZONE,
                                            GSE_NOMFIC
                                        ) VALUES (
                                            @GSE_NUMPN,
                                            @GSE_LIB,
                                            @GSE_REMARK,
                                            @GSE_TEST,
                                            @GSE_CALIBRATION,
                                            @GSE_TEST_UP_LEASE,
                                            @GSE_ZONE,
                                            @GSE_NOMFIC
                                        )";
                foreach (GSE_ZONE gseZone in listGSE)
                {
                    SqlCommand insertGSE = new SqlCommand(insertGSEQuery, connection);
                    insertGSE.Parameters.AddWithValue("@GSE_NUMPN", gseZone.GSE_NUMPN.ToString());
                    insertGSE.Parameters.AddWithValue("@GSE_ZONE", gseZone.GSE_ZONE1);
                    insertGSE = AddParameterValueToRequest(insertGSE, "@GSE_LIB", gseZone.GSE_LIB);
                    insertGSE = AddParameterValueToRequest(insertGSE, "@GSE_REMARK", gseZone.GSE_REMARK);
                    insertGSE = AddParameterValueToRequest(insertGSE, "@GSE_TEST", gseZone.GSE_TEST);
                    insertGSE = AddParameterValueToRequest(insertGSE, "@GSE_CALIBRATION", gseZone.GSE_CALIBRATION);
                    insertGSE = AddParameterValueToRequest(insertGSE, "@GSE_TEST_UP_LEASE", gseZone.GSE_TEST_UP_LEASE);
                    insertGSE = AddParameterValueToRequest(insertGSE, "@GSE_NOMFIC", gseZone.GSE_NOMFIC);
                    insertGSE.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Get GSE_ZONE By Center and search criteria if any
        /// </summary>
        /// <param name="supportCenter">support center</param>
        /// <param name="pn">P/N number</param>
        /// <param name="keywords">keywords</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of GSE_ZONE matching criteria</returns>
        public static List<GSE_ZONE> GetCatalogsGSEByCenterAndCriterias(string supportCenter, string pn = "", string keywords = "", bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                List<GSE_ZONE> results = new List<GSE_ZONE>();
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                IQueryable<GSE_ZONE> query = db.GSE_ZONE.Where(x => x.GSE_ZONE1 == supportCenter);

                if (!string.IsNullOrEmpty(pn))
                {
                    query = query.Where(x => x.GSE_NUMPN.Contains(pn));
                }

                if (!string.IsNullOrEmpty(keywords))
                {
                    query = query.Where(x => x.GSE_LIB.Contains(keywords));
                }

                results = query.ToList();
                return results;
            }
        }
        #endregion

        #region HISTO_LOGIN_USERS

        public static int GetHistoLoginUserRank(string login, bool lazyLoadingEnabled = false)
        {
            int result = -1;

            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                HISTO_LOGIN_USERS hlu = db.HISTO_LOGIN_USERS
                    .Where(x => x.USER_LOGIN_ROOT == login)
                    .OrderByDescending(h => h.USER_RANK)
                    .FirstOrDefault();

                if (hlu != null)
                {
                    result = hlu.USER_RANK;
                }
            }

            return result;
        }

        /// <summary>
        /// Add a HISTO_LOGIN_USERS in database
        /// </summary>
        /// <param name="hlu">HISTO_LOGIN_USERS object</param>
        public static void AddHistoLoginUsersInDb(HISTO_LOGIN_USERS hlu)
        {
            using (DBModel db = new DBModel())
            {
                db.HISTO_LOGIN_USERS.Add(hlu);
                db.SaveChanges();
            }
        }

        #endregion HISTO_LOGIN_USERS

        #region JOB_PROFILES

        /// <summary>
        /// Get all job profiles
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of JOB_PROFIL</returns>
        public static List<JOB_PROFIL> GetAllJobProfils(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.JOB_PROFIL.ToList();
            }
        }

        /// <summary>
        /// Get Job Profile from data model
        /// </summary>
        /// <param name="idJobProfile">id of the Job Profile in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Job Profile matching the provided id</returns>
        public static JOB_PROFIL GetJobProfileById(long idJobProfile, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.JOB_PROFIL.Where(x => x.ID_JOB_PROFIL == idJobProfile).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Job Profile by id and remove it from data model
        /// </summary>
        /// <param name="idJobProfile">The Job Profile id</param>
        public static void DeleteJobProfileById(long idJobProfile)
        {
            using (DBModel db = new DBModel())
            {
                JOB_PROFIL jobProfile = db.JOB_PROFIL.Where(x => x.ID_JOB_PROFIL == idJobProfile).FirstOrDefault();
                db.JOB_PROFIL.Remove(jobProfile);
                db.SaveChanges();
            }
        }

        #endregion JOB_PROFILES

        #region MENUS

        /// <summary>
        /// Get all header menus available for a user
        /// </summary>
        /// <param name="idUser">The user identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of header MENUS</returns>
        public static List<MENUS> GetHeaderMenusAvailableByUserId(long idUser, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                USERS user = db.USERS.Where(u => u.ID_USER == idUser).FirstOrDefault();
                ENTITY userEntity = db.ENTITY.Where(e => e.ID_ENTITY == user.FK_ENTITY).FirstOrDefault();
                List<MENUS> listMenus = db.BUSINESS_TYPE_MENUS.Where(b => b.FK_BUSINESS_TYPE == userEntity.FK_BUSINESS_TYPE).Include(b => b.MENUS).Select(b => b.MENUS).ToList();
                return listMenus.Where(m => m.TYPE_MENU.Equals("HeaderMenu")).ToList();
            }
        }

        /// <summary>
        /// Get all icons menus available
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of icons MENUS</returns>
        public static List<MENUS> GetIconsMenusAvailable(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<MENUS> listMenus = db.MENUS.Where(m => m.TYPE_MENU.Equals("HeaderIcon")).ToList();
                return listMenus;
            }
        }

        /// <summary>
        /// Get all menus from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of menus</returns>
        public static List<MENUS> GetAllMenus(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.MENUS.ToList();
            }
        }

        /// <summary>
        /// Get Menu from data model
        /// </summary>
        /// <param name="idMenu">identifier of the Menu in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Menu matching the provided identifier</returns>
        public static MENUS GetMenusById(long idMenu, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.MENUS.Where(x => x.ID_MENU == idMenu).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Menu from data model
        /// </summary>
        /// <param name="codeMenu">Code of the Menu in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>Menu matching the provided identifier</returns>
        public static MENUS GetMenusByCode(string codeMenu, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.MENUS.Where(x => x.CODE_MENU == codeMenu).FirstOrDefault();
            }
        }

        #endregion

        #region NEW_APPLICATIONS

        /// <summary>
        /// Get all new applications from data model
        /// </summary>
        /// <returns>The list of new applications</returns>
        public static List<NEW_APPLICATIONS> GetAllNewApplications()
        {
            using (DBModel db = new DBModel())
            {
                return db.NEW_APPLICATIONS.ToList();
            }
        }

        /// <summary>
        /// Get all new applications from data model with linked rights, notifications and frequencies
        /// </summary>
        /// <returns>The list of new applications</returns>
        public static List<NEW_APPLICATIONS> GetAllNewApplicationsWithRightsAndNotificationsManagableForUser()
        {
            using (DBModel db = new DBModel())
            {
                return db.NEW_APPLICATIONS.Where(n => n.RIGHT_LEVELS.CODE_RIGHT_LEVEL == "USER")
                    .Include(n => n.RIGHTS)
                    .Include(n => n.NOTIFICATIONS)
                    .Include(n => n.FREQUENCIES)
                    .ToList();
            }
        }

        /// <summary>
        /// Get all new applications from data model with Application Category and Right Levels
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of new applications including Application Category and Right Levels</returns>
        public static List<NEW_APPLICATIONS> GetAllNewApplicationsWithApplicationCategoryAndRightLevels(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.NEW_APPLICATIONS
                    .Include(m => m.APPLICATION_CATEGORY)
                    .Include(r => r.RIGHT_LEVELS)
                    .ToList();
            }
        }

        /// <summary>
        /// Get new application by id from data model
        /// </summary>
        /// <param name="id">The new application id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The new application matching the provided id</returns>
        public static NEW_APPLICATIONS GetNewApplicationById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.NEW_APPLICATIONS.Where(x => x.ID_NEW_APPLICATION == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get new application by code from data model
        /// </summary>
        /// <param name="codeNewApplication">The new application code</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The new application matching the provided code</returns>
        public static NEW_APPLICATIONS GetNewApplicationByCode(string codeNewApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.NEW_APPLICATIONS.Where(x => x.CODE_NEW_APPLICATION.ToLower() == codeNewApplication.ToLower()).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get new application by id and remove it from data model
        /// </summary>
        /// <param name="id">The new application id</param>
        public static void DeleteNewApplicationById(long id)
        {
            using (DBModel db = new DBModel())
            {
                NEW_APPLICATIONS newApplication = db.NEW_APPLICATIONS.Where(x => x.ID_NEW_APPLICATION == id).FirstOrDefault();
                db.NEW_APPLICATIONS.Remove(newApplication);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all New Applications from data model that are not included in ENTITES_NEW_APPLICATIONS
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Applications that are not included in ENTITES_NEW_APPLICATIONS</returns>
        public static List<NEW_APPLICATIONS> GetAllApplicationsNotIncludedInEntitesNewApplication(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<long> newApplicationsIds = db.ENTITES_NEW_APPLICATIONS.Where(c => c.FK_ENTITY == idEntity).Select(c => c.FK_NEW_APPLICATIONS).ToList();
                return db.NEW_APPLICATIONS.Where(c => !newApplicationsIds.Contains(c.ID_NEW_APPLICATION)).ToList();
            }
        }

        /// <summary>
        /// Get all New Applications from data model that are not included in USERS_NEW_APPLICATION and included in ENTITES_NEW_APPLICATIONS with RIGHT_LEVEL is USER
        /// </summary>
        /// <param name="idUser">id of the user in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Applications that are not included in USERS_NEW_APPLICATION</returns>
        public static List<NEW_APPLICATIONS> GetAllApplicationsNotIncludedInUsersNewApplication(long idUser, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                int idEntity = db.USERS.Where(u => u.ID_USER == idUser).Select(u => u.FK_ENTITY).FirstOrDefault();
                List<long> newApplicationsIds = db.USERS_NEW_APPLICATIONS.Where(c => c.FK_USERS == idUser).Select(c => c.FK_NEW_APPLICATIONS).ToList();
                List<long> entityNewApplicationsIds = db.ENTITES_NEW_APPLICATIONS.Where(c => c.FK_ENTITY == idEntity && c.NEW_APPLICATIONS.RIGHT_LEVELS.CODE_RIGHT_LEVEL.Equals("USER", StringComparison.OrdinalIgnoreCase)).Select(c => c.FK_NEW_APPLICATIONS).ToList();
                return db.NEW_APPLICATIONS.Where(c => entityNewApplicationsIds.Contains(c.ID_NEW_APPLICATION) && !newApplicationsIds.Contains(c.ID_NEW_APPLICATION)).ToList();
            }
        }

        /// <summary>
        /// Check if the user's entity has access to the application
        /// </summary>
        /// <param name="idUser">id of the user in the data model</param>
        /// <param name="idNewApplication">id of the new application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>True if the access is allowed for user's entity, False otherwise</returns>
        public static bool IsNewApplicationAvailableForUserEntity(long idUser, long idNewApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                int userEntityId = db.USERS.Where(u => u.ID_USER == idUser).Select(u => u.FK_ENTITY).FirstOrDefault();
                bool hasEntityAccess = db.ENTITES_NEW_APPLICATIONS.Where(e => e.FK_ENTITY == userEntityId && e.FK_NEW_APPLICATIONS == idNewApplication).Select(e => e.ACCESS).FirstOrDefault();
                return hasEntityAccess;
            }
        }

        /// <summary>
        /// Get all visible new applications from data model for which entity has access
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of visible new applications for which entity has access</returns>
        public static List<NEW_APPLICATIONS> GetAllVisibleAndAccessibleNewApplicationForEntityOrderedByLabel(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                long applicationCategoryVisible = db.APPLICATION_CATEGORY.Where(ac => ac.APPLICATION_CATEGORY1.ToLower().Equals("visible")).Select(ac => ac.ID_APPLICATION_CATEGORY).FirstOrDefault();
                List<long> applicationsIds = db.ENTITES_NEW_APPLICATIONS.Where(c => c.FK_ENTITY == idEntity && c.ACCESS).Select(c => c.FK_NEW_APPLICATIONS).ToList();
                return db.NEW_APPLICATIONS.Where(a => applicationsIds.Contains(a.ID_NEW_APPLICATION) && a.FK_APPLICATION_CATEGORY == applicationCategoryVisible).OrderBy(a => a.LABEL_NEW_APPLICATION).ToList();
            }
        }

        /// <summary>
        /// Get all visible new applications from data model for which entity has access
        /// </summary>
        /// <param name="entityId">Entity Id in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be used, false otherwise</param>
        /// <returns>The list of new applications for which entity has access</returns>
        public static List<NEW_APPLICATIONS> GetAllNewApplicationsByEntity(int entityId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                List<long> entityNewApplicationsIds = db.ENTITES_NEW_APPLICATIONS.Where(w => w.FK_ENTITY == entityId && w.ACCESS).Select(s => s.FK_NEW_APPLICATIONS).ToList();
                long applicationCategoryVisible = db.APPLICATION_CATEGORY.Where(w => w.APPLICATION_CATEGORY1.ToLower().Equals("visible")).Select(s => s.ID_APPLICATION_CATEGORY).FirstOrDefault();

                return db.NEW_APPLICATIONS
                    .Where(w => entityNewApplicationsIds.Contains(w.ID_NEW_APPLICATION) && w.FK_APPLICATION_CATEGORY == applicationCategoryVisible)
                    .OrderBy(o => o.LABEL_NEW_APPLICATION)
                    .Include(i => i.RIGHT_LEVELS)
                    .ToList();
            }
        }

        /// <summary>
        /// Get all visible new applications from data model for which user has access
        /// </summary>
        /// <param name="userId">User Id in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be used, false otherwise</param>
        /// <returns>The list of new applications for which user has access</returns>
        public static List<NEW_APPLICATIONS> GetAllNewApplicationsByUser(long userId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                List<long> userNewApplicationsIds = db.USERS_NEW_APPLICATIONS.Where(w => w.FK_USERS == userId && w.ACCESS).Select(s => s.FK_NEW_APPLICATIONS).ToList();
                long applicationCategoryVisible = db.APPLICATION_CATEGORY.Where(w => w.APPLICATION_CATEGORY1.ToLower().Equals("visible")).Select(s => s.ID_APPLICATION_CATEGORY).FirstOrDefault();

                return db.NEW_APPLICATIONS
                    .Where(w => userNewApplicationsIds.Contains(w.ID_NEW_APPLICATION) && w.FK_APPLICATION_CATEGORY == applicationCategoryVisible)
                    .OrderBy(o => o.LABEL_NEW_APPLICATION)
                    .Include(i => i.RIGHT_LEVELS)
                    .ToList();
            }
        }

        #endregion NEW_APPLICATIONS

        #region NOTIFICATIONS

        /// <summary>
        /// Get all notifications from data model with the linked new applications
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of notifications with the linked new applications</returns>
        public static List<NOTIFICATIONS> GetAllNotificationsWithNewApplications(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.NOTIFICATIONS
                    .Include(m => m.NEW_APPLICATIONS)
                    .ToList();
            }
        }

        /// <summary>
        /// Get all notifications from data model by new application identifier
        /// </summary>
        /// <param name="newApplicationId">The new application identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of notifications</returns>
        public static List<NOTIFICATIONS> GetNotificationsByNewApplicationId(long newApplicationId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.NOTIFICATIONS.Where(n => n.FK_NEW_APPLICATIONS == newApplicationId).ToList();
            }
        }

        /// <summary>
        /// Get notification by id from data model
        /// </summary>
        /// <param name="idNotification">The notification id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The notification matching the provided id</returns>
        public static NOTIFICATIONS GetNotificationById(long idNotification, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.NOTIFICATIONS.Where(x => x.ID_NOTIFICATION == idNotification).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get notification by id and remove it from data model
        /// </summary>
        /// <param name="idNotification">The notification id</param>
        public static void DeleteNotificationById(long idNotification)
        {
            using (DBModel db = new DBModel())
            {
                NOTIFICATIONS notification = db.NOTIFICATIONS.Where(x => x.ID_NOTIFICATION == idNotification).FirstOrDefault();
                db.NOTIFICATIONS.Remove(notification);
                db.SaveChanges();
            }
        }

        #endregion NOTIFICATIONS

        #region RIGHTS

        /// <summary>
        /// Get all rights from data model with their new applications
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of rights with their new applications</returns>
        public static List<RIGHTS> GetAllRightsWithNewApplications(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.RIGHTS.Include(r => r.NEW_APPLICATIONS).ToList();
            }
        }

        /// <summary>
        /// Get all rights matching the provided New Application id
        /// </summary>
        /// <param name="idNewApplication">The new application identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of rights matching the provided New Application id</returns>
        public static List<RIGHTS> GetAllRightsByNewApplicationId(long idNewApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.RIGHTS.Where(r => r.FK_NEW_APPLICATIONS == idNewApplication).ToList();
            }
        }

        /// <summary>
        /// Get right from data model matching the provided Code and New Application id
        /// </summary>
        /// <param name="codeRight">The right code</param>
        /// <param name="idNewApplication">The new application identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of rights matching the provided New Application id</returns>
        public static RIGHTS GetRightByCodeAndNewApplicationId(string codeRight, long idNewApplication, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.RIGHTS.Where(x => x.CODE_RIGHT.ToLower() == codeRight.ToLower() && x.FK_NEW_APPLICATIONS == idNewApplication).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get right by id from data model
        /// </summary>
        /// <param name="idRight">The right id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The right matching the provided id</returns>
        public static RIGHTS GetRightById(long idRight, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.RIGHTS.Where(x => x.ID_RIGHT == idRight).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get right by code from data model
        /// </summary>
        /// <param name="codeRight">The right code</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The right matching the provided code</returns>
        public static RIGHTS GetRightByCode(string codeRight, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.RIGHTS.Where(x => x.CODE_RIGHT.ToLower() == codeRight.ToLower()).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get right by id and remove it from data model
        /// </summary>
        /// <param name="id">The right id</param>
        public static void DeleteRightById(long id)
        {
            using (DBModel db = new DBModel())
            {
                RIGHTS right = db.RIGHTS.Where(x => x.ID_RIGHT == id).FirstOrDefault();
                db.RIGHTS.Remove(right);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Check if the user's entity has the provided right checked
        /// </summary>
        /// <param name="idUser">identifier of the user in the data model</param>
        /// <param name="idRight">identifier of the right in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>True if the right is checked for user's entity, False otherwise</returns>
        public static bool IsRightCheckedForUserEntity(long idUser, long idRight, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                int userEntityId = db.USERS.Where(u => u.ID_USER == idUser).Select(u => u.FK_ENTITY).FirstOrDefault();
                ENTITES_RIGHTS entitesRights = db.ENTITES_RIGHTS.Where(x => x.FK_ENTITY == userEntityId && x.FK_RIGHTS == idRight).FirstOrDefault();
                return entitesRights != null ? true : false;
            }
        }

        /// <summary>
        /// Check if the user's entity has at least one right checked linked to the notification
        /// </summary>
        /// <param name="idUser">identifier of the user in the data model</param>
        /// <param name="idNotification">identifier of the notification in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>True if at least one right is checked for user's entity, False otherwise</returns>
        public static bool IsRightCheckedForUserEntityFromNotification(long idUser, long idNotification, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                // Get the user's entity id
                int userEntityId = db.USERS.Where(u => u.ID_USER == idUser).Select(u => u.FK_ENTITY).FirstOrDefault();

                // Get the new application's rights ids
                long idNewApplication = db.NOTIFICATIONS.Where(n => n.ID_NOTIFICATION == idNotification).Select(n => n.FK_NEW_APPLICATIONS).FirstOrDefault();
                NEW_APPLICATIONS newApplication = db.NEW_APPLICATIONS.Where(na => na.ID_NEW_APPLICATION == idNewApplication).Include(r => r.RIGHTS).FirstOrDefault();
                List<long> listRightIds = newApplication.RIGHTS.Select(r => r.ID_RIGHT).ToList();

                // Get the list of entity rights existing in data-table matching the entity id and the list of rights
                List<ENTITES_RIGHTS> listEntitesRights = db.ENTITES_RIGHTS.Where(x => x.FK_ENTITY == userEntityId && listRightIds.Contains(x.FK_RIGHTS)).ToList();
                return listEntitesRights.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// Get the number of the entity's users that have the right granted
        /// </summary>
        /// <param name="entityId">identifier of the entity in the data model</param>
        /// <param name="rightId">identifier of the right in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The number of entity's users having the right granted</returns>
        public static int GetNumberOfEntityUserForRights(int entityId, long rightId, bool lazyLoadingEnabled = false)
        {
            int numberOfUser = 0;
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                // Get the list of entity's users identifier
                List<long> listUserId = db.USERS.Where(u => u.FK_ENTITY == entityId).Select(u => u.ID_USER).ToList();

                // Get the number of users having the right granted
                numberOfUser = db.USERS_RIGHTS.Where(r => r.FK_RIGHTS == rightId && listUserId.Contains(r.FK_USERS)).Count();
            }

            return numberOfUser;
        }

        /// <summary>
        /// Get the list of entity's users with the provided right granted ordered by last name, first name and middle name
        /// </summary>
        /// <param name="entityId">identifier of the entity in the data model</param>
        /// <param name="rightId">identifier of the right in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The ordered list of entity's users having the right granted</returns>
        public static List<USERS> GetListOfEntityUserForRightsOrdered(int entityId, long rightId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                // Get the list of entity's users identifier
                List<long> listUserId = db.USERS.Where(u => u.FK_ENTITY == entityId).Select(u => u.ID_USER).ToList();

                // Get the list of users having the right granted
                return db.USERS_RIGHTS.Where(r => r.FK_RIGHTS == rightId && listUserId.Contains(r.FK_USERS)).Include(r => r.USERS)
                    .Select(r => r.USERS).OrderBy(r => r.LAST_NAME).ThenBy(r => r.FIRST_NAME).ThenBy(r => r.MIDDLE_NAME).ToList();
            }
        }

        #endregion RIGHTS

        #region RIGHTS_LEVEL

        /// <summary>
        /// Get all right levels from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of right levels</returns>
        public static List<RIGHT_LEVELS> GetAllRightLevels(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.RIGHT_LEVELS.ToList();
            }
        }

        /// <summary>
        /// Get right level by id from data model
        /// </summary>
        /// <param name="id">The right level id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The right level matching the provided id</returns>
        public static RIGHT_LEVELS GetRightLevelById(long id, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.RIGHT_LEVELS.Where(x => x.ID_RIGHT_LEVEL == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get right level by id and remove it from data model
        /// </summary>
        /// <param name="id">The right level id</param>
        public static void DeleteRightLevelById(long id)
        {
            using (DBModel db = new DBModel())
            {
                RIGHT_LEVELS rightLevel = db.RIGHT_LEVELS.Where(x => x.ID_RIGHT_LEVEL == id).FirstOrDefault();
                db.RIGHT_LEVELS.Remove(rightLevel);
                db.SaveChanges();
            }
        }

        #endregion RIGHTS_LEVEL

        #region SUBSCRIBE

        /// <summary>
        /// Add a subscription in database
        /// </summary>
        /// <param name="subscription">subscription to add</param>
        public static void AddSubscribeInDatabase(SUBSCRIBE subscription)
        {
            using (DBModel db = new DBModel())
            {
                db.SUBSCRIBE.Add(subscription);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get the list of Subscribes matching the provided user id
        /// </summary>
        /// <param name="idUser">id of the User in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Subscribes matching the provided user id</returns>
        public static List<SUBSCRIBE> GetSubscribeByUserId(long idUser, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.SUBSCRIBE.Where(s => s.FK_USERS == idUser)
                    .Include(s => s.NOTIFICATIONS)
                    .Include(s => s.FREQUENCIES)
                    .ToList();
            }
        }

        /// <summary>
        /// Get the Subscribe matching the provided ids
        /// </summary>
        /// <param name="idUser">id of the User in the data model</param>
        /// <param name="idNotification">id of the notification in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Subscribe matching the user id and the notification id provided</returns>
        public static SUBSCRIBE GetSubscribeByIds(long idUser, long idNotification, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.SUBSCRIBE.Where(s => s.FK_USERS == idUser && s.FK_NOTIFICATIONS == idNotification).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get SUBSCRIBE by id and remove it from data model
        /// </summary>
        /// <param name="idSubscription">The subscription id</param>
        public static void DeleteSubscribeById(long idSubscription)
        {
            using (DBModel db = new DBModel())
            {
                SUBSCRIBE subscription = db.SUBSCRIBE.Where(x => x.ID_SUBSCRIBE == idSubscription).FirstOrDefault();
                db.SUBSCRIBE.Remove(subscription);
                db.SaveChanges();
            }
        }

        #endregion SUBSCRIBE

        #region SUPPORT_CENTER

        /// <summary>
        /// Get all Support Centers from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Support Centers</returns>
        public static List<SUPPORT_CENTER> GetAllSupportCenters(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.SUPPORT_CENTER.ToList();
            }
        }

        /// <summary>
        /// Get all Support Centers from data model excluding those defined in the configuration file (parameter SupportCenterCodeToRemoveForCatalogs)
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Support Centers</returns>
        public static List<SUPPORT_CENTER> GetSupportCentersWithRules(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                // Get code of supports centers in configuration file.
                string[] codesSupportsCenters = ConfigurationManager.AppSettings["SupportCenterCodeToRemoveForCatalogs"].Split(',');

                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.SUPPORT_CENTER.Where(x => !codesSupportsCenters.Contains(x.CODE)).ToList();
            }
        }

        /// <summary>
        /// Get Support Center by id from data model
        /// </summary>
        /// <param name="idSupportCenter">The Support Center id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Support Center matching the provided id</returns>
        public static SUPPORT_CENTER GetSupportCenterById(long idSupportCenter, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.SUPPORT_CENTER.Where(x => x.ID_SUPPORT_CENTER == idSupportCenter).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Support Center by Centre CRM from data model
        /// </summary>
        /// <param name="code">The Support Center code</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Support Center matching the provided Code</returns>
        public static SUPPORT_CENTER GetSupportCenterByCode(string code, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.SUPPORT_CENTER.Where(x => x.CODE == code).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Support Center by id and remove it from data model
        /// </summary>
        /// <param name="idSupportCenter">The Support Center id</param>
        public static void DeleteSupportCenterById(long idSupportCenter)
        {
            using (DBModel db = new DBModel())
            {
                SUPPORT_CENTER supportCenter = db.SUPPORT_CENTER.Where(x => x.ID_SUPPORT_CENTER == idSupportCenter).FirstOrDefault();
                db.SUPPORT_CENTER.Remove(supportCenter);
                db.SaveChanges();
            }
        }

        #endregion SUPPORT_CENTER

        #region TRAINING_CENTER

        /// <summary>
        /// Get all Training Centers from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Training Centers</returns>
        public static List<TRAINING_CENTER> GetAllTrainingCenters(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.TRAINING_CENTER.ToList();
            }
        }

        /// <summary>
        /// Get Training Center by id from data model
        /// </summary>
        /// <param name="idTrainingCenter">The Training Center id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The Training Center matching the provided id</returns>
        public static TRAINING_CENTER GetTrainingCenterById(long idTrainingCenter, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.TRAINING_CENTER.Where(x => x.ID_TRAINING_CENTER == idTrainingCenter).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get Training Center by id and remove it from data model
        /// </summary>
        /// <param name="idTrainingCenter">The Training Center id</param>
        public static void DeleteTrainingCenterById(long idTrainingCenter)
        {
            using (DBModel db = new DBModel())
            {
                TRAINING_CENTER trainingCenter = db.TRAINING_CENTER.Where(x => x.ID_TRAINING_CENTER == idTrainingCenter).FirstOrDefault();
                db.TRAINING_CENTER.Remove(trainingCenter);
                db.SaveChanges();
            }
        }

        #endregion TRAINING_CENTER

        #region USERS

        /// <summary>
        /// Add an user in database
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>The added user id</returns>
        public static long AddUserInDb(USERS user)
        {
            using (DBModel db = new DBModel())
            {
                db.USERS.Add(user);
                db.SaveChanges();
                return user.ID_USER;
            }
        }

        /// <summary>
        /// Update an user in database
        /// </summary>
        /// <param name="user">user</param>
        public static void UpdateUserInDb(USERS user)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update a user from Mys application in database
        /// </summary>
        /// <param name="user">user</param>
        public static void UpdateMyUserInDb(USERS user)
        {
            using (DBModel db = new DBModel())
            {
                string sqlQuery = @"UPDATE USERS SET PREFIX = @userPrefix, FIRST_NAME = @userFirstName, MIDDLE_NAME = @userMiddleName, LAST_NAME = @userLastName, " +
                        "EMAIL_ADDRESS = @userEmailAddress, PHONE_NUMBER = @userPhone, IS_ADMINISTRATOR = @userAdministrator, JOB_TITLE = @userJobTitle, " +
                        "SUBSCRIPTION_STATUS = @userSubscriptionStatus, FK_COUNTRY = @userFkCountry, FK_JOB_PROFIL = @userFkJobProfil, " +
                        "MY_REQUESTS_FOLLOWUP_ACCESS = @userRequestFollowupAccess, MY_WARRANTY_STATUS_ACCESS = @userWarrantyStatusAccess, " +
                        "INTERACTION_WITH_ATR = @userInteractionWithATR, REQUEST_CREATED = @userRequestCreated, REQUEST_ANSWERED = @userRequestAnwsered, " +
                        "WARRANTY_CREATED = @userWarrantyCreated, WARRANTY_ANSWERED = @userWarrantyAnwsered, FREQUENCY = @userFrequency " +
                        "WHERE ID_USER = @idUser";

                db.Database.ExecuteSqlCommand(
                    sqlQuery,
                    new SqlParameter("@idUser", user.ID_USER),
                    new SqlParameter("@userPrefix", user.PREFIX != null ? (object)user.PREFIX : DBNull.Value),
                    new SqlParameter("@userFirstName", user.FIRST_NAME),
                    new SqlParameter("@userMiddleName", user.MIDDLE_NAME != null ? (object)user.MIDDLE_NAME : DBNull.Value),
                    new SqlParameter("@userLastName", user.LAST_NAME),
                    new SqlParameter("@userEmailAddress", user.EMAIL_ADDRESS),
                    new SqlParameter("@userPhone", user.PHONE_NUMBER != null ? (object)user.PHONE_NUMBER : DBNull.Value),
                    new SqlParameter("@userAdministrator", user.IS_ADMINISTRATOR),
                    new SqlParameter("@userJobTitle", user.JOB_TITLE),
                    new SqlParameter("@userSubscriptionStatus", user.SUBSCRIPTION_STATUS),
                    new SqlParameter("@userFkCountry", user.FK_COUNTRY != null ? (object)user.FK_COUNTRY : DBNull.Value),
                    new SqlParameter("@userFkJobProfil", user.FK_JOB_PROFIL != null ? (object)user.FK_JOB_PROFIL : DBNull.Value),
                    new SqlParameter("@userRequestFollowupAccess", user.MY_REQUESTS_FOLLOWUP_ACCESS != null ? (object)user.MY_REQUESTS_FOLLOWUP_ACCESS : DBNull.Value),
                    new SqlParameter("@userWarrantyStatusAccess", user.MY_WARRANTY_STATUS_ACCESS != null ? (object)user.MY_WARRANTY_STATUS_ACCESS : DBNull.Value),
                    new SqlParameter("@userInteractionWithATR", user.INTERACTION_WITH_ATR != null ? (object)user.INTERACTION_WITH_ATR : DBNull.Value),
                    new SqlParameter("@userRequestCreated", user.REQUEST_CREATED != null ? (object)user.REQUEST_CREATED : DBNull.Value),
                    new SqlParameter("@userRequestAnwsered", user.REQUEST_ANSWERED != null ? (object)user.REQUEST_ANSWERED : DBNull.Value),
                    new SqlParameter("@userWarrantyCreated", user.WARRANTY_CREATED != null ? (object)user.WARRANTY_CREATED : DBNull.Value),
                    new SqlParameter("@userWarrantyAnwsered", user.WARRANTY_ANSWERED != null ? (object)user.WARRANTY_ANSWERED : DBNull.Value),
                    new SqlParameter("@userFrequency", user.FREQUENCY != null ? (object)user.FREQUENCY : DBNull.Value));
            }
        }

        /// <summary>
        /// Get User by id and remove it from data model
        /// </summary>
        /// <param name="idUser">The user id</param>
        public static void DeleteUserById(long idUser)
        {
            using (DBModel db = new DBModel())
            {
                USERS user = db.USERS.Where(x => x.ID_USER == idUser).FirstOrDefault();
                db.USERS.Remove(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get the User matching the provided login
        /// </summary>
        /// <param name="login">login of the User in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The User matching the provided login</returns>
        public static USERS GetUserByLogin(string login, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(x => x.USER_LOGIN.Equals(login)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get the User matching the provided login with the linked entity
        /// </summary>
        /// <param name="login">login of the User in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The User matching the provided login with the linked entity</returns>
        public static USERS GetUserByLoginNameWithEntity(string login, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(x => x.USER_LOGIN.Equals(login)).Include(u => u.ENTITY).Include(b => b.ENTITY.BUSINESS_TYPE).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get all users from data model
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of all users</returns>
        public static List<USERS> GetAllUsers(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.ToList();
            }
        }

        /// <summary>
        /// Get all users from data model with Entity
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of users with their entity</returns>
        public static List<USERS> GetAllUsersWithEntity(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Include(u => u.ENTITY).ToList();
            }
        }

        /// <summary>
        /// Get the User matching the id provided
        /// </summary>
        /// <param name="idUser">id of the User in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The User matching the id provided</returns>
        public static USERS GetUserById(long idUser, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(x => x.ID_USER == idUser).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get User (with linked table that will be used for user details) matching the user id provided
        /// </summary>
        /// <param name="idUser">id of the User in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The User (with linked table that will be used for user details) matching the user id provided</returns>
        public static USERS GetUserDetailById(long idUser, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(x => x.ID_USER == idUser)
                    .Include(e => e.COUNTRY)
                    .Include(e => e.JOB_PROFIL)
                    .Include(e => e.ENTITY)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Get the list of the entity's administrators matching the entity id provided
        /// </summary>
        /// <param name="idEntity">The Entity Id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of the entity's administrators matching the entity id provided</returns>
        public static List<USERS> GetEntityAdministrators(long idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(x => x.FK_ENTITY == idEntity && x.IS_ADMINISTRATOR).ToList();
            }
        }

        /// <summary>
        /// Get the list of the entity's administrators matching the entity id provided ordered by last name, first name and middle name
        /// </summary>
        /// <param name="idEntity">The entity identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The ordered list of the entity's administrators matching the entity id provided</returns>
        public static List<USERS> GetEntityAdministratorsOrdered(long idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(x => x.FK_ENTITY == idEntity && x.IS_ADMINISTRATOR)
                    .OrderBy(r => r.LAST_NAME).ThenBy(r => r.FIRST_NAME).ThenBy(r => r.MIDDLE_NAME).ToList();
            }
        }

        /// <summary>
        /// Get the list of entity's users matching the entity id provided
        /// </summary>
        /// <param name="idEntity">The Entity Id</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of entity's users matching the entity id provided</returns>
        public static List<USERS> GetAllEntityUsers(long idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(x => x.FK_ENTITY == idEntity).ToList();
            }
        }

        /// <summary>
        /// Get the list of internal's users
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Internal's users</returns>
        public static List<USERS> GetAllInternalUsers(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(u => u.INTERNAL_USER.HasValue && u.INTERNAL_USER.Value == true).ToList();
            }
        }

        /// <summary>
        /// Get the list of external's users
        /// </summary>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of external's users</returns>
        public static List<USERS> GetAllExternalUsers(bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS.Where(u => u.INTERNAL_USER.HasValue && u.INTERNAL_USER.Value == false).ToList();
            }
        }

        /// <summary>
        /// Get the list of valid users for which the entity has access to the new application
        /// A valid user is a user with Status ="Validated" and with an entity with status = "Validated" and checked TCU and CGV
        /// </summary>
        /// <param name="newApplicationId">The new application identifier</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of valid users</returns>
        public static List<USERS> GetAllValidUsersForWhichEntityHasAccessToNewApplication(long newApplicationId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                // Return a list of user for which the entity is linked to the new application having access or not
                List<USERS> listValidUsersWithRadarApplication = db.USERS.Where(u => u.SUBSCRIPTION_STATUS == "Validated")
                    .Include(r => r.USERS_RIGHTS.Select(ur => ur.RIGHTS))
                    .Include(c => c.COUNTRY)
                    .Include(e => e.ENTITY).Where(e => e.ENTITY.SUBSCRIPTION_STATUS == "Validated"
                                                  && e.ENTITY.E_SPARE_CGV != null
                                                  && e.ENTITY.E_SPARE_CGV.Value
                                                  && e.ENTITY.PORTAL_TC
                                                  && e.ENTITY.SUBSCRIPTION_DATE != null)
                    .Include(e => e.ENTITY.BUSINESS_TYPE)
                    .Include(e => e.ENTITY.COUNTRY)
                    .Include(e => e.ENTITY.SUPPORT_CENTER)
                    .Include(e => e.ENTITY.TRAINING_CENTER)
                    .Include(e => e.ENTITY.ENTITES_RIGHTS.Select(r => r.RIGHTS))
                    .Include(e => e.ENTITY.ENTITY_APPLICATION.Select(ent => ent.APPLICATION))
                    .Include(e => e.ENTITY.ENTITY_APPLICATION_ACCESS.Select(ent => ent.APPLICATION))
                    .Include(e => e.ENTITY.ENTITES_WAREHOUSE.Select(ent => ent.WAREHOUSES))
                    .Include(e => e.ENTITY.ENTITES_NEW_APPLICATIONS).Where(ent => ent.ENTITY.ENTITES_NEW_APPLICATIONS.Select(i => i.FK_NEW_APPLICATIONS).Contains(newApplicationId)).ToList();

                List<USERS> listValidUsersWithRadarApplicationAccess = new List<USERS>();

                // Filtered on users for which the entity has really access to the new application
                foreach (USERS item in listValidUsersWithRadarApplication)
                {
                    if (item.ENTITY.ENTITES_NEW_APPLICATIONS.Where(r => r.ACCESS == true && r.FK_NEW_APPLICATIONS == newApplicationId).Count() > 0)
                    {
                        listValidUsersWithRadarApplicationAccess.Add(item);
                    }
                }

                return listValidUsersWithRadarApplicationAccess;
            }
        }

        /// <summary>
        /// Execute a stored procedure to retrieve users
        /// </summary>
        /// <param name="idEntity">The entity id, if not provided all users are returned</param>
        /// <returns>A list of strings containing users data</returns>
        public static IList<string> ExtractUsers(int idEntity = 0)
        {
            IList<string> result = null;

            using (DBModel db = new DBModel())
            using (SqlCommand query = new SqlCommand())
            using (DataTable table = new DataTable())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                // Define command properties (stored procedure to call, connection...)
                query.CommandText = "usp_extract_users";
                query.Connection = (SqlConnection)db.Database.Connection;
                query.CommandType = CommandType.StoredProcedure;
                if (idEntity != 0)
                {
                    query.Parameters.Add(SqlParameterHelper.CreateIntegerParameter("entity_id", idEntity));
                }

                // Set command as select command of adapter.
                adapter.SelectCommand = query;

                // Update locale table property.
                table.Locale = CultureInfo.InvariantCulture;

                // Execute adapter select command i.e. execute command defined.
                adapter.Fill(table);

                // Convert table to list of string using extension method defined.
                result = table.ToStringListExtract();
            }

            return result;
        }

        /// <summary>
        /// Execute a stored procedure to retrieve the users list and their data
        /// </summary>
        /// <param name="idEntity">The entity identifier</param>
        /// <returns>A list of strings containing users data</returns>
        public static IList<string> ExtractMyUsersListUsers(int idEntity)
        {
            IList<string> result = null;

            using (DBModel db = new DBModel())
            using (SqlCommand query = new SqlCommand())
            using (DataTable table = new DataTable())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                // Define command properties (stored procedure to call, connection...)
                query.CommandText = "usp_extract_myusers_list_users";
                query.Connection = (SqlConnection)db.Database.Connection;
                query.CommandType = CommandType.StoredProcedure;
                if (idEntity != 0)
                {
                    query.Parameters.Add(SqlParameterHelper.CreateIntegerParameter("entity_id", idEntity));
                }

                // Set command as select command of adapter.
                adapter.SelectCommand = query;

                // Update locale table property.
                table.Locale = CultureInfo.InvariantCulture;

                // Execute adapter select command i.e. execute command defined.
                adapter.Fill(table);

                // Convert table to list of string using extension method defined.
                result = table.ToStringListExtract();
            }

            return result;
        }

        #endregion USERS

        #region USERS_NEW_APPLICATIONS

        /// <summary>
        /// Add an user new application in database
        /// </summary>
        /// <param name="userNewApplication">user new application to add</param>
        /// <returns>Created user new application identifier</returns>
        public static long AddUsersNewApplicationsInDb(USERS_NEW_APPLICATIONS userNewApplication)
        {
            USERS_NEW_APPLICATIONS addedUsersNewApplication = null;
            using (DBModel db = new DBModel())
            {
                addedUsersNewApplication = db.USERS_NEW_APPLICATIONS.Add(userNewApplication);
                db.SaveChanges();
            }

            return addedUsersNewApplication != null ? addedUsersNewApplication.ID_USER_NEW_APPLICATION : 0;
        }

        /// <summary>
        /// Update an user new application in database
        /// </summary>
        /// <param name="userNewApplication">user application to update</param>
        public static void UpdateUsersNewApplicationsInDb(USERS_NEW_APPLICATIONS userNewApplication)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(userNewApplication).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Check if at least one of the entity's user have access to the new application
        /// </summary>
        /// <param name="idEntity">id of the entity in the data model</param>
        /// <param name="idNewApplication">id of the new application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>True if at least one entity's user have access to the new application, false otherwise</returns>
        public static bool HasEntityUserAccessOnNewApplication(int idEntity, long idNewApplication, bool lazyLoadingEnabled = false)
        {
            bool result = false;
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<long> listUserId = db.USERS.Where(u => u.FK_ENTITY == idEntity).Select(u => u.ID_USER).ToList();
                USERS_NEW_APPLICATIONS userNewApplication = db.USERS_NEW_APPLICATIONS.Where(x => listUserId.Contains(x.FK_USERS) && x.FK_NEW_APPLICATIONS == idNewApplication && x.ACCESS).FirstOrDefault();

                if (userNewApplication != null)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Get the user New Application from data model
        /// </summary>
        /// <param name="idUsersNewApplications">id of the user's new application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The user New Application matching the user id and the new application id provided</returns>
        public static USERS_NEW_APPLICATIONS GetUsersNewApplicationsByIdWithNewApplications(long idUsersNewApplications, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS_NEW_APPLICATIONS.Where(x => x.ID_USER_NEW_APPLICATION == idUsersNewApplications)
                      .Include(e => e.NEW_APPLICATIONS)
                      .Include(e => e.NEW_APPLICATIONS.RIGHTS)
                      .Include(e => e.NEW_APPLICATIONS.NOTIFICATIONS)
                      .Include(e => e.NEW_APPLICATIONS.FREQUENCIES)
                      .FirstOrDefault();
            }
        }

        /// <summary>
        /// Get the user New Application from data model
        /// </summary>
        /// <param name="userId">id of the user in the data model</param>
        /// <param name="newApplicationId">id of the new application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The user New Application matching the user id and the new application id provided</returns>
        public static USERS_NEW_APPLICATIONS GetUsersNewApplicationByUserAndNewApplicationIds(long userId, long newApplicationId, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS_NEW_APPLICATIONS.Where(x => x.FK_USERS == userId && x.FK_NEW_APPLICATIONS == newApplicationId).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get the list of User New Application matching the user id provided
        /// </summary>
        /// <param name="idUser">id of the user in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of User New Application matching the user id provided</returns>
        public static List<USERS_NEW_APPLICATIONS> GetUsersNewApplicationsByUserIdWithNewApplications(long idUser, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS_NEW_APPLICATIONS.Where(x => x.FK_USERS == idUser)
                      .Include(e => e.NEW_APPLICATIONS)
                      .Include(e => e.NEW_APPLICATIONS.RIGHTS)
                      .Include(e => e.NEW_APPLICATIONS.NOTIFICATIONS)
                      .Include(e => e.NEW_APPLICATIONS.FREQUENCIES)
                      .ToList();
            }
        }

        /// <summary>
        /// Get the list of User New Application matching the user id provided
        /// </summary>
        /// <param name="idUser">id of the user in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of User New Application matching the user id provided</returns>
        public static List<USERS_NEW_APPLICATIONS> GetUsersNewApplicationsByUserId(long idUser, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS_NEW_APPLICATIONS.Where(x => x.FK_USERS == idUser).ToList();
            }
        }

        /// <summary>
        /// Get USERS_NEW_APPLICATIONS by id and remove it from data model
        /// Remove also linked RIGHTS ans NOTIFICATIONS
        /// </summary>
        /// <param name="idUsersNewApplications">id of the user's new application in the data model</param>
        public static void DeleteUsersNewApplicationsById(long idUsersNewApplications)
        {
            using (DBModel db = new DBModel())
            {
                // Get users new applications
                USERS_NEW_APPLICATIONS userNewApplication = db.USERS_NEW_APPLICATIONS.Where(x => x.ID_USER_NEW_APPLICATION == idUsersNewApplications).FirstOrDefault();

                // Remove linked rights
                foreach (RIGHTS right in userNewApplication.NEW_APPLICATIONS.RIGHTS)
                {
                    if (GetUsersRightsByIds(userNewApplication.FK_USERS, right.ID_RIGHT) != null)
                    {
                        DeleteUsersRightsByIds(userNewApplication.FK_USERS, right.ID_RIGHT);
                    }
                }

                // Remove linked notifications
                foreach (NOTIFICATIONS notification in userNewApplication.NEW_APPLICATIONS.NOTIFICATIONS)
                {
                    SUBSCRIBE subscription = GetSubscribeByIds(userNewApplication.FK_USERS, notification.ID_NOTIFICATION);
                    if (subscription != null)
                    {
                        DeleteSubscribeById(subscription.ID_SUBSCRIBE);
                    }
                }

                // Remove users new applications
                db.USERS_NEW_APPLICATIONS.Remove(userNewApplication);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get USERS_NEW_APPLICATIONS by ids and remove it from data model
        /// </summary>
        /// <param name="idUser">The user id</param>
        /// <param name="idNewApplication">The right id</param>
        public static void DeleteUsersNewApplicationByIds(long idUser, long idNewApplication)
        {
            using (DBModel db = new DBModel())
            {
                USERS_NEW_APPLICATIONS userNewApplication = db.USERS_NEW_APPLICATIONS.Where(x => x.FK_USERS == idUser && x.FK_NEW_APPLICATIONS == idNewApplication).FirstOrDefault();
                db.USERS_NEW_APPLICATIONS.Remove(userNewApplication);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Check if the new application exist in USERS_NEW_APPLICATIONS for the user
        /// </summary>
        /// <param name="idUser">identifier of the user in the data model</param>
        /// <param name="idNewApplication">identifier of the new application in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>True if the USERS_NEW_APPLICATIONS exists, false otherwise</returns>
        public static bool DoesNewApplicationExistForUser(long idUser, long idNewApplication, bool lazyLoadingEnabled = false)
        {
            bool result = false;

            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                USERS_NEW_APPLICATIONS userNewApplication = db.USERS_NEW_APPLICATIONS.Where(x => x.FK_USERS == idUser && x.FK_NEW_APPLICATIONS == idNewApplication)
                    .FirstOrDefault();

                if (userNewApplication != null)
                {
                    result = true;
                }
            }

            return result;
        }

        #endregion USERS_NEW_APPLICATIONS

        #region USERS_RIGHTS

        /// <summary>
        /// Add an user right in database
        /// </summary>
        /// <param name="userRight">USERS_RIGHTS to add</param>
        public static void AddUsersRightsInDatabase(USERS_RIGHTS userRight)
        {
            using (DBModel db = new DBModel())
            {
                db.USERS_RIGHTS.Add(userRight);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get User Right from data model
        /// </summary>
        /// <param name="idUser">id of the User in the data model</param>
        /// <param name="idRight">id of the right in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The User right matching the user id and the right id provided</returns>
        public static USERS_RIGHTS GetUsersRightsByIds(long idUser, long idRight, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return db.USERS_RIGHTS.Where(x => x.FK_USERS == idUser && x.FK_RIGHTS == idRight).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get USERS_RIGHTS by ids and remove it from data model
        /// </summary>
        /// <param name="idUser">The user id</param>
        /// <param name="idRight">The right id</param>
        public static void DeleteUsersRightsByIds(long idUser, long idRight)
        {
            using (DBModel db = new DBModel())
            {
                USERS_RIGHTS userRight = db.USERS_RIGHTS.Where(x => x.FK_USERS == idUser && x.FK_RIGHTS == idRight).FirstOrDefault();
                db.USERS_RIGHTS.Remove(userRight);
                db.SaveChanges();
            }
        }

        #endregion USERS_RIGHTS

        #region WHAREHOUSES

        /// <summary>
        /// Get all warehouses from data model
        /// </summary>
        /// <returns>The list of warehouses</returns>
        public static List<WAREHOUSES> GetAllWarehouses()
        {
            using (DBModel db = new DBModel())
            {
                return db.WAREHOUSES.ToList();
            }
        }

        /// <summary>
        /// Get all Warehouses from data model that are not included in ENTITES_WAREHOUSES
        /// </summary>
        /// <param name="idEntity">id of the Entity in the data model</param>
        /// <param name="lazyLoadingEnabled">True if lazyLoading can be use, false otherwise</param>
        /// <returns>The list of Warehouses that are not included in ENTITES_WAREHOUSES</returns>
        public static List<WAREHOUSES> GetAllWarehousesNotIncludedInEntityWarehouses(int idEntity, bool lazyLoadingEnabled = false)
        {
            using (DBModel db = new DBModel())
            {
                // Get all Warehouses that are not included in ENTITES_WAREHOUSES but included in ENTITES_WAREHOUSES Default
                db.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                List<long> warehouseIds = db.ENTITES_WAREHOUSE.Where(c => c.FK_ENTITY == idEntity && (c.TYPE_WAREHOUSE != WarehouseType.DefaultWarehouseNew.ToString()
                        && c.TYPE_WAREHOUSE != WarehouseType.DefaultWarehouseSecondHand.ToString()
                        && c.TYPE_WAREHOUSE != WarehouseType.DefaultWarehouseOverhauled.ToString())).Select(c => c.FK_WAREHOUSE).ToList();
                return db.WAREHOUSES.Where(c => !warehouseIds.Contains(c.ID_WAREHOUSES)).ToList();
            }
        }

        /// <summary>
        /// Get warehouses by id from data model
        /// </summary>
        /// <param name="idWarehouse">The warehouse id</param>
        /// <returns>The warehouses matching the provided id</returns>
        public static WAREHOUSES GetWarehouseById(long idWarehouse)
        {
            using (DBModel db = new DBModel())
            {
                return db.WAREHOUSES.Where(x => x.ID_WAREHOUSES == idWarehouse).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get warehouses by id and remove it from data model
        /// </summary>
        /// <param name="idWarehouse">The warehouse id</param>
        public static void DeleteWarehouseById(long idWarehouse)
        {
            using (DBModel db = new DBModel())
            {
                WAREHOUSES warehouse = db.WAREHOUSES.Where(x => x.ID_WAREHOUSES == idWarehouse).FirstOrDefault();
                db.WAREHOUSES.Remove(warehouse);
                db.SaveChanges();
            }
        }

        #endregion WHAREHOUSES

        #region Private function

        /// <summary>
        /// Add a parameter value to a SqlCommand.
        /// </summary>
        /// <param name="request">Request that receives the values.</param>
        /// <param name="nameParameter">Name of parameter.</param>
        /// <param name="value">Value added in <paramref name="request"/> by <paramref name="nameParameter"/>.</param> (can be null)
        /// <returns>Return the request with the value of the parameter.</returns>
        private static SqlCommand AddParameterValueToRequest(SqlCommand request, string nameParameter, object value)
        {
            if (value != null)
            {
                request.Parameters.AddWithValue(nameParameter, value.ToString());
            }
            else
            {
                request.Parameters.AddWithValue(nameParameter, DBNull.Value);
            }

            return request;
        }

        #endregion Private function
    }
}