using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using App.Core.Interfaces;
using App.Core.Entities;
using Microsoft.Extensions.Options;
using App;
using App.Core;

namespace WebApi.Controllers
{
    // Implementation based largely on http://jasonwatmore.com/post/2018/06/26/aspnet-core-21-simple-api-for-authentication-registration-and-user-management#user-dto-cs
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public AppSettings _settings { get; }

        public UsersController(IUserService userService, IOptions<AppSettings> settings)
        {
            _userService = userService;
            _settings = settings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.AuthKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }
        
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            var user = new User()
            {
                 FirstName = userDto.FirstName,
                 LastName = userDto.LastName,
                 UserName = userDto.Username
            };

            try
            {
                _userService.Create(user, userDto.Password);
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            List<UserDto> list = new List<UserDto>();
            foreach(var user in users)
            {
                var userDto = GetUserDto(user);
                list.Add(userDto);
            }

            return Ok(list);
        }

        private static UserDto GetUserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Password = string.Empty
            };
        }

        [HttpPost("GetById/{id}")]
        public IActionResult GetById(string id)
        {
            var user = _userService.GetById(id);
            var userDto = GetUserDto(user);
            return Ok(userDto);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}