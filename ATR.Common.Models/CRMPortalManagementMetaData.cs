namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend CRM_PORTAL_MANAGEMENT to add data annotations
    /// </summary>
    [MetadataType(typeof(CRMPortalManagementMetaData))]
    partial class CRM_PORTAL_MANAGEMENT
    {
        /// <summary>
        /// Gets or sets a boolean value corresponding to AOG_AVAILABLE field in CRM_PORTAL_MANAGEMENT datatable
        /// </summary>
        [DisplayName("AOG Available")]
        public bool AOG_AVAILABLE_BOOLEAN
        {
            get
            {
                return this.AOG_AVAILABLE.HasValue ? this.AOG_AVAILABLE.Value == 1 ? true : false : false;
            }

            set
            {
                this.AOG_AVAILABLE = value ? 1 : 0;
            }
        }

        /// <summary>
        /// Gets or sets a boolean value corresponding to CRITICAL_AVAILABLE field in CRM_PORTAL_MANAGEMENT datatable
        /// </summary>
        [DisplayName("Critical Available")]
        public bool CRITICAL_AVAILABLE_BOOLEAN
        {
            get
            {
                return this.CRITICAL_AVAILABLE.HasValue ? this.CRITICAL_AVAILABLE.Value == 1 ? true : false : false;
            }

            set
            {
                this.CRITICAL_AVAILABLE = value ? 1 : 0;
            }
        }

        /// <summary>
        /// Gets or sets a boolean value corresponding to ROUTINE_AVAILABLE field in CRM_PORTAL_MANAGEMENT datatable
        /// </summary>
        [DisplayName("Routine Available")]
        public bool ROUTINE_AVAILABLE_BOOLEAN
        {
            get
            {
                return this.ROUTINE_AVAILABLE.HasValue ? this.ROUTINE_AVAILABLE.Value == 1 ? true : false : false;
            }

            set
            {
                this.ROUTINE_AVAILABLE = value ? 1 : 0;
            }
        }
    }

    /// <summary>
    /// Data annotations for CRM_PORTAL_MANAGEMENT SQL DataTable
    /// </summary>
    public class CRMPortalManagementMetaData
    {
        [DisplayName("AOG Delay Hours")]
        public int? AOG_DELAY_HOURS { get; set; }

        [DisplayName("Critical Delay Hours")]
        public int? CRITICAL_DELAY_HOURS { get; set; }

        [DisplayName("Routine Delay Hours")]
        public int? ROUTINE_DELAY_HOURS { get; set; }

        /// <summary>
        /// Gets or sets email address for AAS
        /// </summary>
        [DisplayName("Email Miami (AAS)")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string EMAIL_AAS { get; set; }

        /// <summary>
        /// Gets or sets email address for AES
        /// </summary>
        [DisplayName("Email Singapore (AES)")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string EMAIL_AES { get; set; }

        /// <summary>
        /// Gets or sets email address for AICS
        /// </summary>
        [DisplayName("Email India (AICS)")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string EMAIL_AICS { get; set; }

        /// <summary>
        /// Gets or sets email address for TLS
        /// </summary>
        [DisplayName("Email Toulouse (TLS)")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [RegularExpression("^(\\w)+(\\w|-|\\.)*\\@(\\w)+(\\w|-|\\.)*\\.(\\w){2,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataIncorrectEmail")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string EMAIL_TLS { get; set; }

        /// <summary>
        /// Gets or sets Theme
        /// </summary>
        [DisplayName("Theme")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string THEME { get; set; }

        /// <summary>
        /// Gets or sets Type
        /// </summary>
        [DisplayName("Type")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string TYPE_NAME { get; set; }
    }
}
