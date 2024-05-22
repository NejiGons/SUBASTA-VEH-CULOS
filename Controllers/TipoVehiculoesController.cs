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
using subasta.Models;

namespace subasta.Controllers
{
    public class TipoVehiculoesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/TipoVehiculoes
        public IQueryable<TipoVehiculo> GetTipoVehiculo()
        {
            return db.TipoVehiculo;
        }

        // GET: api/TipoVehiculoes/5
        [ResponseType(typeof(TipoVehiculo))]
        public IHttpActionResult GetTipoVehiculo(int id)
        {
            TipoVehiculo tipoVehiculo = db.TipoVehiculo.Find(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return Ok(tipoVehiculo);
        }

        // PUT: api/TipoVehiculoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoVehiculo(int id, TipoVehiculo tipoVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoVehiculo.idTipoVehiculo)
            {
                return BadRequest();
            }

            db.Entry(tipoVehiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVehiculoExists(id))
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

        // POST: api/TipoVehiculoes
        [ResponseType(typeof(TipoVehiculo))]
        public IHttpActionResult PostTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoVehiculo.Add(tipoVehiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoVehiculo.idTipoVehiculo }, tipoVehiculo);
        }

        // DELETE: api/TipoVehiculoes/5
        [ResponseType(typeof(TipoVehiculo))]
        public IHttpActionResult DeleteTipoVehiculo(int id)
        {
            TipoVehiculo tipoVehiculo = db.TipoVehiculo.Find(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            db.TipoVehiculo.Remove(tipoVehiculo);
            db.SaveChanges();

            return Ok(tipoVehiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoVehiculoExists(int id)
        {
            return db.TipoVehiculo.Count(e => e.idTipoVehiculo == id) > 0;
        }
    }
}