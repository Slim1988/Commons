namespace ATR.Common.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    /// <summary>
    /// Extend ENTITY_TCU to add data annotations
    /// </summary>
    [MetadataType(typeof(EntityTCUMetadata))]
    partial class ENTITY_TCU
    {
        /// <summary>
        /// Gets the Publication Date TCU Creation
        /// </summary>
        public string SIGNATURE_DATE_ENTITY_TCU_VIEW_FORMAT
        {
            get { return this.SIGNATURE_DATE_ENTITY_TCU.HasValue ? this.SIGNATURE_DATE_ENTITY_TCU.Value.ToString("dd-MMM-yyyy HH:mm", new CultureInfo("en-US")) : string.Empty; }
        }
    }

    /// <summary>
    /// Data annotations for ENTITY_TCU SQL DataTable
    /// </summary>
    public class EntityTCUMetadata
    {
        /// <summary>
        /// Gets ID_ENTITY_TCU
        /// </summary>
        [DisplayName("Id")]
        public int ID_ENTITY_TCU { get; }

        /// <summary>
        /// Gets ID_TCU
        /// </summary>
        [DisplayName("TCU")]
        public string FK_TCU { get; }

        /// <summary>
        /// Gets SIGNATURE_DATE_ENTITY_TCU
        /// </summary>
        [DisplayName("Signed on")]
        public DateTime? SIGNATURE_DATE_ENTITY_TCU { get; }

        /// <summary>
        /// Gets SIGNATURE_USER_ENTITY_TCU
        /// </summary>
        [DisplayName("Signed by")]
        public DateTime? SIGNATURE_USER_ENTITY_TCU { get; }
    }
}