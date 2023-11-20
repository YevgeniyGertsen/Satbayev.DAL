using Satbayev.BLL;
using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.ConsoleApp
{
    internal class Program
    {
        public static string Path = ConfigurationManager
            .ConnectionStrings["defaultConnection"]
            .ConnectionString;
        static void Main(string[] args)
        {
            Console.WriteLine("1) - Авторизация");
            Console.WriteLine("2) - Регистрация");

            ServiceClient service = 
                new ServiceClient(Path);

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
                    SrviceAccount serviceAccount = new SrviceAccount(Path);
                    List<Account> accounts = serviceAccount.GetAllAccount(client.Id);
                    if(accounts == null)
                    {
                        Console.WriteLine("Желаете открыть счет: Да / Нет?");
                        string newChet = Console.ReadLine();
                        if (newChet == "Да")
                        {
                            Account acc = new Account();
                            acc.ClientId = client.Id;
                            serviceAccount.CreateAccount(acc);
                            
                        }
                    }

                    foreach (Account item in accounts)
                    {
                        Console.WriteLine("{0}.\t{1}\t{2}KZT", item.Id,item.IBAN, item.Balance);
                    }

                    Console.Write("Выберите счет: ");
                    int accountId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Пополнить счет / Снять: ");
                    string take = Console.ReadLine();
                    switch (take)
                    {
                        case "Пополнить":
                            {
                                break;
                            }
                    }

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
