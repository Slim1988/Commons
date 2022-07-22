namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend TRAINING_CENTER to add data annotations
    /// </summary>
    [MetadataType(typeof(TrainingCenterMetaData))]
    partial class TRAINING_CENTER
    {
    }

    /// <summary>
    /// Data annotations for TRAINING_CENTER SQL DataTable
    /// </summary>
    public class TrainingCenterMetaData
    {
        /// <summary>
        /// Gets or sets Training Center
        /// </summary>
        [DisplayName("Training Center")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(60, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string TRAINING_CENTER1 { get; set; }

        /// <summary>
        /// Gets or sets Phone Number
        /// </summary>
        [DisplayName("Phone Number")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        public string PHONE_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets Fax Number
        /// </summary>
        [DisplayName("Fax Number")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression(@"^(\+ ?\d{1,4}|00\d{1,4}|\(\+ ?\d{1,4}\)|\d)(\d|\(| |\.|\/|\-|\))*(\d)$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectPhoneNumber")]
        public string FAX_NUMBER { get; set; }

        /// <summary>
        /// Gets or sets Sales Email
        /// </summary>
        [DisplayName("Sales Email")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string SALES_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets Planning Email
        /// </summary>
        [DisplayName("Planning Email")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string PLANNING_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets Reception Email
        /// </summary>
        [DisplayName("Reception Email")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string RECEPTION_EMAIL { get; set; }

        /// <summary>
        /// Gets or sets Other Email
        /// </summary>
        [DisplayName("Other Email")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        public string OTHER_EMAIL { get; set; }
    }
}
