namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend ENTITY_APPLICATION_ACCESS to add data annotations
    /// </summary>
    [MetadataType(typeof(EntityApplicationAccessMetaData))]
    partial class ENTITY_APPLICATION_ACCESS
    {
    }

    /// <summary>
    /// Data annotations for ENTITY_APPLICATION_ACCESS SQL DataTable
    /// </summary>
    public class EntityApplicationAccessMetaData
    {
        /// <summary>
        /// Gets or sets access allowed
        /// </summary>
        [DisplayName("Access Allowed")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public bool ACCESS_ALLOWED { get; set; }

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

        /// <summary>
        /// Gets or sets entity login
        /// </summary>
        [DisplayName("Entity Login")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string EntityLogin { get; set; }

        /// <summary>
        /// Gets or sets entity password
        /// </summary>
        [DisplayName("Entity Password")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string EntityPassword { get; set; }
    }
}
