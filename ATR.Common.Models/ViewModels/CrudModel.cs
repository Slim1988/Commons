namespace ATR.Common.Models
{
    using System;
    using System.Collections.Generic;
    using Enumerations;

    /// <summary>
    /// Crud View Model
    /// </summary>
    public class CrudModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudModel"/> class.
        /// </summary>
        public CrudModel()
        {
            this.ListColumnsNames = new List<string>();
            this.ListColumnsNamesWithTooltip = new List<Tuple<string, string>>();
            this.ListDataNames = new List<string>();
            this.ColumnsClasses = new Dictionary<string, string>();
            this.ColumnsSortData = new Dictionary<string, string>();
            this.ColumnsRenderData = new Dictionary<string, string>();
            this.ColumnsOrderable = new List<string>();
            this.PluralName = string.Empty;
            this.SingularName = string.Empty;
            this.LinkedEntityId = 0;
            this.DatatableColumns = DatatableColumns.EditDelete;
            this.TypeOfIdentifier = typeof(long);
            this.OldEntityOnAddOrEdit = false;
            this.CanAddEntity = true;
            this.CanExport = false;
            this.Searching = true;
            this.Paging = true;
            this.DatatableInitComplete = string.Empty;
            this.DataOrder = string.Empty;
            this.PageLength = 10;
            this.DatatableColumnAction = string.Empty;
        }

        /// <summary>
        /// Gets or sets list of column names.
        /// </summary>
        public List<string> ListColumnsNames { get; set; }

        /// <summary>
        /// Gets or sets list of column names with tooltip.
        /// </summary>
        public List<Tuple<string, string>> ListColumnsNamesWithTooltip { get; set; }

        /// <summary>
        /// Gets or sets list of data names.
        /// </summary>
        public List<string> ListDataNames { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of classes to be attributed to columns
        /// </summary>
        public Dictionary<string, string> ColumnsClasses { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of types to be attributed to columns
        /// </summary>
        public Dictionary<string, string> ColumnsSortData { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of render method to be used on column
        /// </summary>
        public Dictionary<string, string> ColumnsRenderData { get; set; }

        /// <summary>
        /// Gets or sets the list of orderable columns
        /// </summary>
        public List<string> ColumnsOrderable { get; set; }

        /// <summary>
        /// Gets or sets the plural name.
        /// </summary>
        public string PluralName { get; set; }

        /// <summary>
        /// Gets or sets the singular name.
        /// </summary>
        public string SingularName { get; set; }

        /// <summary>
        /// Gets or sets the data identifier name.
        /// </summary>
        public string DataIdName { get; set; }

        /// <summary>
        /// Gets or sets linked entity identifier.
        /// </summary>
        public long LinkedEntityId { get; set; }

        /// <summary>
        /// Gets or sets datatable columns.
        /// </summary>
        public DatatableColumns DatatableColumns { get; set; }

        /// <summary>
        /// Gets or sets the type of identifier.
        /// </summary>
        public Type TypeOfIdentifier { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the old entity is used for Add or Edit action or not
        /// </summary>
        public bool OldEntityOnAddOrEdit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can add an entity or not
        /// </summary>
        public bool CanAddEntity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can export
        /// </summary>
        public bool CanExport { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of results to display on each page of the CRUD
        /// </summary>
        public int PageLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the datatable is searchable or not
        /// </summary>
        public bool Searching { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the datatable is pageable or not
        /// </summary>
        public bool Paging { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the function(s) to run once the datatable initialization is complete
        /// </summary>
        public string DatatableInitComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the datatable columns order
        /// </summary>
        public string DataOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the datatable column action
        /// </summary>
        public string DatatableColumnAction { get; set; }
    }
}