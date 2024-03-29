﻿using System;
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
    public class DelseenController : ApiController
    {

        private TestContext context;

        public DelseenController()
        {

            context = new TestContext();
        }


        public void Get(int UserId,int GroupId)
        {
            List<SeenBy> sn = this.context.SeenBys.ToList();

            foreach(SeenBy seen in sn)
            {
                if (seen.UserId == UserId && seen.GroupId == GroupId)
                {
                    this.context.SeenBys.Remove(seen);
                    this.context.SaveChanges();
                    break;
                }



            }


        }





    }
}
