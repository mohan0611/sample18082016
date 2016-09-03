using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace sample18082016.Controllers
{
    public class TimesheetsController : Controller
    {
        // GET: Timesheets
        public ActionResult Index()
        {
            List<TimesheetEntry> obj = new List<TimesheetEntry>()
                        {
                            new TimesheetEntry() {TimesheetId = 1, ProjectName ="Project 1", ActivityName = "Coding", day1 = 0, day2 = 0 },
                            new TimesheetEntry() {TimesheetId = 24, ProjectName ="Project 2", ActivityName = "Coding"}
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
            //                new TimesheetEntry() {P5rojectName ="Project 1", ActivityName = "Coding", day1 = -1, day2 = -1 }
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


            ViewBag.ErrorMessage = "Please fill the Project Name and Activity in Row 2";

            return View(obj);
        }
    }


    public class TimesheetEntry
    {

        public int TimesheetId { get; set; }

        [StringLength(20)]
        [Required]
        public string ProjectName { get; set; }

        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string ActivityName { get; set; }

        //public string StartDate { get; set; }
        [Range(0, 24)]
        public Decimal day1 { get; set; }

        [Range(0, 24)]
        public Decimal day2 { get; set; }

    }
}