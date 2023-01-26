using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    /// <summary>
    /// The Class of this project
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        /// <summary>
        /// The list that contains every devises
        /// </summary>
        public List<Devise> listDevises;

        /// <summary>
        /// The controller of this class
        /// </summary>
        public DevisesController()
        {
            listDevises = new List<Devise>();
            listDevises.Add(new Devise(1, "Dollar", 1.08));
            listDevises.Add(new Devise(2, "Franc Suisse", 1.07));
            listDevises.Add(new Devise(3, "Yen", 120));
        }

        /// <summary>
        /// Get all data.
        /// </summary>
        /// <returns>Http response</returns>
        // GET: api/<DevisesController>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Devise> GetAll()
        {
            return listDevises;
        }


        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise =
                (from d in listDevises
                 where d.Id == id
                 select d).FirstOrDefault();
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        /// <summary>
        /// Add a devise to the list.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">The devise object</param>
        /// <response code="400">When the currency id is bad request</response>
        // POST api/<DevisesController>
        [HttpPost]
        [ProducesResponseType(400)]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            listDevises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Update a devise that already exist.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <param name="devise">The object devise</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="400">When the currency id is bad request</response>
        /// <response code="404">When the currency id is not found</response>
        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = listDevises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            listDevises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Delete a object devise
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="404">When the currency id is not found</response>
        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? devise =
                (from d in listDevises
                 where d.Id == id
                 select d).FirstOrDefault();
            if (devise == null)
            {
                return NotFound();
            }
            listDevises.Remove(devise);
            return NoContent();
        }
    }
}
