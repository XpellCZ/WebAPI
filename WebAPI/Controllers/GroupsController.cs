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
    public class GroupsController : ApiController
    {
        private TestContext context;

        public GroupsController()
        {
            context = new TestContext();

        }

        // Get groups in which user participates. Search by user's ID
        public List<Groups> Get(int Id)
        {
            List<GroupsRelations> grRelations = this.context.GrRelations.ToList();
            List<Groups> userGroups = new List<Groups>();

            foreach(GroupsRelations gr in grRelations)
            {
                if (gr.UserId == Id)
                {
                    userGroups.Add(this.context.Groups.Find(gr.GroupId));
                }

            }

            return userGroups;

        }

        public List<Groups> Get(int Id,bool More)
        {
            List<GroupsRelations> grRelations = this.context.GrRelations.ToList();
            List<Groups> userGroups = new List<Groups>();

            foreach (GroupsRelations gr in grRelations)
            {
                int count = 0;

                foreach(GroupsRelations gre in grRelations)
                {
                    if (gre.GroupId == gr.GroupId)
                    {
                        count++;
                    }
                }


                if (gr.UserId == Id&&count>2&&More==true)
                {
                    userGroups.Add(this.context.Groups.Find(gr.GroupId));
                } else if(gr.UserId == Id&&count==2&&More == false)
                {
                    userGroups.Add(this.context.Groups.Find(gr.GroupId));
                }

            }

            return userGroups;

        }



        //Send the object in JSON format.
        public void Post(Groups newGroup)
        {
            Groups gr = new Groups();
            gr.Name = newGroup.Name;

            this.context.Groups.Add(gr);
            this.context.SaveChanges();




        }



    }
}
