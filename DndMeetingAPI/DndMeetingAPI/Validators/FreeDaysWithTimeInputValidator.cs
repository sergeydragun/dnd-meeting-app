namespace DndMeetingAPI.Validators;

using FluentValidation;
using Models;

public class FreeDaysWithTimeInputValidator : AbstractValidator<FreeDayWithTimesInput>
{
    public FreeDaysWithTimeInputValidator()
    {
        RuleForEach(x => x.FreeTimes).SetValidator(new FreeTimeInputValidator());

        RuleFor(x => x.FreeTimes)
            .Must(NoOverlappingFreeTimes)
            .WithMessage("Free times are not overlapping.");
    }

    private bool NoOverlappingFreeTimes(List<FreeTimeInput> freeTime)
    {
        var sortedTimes = freeTime.OrderBy(t => t.StartTime).ToList();


        for (Int32 i = 1; i < sortedTimes.Count; i++)
        {
            if (sortedTimes[i].StartTime < sortedTimes[i - 1].EndTime)
            {
                return false;
            }
        }

        return true;
    }
}
