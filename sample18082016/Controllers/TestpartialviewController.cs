using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using sampleentity.Entity;

namespace sample18082016.Controllers
{
    public class TestpartialviewController : Controller
    {
        private ProductTestDBEntities1 db = new ProductTestDBEntities1();

        // GET: Testpartialview
        public ActionResult Index()
        {
            return View();
        }

        //Add new employee
        public ActionResult Addnew()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "CountryId", "CountryName");
            var obj = new Customer();
            return PartialView("_addNewEmployee", obj);
        }



        public ActionResult Addnew1(Customer obj)
        {
            if (obj.CustomerID > 0)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Customers.Add(obj);
                db.SaveChanges();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryId", "CountryName");
            //var obj = new Customer();
            return PartialView("_addNewEmployee", obj);
        }

        public ActionResult edit(int CustomerID)
        {
            var obj = db.Customers.Find(CustomerID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryId", "CountryName");
            //var obj = new Customer();
            return PartialView("_addNewEmployee", obj);
        }

        public ActionResult Create(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentFilter = searchString;


            var customers = db.Customers.Include(c => c.Country);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            System.Threading.Thread.Sleep(1000);

            //return View(await customers.ToListAsync());
            return PartialView("_CreateEmployee", customers.OrderBy(s => s.CustomerID).ToPagedList(pageNumber, pageSize));

            //if (Request.IsAjaxRequest())
            //{
            //    ViewBag.IsUpdate = false;

            //}
            //else

            //    return View();
        }


        public ActionResult View(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CurrentFilter = searchString;


            var customers = db.Customers.Include(c => c.Country);
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //return View(await customers.ToListAsync());
            return PartialView("_ViewEmployee", customers.OrderBy(s => s.CustomerID).ToPagedList(pageNumber, pageSize));

        }
    }
}