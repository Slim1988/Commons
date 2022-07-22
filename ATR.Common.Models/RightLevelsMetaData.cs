namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend RIGHT_LEVELS to add data annotations
    /// </summary>
    [MetadataType(typeof(RightLevelsMetaData))]
    partial class RIGHT_LEVELS
    {
    }

    /// <summary>
    /// Data annotations for RIGHT_LEVELS SQL DataTable
    /// </summary>
    public class RightLevelsMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Right Level Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_RIGHT_LEVEL { get; set; }

        /// <summary>
        /// Gets or sets label
        /// </summary>
        [DisplayName("Right Level Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_RIGHT_LEVEL { get; set; }
    }
}
