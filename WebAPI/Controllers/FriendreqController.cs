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
    public class FriendreqController : ApiController
    {


        private TestContext context;


        public FriendreqController()
        {
            context = new TestContext();

        }


        public List<FriendRequest> Get(int Id)
        {
            List<FriendRequest> result = new List<FriendRequest>();
            List<FriendRequest> reqs = this.context.FriendReq.ToList();


            foreach(FriendRequest req in reqs)
            {
                if (req.SendToUserId == Id)
                {

                    result.Add(req);
                }


            }

            return result;

        }

        public void Get(int ReqId,bool Accepted)
        {
            FriendRequest req = this.context.FriendReq.Find(ReqId);

            if (Accepted == true)
            {
                FriendsRelations newRel = new FriendsRelations();
                newRel.FirstUser = req.SendByUserId;
                newRel.SecondUser = req.SendToUserId;

                this.context.Friends.Add(newRel);
                this.context.FriendReq.Remove(req);
                


            } else if (Accepted == false)
            {
                this.context.FriendReq.Remove(req);

            }



            this.context.SaveChanges();


        }




        public void Post(FriendRequest newReq)
        {

            List<FriendRequest> reqs = this.context.FriendReq.ToList();
            List<FriendsRelations> rels = this.context.Friends.ToList();
            bool exists = false;

            foreach(FriendRequest req in reqs)
            {
                if (newReq.SendByUserId == req.SendByUserId && newReq.SendToUserId == req.SendToUserId)
                {
                    exists = true;
                    break;
                }

            }

            foreach (FriendsRelations rel in rels)
            {
                if ((rel.FirstUser==newReq.SendByUserId&&rel.SecondUser==newReq.SendToUserId)||(rel.FirstUser==newReq.SendToUserId&&rel.SecondUser==newReq.SendByUserId))
                {
                    exists = true;
                    break;
                }

            }

            if (!exists)
            {

                this.context.FriendReq.Add(newReq);
                this.context.SaveChanges();


            }


        }


    }
}
