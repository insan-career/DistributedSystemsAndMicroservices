using DistributedSystemsAndMicroservices.Models;
using DistributedSystemsAndMicroservices.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistributedSystemsAndMicroservices.Controllers;

public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("api/[controller]/GetUsers")]
    public IActionResult GetUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }
    
    [HttpGet]
    [Route("api/[controller]/GetUser/{id}", Name = "GetUser")]
    public IActionResult GetUser(int id)
    {
        try
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [Route("api/[controller]/AddUser")]
    public IActionResult AddUser([FromBody] User? user)
    {
        if (user == null)
        {
            return BadRequest("Please provide name and email in the request body");
        }
        
        if (user.Id != 0)
        {
            return BadRequest("Id should not be provided in the request body.");
        }
        
        var userAdded = _userService.AddUser(user);

        if (!userAdded)
        {
            return BadRequest($"User with email address {user.Email} already exist or invalid");
        }
        
        return CreatedAtRoute("GetUser", new { id = user.Id }, user);
    }
}