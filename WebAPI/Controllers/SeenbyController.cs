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
    public class SeenbyController : ApiController
    {

        private TestContext context;


        public SeenbyController()
        {
            context = new TestContext();

        }

        // Get list of SeenBys filtered by GroupId
        public List<SeenBy> Get(int Id)
        {

            List<SeenBy> seen = this.context.SeenBys.ToList();
            List<SeenBy> result = new List<SeenBy>();

            foreach (SeenBy sn in seen)
            {
                if(sn.GroupId == Id)
                {
                    result.Add(sn);
                }


            }

            return result;

        }

        // Post SeenBy as JSON
        public void Post(SeenBy sn)
        {
            this.context.SeenBys.Add(sn);
            this.context.SaveChanges();



        } 


    }
}
