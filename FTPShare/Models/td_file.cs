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
    
    public partial class td_file
    {
        public string owner { get; set; }
        public string folder { get; set; }
        public string filename { get; set; }
        public string path { get; set; }
        public System.DateTime exp_dt { get; set; }
    
        public virtual td_owner_folder td_owner_folder { get; set; }
    }
}
