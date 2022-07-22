namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend CONTACT_TYPE to add data annotations
    /// </summary>
    [MetadataType(typeof(ContactTypeMetaData))]
    partial class CONTACT_TYPE
    {
    }

    /// <summary>
    /// Data annotations for CONTACT_TYPE SQL DataTable
    /// </summary>
    public class ContactTypeMetaData
    {
        /// <summary>
        /// Gets or sets contact type
        /// </summary>
        [DisplayName("Contact Type")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(60, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CONTACT_TYPE1 { get; set; }

        /// <summary>
        /// Gets or sets is default
        /// </summary>
        [DisplayName("Default")]
        public bool IS_DEFAULT { get; set; }
    }
}
