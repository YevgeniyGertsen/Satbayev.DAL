using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private string Path;
        public Repository(string Path)
        {
            this.Path = Path;
        }

        public bool Create(T data)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<T>    
                                    (typeof(T).Name);
                    clients.Insert(data);
                }
            }
            catch (Exception ex)
            {
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<T>
                                    (typeof(T).Name);
                    clients.Delete(id);
                }
            }
            catch (Exception ex)
            {
            }
            return true;
        }

        public List<T> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<T>
                                    (typeof(T).Name);
                    return clients.FindAll().ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public bool Update(T data)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<T>
                                    (typeof(T).Name);
                    clients.Update(data);
                }
            }
            catch (Exception ex)
            {
            }
            return true;
        }
    }
}
