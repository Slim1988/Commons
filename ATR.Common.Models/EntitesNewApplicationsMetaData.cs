namespace ATR.Common.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend ENTITES_NEW_APPLICATION to add data annotations
    /// </summary>
    [MetadataType(typeof(EntitesNewApplicationsMetaData))]
    partial class ENTITES_NEW_APPLICATIONS
    {
        /// <summary>
        /// Gets or sets the list of rights
        /// </summary>
        public List<RIGHTS> LIST_RIGHTS { get; set; }
    }

    /// <summary>
    /// Data annotations for ENTITES_NEW_APPLICATION SQL DataTable
    /// </summary>
    public class EntitesNewApplicationsMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Code")]
        [StringLength(1024, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_ENTITY { get; set; }

        /// <summary>
        /// Gets or sets access
        /// </summary>
        [DisplayName("Access")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
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
    }
}
