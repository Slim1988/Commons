//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATR.Common.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NOTIFICATIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NOTIFICATIONS()
        {
            this.SUBSCRIBE = new HashSet<SUBSCRIBE>();
        }
    
        public long ID_NOTIFICATION { get; set; }
        public string CODE_NOTIFICATION { get; set; }
        public string LABEL_NOTIFICATION { get; set; }
        public string DESCRIPTION_NOTIFICATION { get; set; }
        public long FK_NEW_APPLICATIONS { get; set; }
    
        public virtual NEW_APPLICATIONS NEW_APPLICATIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBSCRIBE> SUBSCRIBE { get; set; }
    }
}