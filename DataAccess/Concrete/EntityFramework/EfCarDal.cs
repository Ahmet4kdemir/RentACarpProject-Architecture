using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal: ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Add(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
