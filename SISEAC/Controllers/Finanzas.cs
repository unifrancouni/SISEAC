using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISEAC.Controllers
{
    public class FinanzasController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = { "Módulos", "Finanzas" };

            ViewData["SubTitle"] = "Módulo de Finanzas";
            ViewData["Message"] = "Control de ingresos y egresos financieros";
            ViewData["BreadCrumb"] = bc;

            return View();
        }
    }
}