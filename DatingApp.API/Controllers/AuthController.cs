using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers 
{
    [Route ("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly IAuthRepository _repo;
        // Why am I initilizing these parameters from a56uth controller, and is renaming using the underscore for private 
        // class part of clean code
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController (IAuthRepository repo, IConfiguration config, IMapper mapper) 
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;
        }

        // [HttpPost ("register")]
        // public async Task<IActionResult> Register (UserForRegisterDTO userForRegisterDTO) 
        // {
        //     userForRegisterDTO.UserName = userForRegisterDTO.UserName.ToLower();

        //     if (await _repo.UserExists (userForRegisterDTO.UserName))
        //         return BadRequest ("Username already exists");

        //     var userToCreate = _mapper.Map<AppUser>(userForRegisterDTO);

        //     var createdUser = await _repo.Register (userToCreate, userForRegisterDTO.Password);

        //     var userToReturn = _mapper.Map<UserForDetailedDTO>(createdUser);

        //     return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.Id }, userToReturn);
        // }

        // [HttpPost ("login")]
        // public async Task<IActionResult> Login (UserForLoginDTO userforLoginDTO) 
        // {
        //     var userFromRepo = await _repo.Login (userforLoginDTO.UserName.ToLower(), userforLoginDTO.Password);

        //     if (userFromRepo == null)
        //         return Unauthorized ();

        //     var claims = new [] 
        //     {
        //         new Claim (ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        //         new Claim (ClaimTypes.Name, userFromRepo.UserName)
        //     };

        //     var key = new SymmetricSecurityKey (Encoding.UTF8
        //         .GetBytes (_config.GetSection ("AppSettings:Token").Value));

        //     var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

        //     var tokenDescriptor = new SecurityTokenDescriptor 
        //     {
        //         Subject = new ClaimsIdentity (claims),
        //         Expires = DateTime.Now.AddDays (1),
        //         SigningCredentials = creds
        //     };

        //     var tokenHandler = new JwtSecurityTokenHandler ();

        //     var token = tokenHandler.CreateToken (tokenDescriptor);

        //     var user = _mapper.Map<UserForListDTO>(userFromRepo);

        //     return Ok (new 
        //     {
        //         token = tokenHandler.WriteToken (token),
        //         user
        //     });
        // }
    }
}