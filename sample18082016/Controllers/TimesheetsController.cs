using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample18082016.Controllers
{
    public class TimesheetsController : Controller
    {
        // GET: Timesheets
        public ActionResult Index()
        {
            List<TimesheetEntry> obj = new List<TimesheetEntry>()
                        {
                            new TimesheetEntry() {ProjectName ="Project 1", ActivityName = "Coding", day1 = -1, day2 = -1 },
                            new TimesheetEntry() {ProjectName ="Project 2", ActivityName = "Coding", day1 = -1, day2 = -1 }
                        };


            //public List<TimesheetEntry> obj = new List<TimesheetEntry>();
            ////;{
            ////                                new TimesheetEntry() {ProjectName ="Project 1", ActivityName = "Coding", day1 = -1, day2 = -1 }
            ////                            };
            

            return View(obj);
        }

        [HttpPost]
        //public ActionResult Index(FormCollection obj)
        public ActionResult Index(List<TimesheetEntry> obj)
        {
            //List<TimesheetEntry> obj = new List<TimesheetEntry>()
            //            {
            //                new TimesheetEntry() {ProjectName ="Project 1", ActivityName = "Coding", day1 = -1, day2 = -1 }
            //            };


            //public List<TimesheetEntry> obj = new List<TimesheetEntry>();
            ////;{
            ////                                new TimesheetEntry() {ProjectName ="Project 1", ActivityName = "Coding", day1 = -1, day2 = -1 }
            ////                            };

            //foreach (var key in obj.AllKeys)
            //{
            //    var value = obj[key];
            //    // etc.
            //}

            //foreach (var key in obj.Keys)
            //{
            //    var objEntry = new TimesheetEntry();
            //    //objEntry.ProjectName = 
            //    var value = obj[key.ToString()];
            //    // etc.
            //}




            return View(obj);
        }
    }


    public class TimesheetEntry
    {
        public string ProjectName { get; set; }
        public string ActivityName { get; set; }
        //public string StartDate { get; set; }
        public Decimal day1 { get; set; }
        public Decimal day2 { get; set; }

    }
}