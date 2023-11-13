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
            Errordelegate del=null;
            del += ShowErrorMesage;
            del += SantEmail;

            Path = @"C:\Temp1\test.db";

            Console.WriteLine("1) - Авторизация");
            Console.WriteLine("2) - Регистрация");
            ServiceClient service = 
                new ServiceClient(Path, del);


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
        public static void ShowErrorMesage (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void SantEmail (Exception exception)
        {
            Console.WriteLine("Email sant");
        }
    }
    
}
