using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.BLL
{
   public class SrviceAccount : Service<Account>
    {
        public SrviceAccount(string Path) :base(Path)
        {}

        public bool CreateAccount(Account account) 
        {
            return repo.Create(account);
        }

        public List<Account> GetAllAccount(int id)
        {
            return repo.GetAll().Where(w => w.ClientId == id).ToList();
        }

        public bool CashInAccount(int id, double sum)
        {
            Account schet = repo.GetAll().FirstOrDefault(F => F.Id == id);
            schet.Balance += sum;
            return repo.Update(schet);
        }

        public bool CashOutAccount(int id, double sum)
        {
            Account schet = repo.GetAll().FirstOrDefault(F => F.Id == id);
            if(schet.Balance < sum)
            {
                throw new Exception("Balance is null");
            }
            else
            {
                schet.Balance -= sum;
            }
            
            return repo.Update(schet);
        }
    }
}
