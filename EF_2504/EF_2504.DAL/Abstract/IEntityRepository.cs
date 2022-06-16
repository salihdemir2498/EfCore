using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF_2504.DAL.Abstract
{
    public interface IEntityRepository<T> where T:class
    {
        void Add(T entity); //ekleme için Create
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //getirme için okuma yapma Read
        T Get(Expression<Func<T, bool>> filter); //tek bir getirme için 
        void Update(T entity); //güncelleme  Update
        void Delete(T entity);//silme Delete

    }

}
