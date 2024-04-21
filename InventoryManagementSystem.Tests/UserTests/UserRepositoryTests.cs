using InventoryManagementSystem.Db;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using InventoryManagementSystem.Db.Repositories.Interfaces;

namespace InventoryManagementSystem.Tests.UserTests;

public class UserRepositoryTests
{
    private readonly InventoryManagementSystemDbContext _dbContext;
    private readonly IUserRepository _userRepository;

    public UserRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<InventoryManagementSystemDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name to ensure isolated context for each test run
            .Options;

        _dbContext = new InventoryManagementSystemDbContext(options);
        _userRepository = new UserRepository(_dbContext);

        InitializeTestData();
    }

    private void InitializeTestData()
    {
        // Add test data to the in-memory database
        _dbContext.Users.AddRange(
            new User { UserId = 1, Username = "user1", Email = "user1@example.com", Password = "Password1" },
            new User { UserId = 2, Username = "user2", Email = "user2@example.com", Password = "Password2" }
        );
        _dbContext.SaveChanges();
    }

    [Fact]
    public async Task GetUserByIdAsync_ReturnsCorrectUser()
    {
        // Arrange
        var user = await _dbContext.Users.FirstAsync(u => u.Username == "user1");

        // Act
        var retrievedUser = await _userRepository.GetUserByIdAsync(user.UserId);

        //Assert
        retrievedUser.Should().NotBeNull();
        retrievedUser.UserId.Should().Be(user.UserId);
        retrievedUser.Username.Should().Be("user1");
    }

    [Fact]
    public async Task CreateUserAsync_ShouldAddUser()
    {
        // Arrange
        var user = new User { Username = "newUser", Email = "newuser@test.com", Password = "password" };

        // Act
        var createdUser = await _userRepository.CreateUserAsync(user);

        // Assert
        createdUser.Should().NotBeNull();
        user.Should().BeEquivalentTo(createdUser, options => options.Excluding(u => u.Password));
        // check that the user is indeed added to the database
        _dbContext.Users.Should().ContainEquivalentOf(createdUser);
    }

    [Fact]
    public async Task GetUserByUsernameAsync_ShouldReturnUser_WhenUsernameExists()
    {
        // Arrange
        var username = "user1";

        // Act
        var user = await _userRepository.GetUserByUsernameAsync(username);

        // Assert
        user.Should().NotBeNull();
        user.Username.Should().Be(username);
    }

    [Fact]
    public async Task GetUserByUsernameAsync_ShouldReturnNull_WhenUsernameDoesNotExist()
    {
        // Arrange
        var username = "nonExistentUser";

        // Act
        var user = await _userRepository.GetUserByUsernameAsync(username);

        // Assert
        user.Should().BeNull();
    }

    [Fact]
    public async Task GetUserByEmailAsync_ShouldReturnUser_WhenEmailExists()
    {
        // Arrange
        var email = "user1@example.com";

        // Act
        var user = await _userRepository.GetUserByEmailAsync(email);

        // Assert
        user.Should().NotBeNull();
        user.Email.Should().Be(email);
    }

    [Fact]
    public async Task GetUserByEmailAsync_ShouldReturnNull_WhenEmailDoesNotExist()
    {
        // Arrange
        var email = "nonExistentEmail@example.com";

        // Act
        var user = await _userRepository.GetUserByEmailAsync(email);

        // Assert
        user.Should().BeNull();
    }

    [Fact]
    public async Task GetUsersAsync_ShouldReturnAllUsers()
    {
        // Act
        var users = await _userRepository.GetUsersAsync();

        // Assert
        users.Should().NotBeNull();
    }

    [Theory]
    [InlineData("uniqueUsername", true)]
    [InlineData("user1", false)]
    public async Task IsUsernameUniqueAsync_ShouldReturnCorrectResult(string username, bool expected)
    {
        // Act
        var isUnique = await _userRepository.IsUsernameUniqueAsync(username);

        // Assert
        isUnique.Should().Be(expected);
    }

    [Theory]
    [InlineData("uniqueEmail@example.com", true)]
    [InlineData("user1@example.com", false)]
    public async Task IsEmailUniqueAsync_ShouldReturnCorrectResult(string email, bool expected)
    {
        // Act
        var isUnique = await _userRepository.IsEmailUniqueAsync(email);

        // Assert
        isUnique.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(004647383, false)]
    public async Task IsUserExistAsync_ShouldReturnCorrectResult(int userId, bool expected)
    {
        // Act
        var doesExist = await _userRepository.IsUserExistAsync(userId);

        // Assert
        doesExist.Should().Be(expected);
    }
}
