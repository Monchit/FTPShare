//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTPShare.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tm_sys_utype
    {
        public tm_sys_utype()
        {
            this.tm_sys_user = new HashSet<tm_sys_user>();
        }
    
        public byte utype_id { get; set; }
        public string utype_name { get; set; }
        public byte authority { get; set; }
    
        public virtual ICollection<tm_sys_user> tm_sys_user { get; set; }
    }
}