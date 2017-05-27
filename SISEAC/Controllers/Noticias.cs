using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISEAC.Controllers
{
    public class NoticiasController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = {};

            ViewData["SubTitle"] = "Noticias";
            ViewData["Message"] = "Estar al tanto";
            ViewData["BreadCrumb"] = bc;

            return View();
        }
    }
}