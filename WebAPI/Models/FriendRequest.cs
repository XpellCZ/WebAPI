using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class FriendRequest
    {

        public int Id { get; set; }
        public int SendToUserId { get; set; }
        public int SendByUserId { get; set; }
        public bool Accepted { get; set; }
        

    }
}