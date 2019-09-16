using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace help.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            var usuarioLogado = HttpContext.Session["admin"];
            if(usuarioLogado == null)
            {
                return Redirect("/Usuario/Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Deslogar()
        {
            HttpContext.Session.Clear();
            return Redirect("/Usuario/Login");
        }
    }
}