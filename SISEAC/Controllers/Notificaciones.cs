using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISEAC.Controllers
{
    public class NotificacionesController : Controller
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

            ViewData["SubTitle"] = "Notificaciones";
            ViewData["Message"] = "Historial de notificaciones";
            ViewData["BreadCrumb"] = bc;

            return View();
        }
    }
}