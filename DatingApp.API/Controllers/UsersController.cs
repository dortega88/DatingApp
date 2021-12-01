using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Helpers;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DatingApp.API.Controllers
{
    // [ServiceFilter(typeof(LogUserActivity))]
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        // api/users
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers() 
        {
            return _context.Users.ToList();
        }

        // api/users/3
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id) 
        {
            return _context.Users.Find(id);
        }


        // private readonly IDatingRepository _repo;
        // private readonly IMapper _mapper;
        // private readonly ILogger<UsersController> _logger;

        // OLD UsersController constructor
        // public UsersController (IDatingRepository repo, IMapper mapper, ILogger<UsersController> logger) 
        // {
        //     _mapper = mapper;
        //     _repo = repo;
        //     _logger = logger;
        // }

        // GET api/users
        // [HttpGet]
        // public async Task<IActionResult> GetUsers([FromQuery]UserParams userParams) 
        // {
        //     // return Ok("HI");
        //     // throw new Exception("error");
        //     // _logger.LogError("Not an error. Just to show the custom logger");
        //     // System.Diagnostics.Debugger.Break();
        //     // Console.WriteLine("Hello world");
        //     var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //     var userFromRepo = await _repo.GetUser(currentUserId);
        //     userParams.UserId = currentUserId;
        //     if (string.IsNullOrEmpty(userParams.Gender))
        //     {
        //         userParams.Gender = userFromRepo.Gender == "male" ? "female" : "male";
        //     }
        //     var users = await _repo.GetUsers(userParams);
        //     var usersToReturn = _mapper.Map<IEnumerable<UserForListDTO>>(users);
        //     Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);
        //     return Ok(usersToReturn);
        // }

        // [HttpGet ("{id}", Name = "GetUser")]
        // public async Task<IActionResult> GetUser(int id) {
        //     var user = await _repo.GetUser (id);

        //     var userToReturn = _mapper.Map<UserForDetailedDTO>(user);

        //     return Ok (userToReturn);
        // }


        // [HttpPut ("{id}")]
        // public async Task<IActionResult> UpdateUser(int id, UserForUpdateDTO userForUpdateDTO) 
        // {
        //     if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //         return Unauthorized(); 

        //     var userFromRepo = await _repo.GetUser(id);

        //     _mapper.Map(userForUpdateDTO, userFromRepo);

        //     if (await _repo.SaveAll())
        //         return NoContent();

        //     throw new Exception($"Updating user {id} failed on save!");
        // }

        // [HttpPost ("{id}/like/{recipientId}")]
        // public async Task<IActionResult> LikeUser(int id, int recipientId)
        // {
        //     // return Unauthorized("HI");

        //     if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //     {
        //         return Unauthorized();
        //     }

        //     var like = await _repo.GetLike(id, recipientId);

        //     if (like != null)
        //         return BadRequest("You already like this user.");

        //     if (await _repo.GetUser(recipientId) == null)
        //         return NotFound();

        //     like = new Like
        //     {
        //         LikerId = id,
        //         LikeeId = recipientId
        //     };

        //     _repo.Add<Like>(like);

        //     if (await _repo.SaveAll())
        //         return Ok();

        //     return BadRequest("Failed to like user.");
        // }

    }
}