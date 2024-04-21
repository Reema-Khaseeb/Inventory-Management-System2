using FluentValidation;
using InventoryManagementSystem.Dtos.User;
using InventoryManagementSystem.Services.Interfaces;

namespace TravelAccommodationBooking.Api.Validators;
public class UserValidator : AbstractValidator<UserRequest>
{
    private readonly IUserService _userService;

    public UserValidator(IUserService userService)
    {
        _userService = userService ??
            throw new ArgumentNullException(nameof(userService));

        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Username is required. It shouldn't be empty")
            .Must(username => IsValidStringNoSpaces(username))
                .WithMessage("No spaces are allowed in Username.")
            .Must(username => BeUniqueUsername(username))
                .WithMessage("Username must be unique.")
            .MinimumLength(5).WithMessage("Username must be at least 5 characters.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Must(password => IsValidStringNoSpaces(password))
                .WithMessage("No spaces are allowed in Password.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Must(password => HasUpperCase(password))
                .WithMessage("Password must contain at least one uppercase letter.")
            .Must(password => HasLowerCase(password))
                .WithMessage("Password must contain at least one lowercase letter.")
            .Must(password => HasDigit(password))
                .WithMessage("Password must contain at least one digit.")
            .Must(password => HasSpecialCharacter(password))
                .WithMessage("Password must contain at least one special character.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .Must(email => BeUniqueEmail(email))
                .WithMessage("Email must be unique.");
    }

    private bool BeUniqueUsername(string username)
    {
        return _userService.IsUsernameUniqueAsync(username).GetAwaiter().GetResult();
    }

    private bool BeUniqueEmail(string email)
    {
        return _userService.IsEmailUniqueAsync(email).GetAwaiter().GetResult();
    }

    private bool IsValidStringNoSpaces(string value) => !value.Contains(" ");
    private bool HasUpperCase(string password) => password.Any(char.IsUpper);
    private bool HasLowerCase(string password) => password.Any(char.IsLower);
    private bool HasDigit(string password) => password.Any(char.IsDigit);
    private bool HasSpecialCharacter(string password) => password.Any(ch => !char.IsLetterOrDigit(ch));
}
