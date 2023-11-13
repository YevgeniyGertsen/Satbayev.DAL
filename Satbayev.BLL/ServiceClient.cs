using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.BLL

{

    public class ServiceClient
    {
      
        public string Path { get; set; } //Свойства
        ReposityClient reposity = null;
        public ServiceClient(string Path, Errordelegate errordelegate) {
            this.Path = Path;

            reposity = new ReposityClient(Path);
            reposity.RegisterDelegite(errordelegate);
        }
        public void Registration(Client client)
        {     
            bool resault = reposity.CreateClient(client);
        }
        public Client Auth(string login, string password)
        {
            Client client = reposity.GetClient(login, password);
            return client;
        }
        
    }
}
