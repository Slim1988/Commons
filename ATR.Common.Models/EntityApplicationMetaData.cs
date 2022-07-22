namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend ENTITY_APPLICATION to add data annotations
    /// </summary>
    [MetadataType(typeof(EntityApplicationMetaData))]
    partial class ENTITY_APPLICATION
    {
    }

    /// <summary>
    /// Data annotations for ENTITY_APPLICATION SQL DataTable
    /// </summary>
    public class EntityApplicationMetaData
    {
        /// <summary>
        /// Gets or sets internal entity code
        /// </summary>
        [DisplayName("Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string INTERNAL_ENTITY_CODE { get; set; }

        /// <summary>
        /// Gets or sets entity foreign key
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public int FK_ENTITY { get; set; }

        /// <summary>
        /// Gets or sets application foreign key
        /// </summary>
        [DisplayName("Application")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public long FK_APPLICATION { get; set; }
    }
}
