using AutoMapper;
using InventoryManagementSystem.Common.Exceptions;
using InventoryManagementSystem.Common.Exceptions.UserExceptions;
using InventoryManagementSystem.Dtos.Error;
using InventoryManagementSystem.Dtos.Login;
using InventoryManagementSystem.Dtos.User;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IUserService userService,
            IMapper mapper
            )
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Authenticate user and generate JWT token.
        /// </summary>
        /// <param name="loginRequest">User login credentials.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        /// <remarks>This method authenticates the user and provides a JWT token for authorized access.</remarks>
        [HttpPost("login")]
        [SwaggerResponse(StatusCodes.Status200OK, "Login successful", typeof(LoginResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation error", typeof(FluentValidation.Results.ValidationResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Invalid password", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var token = await _authenticationService.LoginAsync(loginRequest);
                var loginResponse = new LoginResponse(token);
                return Ok(loginResponse);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ErrorResponse("An error occurred", ex.Message));
            }
            catch (InvalidPasswordException ex)
            {
                return Unauthorized(new ErrorResponse("An error occurred", ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(
                    "An error occurred during login.",
                    ex.Message
                ));
            }
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="userRequest">User registration data.</param>
        /// <returns>A response indicating the result of the user registration process.</returns>
        [HttpPost("register")]
        [SwaggerResponse(StatusCodes.Status200OK, "User registered successfully.", typeof(UserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data", typeof(IEnumerable<string>))]
        [SwaggerResponse(StatusCodes.Status409Conflict, "Username or email already exists", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error occurred", typeof(ErrorResponse))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequest userRequest)
        {
            try
            {
                var registeredUser = await _userService.RegisterUserAsync(userRequest);
                return Ok(new { Message = "User registered successfully.", User = registeredUser });
            }
            catch (DuplicateUsernameException ex)
            {
                return Conflict(new ErrorResponse("An error occurred", ex.Message));
            }
            catch (DuplicateEmailException ex)
            {
                return Conflict(new ErrorResponse("An error occurred", ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse(
                    "An error occurred while registering the user.",
                    ex.Message
                ));
            }
        }
    }
}
