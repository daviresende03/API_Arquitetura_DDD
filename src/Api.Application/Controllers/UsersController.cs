using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

         [HttpGet]
         public async Task<ActionResult> GetAll()  //([FromServices] IUserService service) - Caso não colocar o service no construtor, essa é uma opção
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 BadRequest
            }

            try
            {
                return Ok (await _service.GetAll()); //Se não der nenhum erro irá retornar Ok, caso contrário entra no Catch
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
         }

         [HttpGet]
         [Route("{id}", Name = "GetWithId")]
         public async Task<ActionResult> Get(Guid id)
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok (await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
         }

         [HttpPost]
         public async Task<ActionResult> Post([FromBody] UserEntity user)
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(user);
                if(result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new {id = result.Id})), result); //Inclui no cabeçalho um link para consulta ao objeto criado
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
         }

         [HttpPut]
         public async Task<ActionResult> Put([FromBody] UserEntity user)
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(user);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
         }

         [HttpDelete ("{id}")]
         public async Task<ActionResult> Delete(Guid id)
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
         }
         
    }
}
