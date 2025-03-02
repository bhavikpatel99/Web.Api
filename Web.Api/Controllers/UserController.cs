using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;
using WebApi.Service.Abstracion;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{tenantId}")]
    public async Task<IActionResult> GetUsers(Guid tenantId)
    {
        var users = await _userService.GetUsersAsync(tenantId);
        return Ok(users);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (user == null || string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email))
            return BadRequest("Invalid user data");

        await _userService.CreateUserAsync(user);
        return Ok(new { Message = "User created successfully" });
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
    {
        if (user == null || id == Guid.Empty)
            return BadRequest("Invalid user data");

        user.Id = id;
        await _userService.UpdateUserAsync(user);
        return Ok(new { Message = "User updated successfully" });
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid user ID");

        await _userService.DeleteUserAsync(id);
        return Ok(new { Message = "User deleted successfully" });
    }
}
