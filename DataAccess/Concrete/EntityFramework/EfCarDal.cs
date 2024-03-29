﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join Co in context.Colors
                        on c.ColorId equals Co.ColorId
                    select new CarDetailDto()
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        ColorName = Co.ColorName,
                        DailyPrice = c.DailyPrice

                    };
                return result.ToList();

            }
        }

    }
}
