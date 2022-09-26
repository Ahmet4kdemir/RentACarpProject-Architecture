using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
       
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarById(int carId);

        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
