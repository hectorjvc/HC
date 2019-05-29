using HC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace HC.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(EmployeeModel emp)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1204");
                int result = client.PostAsync("/api/services",
                                      emp,
                                      new JsonMediaTypeFormatter())
                            .Result
                            .Content
                            .ReadAsAsync<int>()
                            .Result;


            }

            return RedirectToAction("Index");
        }


    }
}