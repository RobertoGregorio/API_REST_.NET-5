using DDD.Data;
using DDD.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiDDD.Services;

namespace WebApiDDD.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        DataContext _dataContext;
        IConfiguration _configuration;

        ITokenService _tokenservice;

        public UserController(DataContext dataContext, IConfiguration configuration, ITokenService tokenservice)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _tokenservice = tokenservice;

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] UserModel userModel)
        {
            try
            {
                if (userModel == null)
                    return BadRequest("Login Inválido.");

                if (userModel.Username != "testeusername" || userModel.Password != "testepassword")
                    return BadRequest("Login Inválido.");

                var token = _tokenservice.CreateNewJwtToken
                (
                    _configuration.GetSection("Jwt").GetSection("key").Value,
                    _configuration.GetSection("Jwt").GetSection("Issuer").Value,
                    _configuration.GetSection("Jwt").GetSection("Audience").Value,
                    userModel
                );

                return Ok(new {token = token});
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao realizar login");
            }
        }
    }
}