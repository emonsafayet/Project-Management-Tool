//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagmentTool.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUser
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> designationId { get; set; }
    
        public virtual tblDesignation tblDesignation { get; set; }
    }
}
