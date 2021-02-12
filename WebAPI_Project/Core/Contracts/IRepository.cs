using StudentSystem.Core.Models;
using System.Linq;

namespace StudentSystem.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        T Find(int Id);
        bool Insert(T t);
        void Update(T t);
        bool Delete(int Id);

    }
}