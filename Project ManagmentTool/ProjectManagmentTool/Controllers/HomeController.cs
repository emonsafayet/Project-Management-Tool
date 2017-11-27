using ProjectManagmentTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagmentTool.Controllers
{
    public class HomeController : Controller
    {
        ManagmentToolEntities1 db = new ManagmentToolEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUserList ()
        {
            List<UserViewModel> UserList = db.tblUsers.Where(u => u.status == true).Select(x => new UserViewModel
            {
                userId = x.userId,
                userName = x.userName,
                userEmail = x.userEmail,
                userPassword = x.userPassword,
                designationId = x.tblDesignation.designationId,
                designationName = x.tblDesignation.designationName

            }).ToList();
            return Json(UserList, JsonRequestBehavior.AllowGet);
        }   

    }
}