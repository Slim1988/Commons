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
    
    public partial class ENTITY_TCU
    {
        public int ID_ENTITY_TCU { get; set; }
        public int FK_ENTITY { get; set; }
        public int FK_TCU { get; set; }
        public Nullable<System.DateTime> SIGNATURE_DATE_ENTITY_TCU { get; set; }
        public string SIGNATURE_USER_ENTITY_TCU { get; set; }
    
        public virtual ENTITY ENTITY { get; set; }
        public virtual TCU TCU { get; set; }
    }
}
