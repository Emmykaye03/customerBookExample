using dataTable.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace dataTable.Content
{
    public class CustomerController : Controller
    {
        private List<Customer> Customers = new List<Customer>();
        [HttpGet]
        public ActionResult Index()
        {
            CustomerGet();
            return View(Customers.OrderBy(c => c.ItemID).ToList());
        }
        private void CustomerGet()
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("~/Content/customer.json")))
            {
                Customers = JsonConvert.DeserializeObject<List<Customer>>(sr.ReadToEnd());
            }
        }
    }
}