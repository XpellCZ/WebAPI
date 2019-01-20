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
    public class UsersController : ApiController
    {
        private TestContext context;


        public UsersController()
        {
            context = new TestContext();

        }


        //Send the object in JSON format.
        public void Post([FromBody]Users newUser)
        {
            List<Users> usersFromDb = this.context.Users.ToList();
            bool exists = false;
            bool edit = false;

            foreach (Users usr in usersFromDb)
            {
                if (usr.Email == newUser.Email || usr.Username == newUser.Username)
                {
                    exists = true;
                }

                if (usr.Id == newUser.Id)
                {
                    edit = true;
                }


            }



            if (exists==false&&edit==false)
            {

                Users user = new Users();
                user.ImgPath = newUser.ImgPath;
                user.Online = newUser.Online;
                user.Description = newUser.Description;
                user.Email = newUser.Email;
                user.FullName = newUser.FullName;
                user.Password = newUser.Password;
                user.Username = newUser.Username;


                this.context.Users.Add(user);

            } else if (edit==true&&exists==false)
            {
                Users user = this.context.Users.Find(newUser.Id);
                user.ImgPath = newUser.ImgPath;
                user.Online = newUser.Online;
                user.Description = newUser.Description;
                user.Email = newUser.Email;
                user.FullName = newUser.FullName;
                user.Password = newUser.Password;
                user.Username = newUser.Username;




            }

            this.context.SaveChanges();
        }


        public List<Users> Get() {

            return this.context.Users.ToList();


        }

        public Users Get(string email)
        {
            Users foundUser=null;
            List<Users> users = this.context.Users.ToList();

            foreach(Users user in users){

                if (user.Email == email)
                {
                    foundUser = user;
                    return foundUser;
                }


            }
            return foundUser;
        }

        public Users Get(int Id)
        {
            Users foundUser = this.context.Users.Find(Id);
            //List<Users> users = this.context.Users.ToList();

            //foreach (Users user in users)
            //{

            //    if (user.Id == Id)
            //    {
            //        foundUser = user;
            //        return foundUser;
            //    }


            //}
            return foundUser;
        }


       

    }
}
