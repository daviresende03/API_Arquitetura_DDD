using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
         [HttpGet]
         public async Task<ActionResult> GetAll([FromServices] IUserService service)
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 BadRequest
            }

            try
            {
                return Ok (await service.GetAll()); //Se não der nenhum erro irá retornar Ok, caso contrário entra no Catch
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
         }
    }
}