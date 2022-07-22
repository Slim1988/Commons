namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend ENTITY_CONTACTS_ATR to add data annotations
    /// </summary>
    [MetadataType(typeof(EntityContactATRMetaData))]
    partial class ENTITY_CONTACTS_ATR
    {
    }

    /// <summary>
    /// Data annotations for ENTITY_CONTACTS_ATR SQL DataTable
    /// </summary>
    public class EntityContactATRMetaData
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [DisplayName("Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public int FK_CONTACTS_ATR { get; set; }
    }
}
