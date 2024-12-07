using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Service.Abstract
{
    public interface IService<T> where T : class
    {
        IQueryable<T> GetQueryable();
        List<T> GetAll();//Tostring
        List<T> GetAllWhere(Expression<Func<T, bool>> expression);//where koşulu
        T GetFirst(Expression<Func<T, bool>> expression);//Firstordefault
        T GetFind(int id);//Find
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        //--------------------------------------------------------------
        Task<List<T>> GetAllAsync();
        Task<T> GetFindAsync(int id);
        Task<List<T>> GetAllWhereAsync(Expression<Func<T, bool>> expression);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task AddAsync(T item);
    }
}
