using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdminForOnlineShoppingApp.Models;
using System.Web.Http.Cors;

namespace AdminForOnlineShoppingApp.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        MiniProject_ShopEntities entities = new MiniProject_ShopEntities();

        [HttpGet]
        public HttpResponseMessage GetAllOrders()
        {
            List<Order> ord = new List<Order>();
            var res = entities.ViewOrders().ToList();
            foreach (var item in res.ToList())
            {
                ord.Add(new Order { Order_Id = item.Order_Id, Prod_id = item.Prod_id, Prod_Price = item.Prod_Price, Prod_Quantity = item.Prod_Quantity, Retail_id = item.Retail_id, User_id=item.User_id });
            }
            return Request.CreateResponse(HttpStatusCode.OK, ord);
        }
    }
}
