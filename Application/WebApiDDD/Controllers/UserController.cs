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

        public UserController(DataContext dataContext , IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserModel userModel, ITokenService _tokenservice)
        {
            try
            {
                if (userModel == null)
                    BadRequest("Login Inválido.");

                if (userModel.Username != "testeusername" || userModel.Password != "testepassword")
                    BadRequest("Login Inválido.");

                var token = _tokenservice.CreateNewJwtToken
                (
                    _configuration.GetSection("Jwt").GetSection("key").Value,
                    _configuration.GetSection("Jwt").GetSection("Issuer").Value,
                    _configuration.GetSection("Jwt").GetSection("Audience").Value,
                    userModel
                );

                return Ok($"Token: {token}");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro ao realizar login");
            }
        }
    }
}