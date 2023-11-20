using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.BLL
{
    public class ServiceAdress : Service<Adress>
    {
        public ServiceAdress(string Path) :base(Path)
        {} 
    }
}
