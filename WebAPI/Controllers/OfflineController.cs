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
    public class OfflineController : ApiController
    {
        private TestContext context;


        public OfflineController()
        {
            context = new TestContext();

        }

        public void Get(int Id)
        {
            Users usr = this.context.Users.Find(Id);
            usr.Online = false;
            this.context.SaveChanges();


        }


    }
}
