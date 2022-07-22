namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend SUPPORT_CENTER to add data annotations
    /// </summary>
    [MetadataType(typeof(SupportCenterMetaData))]
    partial class SUPPORT_CENTER
    {
    }

    /// <summary>
    /// Data annotations for SUPPORT_CENTER SQL DataTable
    /// </summary>
    public class SupportCenterMetaData
    {
        /// <summary>
        /// Gets or sets support center name
        /// </summary>
        [DisplayName("Support Center Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string SUPPORT_CENTER_NAME { get; set; }

        /// <summary>
        /// Gets or sets phone number
        /// </summary>
        [DisplayName("Phone Number")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        public string TELEPHONE_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets fax number
        /// </summary>
        [DisplayName("Fax Number")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        public string FAX_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets display name
        /// </summary>
        [DisplayName("Display Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(25, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string DISPLAY_NAME { get; set; }

        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(25, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE { get; set; }

        /// <summary>
        /// Gets or sets center CRM
        /// </summary>
        [DisplayName("Center CRM")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(12, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CentreCRM { get; set; }

        /// <summary>
        /// Gets or sets AOG Email
        /// </summary>
        [DisplayName("AOG Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string AOG_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets Spares order email
        /// </summary>
        [DisplayName("SparesOrders Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string SparesOrders_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets commercial email
        /// </summary>
        [DisplayName("Commercial Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string Commercial_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets spares quotation email
        /// </summary>
        [DisplayName("SparesQuotation Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string SparesQuotation_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets teck desk email
        /// </summary>
        [DisplayName("TeckDesk Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string TeckDesk_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets warranty email
        /// </summary>
        [DisplayName("Warranty Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string Warranty_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets vendor monitoring email
        /// </summary>
        [DisplayName("Vendor Monitoring Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string VENDOR_MONITORING_EMAIL { get; set; }
    }
}
