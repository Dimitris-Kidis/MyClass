using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.ClassRepository;
using AutoMapper;
using Command.Auth.ChangePassword;
using Command.Auth.Login;
using Command.Auth.Registration;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyClass.Controllers.Common.ViewModels;
using MyClass.Identity;
using Query.Users.GetUser;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyClass.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IClassRepository<ApplicationCore.Domain.Entities.Student> _studRepository;
        public AuthController(
            IMapper mapper,
            IMediator mediator,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IClassRepository<ApplicationCore.Domain.Entities.Student> studRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _userManager = userManager;
            _signInManager = signInManager;
            _studRepository = studRepository;
        }


        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationCommand command)
        {
            if (command == null || !ModelState.IsValid) return BadRequest();
            var result = await _mediator.Send(command);
            if (result == -1) return BadRequest("An error occured...");
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, command.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            if (user != null && user.IsAdmin)
            {
                var adminCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtAdminSecurityToken = new JwtSecurityToken(
                     issuer: AuthOptions.ISSUER,
                     audience: AuthOptions.AUDIENCE,
                     claims: new List<Claim>()
                     {
                     new Claim("username", user.Email),
                     new Claim("id", user.Id.ToString()),
                     new Claim("isAdmin", "true")
                     },
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: adminCredentials
                );
                var tokenAdminHandler = new JwtSecurityTokenHandler();

                var encodedAdminToken = tokenAdminHandler.WriteToken(jwtAdminSecurityToken);
                return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = encodedAdminToken });
            }

            if (user.TeacherId != null)
            {
                var signinCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: AuthOptions.ISSUER,
                     audience: AuthOptions.AUDIENCE,
                     claims: new List<Claim>()
                     {
                     new Claim("username", user.Email),
                     new Claim("id", user.Id.ToString()),
                     new Claim("isAdmin", "false"),
                     new Claim("teacherId", $"{user.TeacherId}"),
                     new Claim("studentId", $"{user.StudentId}"),
                     },
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials
                );
                var tokenHandler = new JwtSecurityTokenHandler();

                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
                return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = encodedToken });
            }
            else
            {

                var signinCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: AuthOptions.ISSUER,
                     audience: AuthOptions.AUDIENCE,
                     claims: new List<Claim>()
                     {
                     new Claim("username", user.Email),
                     new Claim("id", user.Id.ToString()),
                     new Claim("isAdmin", "false"),
                     new Claim("teacherId", $"{user.TeacherId}"),
                     new Claim("studentId", $"{user.StudentId}"),
                     new Claim("classId", $"{_studRepository.FindBy(x => x.Id == user.StudentId).FirstOrDefault().ClassId}"),
                     },
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials
                );
                var tokenHandler = new JwtSecurityTokenHandler();

                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
                return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = encodedToken });
            }

        }

        [HttpPost]
        [Route("logout")]
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpPost]
        [Route("password-reset")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            if (command == null || !ModelState.IsValid) return BadRequest();
            var result = await _mediator.Send(command);
            if (result == -1) return BadRequest("An error occured...");
            return Ok(result);
        }

        [HttpGet("user-data/{userId}")]
        public async Task<IActionResult> GetUserData(int userId)
        {
            var result = await _mediator.Send(new GetUserQuery { UserId = userId });
            if (result == null)
            {
                return BadRequest("Entity is not found");
            }
            return Ok(_mapper.Map<UserViewModel>(result));
        }
    }
}
