namespace DndMeetingAPI.Functions;

public static class DateFunctions
{
    public static DateTime CombineDateAndTime(DateOnly date, TimeOnly time) =>
        new(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
}
