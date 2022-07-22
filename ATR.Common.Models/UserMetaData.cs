namespace ATR.Common.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using ATR.Common.Enumerations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend USERS to add data annotations
    /// </summary>
    [MetadataType(typeof(UserMetaData))]
    partial class USERS
    {
        /// <summary>
        /// Gets or sets a value indicating whether internal user
        /// </summary>
        public bool INTERNAL_USER_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is administrator ATR CRM
        /// </summary>
        public bool IS_ADMIN_ATR_CRM_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Interaction With ATR
        /// </summary>
        public bool INTERACTION_WITH_ATR_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether My request follow up access
        /// </summary>
        public bool MY_REQUESTS_FOLLOWUP_ACCESS_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether My warranty status access
        /// </summary>
        public bool MY_WARRANTY_STATUS_ACCESS_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Request created
        /// </summary>
        public bool REQUEST_CREATED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Warranty created
        /// </summary>
        public bool WARRANTY_CREATED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Request answered
        /// </summary>
        public bool REQUEST_ANSWERED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Warranty answered
        /// </summary>
        public bool WARRANTY_ANSWERED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets frequency
        /// </summary>
        public string FREQUENCY_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets User's account status
        /// </summary>
        public UserAccountStatus USER_ACCOUNT_STATUS { get; set; }
    }

    /// <summary>
    /// Data annotations for USERS SQL DataTable
    /// </summary>
    public class UserMetaData
    {
        /// <summary>
        /// Gets or sets USER_ID
        /// </summary>
        [DisplayName("Id")]
        public string ID_USER { get; set; }

        /// <summary>
        /// Gets or sets prefix
        /// </summary>
        [DisplayName("Prefix")]
        [StringLength(5, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string PREFIX { get; set; }

        /// <summary>
        /// Gets or sets first name
        /// </summary>
        [DisplayName("First Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression(@"^(.*\S.*)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string FIRST_NAME { get; set; }

        /// <summary>
        /// Gets or sets middle name
        /// </summary>
        [DisplayName("Middle Name")]
        [StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string MIDDLE_NAME { get; set; }

        /// <summary>
        /// Gets or sets last name
        /// </summary>
        [DisplayName("Last Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LAST_NAME { get; set; }

        /// <summary>
        /// Gets or sets phone number
        /// </summary>
        [DisplayName("Phone Number")]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        [StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string PHONE_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets fax number
        /// </summary>
        [DisplayName("Fax Number")]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        [StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string FAX_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets email address
        /// </summary>
        [DisplayName("Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string EMAIL_ADDRESS { get; set; }

        /// <summary>
        /// Gets or sets subscription status
        /// </summary>
        [DisplayName("Subscription Status")]
        [StringLength(21, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string SUBSCRIPTION_STATUS { get; set; }

        /// <summary>
        /// Gets or sets user login
        /// </summary>
        [DisplayName("Login")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(21, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string USER_LOGIN { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether e_spares access
        /// </summary>
        [DisplayName("E-Spare Access")]
        public bool E_SPARES_ACCESS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether internal user
        /// </summary>
        [DisplayName("Internal User")]
        public bool? INTERNAL_USER { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is administrator
        /// </summary>
        [DisplayName("Administrator")]
        public bool IS_ADMINISTRATOR { get; set; }

        /// <summary>
        /// Gets or sets last connection date
        /// </summary>
        [DisplayName("Last Connection Date")]
        public DateTime? LAST_CONNEXION_DATE { get; set; }

        /// <summary>
        /// Gets or sets entity foreign key
        /// </summary>
        [DisplayName("Entity")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public int FK_ENTITY { get; set; }

        /// <summary>
        /// Gets or sets job profile
        /// </summary>
        [DisplayName("Job Profil")]
        public long? FK_JOB_PROFIL { get; set; }

        /// <summary>
        /// Gets or sets country
        /// </summary>
        [DisplayName("Country")]
        public int? FK_COUNTRY { get; set; }

        /// <summary>
        /// Gets or sets job title
        /// </summary>
        [DisplayName("Job Title")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression(@"^(.*\S.*)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string JOB_TITLE { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether talk initiators em
        /// </summary>
        [DisplayName("Talk Initiator E&M")]
        public bool TALK_INITIATORS_EM { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether talk initiators fops
        /// </summary>
        [DisplayName("Talk Initiator FOps")]
        public bool TALK_INITIATORS_FOPS { get; set; }

        /// <summary>
        /// Gets or sets my request follow up access
        /// </summary>
        [DisplayName("My Requests Status Access")]
        public bool? MY_REQUESTS_FOLLOWUP_ACCESS { get; set; }

        /// <summary>
        /// Gets or sets subscription date
        /// </summary>
        [DisplayName("Subscription Date")]
        public DateTime? SUBSCRIPTION_DATE { get; set; }

        /// <summary>
        /// Gets or sets my warranty status access
        /// </summary>
        [DisplayName("My Warranty Status Access")]
        public bool? MY_WARRANTY_STATUS_ACCESS { get; set; }

        /// <summary>
        /// Gets or sets frequency
        /// </summary>
        [DisplayName("Notification Frequency")]
        public bool? FREQUENCY { get; set; }

        /// <summary>
        /// Gets or sets request created
        /// </summary>
        [DisplayName("My Requests Status Subscription Created")]
        public bool? REQUEST_CREATED { get; set; }

        /// <summary>
        /// Gets or sets request answered
        /// </summary>
        [DisplayName("My Requests Status Subscription Answered")]
        public bool? REQUEST_ANSWERED { get; set; }

        /// <summary>
        /// Gets or sets warranty created
        /// </summary>
        [DisplayName("My Warranty Status Subscription Created")]
        public bool? WARRANTY_CREATED { get; set; }

        /// <summary>
        /// Gets or sets warranty answered
        /// </summary>
        [DisplayName("My Warranty Status Subscription Answered")]
        public bool? WARRANTY_ANSWERED { get; set; }

        /// <summary>
        /// Gets or sets interaction with ATR
        /// </summary>
        [DisplayName("Interact with ATR Access")]
        public bool? INTERACTION_WITH_ATR { get; set; }

        /// <summary>
        /// Gets or sets is administrator ATR CRM
        /// </summary>
        [DisplayName("ATR CRM Administrator")]
        public bool? IS_ADMIN_ATR_CRM { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether internal user
        /// </summary>
        [DisplayName("Internal User")]
        public bool INTERNAL_USER_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is administrator ATR CRM
        /// </summary>
        [DisplayName("ATR CRM Administrator")]
        public bool IS_ADMIN_ATR_CRM_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Interaction With ATR
        /// </summary>
        [DisplayName("Interact with ATR Access")]
        public bool INTERACTION_WITH_ATR_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether My request follow up access
        /// </summary>
        [DisplayName("My Requests Status Access")]
        public bool MY_REQUESTS_FOLLOWUP_ACCESS_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether My warranty status access
        /// </summary>
        [DisplayName("My Warranty Status Access")]
        public bool MY_WARRANTY_STATUS_ACCESS_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Request created
        /// </summary>
        [DisplayName("My Requests Status Subscription Created")]
        public bool REQUEST_CREATED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Warranty created
        /// </summary>
        [DisplayName("My Warranty Status Subscription Created")]
        public bool WARRANTY_CREATED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Request answered
        /// </summary>
        [DisplayName("My Requests Status Subscription Answered")]
        public bool REQUEST_ANSWERED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Warranty answered
        /// </summary>
        [DisplayName("My Warranty Status Subscription Answered")]
        public bool WARRANTY_ANSWERED_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets frequency
        /// </summary>
        [DisplayName("Notification Frequency")]
        public string FREQUENCY_Edit_Value { get; set; }
    }
}
