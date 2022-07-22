namespace ATR.Common.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;
    using Validators;

    /// <summary>
    /// Extend USERS_NEW_APPLICATIONS to add data annotations
    /// </summary>
    [MetadataType(typeof(UsersNewApplicationsMetaData))]
    partial class USERS_NEW_APPLICATIONS
    {
        /// <summary>
        /// Gets or sets the list of rights
        /// </summary>
        public List<RIGHTS> LIST_RIGHTS { get; set; }

        /// <summary>
        /// Gets or sets the list of notifications
        /// </summary>
        public List<NOTIFICATIONS> LIST_NOTIFICATIONS { get; set; }

        /// <summary>
        /// Gets or sets the frequency identifier
        /// </summary>
        public long FREQUENCY_ID { get; set; }
    }

    /// <summary>
    /// Data annotations for USERS_NEW_APPLICATIONS SQL DataTable
    /// </summary>
    public class UsersNewApplicationsMetaData
    {
        /// <summary>
        /// Gets or sets a value indicating whether the access is allowed or not
        /// </summary>
        [DisplayName("Access")]
        public bool ACCESS { get; set; }

        /// <summary>
        /// Gets or sets new application foreign key
        /// </summary>
        [DisplayName("Application")]
        public long FK_NEW_APPLICATIONS { get; set; }

        /// <summary>
        /// Gets or sets the list of rights
        /// </summary>
        [DisplayName("Rights")]
        public List<RIGHTS> LIST_RIGHTS { get; set; }

        /// <summary>
        /// Gets or sets the list of notifications
        /// </summary>
        [DisplayName("Notifications")]
        [CheckMandatoryFields("IS_CHECKED", "true", new string[] { "FREQUENCY_ID" }, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataMandatoryFrequencyError")]
        public List<NOTIFICATIONS> LIST_NOTIFICATIONS { get; set; }

        /// <summary>
        /// Gets or sets the frequency id
        /// </summary>
        [DisplayName("Frequency")]
        public long FREQUENCY_ID { get; set; }
    }
}
