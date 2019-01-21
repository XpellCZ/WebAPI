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
    public class MembersController : ApiController
    {

        private TestContext context;

        public MembersController(){

            context = new TestContext();
}


        //Get a list of members of a certain group. Use group's ID as parameter
        public List<Users> Get(int Id)
        {
            List<Users> members = new List<Users>();
            List<GroupsRelations> grRelations = this.context.GrRelations.ToList();

            foreach (GroupsRelations gr in grRelations)
            {
                if(gr.GroupId == Id)
                {
                    members.Add(this.context.Users.Find(gr.UserId));
                }


            }

            return members;

        }

        //Send the object in JSON format
        public void Post(GroupsRelations newRelations)
        {
            GroupsRelations grRelations = new GroupsRelations();
            grRelations.GroupId = newRelations.GroupId;
            grRelations.UserId = newRelations.GroupId;
            grRelations.Nickname = newRelations.Nickname;

            this.context.GrRelations.Add(grRelations);
            this.context.SaveChanges();


        }

        public void Get(int GroupId, int UserId, bool Delete)
        {

            List<GroupsRelations> grRelations = this.context.GrRelations.ToList();

            foreach( GroupsRelations gr in grRelations)
            {

                if (gr.GroupId == GroupId && gr.UserId == UserId && Delete == true)
                {
                    this.context.GrRelations.Remove(gr);
                    break;
                }

            }

            this.context.SaveChanges();


        }

    }
}
