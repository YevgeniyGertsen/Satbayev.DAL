using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.BLL

{

    public class ServiceClient :Service<Client>
    {
        public ServiceClient(string Path): base(Path)
        {}

        public void Registration(Client client)
        {     
            bool resault = repo.Create(client);
        }
        public Client Auth(string login, string password)
        {
            Client client = repo.GetAll().FirstOrDefault(f => f.Email == login && f.Password == password);
            return client;
        }
    }
}
