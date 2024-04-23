using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;


namespace WebDemo.Controllers
{
    public class StudentController : Controller
    {
        DAL adl = new DAL ();
        public ActionResult Index()
        {
            DataSet ds = adl.dataSet("select Name,Id,Class,Birthday,JG from Student");


            return View(ds);
        }
    }
}