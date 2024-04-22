using InventoryManagementSystem.Common.Exceptions;
using InventoryManagementSystem.Common.Exceptions.UserExceptions;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos.Login;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Services;
public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthenticationService(
        IUserService userService,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator tokenGenerator,
        ILogger<AuthenticationService> logger
        )
    {
        _userService = userService;
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userService.GetUserByUsernameAsync(loginRequest.Username);
        if (user == null)
        {
            _logger.LogWarning("User '{Username}' not found.", loginRequest.Username);
            throw new NotFoundException($"User '{loginRequest.Username}' not found.");
        }

        VerifyUserPassword(loginRequest, user);
        return _tokenGenerator.GenerateToken(user);
    }

    private void VerifyUserPassword(LoginRequest login, User user)
    {
        if (!_passwordHasher.VerifyPassword(login.Password, user.Password))
        {
            _logger.LogWarning("Authentication failed: Invalid password for user {Username}.", login.Username);
            throw new InvalidPasswordException("Invalid password.");
        }

        _logger.LogInformation("User {Username} authenticated successfully.", login.Username);
    }
}
