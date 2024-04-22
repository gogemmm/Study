using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace WebDemo.Controllers
{
    public class LoginController : Controller
    {
        Bll bll = new Bll();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.UserName = Request["UserName"].ToString();
            
            loginInfo.PassWord = Request["PassWord"].ToString();
            loginInfo.Role = Request["Role"];
            if (bll.login(loginInfo)) 
            {
                //跳转页面代码
                    return RedirectToAction("Index", "HomePage");
 
            }
            else
            {
                //弹窗（密码或者用户错误！！）
                TempData["ErrorMessage"] = "用户名或密码错误！";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
