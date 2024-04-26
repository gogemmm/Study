using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace WebDemo.Controllers
{
    public class addStudentController : Controller
    {
       Bll Bll = new Bll(); 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.stuName = Request["stuName"].ToString();
            addStudent.Id = Request["id"].ToString();
            addStudent.stuclass = Request["stuclass"].ToString();
            addStudent.birthday = Request["birthday"].ToString();
            addStudent.jg = Request["JG"].ToString();
            int result = Bll.addstu(addStudent.stuName, addStudent.Id, addStudent.stuclass, addStudent.birthday, addStudent.jg);
                if (result > 0)
                {
                    TempData["ErrorMessage"] = "保存成功！";
                    return RedirectToAction("Index", "addStudent");
                }
                else
                {
                    TempData["ErrorMessage"] = "保存失败！";
                    return RedirectToAction("Index", "addStudent");
                }

            return View();
            
        }
    }
}