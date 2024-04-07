using FluentValidation;
using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Api.Validators;
public class ItemValidator : AbstractValidator<ItemDto>
{
    public ItemValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Item name is required.")
            .Length(2, 100).WithMessage("Item name must be between 2 and 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot be more than 500 characters.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
    }
}

