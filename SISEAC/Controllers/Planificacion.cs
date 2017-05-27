using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISEAC.Controllers
{
    public class PlanificacionController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = { "Módulos", "Planificación" };

            ViewData["SubTitle"] = "Módulo de Planificación";
            ViewData["Message"] = "Calendario de actividades";
            ViewData["BreadCrumb"] = bc;

            return View();
        }
    }
}