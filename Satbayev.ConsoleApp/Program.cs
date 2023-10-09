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
            
            ServiceClient service = new ServiceClient(Path);
            Client client = new Client();
            client.IIn = "060504186488";
            client.Email = "satbayev@gmail.com";
            client.FirstName = "Bekbulat";
            client.MiddleName = "Asanali";
            client.LastName = "Satbayev";
            client.BirtDay = new DateTime(2002,06,27);
            client.CreatDate = DateTime.Now;
            client.Adress = new Adress() { Country = "Kazakstan", City = "Shymkent", House = "BigHouse", Region="Abai", Street="M.Auezov"};

            service.Registration(client);
        }
    }
}
