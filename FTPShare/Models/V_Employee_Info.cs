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
    
    public partial class V_Employee_Info
    {
        public string emp_code { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string emp_fname { get; set; }
        public string emp_lname { get; set; }
        public Nullable<byte> emp_position { get; set; }
        public string position_name { get; set; }
        public string email { get; set; }
        public Nullable<int> plant_id { get; set; }
        public string plant_name { get; set; }
        public Nullable<int> dept_id { get; set; }
        public string dept_name { get; set; }
        public Nullable<int> group_id { get; set; }
        public string group_name { get; set; }
        public Nullable<int> sub_group_id { get; set; }
        public string sub_group { get; set; }
        public string emp_status { get; set; }
        public string LeafOrganize { get; set; }
        public Nullable<int> LeafOrgGroupId { get; set; }
        public string LeafOrgGroup { get; set; }
        public Nullable<byte> position_level { get; set; }
        public int LeafOrgLevel { get; set; }
        public string ext { get; set; }
        public Nullable<byte> level { get; set; }
    }
}
