namespace ATR.Common.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Resources.MessagesResources;
    using Validators;

    /// <summary>
    /// Extend ENTITY to add data annotations
    /// </summary>
    [MetadataType(typeof(EntityMetaData))]
    partial class ENTITY
    {
        /// <summary>
        /// Gets or sets picture file
        /// </summary>
        public HttpPostedFileBase PictureFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether public entity
        /// </summary>
        public bool PUBLIC_ENTITY_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether e-spares CGV
        /// </summary>
        public bool E_SPARE_CGV_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets validity end date
        /// </summary>
        public string VALIDITY_END_DATE_Edit_Value { get; set; }
    }

    /// <summary>
    /// Data annotations for ENTITY SQL DataTable
    /// </summary>
    public class EntityMetaData
    {
        /// <summary>
        /// Gets or sets ID_ENTITY
        /// </summary>
        [DisplayName("Id")]
        public string ID_ENTITY { get; set; }

        /// <summary>
        /// Gets or sets subscription status
        /// </summary>
        [DisplayName("Subscription Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string SUBSCRIPTION_STATUS { get; set; }

        /// <summary>
        /// Gets or sets e-spares CGV
        /// </summary>
        [DisplayName("CGV Acceptance")]
        public bool? E_SPARE_CGV { get; set; }

        /// <summary>
        /// Gets or sets e-spares CGV date
        /// </summary>
        [DisplayName("CGV Acceptance Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? E_SPARE_CGV_DATE { get; set; }

        /// <summary>
        /// Gets or sets TCU acceptance date
        /// </summary>
        [DisplayName("TCU Acceptance Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? SUBSCRIPTION_DATE { get; set; }

        /// <summary>
        /// Gets or sets activation date
        /// </summary>
        [DisplayName("Activation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? ACTIVATION_DATE { get; set; }

        /// <summary>
        /// Gets or sets company name
        /// </summary>
        [DisplayName("Company Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression(@"^(.*\S.*)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(120, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string COMPANY_NAME { get; set; }

        /// <summary>
        /// Gets or sets URL website
        /// </summary>
        [DisplayName("Url Website")]
        [StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string URL_WEBSITE { get; set; }

        /// <summary>
        /// Gets or sets company description
        /// </summary>
        [DisplayName("Company Description")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string COMPANY_DESCRIPTION { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether TCU acceptance
        /// </summary>
        [DisplayName("TCU Acceptance")]
        public bool PORTAL_TC { get; set; }

        /// <summary>
        /// Gets or sets CRM code
        /// </summary>
        [DisplayName("CRM Code")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string ATR_CODE { get; set; }

        /// <summary>
        /// Gets or sets entity logo
        /// </summary>
        [DisplayName("Entity Logo")]
        public byte[] ENTITY_LOGO { get; set; }

        /// <summary>
        /// Gets or sets public entity
        /// </summary>
        [DisplayName("Public Entity")]
        public bool? PUBLIC_ENTITY { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is GMA
        /// </summary>
        [DisplayName("Is GMA")]
        public bool IS_GMA { get; set; }

        /// <summary>
        /// Gets or sets Support center
        /// </summary>
        [DisplayName("Support Center")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public int? FK_SUPPORT_CENTER { get; set; }

        /// <summary>
        /// Gets or sets Training center
        /// </summary>
        [DisplayName("Training Center")]
        public long? FK_TRAINING_CENTER { get; set; }

        /// <summary>
        /// Gets or sets Business type
        /// </summary>
        [DisplayName("Business Type")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public long FK_BUSINESS_TYPE { get; set; }

        /// <summary>
        /// Gets or sets Country
        /// </summary>
        [DisplayName("Country")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public int FK_COUNTRY { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether CIB Access
        /// </summary>
        [DisplayName("CIB Access")]
        public bool CIB_ACCESS { get; set; }

        /// <summary>
        /// Gets or sets Company Address
        /// </summary>
        [DisplayName("Company Address")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [NotEmptyString(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string COMPANY_MAIL { get; set; }

        /// <summary>
        /// Gets or sets CIN
        /// </summary>
        [DisplayName("CIN")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CIN { get; set; }

        /// <summary>
        /// Gets or sets Validity end date
        /// </summary>
        [DisplayName("Validity End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? VALIDITY_END_DATE { get; set; }

        /// <summary>
        /// Gets or sets Subscription date
        /// </summary>
        [DisplayName("Subscription Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? SUBSCRIPTION_DATE2 { get; set; }

        /// <summary>
        /// Gets or sets currency
        /// </summary>
        [DisplayName("Currency")]
        public long? FK_CURRENCY { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Flight Ops Doc limited access
        /// </summary>
        [DisplayName("Flight Ops Doc Limited Access")]
        public bool FLIGHT_OPS_DOC_LIMITED_ACCESS { get; set; }

        /// <summary>
        /// Gets or sets entity logo
        /// </summary>
        [DisplayName("Entity Logo")]
        [FileSize(16 * 1024, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataImageUploadSizeError")]
        [FileType(new string[] { "image/png", "image/jpeg" }, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataImageUploadFormatError")]
        public HttpPostedFileBase PictureFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether public entity
        /// </summary>
        [DisplayName("Public Entity")]
        public bool PUBLIC_ENTITY_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether CGV acceptance
        /// </summary>
        [DisplayName("CGV Acceptance")]
        public bool E_SPARE_CGV_Edit_Value { get; set; }

        /// <summary>
        /// Gets or sets validity end date
        /// </summary>
        [DisplayName("Validity End Date")]
        public string VALIDITY_END_DATE_Edit_Value { get; set; }
    }
}
