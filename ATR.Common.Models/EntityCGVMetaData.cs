namespace ATR.Common.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    /// <summary>
    /// Extend ENTITY_CGV to add data annotations
    /// </summary>
    [MetadataType(typeof(EntityCGVMetadata))]
    partial class ENTITY_CGV
    {
        /// <summary>
        /// Gets the Publication Date CGV Creation
        /// </summary>
        public string SIGNATURE_DATE_ENTITY_CGV_VIEW_FORMAT
        {
            get { return this.SIGNATURE_DATE_ENTITY_CGV.HasValue ? this.SIGNATURE_DATE_ENTITY_CGV.Value.ToString("dd-MMM-yyyy HH:mm", new CultureInfo("en-US")) : string.Empty; }
        }
    }

    /// <summary>
    /// Data annotations for ENTITY_CGV SQL DataTable
    /// </summary>
    public class EntityCGVMetadata
    {
        /// <summary>
        /// Gets ID_ENTITY_CGV
        /// </summary>
        [DisplayName("Id")]
        public int ID_ENTITY_CGV { get; }

        /// <summary>
        /// Gets ID_CGV
        /// </summary>
        [DisplayName("CGV")]
        public string FK_CGV { get; }

        /// <summary>
        /// Gets SIGNATURE_DATE_ENTITY_CGV
        /// </summary>
        [DisplayName("Signed on")]
        public DateTime? SIGNATURE_DATE_ENTITY_CGV { get; }

        /// <summary>
        /// Gets SIGNATURE_USER_ENTITY_CGV
        /// </summary>
        [DisplayName("Signed by")]
        public DateTime? SIGNATURE_USER_ENTITY_CGV { get; }
    }
}