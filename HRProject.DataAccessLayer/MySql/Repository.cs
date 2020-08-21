using HRProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.DataAccessLayer.MySql
{
   // veritabanı değiştiğinde ilgili veri tabanıyla ilgili kodlar bu sınıfta tanımlanacak.
   //bu sınıf IRepository interfaceini kullanarak türetilecek

    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        public int Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public int Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
