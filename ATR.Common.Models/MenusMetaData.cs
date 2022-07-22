namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend MENUS to add data annotations
    /// </summary>
    [MetadataType(typeof(MenusMetaData))]
    partial class MENUS
    {
    }

    /// <summary>
    /// Data annotations for MENUS SQL DataTable
    /// </summary>
    public class MenusMetaData
    {
        /// <summary>
        /// Gets menu code
        /// </summary>
        [DisplayName("Menu Code")]
        public string CODE_MENU { get; }

        /// <summary>
        /// Gets or sets menu label
        /// </summary>
        [DisplayName("Menu Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_MENU { get; set; }

        /// <summary>
        /// Gets or sets menu description
        /// </summary>
        [DisplayName("Menu Description")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string DESCRIPTION_MENU { get; set; }

        /// <summary>
        /// Gets or sets menu Url
        /// </summary>
        [DisplayName("Menu Url")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string URL_MENU { get; set; }
    }
}
