using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISEAC.Controllers
{
    public class ForoController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = { "Módulos", "Foro" };

            ViewData["SubTitle"] = "Módulo de Foro";
            ViewData["Message"] = "Propuestas de temas de discución";
            ViewData["BreadCrumb"] = bc;

            return View();
        }
    }
}