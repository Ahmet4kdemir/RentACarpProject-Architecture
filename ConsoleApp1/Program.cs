using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());

//foreach (var car in carManager.GetCarsByColorId(1))
//{
//    Console.WriteLine(car.Description+" price: "+car.DailyPrice+" year: "+car.ModelYear);
//}

carManager.Add(new Car(){BrandId = 1,CarId = 3,CarName = "Ford",
    ColorId = 1,DailyPrice = 100,Description = "first",ModelYear = 1999});