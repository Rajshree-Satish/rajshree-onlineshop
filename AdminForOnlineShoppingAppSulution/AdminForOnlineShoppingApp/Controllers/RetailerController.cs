using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AdminForOnlineShoppingApp.Models;

namespace AdminForOnlineShoppingApp.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class RetailerController : ApiController
    {
        MiniProject_ShopEntities entities = new MiniProject_ShopEntities();

        [HttpGet]
        public HttpResponseMessage GetAllRetailers()
        {
            List<Retailer> rlts = new List<Retailer>();
            var res = entities.ViewRetailers().ToList();
            foreach (var item in res.ToList())
            {
                rlts.Add(new Retailer { Retail_Id = item.Retail_Id, Retail_Name = item.Retail_Name, Retail_Email = item.Retail_Email, Retail_Phone = item.Retail_Phone, Retail_Status = item.Retail_Status, Retail_Password = item.Retail_Password });
            }
            return Request.CreateResponse(HttpStatusCode.OK, rlts);
        }

        [HttpPut]
        public void Put(int id, Retailer retailer)//id from the url and object from the body
        {
            Retailer UpdateRetailer = entities.Retailers.Where(r=>r.Retail_Id==id).FirstOrDefault();
            UpdateRetailer.Retail_Status = retailer.Retail_Status;

            entities.SaveChanges();
        }

        [HttpPost]
        public void Post(Retailer retailer)
        {
            entities.Retailers.Add(retailer);
            entities.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            entities.Retailers.Where(r => r.Retail_Id == id).FirstOrDefault();
            entities.DeleteRetailers(id);
            entities.SaveChanges();
        }
    }
}
