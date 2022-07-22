namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend CURRENCIES to add data annotations
    /// </summary>
    [MetadataType(typeof(CurrenciesMetaData))]
    partial class CURRENCIES
    {
    }

    /// <summary>
    /// Data annotations for CURRENCIES SQL DataTable
    /// </summary>
    public class CurrenciesMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Currency Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_CURRENCY { get; set; }

        /// <summary>
        /// Gets or sets label
        /// </summary>
        [DisplayName("Currency Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_CURRENCY { get; set; }
    }
}
