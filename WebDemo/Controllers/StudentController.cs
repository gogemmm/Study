using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Newtonsoft.Json.Linq;


namespace WebDemo.Controllers
{
    public class StudentController : Controller
    {
        DAL adl = new DAL();
        Bll Bll = new Bll();
        public ActionResult Index()
        {
            DataSet ds = adl.dataSet("select Name,Id,Class,Birthday,JG from Student");


            return View(ds);
        }
        [HttpPost]
        public ActionResult del(string res)
        {
            string[] dataArray = res.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Array.Resize(ref dataArray, dataArray.Length - 1);
            AddStudent delStudent = new AddStudent();
            delStudent.stuName = dataArray[0].Trim();
            delStudent.Id = dataArray[1];
            delStudent.stuclass = dataArray[2];
            delStudent.birthday = dataArray[3];
            delStudent.jg = dataArray[4];
            int result = Bll.delstu(delStudent.stuName.Replace(" ", ""), delStudent.Id.Replace(" ", ""), delStudent.stuclass.Replace(" ", ""), delStudent.birthday.Replace(" ", ""), delStudent.jg.Replace(" ", ""));
            if (result > 0) {
                TempData["ErrorMessage"] = "删除成功！";
            }
            else
            {
                TempData["ErrorMessage"] = "删除失败！";
            }
            return Content(dataArray[4]);

        }

        [HttpPost]
        public ActionResult updatastu(string res) 
        {
            string[] dataArray = res.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Array.Resize(ref dataArray, dataArray.Length - 1);
            AddStudent updataStudent = new AddStudent();
            updataStudent.stuName = dataArray[0].Trim();
            updataStudent.Id = dataArray[1];
            updataStudent.stuclass = dataArray[2];
            updataStudent.birthday = dataArray[3];
            updataStudent.jg = dataArray[4];
            int result = Bll.updatastu(updataStudent.stuName.Replace(" ", ""), updataStudent.Id.Replace(" ", ""), updataStudent.stuclass.Replace(" ", ""), updataStudent.birthday.Replace(" ", ""), updataStudent.jg.Replace(" ", ""));
            if (result > 0)
            {
                TempData["ErrorMessage"] = "修改成功！";
            }
            else
            {
                TempData["ErrorMessage"] = "修改失败！";
            }
            return Content(dataArray[4]);
        }

    }
}