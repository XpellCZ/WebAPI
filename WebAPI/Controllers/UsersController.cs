using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private TestContext context;


        public UsersController()
        {
            context = new TestContext();

        }

        public List<Users> Post() {

            return this.context.Users.ToList();


        }

    }
}
