using InventoryManagementSystem.Services;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using Moq;
using FluentAssertions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using InventoryManagementSystem.Services.Interfaces;
using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Dtos.User;
using InventoryManagementSystem.Common.Exceptions.UserExceptions;
using InventoryManagementSystem.Common.Exceptions;

namespace InventoryManagementSystem.Tests.UserTests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IPasswordHasher> _mockPasswordHasher;
    private readonly Mock<ILogger<UserService>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _mockLogger = new Mock<ILogger<UserService>>();
        _mockMapper = new Mock<IMapper>();

        // pass all the required dependencies to the UserService constructor
        _userService = new UserService(_mockUserRepository.Object, _mockPasswordHasher.Object, _mockLogger.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldRegisterUser_WhenDetailsAreUnique()
    {
        // Arrange
        var userRequest = new UserRequest("NewUser", "Password123", "newuser@example.com", UserRole.User);
        var user = new User { UserId = 1, Username = userRequest.Username, Email = userRequest.Email, Role = userRequest.Role };
        var userResponse = new UserResponse(user.Username);

        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserRequest>())).Returns(user);
        _mockUserRepository.Setup(repo => repo.IsUsernameUniqueAsync(user.Username)).ReturnsAsync(true);
        _mockUserRepository.Setup(repo => repo.IsEmailUniqueAsync(user.Email)).ReturnsAsync(true);
        _mockUserRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>())).ReturnsAsync(user);
        _mockMapper.Setup(m => m.Map<UserResponse>(It.IsAny<User>())).Returns(userResponse);
        _mockPasswordHasher.Setup(hasher => hasher.HashPassword(user.Password)).Returns("hashed_password");

        var userService = new UserService(_mockUserRepository.Object, _mockPasswordHasher.Object, _mockLogger.Object, _mockMapper.Object);

        // Act
        var result = await userService.RegisterUserAsync(userRequest);

        // Assert
        result.Should().BeOfType<UserResponse>();
        result.Username.Should().Be(user.Username);
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldThrow_WhenUnexpectedExceptionOccurs()
    {
        // Arrange
        var userRequest = new UserRequest("NewUser", "Password123", "newuser@example.com", UserRole.User);
        var user = new User { UserId = 1, Username = userRequest.Username, Email = userRequest.Email, Role = userRequest.Role };
        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserRequest>())).Returns(user);
        _mockUserRepository.Setup(repo => repo.IsUsernameUniqueAsync(user.Username)).ReturnsAsync(true);
        _mockUserRepository.Setup(repo => repo.IsEmailUniqueAsync(user.Email)).ReturnsAsync(true);
        _mockUserRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>())).ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        Func<Task> act = async () => await _userService.RegisterUserAsync(userRequest);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Database error");
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldThrow_WhenUsernameAlreadyExists()
    {
        // Arrange
        var userRequest = new UserRequest("ExistingUser", "Password123", "user@example.com", UserRole.User);
        var user = new User { UserId = 1, Username = userRequest.Username, Email = userRequest.Email, Role = userRequest.Role };

        _mockMapper.Setup(m => m.Map<User>(userRequest)).Returns(user);
        _mockUserRepository.Setup(repo => repo.IsUsernameUniqueAsync(user.Username)).ReturnsAsync(false);
        _mockPasswordHasher.Setup(hasher => hasher.HashPassword(user.Password)).Returns("hashed_password");

        // Act & Assert
        Func<Task> act = async () => await _userService.RegisterUserAsync(userRequest);

        // Assert
        await act.Should().ThrowAsync<DuplicateUsernameException>();
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldThrow_WhenEmailAlreadyExists()
    {
        // Arrange
        var userRequest = new UserRequest("NewUser", "Password123", "existingemail@example.com", UserRole.User);
        var user = new User { UserId = 1, Username = userRequest.Username, Email = userRequest.Email, Role = userRequest.Role };

        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserRequest>())).Returns(user);
        _mockUserRepository.Setup(repo => repo.IsUsernameUniqueAsync(user.Username)).ReturnsAsync(true);
        _mockUserRepository.Setup(repo => repo.IsEmailUniqueAsync(user.Email)).ReturnsAsync(false);
        _mockPasswordHasher.Setup(hasher => hasher.HashPassword(It.IsAny<string>())).Returns("hashed_password");

        // Act & Assert
        Func<Task> act = async () => await _userService.RegisterUserAsync(userRequest);

        // Assert
        await act.Should().ThrowAsync<DuplicateEmailException>();
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldThrow_WhenMappedUserIsNull()
    {
        // Arrange
        var userRequest = new UserRequest("NewUser", "Password123", "newuser@example.com", UserRole.User);
        _mockMapper.Setup(m => m.Map<User>(It.IsAny<UserRequest>())).Returns((User)null);

        // Act & Assert
        Func<Task> act = async () => await _userService.RegisterUserAsync(userRequest);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task GetUserByIdAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userId = 1;
        var expectedUser = new User { UserId = userId, Username = "TestUser", Email = "test@example.com" };
        _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(expectedUser);

        // Act
        var result = await _userService.GetUserByIdAsync(userId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedUser, options => options.ComparingByMembers<User>());
        _mockUserRepository.Verify(x => x.GetUserByIdAsync(1), Times.Once); //  Verify the interaction between the service and its dependency
    }

    [Fact]
    public async Task GetUserByIdAsync_ShouldThrowNotFoundException_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = 1;
        _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync((User)null);

        var userService = new UserService(_mockUserRepository.Object, _mockPasswordHasher.Object, _mockLogger.Object, _mockMapper.Object);

        // Act & Assert
        Func<Task> act = async () => await userService.GetUserByIdAsync(userId);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>().WithMessage($"User with ID {userId} not found.");
        _mockUserRepository.Verify(x => x.GetUserByIdAsync(1), Times.Once); //  Verify the interaction between the service and its dependency
    }

    [Fact]
    public async Task GetUserByUsernameAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var username = "existingUser";
        var expectedUser = new User { UserId = 1, Username = username };
        _mockUserRepository.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync(expectedUser);

        // Act
        var result = await _userService.GetUserByUsernameAsync(username);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedUser, options => options.ComparingByMembers<User>());
        _mockUserRepository.Verify(repo => repo.GetUserByUsernameAsync(username), Times.Once); // Verify the interaction between the service and its dependency
    }

    [Fact]
    public async Task GetUserByUsernameAsync_ShouldThrowNotFoundException_WhenUserDoesNotExist()
    {
        // Arrange
        var username = "nonexistentUser";
        _mockUserRepository.Setup(repo => repo.GetUserByUsernameAsync(username)).ReturnsAsync((User)null);

        // Act & Assert
        Func<Task> act = async () => await _userService.GetUserByUsernameAsync(username);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"User '{username}' not found.");
        _mockUserRepository.Verify(repo => repo.GetUserByUsernameAsync(username), Times.Once); // Verify the interaction between the service and its dependency
    }

    [Fact]
    public async Task GetUserByUsernameAsync_ShouldRethrowException_OnError()
    {
        // Arrange
        var username = "testUser";
        _mockUserRepository.Setup(repo => repo.GetUserByUsernameAsync(username)).ThrowsAsync(new Exception("Database failure"));

        // Act & Assert
        Func<Task> act = async () => await _userService.GetUserByUsernameAsync(username);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Database failure");
    }

    [Fact]
    public async Task IsUsernameUniqueAsync_ShouldReturnTrue_WhenUsernameIsUnique()
    {
        // Arrange
        var username = "uniqueUsername";
        _mockUserRepository.Setup(repo => repo.IsUsernameUniqueAsync(username)).ReturnsAsync(true);

        // Act
        var result = await _userService.IsUsernameUniqueAsync(username);

        // Assert
        result.Should().BeTrue();
        _mockUserRepository.Verify(repo => repo.IsUsernameUniqueAsync(username), Times.Once); // Verify the interaction between the service and its dependency
    }

    [Fact]
    public async Task IsUsernameUniqueAsync_ShouldReturnFalse_WhenUsernameIsNotUnique()
    {
        // Arrange
        var username = "existingUsername";
        _mockUserRepository.Setup(repo => repo.IsUsernameUniqueAsync(username)).ReturnsAsync(false);

        // Act
        var result = await _userService.IsUsernameUniqueAsync(username);

        // Assert
        result.Should().BeFalse();
        _mockUserRepository.Verify(repo => repo.IsUsernameUniqueAsync(username), Times.Once); // Verify the interaction between the service and its dependency
    }

    [Fact]
    public async Task IsEmailUniqueAsync_ShouldReturnTrue_WhenEmailIsUnique()
    {
        // Arrange
        var email = "unique@example.com";
        _mockUserRepository.Setup(repo => repo.IsEmailUniqueAsync(email)).ReturnsAsync(true);

        // Act
        var result = await _userService.IsEmailUniqueAsync(email);

        // Assert
        result.Should().BeTrue();
        _mockUserRepository.Verify(repo => repo.IsEmailUniqueAsync(email), Times.Once); // Verify the interaction between the service and its dependency
    }

    [Fact]
    public async Task IsEmailUniqueAsync_ShouldReturnFalse_WhenEmailIsNotUnique()
    {
        // Arrange
        var email = "existing@example.com";
        _mockUserRepository.Setup(repo => repo.IsEmailUniqueAsync(email)).ReturnsAsync(false);

        // Act
        var result = await _userService.IsEmailUniqueAsync(email);

        // Assert
        result.Should().BeFalse();
        _mockUserRepository.Verify(repo => repo.IsEmailUniqueAsync(email), Times.Once); // Verify the interaction between the service and its dependency
    }
}
