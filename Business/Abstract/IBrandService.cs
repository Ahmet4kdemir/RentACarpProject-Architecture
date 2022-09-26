using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetBrandById(int brandId);

        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
