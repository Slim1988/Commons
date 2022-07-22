namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend APPLICATIONS_MESSAGES to add data annotations
    /// </summary>
    [MetadataType(typeof(ApplicationsMessagesMetaData))]
    partial class APPLICATIONS_MESSAGES
    {
    }

    /// <summary>
    /// Data annotations for APPLICATIONS_MESSAGES SQL DataTable
    /// </summary>
    public class ApplicationsMessagesMetaData
    {
        /// <summary>
        /// Gets APPLICATION
        /// </summary>
        [DisplayName("Application")]
        public string APPLICATION { get; }

        /// <summary>
        /// Gets CODE_MESSAGE
        /// </summary>
        [DisplayName("Code Message")]
        public string CODE_MESSAGE { get; }

        /// <summary>
        /// Gets or sets MESSAGE
        /// </summary>
        [DisplayName("Message")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [AllowHtml]
        [StringLength(2500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string MESSAGE { get; set;  }

        /// <summary>
        /// Gets or sets DESCRIPTION
        /// </summary>
        [DisplayName("Description")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        [RegularExpression("[^<>]*", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataForbiddenSuperiorInferiorCharaters")]
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// Gets or sets SOLUTION
        /// </summary>
        [DisplayName("Solution/Additional Message")]
        [AllowHtml]
        [StringLength(2500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string SOLUTION { get; set; }
    }
}
