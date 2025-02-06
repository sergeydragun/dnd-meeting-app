namespace DndMeetingAPI.Validators;

using FluentValidation;
using Models;

public class FreeTimeInputValidator : AbstractValidator<FreeTimeInput>
{
    public FreeTimeInputValidator()
    {
        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("Start time must be after end time.");
    }
}
