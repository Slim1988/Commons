namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend NEW_APPLICATIONS to add data annotations
    /// </summary>
    [MetadataType(typeof(NewApplicationsMetaData))]
    partial class NEW_APPLICATIONS
    {
    }

    /// <summary>
    /// Data annotations for NEW_APPLICATIONS SQL DataTable
    /// </summary>
    public class NewApplicationsMetaData
    {
        /// <summary>
        /// Gets or sets USER_ID
        /// </summary>
        [DisplayName("Id")]
        public string ID_NEW_APPLICATION { get; set; }

        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("New Application Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_NEW_APPLICATION { get; set; }

        /// <summary>
        /// Gets or sets label
        /// </summary>
        [DisplayName("New Application Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_NEW_APPLICATION { get; set; }

        /// <summary>
        /// Gets or sets new application description
        /// </summary>
        [DisplayName("New Application Description")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string DESCRIPTION_NEW_APPLICATION { get; set; }

        /// <summary>
        /// Gets or sets new application URL
        /// </summary>
        [DisplayName("New Application URL")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(1024, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string URL_NEW_APPLICATION { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Is enabled
        /// </summary>
        [DisplayName("Is Enabled")]
        public bool IS_ENABLED { get; set; }
    }
}
