using Newtonsoft.Json;
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
            List<tblDesignation> DesignationList = db.tblDesignations.ToList();
            ViewBag.ListOfDesignation = new SelectList(DesignationList, "designationId", "designationName");
            return View();
        }
        public JsonResult GetUserList ()
        {
            List<UserViewModel> UserList = db.tblUsers.Where(x=>x.isDeleted == false).Select(x => new UserViewModel
            {
                userId = x.userId,
                userName = x.userName,
                userEmail = x.userEmail,
                userPassword = x.userPassword,
                status =x.status,
                designationId = x.tblDesignation.designationId,
                designationName = x.tblDesignation.designationName

            }).ToList();
            
            return Json(UserList, JsonRequestBehavior.AllowGet);
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserById(int userId)
        {
            tblUser model = db.tblUsers.Where(x=> x.userId == userId).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model,Formatting.Indented,new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveUser(UserViewModel model)
        {
            var result = false;
            try
            {
                if(model.userId>0)
                {
                    tblUser u = db.tblUsers.SingleOrDefault(x => x.isDeleted == false && x.userId == model.userId);
                    u.userName = model.userName;
                    u.userEmail = model.userEmail;
                    u.userPassword = model.userPassword;
                    u.status = model.status;
                    u.designationId = model.designationId;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    tblUser u = new tblUser();
                    u.userName = model.userName;
                    u.userEmail = model.userEmail;
                    u.userPassword = model.userPassword;
                    u.status = model.status;
                    u.isDeleted = false;
                    u.designationId = model.designationId;
                    db.tblUsers.Add(u);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       /// <summary>
       /// Delete user informations
       /// </summary>
       /// <returns></returns>
        public JsonResult DeleteUserRecord(int userId)
        {
            bool result = false;
            tblUser us = db.tblUsers.SingleOrDefault(x =>x.isDeleted == false && x.userId == userId);
            if (us != null)
            {
                us.isDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}