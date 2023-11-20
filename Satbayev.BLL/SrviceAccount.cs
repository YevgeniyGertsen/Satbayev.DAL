using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.BLL
{
    class SrviceAccount : Service<Account>
    {
        public SrviceAccount(string Path) :base(Path)
        {}
    }
}
