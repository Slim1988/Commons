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
    
    public partial class USERS_NEW_APPLICATIONS
    {
        public long ID_USER_NEW_APPLICATION { get; set; }
        public long FK_NEW_APPLICATIONS { get; set; }
        public long FK_USERS { get; set; }
        public bool ACCESS { get; set; }
    
        public virtual NEW_APPLICATIONS NEW_APPLICATIONS { get; set; }
        public virtual USERS USERS { get; set; }
    }
}
