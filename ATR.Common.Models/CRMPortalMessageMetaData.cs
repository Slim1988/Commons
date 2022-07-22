namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend CRM_PORTAL_MESSAGES to add data annotations
    /// </summary>
    [MetadataType(typeof(CRMPortalMessageMetaData))]
    partial class CRM_PORTAL_MESSAGES
    {
    }

    /// <summary>
    /// Data annotations for CRM_PORTAL_MESSAGES SQL DataTable
    /// </summary>
    public class CRMPortalMessageMetaData
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [DisplayName("Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string NAME { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        [DisplayName("Description")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// Gets or sets Message Value
        /// </summary>
        [DisplayName("Message Value")]
        [AllowHtml]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string MESSAGEVALUE { get; set; }
    }
}
