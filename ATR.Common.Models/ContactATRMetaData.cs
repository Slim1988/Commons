namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Resources.MessagesResources;
    using Validators;

    /// <summary>
    /// Extend CONTACTS_ATR to add data annotations
    /// </summary>
    [MetadataType(typeof(ContactATRMetaData))]
    partial class CONTACTS_ATR
    {
        /// <summary>
        /// Gets or sets picture file
        /// </summary>
        public HttpPostedFileBase PictureFile { get; set; }
    }

    /// <summary>
    /// Data annotations for CONTACTS_ATR SQL DataTable
    /// </summary>
    public class ContactATRMetaData
    {
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
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        public string PHONE_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets fax number
        /// </summary>
        [DisplayName("Fax Number")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        public string FAX_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets email address
        /// </summary>
        [DisplayName("Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string EMAIL_ADDRESS { get; set; }

        /// <summary>
        /// Gets or sets picture
        /// </summary>
        [DisplayName("Picture")]
        [FileSize(16 * 1024, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataImageUploadSizeError")]
        [FileType(new string[] { "image/png", "image/jpeg" }, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataImageUploadFormatError")]
        public HttpPostedFileBase PictureFile { get; set; }
    }
}
