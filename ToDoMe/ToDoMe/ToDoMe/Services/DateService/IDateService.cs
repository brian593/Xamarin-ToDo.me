using System;
using System.Collections.Generic;
using ToDoMe.Models;

namespace ToDoMe.Services.DateService
{
    public interface IDateService
    {
        WeekModel GetWeek(DateTime date);

        List<DayModel> GetDayList(DateTime firstDayInWeek, DateTime lastDayInWeek);
    }
}
