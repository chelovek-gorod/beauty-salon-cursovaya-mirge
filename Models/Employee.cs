using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Display(Name = "ФИО Сотрудника")]
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Это обязательное поле для заполнения!")]
        public string? FullName { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Адрес")]
        public string? Address { get; set; }

        [Display(Name = "Телефон")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Должность")]
        public string? Position { get; set; }

        // SET MODEL "Employee" TO MODEL <Schedule> AS "Schedules"
        public ICollection<Schedule>? Schedules { get; set; }

        // SET MODEL "Employee" TO MODEL <Order> AS "Orders"
        public ICollection<Order>? Orders { get; set; }
    }
}
