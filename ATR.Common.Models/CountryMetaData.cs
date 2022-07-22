namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend COUNTRY to add data annotations
    /// </summary>
    [MetadataType(typeof(CountryMetaData))]
    partial class COUNTRY
    {
    }

    /// <summary>
    /// Data annotations for COUNTRY SQL DataTable
    /// </summary>
    public class CountryMetaData
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [DisplayName("Country Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string COUNTRY1 { get; set; }

        /// <summary>
        /// Gets or sets Code
        /// </summary>
        [DisplayName("Country Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string COUNTRY_CODE { get; set; }
    }
}
