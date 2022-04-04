using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationKnow.Models;
using WebApplicationKnow.Models.JSON;

namespace WebApplicationKnow.Controllers
{
    public class UsersController : ApiController
    {
        private ADO db = new ADO();








        // GET: api/Users
        public IQueryable<User> GetUser()
        {
            return db.User;
        }

        // GET: api/Users/5
        [ActionName("Gettsuser")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }


        //Post
        [ActionName("SignIn")]
        [ResponseType(typeof(AuthSigIn))]
        public IHttpActionResult AuthSignIn(AuthSigIn user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            User userNew = db.User.Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault();

            

            //user = db.User.FirstOrDefault(u => u.Login == u.Login && u.Password == u.Password);
            //User users = db.User.Where(u=> u.Login == user.Login && u.Password == user.Password).FirstOrDefault();
            //new User() { Role = db.Role.FirstOrDefault(r => r.Name == "Fisherman"), UserLogin = user.UserLogin, UserPassword = user.UserPassword  };

            //{ Role = db.Role.FirstOrDefault(r => r.Name == "Fisher"), };
            //db.User.Add(userNew);
            //db.SaveChanges();

            //var users = new User() {Id = user.Id, Login = user.Login, Password = user.Password, FirsName = user.FirsName , Adress = user.Adress, Email = user.Email, LastName = user.LastName, MidleName = user.MidleName, Phone = user.Phone  };

            //user = ADO.Instance.User.FirstOrDefault();
            if (userNew == null)
            {
                return Ok(new AuthSignInResponse());
            }
            else
            {
                return Ok(new AuthSignInResponse() { Id = userNew.Id, Login = userNew.Login, Password = userNew.Password, FIO = userNew.FIO, Role = userNew.Role.Name, Address = userNew.Address, Email = userNew.Email, Phone = userNew.Phone, Group = userNew.Group.Name });
            }




        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.User.Count(e => e.Id == id) > 0;
        }
    }
}