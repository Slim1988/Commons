namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend BUSINESS_TYPE to add data annotations
    /// </summary>
    [MetadataType(typeof(BusinessTypeMetaData))]
    partial class BUSINESS_TYPE
    {
    }

    /// <summary>
    /// Data annotations for BUSINESS_TYPE SQL DataTable
    /// </summary>
    public class BusinessTypeMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Business Type Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_BUSINESS_TYPE { get; set; }

        /// <summary>
        /// Gets or sets business type
        /// </summary>
        [DisplayName("Business Type")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(60, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string BUSINESS_TYPE1 { get; set; }
    }
}
