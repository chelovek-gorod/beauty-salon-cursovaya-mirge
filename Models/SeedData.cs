using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeautySalon.Data;
using System;
using System.Linq;

namespace BeautySalon.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BeautySalonContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BeautySalonContext>>()))
            {
                // Look for any movies.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee { FullName = "Стрижкина Светлана", DateOfBirth = DateTime.Parse("1986-2-23"), Address = "ул. Приключений 13", PhoneNumber = "+375(29)123-45-67", Position = "Парикмахер" },
                    new Employee { FullName = "Прическина Елена", DateOfBirth = DateTime.Parse("1986-3-13"), Address = "ул. Вертикальная 123", PhoneNumber = "+375(29)234-56-78", Position = "Парикмахер" },
                    new Employee { FullName = "Ногтева Валентина", DateOfBirth = DateTime.Parse("1986-4-21"), Address = "ул. Дорожная 11", PhoneNumber = "+375(29)345-67-89", Position = "Мастер маникюра и педикюра" },
                    new Employee { FullName = "Маникюренко Алина", DateOfBirth = DateTime.Parse("1986-5-14"), Address = "ул. Неровная 49", PhoneNumber = "+375(29)456-78-90", Position = "Мастер маникюра и педикюра" },
                    new Employee { FullName = "Накрашенова Наталья", DateOfBirth = DateTime.Parse("1986-6-26"), Address = "ул. Скоростная 70", PhoneNumber = "+375(29)567-89-01", Position = "Визажист" }
                );
                context.SaveChanges();

                context.Schedule.AddRange(
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-20"), Shift = Shift.First, EmployeeID = 1 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-20"), Shift = Shift.Second, EmployeeID = 3 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-21"), Shift = Shift.First, EmployeeID = 1 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-21"), Shift = Shift.Second, EmployeeID = 4 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-22"), Shift = Shift.First, EmployeeID = 2 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-22"), Shift = Shift.Second, EmployeeID = 5 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-23"), Shift = Shift.First, EmployeeID = 2 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-23"), Shift = Shift.Second, EmployeeID = 3 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-24"), Shift = Shift.First, EmployeeID = 1 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-24"), Shift = Shift.Second, EmployeeID = 4 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-25"), Shift = Shift.First, EmployeeID = 1 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-25"), Shift = Shift.Second, EmployeeID = 5 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-26"), Shift = Shift.First, EmployeeID = 2 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-26"), Shift = Shift.Second, EmployeeID = 3 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-27"), Shift = Shift.First, EmployeeID = 2 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-27"), Shift = Shift.Second, EmployeeID = 4 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-28"), Shift = Shift.First, EmployeeID = 1 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-28"), Shift = Shift.Second, EmployeeID = 5 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-29"), Shift = Shift.First, EmployeeID = 1 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-29"), Shift = Shift.Second, EmployeeID = 3 },

                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-30"), Shift = Shift.First, EmployeeID = 2 },
                    new Schedule { ScheduleDate = DateTime.Parse("2022-4-30"), Shift = Shift.Second, EmployeeID = 4 }
                );
                context.SaveChanges();

                context.Service.AddRange(
                    new Service { ServiceName = "Стрижка", Price = 29.95M },
                    new Service { ServiceName = "Покраска", Price = 32.45M },
                    new Service { ServiceName = "Завивка", Price = 37.25M },

                    new Service { ServiceName = "Маникюр", Price = 10.26M },
                    new Service { ServiceName = "Педикюр", Price = 15.69M },

                    new Service { ServiceName = "Вечерний макияж", Price = 20.12M }
                );
                context.SaveChanges();

                context.Client.AddRange(
                    new Client { FullName = "Фамилова Ирина", PhoneNumber = "+375(29)701-01-23", Address = "ул. Приключений 66" },
                    new Client { FullName = "Погодина Екатерина", PhoneNumber = "+375(29)701-12-34", Address = "ул. Приключений 68" },
                    new Client { FullName = "Раенова Светлана", PhoneNumber = "+375(29)701-23-45", Address = "ул. Приключений 69" },
                    new Client { FullName = "Скамейкина Жанна", PhoneNumber = "+375(29)701-34-56", Address = "ул. Вертикальная 12" },

                    new Client { FullName = "Листова Анна", PhoneNumber = "+375(29)701-45-67", Address = "ул. Вертикальная 13" },
                    new Client { FullName = "Полетова Ольга", PhoneNumber = "+375(29)701-56-78", Address = "ул. Вертикальная 14" },
                    new Client { FullName = "Плавцова Карина", PhoneNumber = "+375(29)701-67-89", Address = "ул. Дорожная 132" },
                    new Client { FullName = "Бровкина Инга", PhoneNumber = "+375(29)701-78-90", Address = "ул. Дорожная 133" },

                    new Client { FullName = "Максимова Галина", PhoneNumber = "+375(29)701-89-01", Address = "ул. Дорожная 134" },
                    new Client { FullName = "Посольская Полина", PhoneNumber = "+375(29)701-90-12", Address = "ул. Неровная 211" },
                    new Client { FullName = "Победина Виктория", PhoneNumber = "+375(29)702-01-23", Address = "ул. Неровная 212" },
                    new Client { FullName = "Логикова Яна", PhoneNumber = "+375(29)703-01-23", Address = "ул. Неровная 213" }
                );
                context.SaveChanges();

                context.Order.AddRange(
                    new Order { ClientID = 1, EmployeeID = 1, OrderDate = DateTime.Parse("2022-4-20"), ServiceID = 1 },
                    new Order { ClientID = 2, EmployeeID = 3, OrderDate = DateTime.Parse("2022-4-20"), ServiceID = 4 },

                    new Order { ClientID = 3, EmployeeID = 1, OrderDate = DateTime.Parse("2022-4-21"), ServiceID = 2 },
                    new Order { ClientID = 4, EmployeeID = 4, OrderDate = DateTime.Parse("2022-4-21"), ServiceID = 4 },

                    new Order { ClientID = 5, EmployeeID = 2, OrderDate = DateTime.Parse("2022-4-22"), ServiceID = 3 },
                    new Order { ClientID = 6, EmployeeID = 5, OrderDate = DateTime.Parse("2022-4-22"), ServiceID = 6 },

                    new Order { ClientID = 7, EmployeeID = 2, OrderDate = DateTime.Parse("2022-4-23"), ServiceID = 1 },
                    new Order { ClientID = 8, EmployeeID = 3, OrderDate = DateTime.Parse("2022-4-23"), ServiceID = 4 },

                    new Order { ClientID = 9, EmployeeID = 1, OrderDate = DateTime.Parse("2022-4-24"), ServiceID = 2 },
                    new Order { ClientID = 10, EmployeeID = 4, OrderDate = DateTime.Parse("2022-4-24"), ServiceID = 5 },

                    new Order { ClientID = 11, EmployeeID = 1, OrderDate = DateTime.Parse("2022-4-25"), ServiceID = 3 },
                    new Order { ClientID = 12, EmployeeID = 5, OrderDate = DateTime.Parse("2022-4-25"), ServiceID = 6 },

                    new Order { ClientID = 2, EmployeeID = 2, OrderDate = DateTime.Parse("2022-4-26"), ServiceID = 1 },
                    new Order { ClientID = 1, EmployeeID = 3, OrderDate = DateTime.Parse("2022-4-26"), ServiceID = 5 },

                    new Order { ClientID = 4, EmployeeID = 2, OrderDate = DateTime.Parse("2022-4-27"), ServiceID = 2 },
                    new Order { ClientID = 3, EmployeeID = 4, OrderDate = DateTime.Parse("2022-4-27"), ServiceID = 4 },

                    new Order { ClientID = 6, EmployeeID = 1, OrderDate = DateTime.Parse("2022-4-28"), ServiceID = 3 },
                    new Order { ClientID = 5, EmployeeID = 5, OrderDate = DateTime.Parse("2022-4-28"), ServiceID = 6 },

                    new Order { ClientID = 8, EmployeeID = 1, OrderDate = DateTime.Parse("2022-4-28"), ServiceID = 1 },
                    new Order { ClientID = 7, EmployeeID = 3, OrderDate = DateTime.Parse("2022-4-28"), ServiceID = 5 },

                    new Order { ClientID = 10, EmployeeID = 2, OrderDate = DateTime.Parse("2022-4-30"), ServiceID = 2 },
                    new Order { ClientID = 9, EmployeeID = 4, OrderDate = DateTime.Parse("2022-4-30"), ServiceID = 5 }
                );
                context.SaveChanges();
            }
        }
    }
}
