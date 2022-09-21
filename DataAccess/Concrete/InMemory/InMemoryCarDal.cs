using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car(){BrandId = 1,CarId = 1,ColorId = 1,DailyPrice = 120000,ModelYear = 2011,Description = "Temiz"},
                new Car(){BrandId = 1,CarId = 2,ColorId = 2,DailyPrice = 140000,ModelYear = 2016,Description = "Ağır hasarlı"},
                new Car(){BrandId = 4,CarId = 3,ColorId = 3,DailyPrice = 180000,ModelYear = 2015,Description = "Temiz"}

            };
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

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
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car CarToUpdate;
            CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
            CarToUpdate.BrandId = car.BrandId;

        }

        public void Delete(Car car)
        {
            Car CarToDelete;
            CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
