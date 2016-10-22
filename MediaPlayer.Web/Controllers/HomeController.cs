using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaPlayer.Data;

namespace MediaPlayer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationIdentityDbContext _dbContext;

        public HomeController(ApplicationIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}