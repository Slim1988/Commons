namespace ATR.Common.Models
{
    using System.Configuration;
    using Enumerations;

    /// <summary>
    /// User Model in session
    /// </summary>
    public class UserSessionModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserSessionModel"/> class.
        /// Constructor used for unknown users
        /// </summary>
        public UserSessionModel()
        {
            this.HasApplicationsAccess = AccessCode.UserNotFound;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSessionModel" /> class.
        /// </summary>
        /// <param name="databaseUser">the user object in database.</param>
        public UserSessionModel(USERS databaseUser)
        {
            this.IdUser = databaseUser.ID_USER;
            this.IsAdministrator = databaseUser.IS_ADMINISTRATOR;
            this.FirstName = databaseUser.FIRST_NAME;
            this.LastName = databaseUser.LAST_NAME;
            this.UserLogin = databaseUser.USER_LOGIN;
            this.EntityId = databaseUser.FK_ENTITY;
            this.IsEntityPublic = databaseUser.ENTITY.PUBLIC_ENTITY != null ? databaseUser.ENTITY.PUBLIC_ENTITY.Value : false;
            this.IsValidatedStatus = databaseUser.SUBSCRIPTION_STATUS.ToLower().Equals("validated") ? true : false;
            this.IsEntityValidatedStatus = databaseUser.ENTITY.SUBSCRIPTION_STATUS.ToLower().Equals("validated") ? true : false;
            this.EntityName = databaseUser.ENTITY.COMPANY_NAME;
            this.BusinessTypeName = databaseUser.ENTITY.BUSINESS_TYPE.BUSINESS_TYPE1;
            this.BusinessTypeCode = databaseUser.ENTITY.BUSINESS_TYPE.CODE_BUSINESS_TYPE;
            this.EmailAddress = databaseUser.EMAIL_ADDRESS;
            this.InternalLogin = databaseUser.INTERNAL_LOGIN;
            this.JobTitle = databaseUser.JOB_TITLE;
            this.PhoneNumber = databaseUser.PHONE_NUMBER;

            // The TCU & CGV are considered checked if the Portal_TC value is set to True, The E_SPARES_CGV is set to True
            // and both SUBSCRIPTION_DATE and E_SPARES_CGV_DATE are not null
            this.IsEntityTcuCgvChecked = databaseUser.ENTITY.PORTAL_TC && databaseUser.ENTITY.E_SPARE_CGV != null && databaseUser.ENTITY.E_SPARE_CGV.Value
            && databaseUser.ENTITY.E_SPARE_CGV_DATE != null && databaseUser.ENTITY.SUBSCRIPTION_DATE != null;

            // Initialize right management to false
            this.HasCatalogsACSAccess = false;
            this.HasCatalogsGSEAccess = false;
            this.HasCmmvAirlineAccess = false;
            this.HasCmmvOEMAccess = false;
            this.HasMyAcknowledgmentsAccess = false;
            this.HasMyAppsAccess = false;
            this.HasMyContactsAccess = false;
            this.HasMyProfileAccess = false;
            this.HasMyUsersAccess = false;
            this.HasMyCompanyAccess = false;
            this.HasOrderFollowUpAccess = false;
            this.HasSMaRTAccess = false;
            this.HasStripReportsAccess = false;
            this.EntityHasAccessSRMT = false;
            this.EntityHasRequestRight = false;
            this.EntityHasWarrantyRight = false;
            this.HasAccessSRMT = false;
            this.HasRequestRight = false;
            this.HasWarrantyRight = false;

            // Get My Requests Status and My Warranty Status rights
            this.HasMyRequestsStatusAccess = databaseUser.MY_REQUESTS_FOLLOWUP_ACCESS.HasValue ? databaseUser.MY_REQUESTS_FOLLOWUP_ACCESS.Value : false;
            this.HasMyWarrantyStatusAccess = databaseUser.MY_WARRANTY_STATUS_ACCESS.HasValue ? databaseUser.MY_WARRANTY_STATUS_ACCESS.Value : false;
        }

        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public long IdUser { get; set; }

        /// <summary>
        /// Gets or sets the user first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user login
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Gets or sets the user's entity identifier
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user is Administrator or not
        /// </summary>
        public bool IsAdministrator { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's entity is public or not
        /// </summary>
        public bool IsEntityPublic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user's entity name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user's BusinessType Name
        /// </summary>
        public string BusinessTypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user's BusinessType Code
        /// </summary>
        public string BusinessTypeCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user's email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user's internal login
        /// </summary>
        public string InternalLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user's Job title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the user's Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's entity has TCU and CGV checked or not
        /// </summary>
        public bool IsEntityTcuCgvChecked { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has a "Validated" status
        /// </summary>
        public bool IsValidatedStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's entity has a "Validated" status
        /// </summary>
        public bool IsEntityValidatedStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can access to My Profile or not
        /// </summary>
        public bool HasMyProfileAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can access to My Users or not
        /// </summary>
        public bool HasMyUsersAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can access to My Company or not
        /// </summary>
        public bool HasMyCompanyAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to my acknowledgment page or not
        /// </summary>
        public bool HasMyAcknowledgmentsAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to CMMVOEM page or not
        /// </summary>
        public bool HasCmmvOEMAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to CMMVAirlin page or not
        /// </summary>
        public bool HasCmmvAirlineAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to Order Follow Up page or not
        /// </summary>
        public bool HasOrderFollowUpAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to Catalogs ACS page or not
        /// </summary>
        public bool HasCatalogsACSAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to Catalogs GSE page or not
        /// </summary>
        public bool HasCatalogsGSEAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to Strip Reports page or not
        /// </summary>
        public bool HasStripReportsAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to SMaRT page or not
        /// </summary>
        public bool HasSMaRTAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to My Apps pages or not
        /// </summary>
        public bool HasMyAppsAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to My Contacts pages or not
        /// </summary>
        public bool HasMyContactsAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to My Requests Status page or not
        /// </summary>
        public bool HasMyRequestsStatusAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to My Warranty Status page or not
        /// </summary>
        public bool HasMyWarrantyStatusAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to the boapps applications or not
        /// </summary>
        public AccessCode HasApplicationsAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's entity can access to SRMT
        /// </summary>
        public bool EntityHasAccessSRMT { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's entity can access to Request
        /// </summary>
        public bool EntityHasRequestRight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's entity can access to Warranty
        /// </summary>
        public bool EntityHasWarrantyRight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to SRMT
        /// </summary>
        public bool HasAccessSRMT { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to Request
        /// </summary>
        public bool HasRequestRight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's can access to Warranty
        /// </summary>
        public bool HasWarrantyRight { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user is an ATR user or not
        /// </summary>
        /// <returns>True if user have a Business Type ATR</returns>
        public bool IsATR()
        {
            bool isATR = false;
            if (!string.IsNullOrEmpty(this.BusinessTypeCode))
            {
                if (this.BusinessTypeCode.Equals(ConfigurationManager.AppSettings["BusinessTypeCodeATR"]) || !this.IsEntityPublic)
                {
                    isATR = true;
                }
            }

            return isATR;
        }
    }
}