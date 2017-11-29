using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class UserViewModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public bool status { get; set; }
        public Nullable<int> designationId { get; set; }
        public string designationName { get; set; }


    }
}