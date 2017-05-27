using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISEAC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];
            
            ViewData["SubTitle"] = "Panel Principal";
            ViewData["Message"] = "Indicadores";

            //Pienso poner aqui accesos directos a los modulos e indices contadores (Indicadores)
            //El Top de Noticias podria ser una buena idea

            return View();
        }

        public ActionResult _404()
        {

            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            ViewData["SubTitle"] = "Página No Encontrada";
            ViewData["Message"] = "Lo sentimos, pero la página que busca no ha sido encontrada. Prueba a comprobar la URL de error, luego pulsa el botón de actualización en tu navegador o intenta encontrar algo más en nuestra aplicación.";

            //Pienso poner aqui accesos directos a los modulos e indices contadores (Indicadores)
            //El Top de Noticias podria ser una buena idea

            return View();
        }
    }
}