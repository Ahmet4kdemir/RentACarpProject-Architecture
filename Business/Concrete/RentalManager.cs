using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager: IRentalService
    {
        IRentalDal _rentalDal;


        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == rentalId));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result != null)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarAdded);
        }

        public void Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            new SuccessResult(Messages.Deleted);
        }

        public void Update(Rental rental)
        {
            _rentalDal.Update(rental);
            new SuccessResult(Messages.Updated);
        }
        public IDataResult<List<Rental>> RentedCars()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == null), Messages.CarsListed);
        }
    }
}
