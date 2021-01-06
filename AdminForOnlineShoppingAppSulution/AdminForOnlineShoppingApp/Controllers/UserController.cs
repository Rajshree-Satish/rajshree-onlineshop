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
    public class UserController : ApiController
    {
        MiniProject_ShopEntities entities = new MiniProject_ShopEntities();

        [HttpGet]
        public HttpResponseMessage GetAllUsers()
        {
            List<User> users = new List<User>();
            var res = entities.ViewUsers().ToList();
            foreach (var item in res.ToList())
            {
                users.Add(new User { User_Id = item.User_Id, User_Name = item.User_Name, User_Email = item.User_Email, User_Phone = item.User_Phone, User_Address = item.User_Address, User_City=item.User_City,User_Country=item.User_Country,User_Password=item.User_Password,User_Type=item.User_Type });
            }
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        

    }
}
