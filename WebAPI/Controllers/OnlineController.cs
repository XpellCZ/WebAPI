using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [EnableCors(origins: "http://localhost:50328", headers: "*", methods: "*")]
    public class OnlineController : ApiController
    {

        private TestContext context;


        public OnlineController()
        {
            context = new TestContext();

        }

        // Change status of user to online
        public void Get(int Id)
        {
            Users usr = this.context.Users.Find(Id);
            usr.Online = true;
            this.context.SaveChanges();

           
        }


    }
}
