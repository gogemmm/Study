using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace WebDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Check_Login() 
        //{
        //    string Name = Request.Params["Name"].ToString();
        //    string PassWord = Request.Params["PassWord"].ToString();
        //    string Role = Request.Params["Role"].ToString();
        //    return View("Index");
        //}
        public ActionResult Check_Login(LoginInfo loginInfo) 
        {
            string Name = loginInfo.Name;
            string PassWord = loginInfo.PassWord;
            string Role = loginInfo.Role;
            return View("Index");
        }
    }
}