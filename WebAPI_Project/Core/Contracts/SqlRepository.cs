using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentSystem.Core.Contracts;
using StudentSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Project.Core.Models;

namespace StudentSystem.Core.Contracts
{
    public class SqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        StudentSystemContext context;
        DbSet<T> dbset;
        public SqlRepository(StudentSystemContext context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return dbset;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public bool Delete(int Id)
        {
            var t = dbset.Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
                dbset.Attach(t);

            EntityEntry<T> mm= dbset.Remove(t);
            if (mm != null)
            {
                return true;
            }
            return false;
        }

        public T Find(int Id)
        {
            return dbset.Find(Id);
        }

        public bool Insert(T t)
        {
            
            EntityEntry<T> mm =  dbset.Add(t);
            if (mm != null)
            {
                return true;
            }
            return false;
        }

        public void Update(T t)
        {
            dbset.Attach(t);
            context.Entry(t).State = EntityState.Modified;

        }
    }
}
