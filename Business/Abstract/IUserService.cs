﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetUserById(int userId);

        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        void Delete(User user);
        void Update(User user);
    }
}
