namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend WAREHOUSES to add data annotations
    /// </summary>
    [MetadataType(typeof(WarehousesMetaData))]
    partial class WAREHOUSES
    {
    }

    /// <summary>
    /// Data annotations for WAREHOUSES SQL DataTable
    /// </summary>
    public class WarehousesMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Warehouse Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_WAREHOUSES { get; set; }

        /// <summary>
        /// Gets or sets label
        /// </summary>
        [DisplayName("Warehouse Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_WAREHOUSES { get; set; }
    }
}