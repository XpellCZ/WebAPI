using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class FriendsRelations
    {
        public int Id { get; set; }
        public int FirstUser { get; set; }
        public int SecondUser { get; set; }
        public int GroupId { get; set; }

    }
}