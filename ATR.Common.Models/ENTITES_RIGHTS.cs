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
    
    public partial class ENTITES_RIGHTS
    {
        public long ID_ENTITE_RIGHT { get; set; }
        public int FK_ENTITY { get; set; }
        public long FK_RIGHTS { get; set; }
    
        public virtual ENTITY ENTITY { get; set; }
        public virtual RIGHTS RIGHTS { get; set; }
    }
}