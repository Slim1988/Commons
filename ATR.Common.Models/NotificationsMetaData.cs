namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend NOTIFICATIONS to add data annotations
    /// </summary>
    [MetadataType(typeof(NotificationsMetaData))]
    partial class NOTIFICATIONS
    {
        /// <summary>
        /// Gets or sets a value indicating whether the notification is checked
        /// </summary>
        public bool IS_CHECKED { get; set; }
    }

    /// <summary>
    /// Data annotations for NOTIFICATIONS SQL DataTable
    /// </summary>
    public class NotificationsMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Notification Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_NOTIFICATION { get; set; }

        /// <summary>
        /// Gets or sets label
        /// </summary>
        [DisplayName("Notification Label")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_NOTIFICATION { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        [DisplayName("Notification Description")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string DESCRIPTION_NOTIFICATION { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification is checked
        /// </summary>
        public bool IS_CHECKED { get; set; }
    }
}
