using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{
    public class ReposityClient
    {
        private string Path;
        public ReposityClient(string Path)
        {
            this.Path = Path;
        }
        public bool CreateClient(Client client)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<Client>("Client");
                    clients.Insert(client);
                }
            }
            catch (Exception)
            {

            }

            return true;
        }

        public Client GetClient(string email, string password)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    return db.GetCollection<Client>("Client").FindAll()
                         .First(f => f.Email == email & f.Password == password);
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public Client GetClient(int Id)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    return db.GetCollection<Client>
                    ("Client").FindAll()
                        .First(f => f.Id == Id);
                }
            }
            catch (Exception)
            {

               
            }
            return null;
            
        }
    }
}
