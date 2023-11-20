using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{
    public class RepositoryAccount
    {
        private string Path;
        public RepositoryAccount(string Path)
        {
            this.Path = Path;
        }

        public bool CreateAccount(Account account)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<Account>("Account");
                    clients.Insert(account);
                }
            }
            catch (Exception ex)
            {
            }

            return true;
        }
    }
}
