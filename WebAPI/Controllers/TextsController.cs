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
    public class TextsController : ApiController
    {
        private TestContext context;


        public TextsController()
        {
            context = new TestContext();

        }

        // Get a list of texts which belong to a certain group. Search by group's Id
        public List<Texts> Get(int Id)
        {
            List<Texts> allTexts = this.context.Texts.ToList();
            List<Texts> result = new List<Texts>();

            foreach(Texts text in allTexts)
            {
                if (text.GroupId == Id)
                {
                    result.Add(text);
                }

            }
            return result;



        }

        //Send the object in JSON format.
        public void Post(Texts newText)
        {
            Texts text = new Texts();
            text.Text = newText.Text;
            text.Attachment = newText.Attachment;
            text.CreatedBy = newText.CreatedBy;
            text.CreationDate = newText.CreationDate;
            text.GroupId = newText.GroupId;
            text.UpdateDate = newText.UpdateDate;

            this.context.Texts.Add(text);
            this.context.SaveChanges();
        }


    }
}
