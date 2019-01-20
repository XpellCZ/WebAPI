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
    public class SearchController : ApiController
    {


        private TestContext context;


        public SearchController()
        {
            context = new TestContext();

        }

        public Users Get(int Id)
        {
            List<Users> userList = this.context.Users.ToList();
            Users final = new Users();

            foreach(Users usr in userList)
            {
                if (usr.UniId == Id)
                {
                    final = usr;
                    break;
                }


            }

            return final;

        }




    }
}
