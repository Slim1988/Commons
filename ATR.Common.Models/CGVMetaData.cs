namespace ATR.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;
    using ATR.Common.Models.Validators;
    using ATR.Common.Resources.MessagesResources;

    /// <summary>
    /// Extend CGV to add data annotations
    /// </summary>
    [MetadataType(typeof(CGVMetadata))]
    partial class CGV
    {
        /// <summary>
        /// Gets or sets a value indicating whether record need to be inserted in ENTITY_CGV datatable
        /// </summary>
        public bool INSERT_IN_ENTITY_CGV { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether PUBLICATION_STATE_CGV
        /// </summary>
        public bool PUBLICATION_STATE_CGV { get; set; }

        /// <summary>
        /// Gets the Publication Date CGV Creation
        /// </summary>
        public string PUBLICATION_DATE_CGV_VIEW_FORMAT
        {
            get { return this.PUBLICATION_DATE_CGV.HasValue ? this.PUBLICATION_DATE_CGV.Value.ToString("dd-MMM-yyyy", new CultureInfo("en-US")) : string.Empty; }
        }

        /// <summary>
        /// Gets the Publication Date CGV for sort
        /// </summary>
        public string PUBLICATION_DATE_CGV_SORT_FORMAT
        {
            get
            {
                System.DateTime zeroDate = new System.DateTime(1970, 1, 1, 0, 0, 0);
                return this.PUBLICATION_DATE_CGV.HasValue ? (this.PUBLICATION_DATE_CGV.Value - zeroDate).ToString() : (DateTime.MaxValue - zeroDate).ToString();
            }
        }

        /// <summary>
        /// Gets the Publication Date CGV for csv export
        /// </summary>
        public string PUBLICATION_DATE_CGV_EXPORT_FORMAT
        {
            get { return this.PUBLICATION_DATE_CGV.HasValue ? this.PUBLICATION_DATE_CGV.Value.ToString("yyyy-MM-dd") : string.Empty; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether PUBLICATION_STATE_CGV
        /// </summary>
        public bool APPLICATION_STATE_CGV { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether APPLICATION_STATE_OLD_CGV
        /// </summary>
        public bool APPLICATION_STATE_OLD_CGV { get; set; }

        /// <summary>
        /// Gets the Application Date CGV Creation
        /// </summary>
        public string APPLICATION_DATE_CGV_VIEW_FORMAT
        {
            get { return this.APPLICATION_DATE_CGV.HasValue ? this.APPLICATION_DATE_CGV.Value.ToString("dd-MMM-yyyy", new CultureInfo("en-US")) : string.Empty; }
        }

        /// <summary>
        /// Gets the Application Date CGV for sort
        /// </summary>
        public string APPLICATION_DATE_CGV_SORT_FORMAT
        {
            get
            {
                System.DateTime zeroDate = new System.DateTime(1970, 1, 1, 0, 0, 0);
                return this.APPLICATION_DATE_CGV.HasValue ? (this.APPLICATION_DATE_CGV.Value - zeroDate).ToString() : "0";
            }
        }

        /// <summary>
        /// Gets the Application Date CGV for csv export
        /// </summary>
        public string APPLICATION_DATE_CGV_EXPORT_FORMAT
        {
            get { return this.APPLICATION_DATE_CGV.HasValue ? this.APPLICATION_DATE_CGV.Value.ToString("yyyy-MM-dd") : string.Empty; }
        }

        /// <summary>
        /// Gets or sets pdf file
        /// </summary>
        [DisplayName("PDF File")]
        [FileType(new string[] { "application/pdf" }, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataPdfFileUploadFormatError")]
        public HttpPostedFileBase File { get; set; }

        /// <summary>
        /// Gets or sets Pdf File
        /// </summary>
        public Dictionary<string, string> PdfFile { get; set; }

        /// <summary>
        /// Gets or sets the Application Warning Message
        /// </summary>
        public string ApplicationWarningMessage { get; set; }
    }

    /// <summary>
    /// Data annotations for CGV SQL DataTable
    /// </summary>
    public class CGVMetadata
    {
        /// <summary>
        /// Gets ID_CGV
        /// </summary>
        [DisplayName("Id")]
        public int ID_CGV { get; }

        /// <summary>
        /// Gets or sets CODE_CGV
        /// </summary>
        [DisplayName("Code")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataRequiredError")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string CODE_CGV { get; set; }

        /// <summary>
        /// Gets or sets LABEL_CGV
        /// </summary>
        [DisplayName("Label")]
        [StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string LABEL_CGV { get; set; }

        /// <summary>
        /// Gets or sets PUBLICATION_DATE_CGV
        /// </summary>
        [DisplayName("Publication Date")]
        public DateTime? PUBLICATION_DATE_CGV { get; set; }

        /// <summary>
        /// Gets or sets PUBLICATION_DATE_CGV
        /// </summary>
        [DisplayName("Application Date")]
        public DateTime? APPLICATION_DATE_CGV { get; set; }

        /// <summary>
        /// Gets or sets LABEL_CGV
        /// </summary>
        [DisplayName("Url")]
        [AllowHtml]
        [StringLength(2083, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "dataLengthError")]
        public string URL_CGV { get; set; }
    }
}