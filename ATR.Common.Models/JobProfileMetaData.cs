namespace ATR.Common.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Resources.MessagesResources;

    /// <summary>
    /// Extend JOB_PROFIL to add data annotations
    /// </summary>
    [MetadataType(typeof(JobProfileMetaData))]
    partial class JOB_PROFIL
    {
    }

    /// <summary>
    /// Data annotations for JOB_PROFIL SQL DataTable
    /// </summary>
    public class JobProfileMetaData
    {
        /// <summary>
        /// Gets or sets code
        /// </summary>
        [DisplayName("Job Profile")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(40, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string JOB_PROFIL1 { get; set; }
    }
}
