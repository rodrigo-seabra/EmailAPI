using EmailApi.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailApi.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataContactController : ControllerBase
    {
        private readonly Contexto _context;

        public DataContactController(Contexto context)
        {
            _context = context;
        }
        // GET: api/<DataContactController>
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _context.DataContact.ToList();
            return Ok(posts);
        }

        // GET api/<DataContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        [HttpPost]
        public IActionResult CreatePost([FromBody] DataContact dataContact)
        {
            if (dataContact == null)
            {
                return BadRequest("Dados inválidos");
            }

            _context.Add(dataContact);
            _context.SaveChanges();

            return Ok("Post criado com sucesso");
        }

        // PUT api/<DataContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
