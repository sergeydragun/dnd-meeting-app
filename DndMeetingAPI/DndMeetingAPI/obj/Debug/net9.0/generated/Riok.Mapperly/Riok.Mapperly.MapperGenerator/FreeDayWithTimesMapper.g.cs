﻿// <auto-generated />
#nullable enable
namespace DndMeetingAPI.Mappers
{
    public static partial class FreeDayWithTimesMapper
    {
        [global::System.CodeDom.Compiler.GeneratedCode("Riok.Mapperly", "4.1.1.0")]
        public static partial global::DndMeetingAPI.Models.FreeTime ToEntity(this global::DndMeetingAPI.Models.FreeTimeInput input, global::System.Guid userId, global::System.Guid dayWithFreeTimeId)
        {
            var target = new global::DndMeetingAPI.Models.FreeTime();
            target.StartTime = input.StartTime;
            target.EndTime = input.EndTime;
            target.UserId = userId;
            target.DayWithFreeTimeId = dayWithFreeTimeId;
            return target;
        }

        [global::System.CodeDom.Compiler.GeneratedCode("Riok.Mapperly", "4.1.1.0")]
        public static partial global::DndMeetingAPI.Models.FreeTime ToEntity(this global::DndMeetingAPI.Models.FreeTimeInput input, global::System.Guid userId)
        {
            var target = new global::DndMeetingAPI.Models.FreeTime();
            target.StartTime = input.StartTime;
            target.EndTime = input.EndTime;
            target.UserId = userId;
            return target;
        }

        [global::System.CodeDom.Compiler.GeneratedCode("Riok.Mapperly", "4.1.1.0")]
        private static partial global::DndMeetingAPI.Models.DayWithFreeTime MapToEntity(this global::DndMeetingAPI.Models.FreeDayWithTimesInput input)
        {
            var target = new global::DndMeetingAPI.Models.DayWithFreeTime();
            target.Date = input.Date;
            target.UsersAndDaysWithFreeTime = MapUsersAndDays(input.UserId);
            return target;
        }

        [global::System.CodeDom.Compiler.GeneratedCode("Riok.Mapperly", "4.1.1.0")]
        public static partial global::DndMeetingAPI.Models.FreeTime ToEntity(this global::DndMeetingAPI.Models.UpdateFreeTimeInput input, global::System.Guid userId, global::System.Guid dayWithFreeTimeId)
        {
            var target = new global::DndMeetingAPI.Models.FreeTime();
            target.StartTime = input.StartTime;
            target.EndTime = input.EndTime;
            target.UserId = userId;
            target.DayWithFreeTimeId = dayWithFreeTimeId;
            target.Id = input.Id;
            return target;
        }
    }
}