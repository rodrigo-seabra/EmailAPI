﻿using EmailApi.models;
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
            else
            {
                try
                {
                    _context.Add(dataContact);
                    _context.SaveChanges();


                    var resposta = new
                    {
                        status = "success",
                        message = "Mensagem enviada com sucesso!"
                    };

                    return Ok(resposta);
                } catch (Exception ex)
                {
                    // Resposta JSON para erro
                    var erro = new
                    {
                        status = "error",
                        message = $"Erro no envio do e-mail: {ex.Message}"
                    };
                    return StatusCode(500, erro);

                }
            }

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
