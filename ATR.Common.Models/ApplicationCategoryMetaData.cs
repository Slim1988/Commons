namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend APPLICATION_CATEGORY to add data annotations
    /// </summary>
    [MetadataType(typeof(ApplicationCategoryMetaData))]
    partial class APPLICATION_CATEGORY
    {
    }

    /// <summary>
    /// Data annotations for APPLICATION_CATEGORY SQL DataTable
    /// </summary>
    public class ApplicationCategoryMetaData
    {
        /// <summary>
        /// Gets or sets Application Category
        /// </summary>
        [DisplayName("Application Category")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(60, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string APPLICATION_CATEGORY1 { get; set; }
    }
}
