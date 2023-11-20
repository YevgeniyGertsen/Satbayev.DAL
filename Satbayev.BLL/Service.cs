using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.BLL
{
    public abstract class Service<T> where T: class
    {
        protected string Path { get; set; }

        protected Repository<T> repo;
        public Service(string Path)
        {
            this.Path = Path;
            repo = new Repository<T>(Path);
        }
    }
}