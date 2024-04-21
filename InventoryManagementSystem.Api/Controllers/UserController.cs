using AutoMapper;
using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Dtos.Error;
using InventoryManagementSystem.Dtos.User;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper
            )
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);

                if (user == null)
                {
                    return NotFound(new { Message = $"User with ID {userId} not found." });
                }

                var userResponse = _mapper.Map<UserResponse>(user);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(
                    "An error occurred while fetching the user.",
                    ex.Message));
            }
        }
    }
}
