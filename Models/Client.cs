using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public class Client
    {
        public int ClientID { get; set; }

        [Display(Name = "ФИО Клиента")]
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Это обязательное поле для заполнения!")]
        public string? FullName { get; set; }

        [Display(Name = "Телефон")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Адрес")]
        public string? Address { get; set; }

        // SET MODEL "Client" TO MODEL <Order> AS "Orders"
        public ICollection<Order>? Orders { get; set; }
    }
}