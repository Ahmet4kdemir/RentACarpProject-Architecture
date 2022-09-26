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
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetUserById(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserId == userId));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.ProductAdded);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
            new SuccessResult(Messages.Deleted);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
            new SuccessResult(Messages.Updated);
        }
    }
}
