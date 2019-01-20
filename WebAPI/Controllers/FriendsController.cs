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
    public class FriendsController : ApiController
    {

        private TestContext context;


        public FriendsController()
        {
            context = new TestContext();

        }


        public List<Users> Get(int Id)
        {
            List<Users> result = new List<Users>();
            List<FriendsRelations> rels = this.context.Friends.ToList();

            foreach (FriendsRelations rel in rels)
            {
                if (rel.FirstUser == Id && rel.SecondUser != Id)
                {
                    Users friend = this.context.Users.Find(rel.SecondUser);
                    result.Add(friend);


                }
                else if (rel.FirstUser != Id && rel.SecondUser == Id)
                {
                    Users friend = this.context.Users.Find(rel.FirstUser);
                    result.Add(friend);


                }



            }

            return result;


        }



    }
}
