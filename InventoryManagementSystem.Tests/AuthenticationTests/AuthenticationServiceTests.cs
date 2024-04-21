using FluentAssertions;
using InventoryManagementSystem.Common.Exceptions;
using InventoryManagementSystem.Common.Exceptions.UserExceptions;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos.Login;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace InventoryManagementSystem.Tests.AuthenticationTests;

public class AuthenticationServiceTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly Mock<IPasswordHasher> _mockPasswordHasher;
    private readonly Mock<IJwtTokenGenerator> _mockTokenGenerator;
    private readonly Mock<ILogger<AuthenticationService>> _mockLogger;
    private readonly AuthenticationService _authenticationService;

    public AuthenticationServiceTests()
    {
        _mockUserService = new Mock<IUserService>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _mockTokenGenerator = new Mock<IJwtTokenGenerator>();
        _mockLogger = new Mock<ILogger<AuthenticationService>>();
        _authenticationService = new AuthenticationService(
            _mockUserService.Object,
            _mockPasswordHasher.Object,
            _mockTokenGenerator.Object,
            _mockLogger.Object);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var loginRequest = new LoginRequest("validUser", "correctPassword");
        var user = new User { Username = loginRequest.Username, Password = "hashed_password" };
        _mockUserService.Setup(x => x.GetUserByUsernameAsync(loginRequest.Username)).ReturnsAsync(user);
        _mockPasswordHasher.Setup(x => x.VerifyPassword(loginRequest.Password, user.Password)).Returns(true);
        _mockTokenGenerator.Setup(x => x.GenerateToken(user)).Returns("valid_token");

        // Act
        var token = await _authenticationService.LoginAsync(loginRequest);

        // Assert
        token.Should().Be("valid_token");
    }

    [Fact]
    public async Task LoginAsync_ShouldThrowInvalidPasswordException_WhenPasswordIsIncorrect()
    {
        // Arrange
        var loginRequest = new LoginRequest("validUser", "incorrectPassword");
        var user = new User { Username = "validUser", Password = "hashed_password" };
        _mockUserService.Setup(x => x.GetUserByUsernameAsync(loginRequest.Username)).ReturnsAsync(user);
        _mockPasswordHasher.Setup(x => x.VerifyPassword(loginRequest.Password, user.Password)).Returns(false);

        // Act & Assert
        Func<Task> act = async () => await _authenticationService.LoginAsync(loginRequest);
        await act.Should().ThrowAsync<InvalidPasswordException>().WithMessage("Invalid password.");
    }

    [Fact]
    public async Task LoginAsync_ShouldThrowNotFoundException_WhenUserDoesNotExist()
    {
        // Arrange
        var loginRequest = new LoginRequest("nonexistentUser", "anyPassword");
        _mockUserService.Setup(x => x.GetUserByUsernameAsync(loginRequest.Username)).ReturnsAsync((User)null);

        // Act & Assert
        Func<Task> act = async () => await _authenticationService.LoginAsync(loginRequest);
        await act.Should().ThrowAsync<NotFoundException>().WithMessage("User 'nonexistentUser' not found.");
    }
}

