using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalon.Models
{
    public class Service
    {
        public int ServiceID { get; set; }

        [Display(Name = "Услуга")]
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Это обязательное поле для заполнения!")]
        public string? ServiceName { get; set; }

        [Display(Name = "Стоимость")]
        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // SET MODEL "Service" TO MODEL <Order> AS "Orders"
        public ICollection<Order>? Orders { get; set; }
    }
}