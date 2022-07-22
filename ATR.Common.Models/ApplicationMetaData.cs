namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend APPLICATION to add data annotations
    /// </summary>
    [MetadataType(typeof(ApplicationMetaData))]
    partial class APPLICATION
    {
    }

    /// <summary>
    /// Data annotations for APPLICATION SQL DataTable
    /// </summary>
    public class ApplicationMetaData
    {
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        [DisplayName("Application Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string APPLICATION_CODE { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        [DisplayName("Short Description")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string SHORT_DESCRIPTION { get; set; }
    }
}
