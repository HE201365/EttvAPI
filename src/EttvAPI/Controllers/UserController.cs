using EttvAPI.Models;
using AutoMapper;
using EttvAPI.Data.Models;
using EttvAPI.Help.Extensions;
using Microsoft.AspNetCore.Mvc;
using EttvAPI.Services;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly IMapper _mapper;

        public UserController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService as LoginService;
            _mapper = mapper;
        }

        // Post: api/User
        [HttpPost]
        [Route("Login")]
        public  ActionResult Post([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = _loginService.UserLogin(model);

            if (result == null)
                return BadRequest("Email / Password is not correct");

            var appUserModel = _mapper.Map<AppUser, AppUserModel>(result);
            return Ok(appUserModel);
        }
    }
}