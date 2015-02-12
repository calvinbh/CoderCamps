using Bug_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Work_Tracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Db.WorkItems);
        }

        public ActionResult Chores()
        {
            List<Chore> model = Db.WorkItems.Where(x => x.WorkItemType == WorkItemType.Chore).Cast<Chore>().ToList();
            return View(model);
        }

        public ActionResult Bugs()
        {
            List<Bug> model = Db.WorkItems.Where(x => x.WorkItemType == WorkItemType.Bug).Cast<Bug>().ToList();
            return View(model);
        }
    }
}