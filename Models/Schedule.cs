using System;
using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public enum Shift
    {
        [Display(Name = "l-я смена")]
        First = 1,
        [Display(Name = "2-я смена")]
        Second = 2
    }

    public class Schedule
    {
        public int ScheduleID { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime ScheduleDate { get; set; }

        [Display(Name = "Смена")]
        public Shift Shift { get; set; }

        [Display(Name = "Сотрудник")]
        public int EmployeeID { get; set; }

        [Display(Name = "Сотрудник")]
        public Employee? Employee { get; set; }
    }
}