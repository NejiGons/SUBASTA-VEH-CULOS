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
    public class SubastaVehiculosController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/SubastaVehiculos
        public IQueryable<SubastaVehiculos> GetSubastaVehiculos()
        {
            return db.SubastaVehiculos;
        }

        // GET: api/SubastaVehiculos/5
        [ResponseType(typeof(SubastaVehiculos))]
        public IHttpActionResult GetSubastaVehiculos(int id)
        {
            SubastaVehiculos subastaVehiculos = db.SubastaVehiculos.Find(id);
            if (subastaVehiculos == null)
            {
                return NotFound();
            }

            return Ok(subastaVehiculos);
        }

        // PUT: api/SubastaVehiculos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubastaVehiculos(int id, SubastaVehiculos subastaVehiculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subastaVehiculos.idSubastaVehiculos)
            {
                return BadRequest();
            }

            float comision = subastaVehiculos.ValorVenta * 0.013f;
            subastaVehiculos.ValorComision = comision;

            db.Entry(subastaVehiculos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubastaVehiculosExists(id))
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

        // POST: api/SubastaVehiculos
        [ResponseType(typeof(SubastaVehiculos))]
        public IHttpActionResult PostSubastaVehiculos(SubastaVehiculos subastaVehiculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            float comision = subastaVehiculos.ValorVenta * 0.013f;


            subastaVehiculos.ValorComision = comision;

            db.SubastaVehiculos.Add(subastaVehiculos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subastaVehiculos.idSubastaVehiculos }, subastaVehiculos);
        }

        // DELETE: api/SubastaVehiculos/5
        [ResponseType(typeof(SubastaVehiculos))]
        public IHttpActionResult DeleteSubastaVehiculos(int id)
        {
            SubastaVehiculos subastaVehiculos = db.SubastaVehiculos.Find(id);
            if (subastaVehiculos == null)
            {
                return NotFound();
            }

            db.SubastaVehiculos.Remove(subastaVehiculos);
            db.SaveChanges();

            return Ok(subastaVehiculos);
        }

        [Route("api/SubastaVehiculos/ConTipoVehiculo")]
        [HttpGet]
        public IHttpActionResult GetSubastasConTipoVehiculo()
        {
            var subastasConTipoVehiculo = db.SubastaVehiculos.Include(s => s.TipoVehiculo).Select(s => new
            {
                s.idSubastaVehiculos,
                s.idTipoVehiculo,
                NombreTipoVehiculo = s.TipoVehiculo.Nombre, // Obtener el nombre del tipo de vehículo
                s.Vehiculo,
                s.Vendedor,
                s.Comprador,
                s.ValorVenta,
                s.PlacaVehiculo,
                s.ValorComision,
                s.CiudadEntrega
            });

            return Ok(subastasConTipoVehiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubastaVehiculosExists(int id)
        {
            return db.SubastaVehiculos.Count(e => e.idSubastaVehiculos == id) > 0;
        }
    }
}