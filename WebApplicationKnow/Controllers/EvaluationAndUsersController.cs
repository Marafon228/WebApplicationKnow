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
    public class EvaluationAndUsersController : ApiController
    {
        private ADO db = new ADO();


        //Get
        [ActionName("GettEvaluationAndUser")]
        [ResponseType(typeof(List<EvaluationAndUser>))]
        public IHttpActionResult GetEv()
        {
            //EvaluationAndUser evaluation = db.EvaluationAndUser.FirstOrDefault(u => u.Id == 1);

            //return Ok(db.Product.ToList().ConvertAll(p => new ProductResponse(p)));

            var eval = db.EvaluationAndUser.ToList<EvaluationAndUser>().Select(p => new ResponseEvaluation { Id = p.Id,  IdDay = p.IdDay, Time = p.Time,  IdUser = p.IdUser,  ValueEvaluation = p.ValueEvaluation, SublectName = p.Subject.Name});

            return Ok(eval.ToArray());
        }





        // GET: api/EvaluationAndUsers
        public IQueryable<EvaluationAndUser> GetEvaluationAndUser()
        {
            return db.EvaluationAndUser;
        }

        // GET: api/EvaluationAndUsers/5
        [ResponseType(typeof(EvaluationAndUser))]
        public IHttpActionResult GetEvaluationAndUser(int id)
        {
            EvaluationAndUser evaluationAndUser = db.EvaluationAndUser.Find(id);
            if (evaluationAndUser == null)
            {
                return NotFound();
            }

            return Ok(evaluationAndUser);
        }

        // PUT: api/EvaluationAndUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvaluationAndUser(int id, EvaluationAndUser evaluationAndUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evaluationAndUser.Id)
            {
                return BadRequest();
            }

            db.Entry(evaluationAndUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationAndUserExists(id))
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

        // POST: api/EvaluationAndUsers
        [ResponseType(typeof(EvaluationAndUser))]
        public IHttpActionResult PostEvaluationAndUser(EvaluationAndUser evaluationAndUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EvaluationAndUser.Add(evaluationAndUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = evaluationAndUser.Id }, evaluationAndUser);
        }

        // DELETE: api/EvaluationAndUsers/5
        [ResponseType(typeof(EvaluationAndUser))]
        public IHttpActionResult DeleteEvaluationAndUser(int id)
        {
            EvaluationAndUser evaluationAndUser = db.EvaluationAndUser.Find(id);
            if (evaluationAndUser == null)
            {
                return NotFound();
            }

            db.EvaluationAndUser.Remove(evaluationAndUser);
            db.SaveChanges();

            return Ok(evaluationAndUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvaluationAndUserExists(int id)
        {
            return db.EvaluationAndUser.Count(e => e.Id == id) > 0;
        }
    }
}