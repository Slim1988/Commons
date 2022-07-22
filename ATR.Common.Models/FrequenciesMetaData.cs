namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend FREQUENCIES to add data annotations
    /// </summary>
    [MetadataType(typeof(FrequenciesMetaData))]
    partial class FREQUENCIES
    {
    }

    /// <summary>
    /// Data annotations for FREQUENCIES SQL DataTable
    /// </summary>
    public class FrequenciesMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Frequency Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_FREQUENCY { get; set; }

        /// <summary>
        /// Gets or sets label
        /// </summary>
        [DisplayName("Frequency Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_FREQUENCY { get; set; }
    }
}
