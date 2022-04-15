using System;
using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Display(Name = "Клиент")]
        public int ClientID { get; set; }

        [Display(Name = "Сотрудкик")]
        public int EmployeeID { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Услуга")]
        public int ServiceID { get; set; }

        [Display(Name = "Клиент")]
        public Client? Client { get; set; }

        [Display(Name = "Сотрудкик")]
        public Employee? Employee { get; set; }

        [Display(Name = "Услуга")]
        public Service? Service { get; set; }
    }
}
