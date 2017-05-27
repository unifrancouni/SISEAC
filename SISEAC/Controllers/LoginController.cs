using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISEAC.Models;

namespace SISEAC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ReturnUrl = Url.Action("Index", "Home");

            if (TempData["Mensaje"] != null && TempData["MensajeType"] != null)
            {
                ViewBag.Mensaje = TempData["Mensaje"];
                ViewBag.MensajeType = TempData["MensajeType"];
                ViewBag.MensajeTitle = TempData["MensajeTitle"];
            }
            else
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeType = "";
                ViewBag.MensajeTitle = "";
            }

            return View();
        }

        public ActionResult Login(string ReturnUrl, string UserName, string Password)
        {
            Session["Sesion"] = UserName;

            var db = new Models.EntStdUniAtd();
            string strSQL = "Select 1 from SsgCuenta where sNombreUsuario='"+UserName+"' and sClave='"+Password+"'";
            var existe = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();

            if (existe==1)
                return Redirect(ReturnUrl);
            else
            {
                TempData["Mensaje"] = "Error: El usuario o contraseña está incorrecto.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Index");
            }

        }

        public ActionResult Logout()
        {
            //var db = new EntStdUniAtd();

            //string strSQL = "delete From SsgSesion Where [user]='" + Session["Sesion"] + "'";
            //db.Database.ExecuteSqlCommand(strSQL);

            Session["Sesion"] = null;

            return RedirectToAction("Index");
        }

    }
}