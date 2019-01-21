using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Texts
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public int CreatedBy { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public string Attachment { get; set; }
        public int GroupId { get; set; }
    }
}