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
    
    public partial class tblProject
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public string projectCode { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> possibleStartDate { get; set; }
        public Nullable<System.DateTime> possibleEndDate { get; set; }
        public string filePath { get; set; }
        public string status { get; set; }
    }
}
