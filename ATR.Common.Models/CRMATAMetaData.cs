namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend CRM_ATA to add data annotations
    /// </summary>
    [MetadataType(typeof(CRMATAMetaData))]
    partial class CRM_ATA
    {
    }

    /// <summary>
    /// Data annotations for CRM_ATA SQL DataTable
    /// </summary>
    public class CRMATAMetaData
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [DisplayName("ATA")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(4, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string ATA { get; set; }
    }
}
