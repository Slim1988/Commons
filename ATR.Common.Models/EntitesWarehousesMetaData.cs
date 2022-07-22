namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend ENTITES_WAREHOUSE to add data annotations
    /// </summary>
    [MetadataType(typeof(EntitesWarehousesMetaData))]
    partial class ENTITES_WAREHOUSE
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Local new warehouse
        /// </summary>
        public bool LOCAL_NEW { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Local second hand warehouse
        /// </summary>
        public bool LOCAL_SECONDHAND { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Local overhauled warehouse
        /// </summary>
        public bool LOCAL_OVERHAULED { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets World new warehouse
        /// </summary>
        public bool WORLD_NEW { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets World second hand warehouse
        /// </summary>
        public bool WORLD_SECONDHAND { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets World overhauled warehouse
        /// </summary>
        public bool WORLD_OVERHAULED { get; set; }

        /// <summary>
        /// Gets or sets warehouse default new identifier
        /// </summary>
        [DisplayName("New")]
        public long FK_WAREHOUSE_NEW { get; set; }

        /// <summary>
        /// Gets or sets warehouse default repaired identifier
        /// </summary>
        [DisplayName("Repaired")]
        public long FK_WAREHOUSE_REPAIRED { get; set; }

        /// <summary>
        /// Gets or sets warehouses default overhauled identifier
        /// </summary>
        [DisplayName("Overhauled")]
        public long FK_WAREHOUSE_OVERHAULED { get; set; }

        /// <summary>
        /// Gets or sets warehouses default new
        /// </summary>
        public WAREHOUSES WAREHOUSEDEFAULTNEW { get; set; }

        /// <summary>
        /// Gets or sets warehouse default repaired
        /// </summary>
        public WAREHOUSES WAREHOUSEDEFAULTREPAIRED { get; set; }

        /// <summary>
        /// Gets or sets warehouses default overhauled
        /// </summary>
        public WAREHOUSES WAREHOUSEDEFAULTOVERHAULED { get; set; }
    }

    /// <summary>
    /// Data annotations for ENTITES_WAREHOUSE SQL DataTable
    /// </summary>
    public class EntitesWarehousesMetaData
    {
        /// <summary>
        /// Gets or sets entity warehouse identifier
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public long ID_ENTITES_WAREHOUSE { get; set; }

        /// <summary>
        /// Gets or sets entity foreign key
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public int FK_ENTITY { get; set; }

        /// <summary>
        /// Gets or sets warehouse foreign key
        /// </summary>
        [DisplayName("Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        public long FK_WAREHOUSE { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Local new warehouse
        /// </summary>
        [DisplayName("Local - New")]
        public bool LOCAL_NEW { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Local second hand warehouse
        /// </summary>
        [DisplayName("Local - Repaired")]
        public bool LOCAL_SECONDHAND { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Local overhauled warehouse
        /// </summary>
        [DisplayName("Local - Overhauled")]
        public bool LOCAL_OVERHAULED { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets World new warehouse
        /// </summary>
        [DisplayName("World - New")]
        public bool WORLD_NEW { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets World second hand warehouse
        /// </summary>
        [DisplayName("World - Repaired")]
        public bool WORLD_SECONDHAND { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets World overhauled warehouse
        /// </summary>
        [DisplayName("World - Overhauled")]
        public bool WORLD_OVERHAULED { get; set; }
    }
}
