using Satbayev.BLL;
using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.ConsoleApp
{
    internal class Program
    {
        public static string Path = "";
        static void Main(string[] args)
        {
            Console.Write("Введите путь к базе данных: ");
            Path = Console.ReadLine();

            Console.WriteLine("1) - Авторизация");
            Console.WriteLine("2) - Регистрация");
            ServiceClient service = new ServiceClient(Path);
            string Question = Console.ReadLine();
            if (Question == "1")
            {
                Console.Write("ВВедите ваш логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                Client client = service.Auth(login, password);
                if(client == null)
                {
                    Console.WriteLine("Ваш пароль или логин не правильный!!!");
                }else
                {
                    Console.WriteLine("Привет " + client.FirstName);
                }

            } else if(Question == "2")
            {
                Client client = new Client();
                Console.Write("Введите ИИН: ");
                client.IIn = Console.ReadLine();

                Console.Write("Введите Email: ");
                client.Email = Console.ReadLine();

                Console.Write("Введите Фамилию: ");
                client.FirstName = Console.ReadLine();

                Console.Write("Введите Имя: ");
                client.MiddleName = Console.ReadLine();

                Console.Write("Введите Отечство: ");
                client.LastName = Console.ReadLine();

                Console.Write("Введите Дату рождения: ");
                client.BirtDay = DateTime.Parse(Console.ReadLine());
                client.CreatDate = DateTime.Now;
                client.Adress = new Adress() { Country = "Kazakstan", City = "Shymkent", House = "BigHouse", Region = "Abai", Street = "M.Auezov" };

                service.Registration(client);
            }
           
        }
    }
}
