using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;

        }
        // GET: api/users
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        // GET api/users/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound($"User with id = {id} not found");
            }
            return Ok(user);
        }

        // POST api/users
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewUser([FromBody] AddUserRequest userRequest)
        {
            var user = await _userService.AddUser(userRequest);
            if (user == null)
            {
                return BadRequest("Incorrect data(user/householdProduct)");
            }
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT api/users/id
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequest userRequest)
        {
            var user = await _userService.Get(id);
            if (user == null)
            {
                return NotFound($"User with id = {id} not found");
            }

            var userUpdated = await _userService.UpdateUser(id, userRequest);
            if (userUpdated == null)
            {
                return BadRequest();
            }
            return Ok(userUpdated);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userService.Get(id);
            if (user == null)
            {
                return NotFound($"User with id = {id} not found");
            }
            var userDeleted = await _userService.DeleteUser(id);

            return Ok(userDeleted);
        }

    }
}
