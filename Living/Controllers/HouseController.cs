using Dapper;
using Living.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Living.Controllers
{
    public class HouseController : Controller
    {
        // GET: House
        public ActionResult Index()
        {
            ViewBag.Name = GetHead();
            ViewBag.A = GetA();
            ViewBag.B = GetB();
            ViewBag.T = GetTest();

            ViewBag.H = GetHouse();

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Name = GetHead();
            return View();
        }

        public string GetHead() {
            return "House";
        }

        public List<string> GetA() {
            string a;
            int b = 0;
            List<string> x = new List<string>();

            x.Add("Ball");
            x.Add("Bas");

            return x;
        }

        public List<int> GetB()
        {
            string a;
            int b = 0;
            var x = new List<int>();

            x.Add(1000000);
            x.Add(1212121);

            return x;
        }

        public List<TestModel> GetTest() {
            var x = new List<TestModel>();
            x.Add(new TestModel { Name = "Abhisit", Salary = 80000 });
            x.Add(new TestModel { Name = "Supawan", Salary = 80000 });
            x.Add(new TestModel { Name = "Siriwan", Salary = 2000 });

            return x;
        }

        public List<HouseModel> GetHouse()
        {
            var x = new List<HouseModel>();
            x.Add(new HouseModel { HouseNo = "200/14", Area = "Bangna" });
            x.Add(new HouseModel { HouseNo = "1990/1", Area = "Rama 3" });
            x.Add(new HouseModel { HouseNo = "10/560", Area = "Sukhumvit" });
            x.Add(new HouseModel { HouseNo = "30/100", Area = "Rama 4" });
            x.Add(new HouseModel { HouseNo = "100/99", Area = "Ratchada" });

            return x;
        }

        public JsonResult Insert(string data)
        {
            var model = new JavaScriptSerializer().Deserialize<HouseModel>(data);

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LivingConnectionString"].ConnectionString);

            var p = new DynamicParameters();
            p.Add("@HouseNO", model.HouseNo);
            p.Add("@Area", model.Area);

            conn.Query<int>("InsertHouse", p, commandType: CommandType.StoredProcedure);

            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}