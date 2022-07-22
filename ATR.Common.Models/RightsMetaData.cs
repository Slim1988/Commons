namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend RIGHTS to add data annotations
    /// </summary>
    [MetadataType(typeof(RightsMetaData))]
    partial class RIGHTS
    {
        /// <summary>
        /// Gets or sets a value indicating whether the notification is checked
        /// </summary>
        public bool IS_CHECKED { get; set; }
    }

    /// <summary>
    /// Data annotations for RIGHTS SQL DataTable
    /// </summary>
    public class RightsMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Right Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_RIGHT { get; set; }

        /// <summary>
        /// Gets or sets label
        /// </summary>
        [DisplayName("Right Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_RIGHT { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        [DisplayName("Right Description")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string DESCRIPTION_RIGHTS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification is checked
        /// </summary>
        public bool IS_CHECKED { get; set; }
    }
}
