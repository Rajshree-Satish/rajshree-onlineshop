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
    public class ProductController : ApiController
    {
        MiniProject_ShopEntities entities = new MiniProject_ShopEntities();

        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            List<Product> pdts = new List<Product>();
            var res = entities.ViewProducts().ToList();
            foreach (var item in res.ToList())
            {
                pdts.Add(new Product { Prod_Id = item.Prod_Id, Prod_Name = item.Prod_Name, Prod_Price = item.Prod_Price, Prod_Quantity = item.Prod_Quantity, Prod_Description = item.Prod_Description, Prod_Image = item.Prod_Image });
            }
            return Request.CreateResponse(HttpStatusCode.OK, pdts);
        }

        [HttpPut]
        public void Put(int id, Product prod)//id from the url and object from the body
        {
            Product UpdateProduct = entities.Products.Where(i=>i.Prod_Id==id).FirstOrDefault();
            UpdateProduct.Prod_Price = prod.Prod_Price;
            UpdateProduct.Prod_Quantity = prod.Prod_Quantity;
            UpdateProduct.Prod_Status = prod.Prod_Status;
            entities.SaveChanges();
        }

        [HttpPost]
        public void Post(Product prod)
        {
            entities.Products.Add(prod);
            entities.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            entities.Products.Where(i => i.Prod_Id == id).FirstOrDefault();
            entities.DeleteProduct(id);
            entities.SaveChanges();
        }
    }
}
