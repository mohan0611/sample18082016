using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample18082016.Controllers
{
    public class TestJqgridController : Controller
    {
        // GET: TestJqgrid
        public ActionResult Index()
        {


            return View();
        }

        public JsonResult GetCountryLists(string sidx, string sord, int page, int rows)  //Gets the todo Lists.
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            //var countryresult = db.Countries.Select(
            //        a => new
            //        {
            //            a.CountryId,
            //            a.CountryName,
            //            a.Primarylanguage
            //        });

            var obj = new List<Country>()
                        {
                            new Country() {CountryID = 1, CountryName ="Africa 1", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 2, CountryName ="Africa 2", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 3, CountryName ="Africa 3", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 4, CountryName ="Africa 4", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 5, CountryName ="Africa 5", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 6, CountryName ="Africa 6", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 7, CountryName ="Africa 7", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 8, CountryName ="Africa 8", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 9, CountryName ="Africa 9", CapitalCity = "City 1", Population = 1000 },
                            new Country() {CountryID = 10, CountryName ="Africa 10", CapitalCity = "City 1", Population = 1000 }
                        };

            var obj1 = obj.AsQueryable();
            int totalRecords = obj1.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                obj1 = obj1.OrderByDescending(s => s.CountryName);
                obj1 = obj1.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                obj1 = obj1.OrderBy(s => s.CountryName);
                obj1 = obj1.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = obj1
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }

    public class Country
    {

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CapitalCity { get; set; }
        public int Population { get; set; }

    }
}