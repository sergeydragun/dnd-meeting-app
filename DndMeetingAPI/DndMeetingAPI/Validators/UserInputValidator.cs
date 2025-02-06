namespace DndMeetingAPI.Validators;

using Data.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models;

public class UserInputValidator : AbstractValidator<UserInput>
{
    public UserInputValidator(UserRepository userRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Имя обязательно!")
            .MustAsync(async (name, cancellationToken) =>
            {
                var currentNames = await userRepository.GetAllQueryable()
                    .Select(x => x.Name)
                    .ToListAsync(cancellationToken);

                return !currentNames.Any(x => x.Equals(name));
            })
            .WithMessage("Такое имя уже есть (вы можете запутаваться)");
    }
}
