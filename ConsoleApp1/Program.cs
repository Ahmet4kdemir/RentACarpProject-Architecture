using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EfCarDal());
            IColorService colorService = new ColorManager(new EfColorDal());
            IBrandService brandService = new BrandManager(new EfBrandDal());
            
            //AddCar(carService);
            //DeleteCar(carService);
            //UpdateCar(carService);
            //CarGetAll(carService);
            //GetCarById(carService);
            //AddColor(colorService);
            //DeleteColor(colorService);
            //UpdateColor(colorService);
            //GetColorById(colorService);
            //GetAllColors(colorService);
            var result = carService.GetCarDetails();
            foreach (var car in result)
            {
                Console.WriteLine(car.CarName+" "+car.BrandName+" "+car.ColorName+" "+car.DailyPrice);
            }
        }

        private static void GetAllColors(IColorService colorService)
        {
            var result = colorService.GetAll();
            foreach (var color in result)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetColorById(IColorService colorService)
        {
            var result = colorService.GetColorById(4);
            foreach (var color in result)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void UpdateColor(IColorService colorService)
        {
            colorService.Update(new Color() { ColorId = 4, ColorName = "Test2" });
        }

        private static void DeleteColor(IColorService colorService)
        {
            colorService.Delete(new Color() { ColorId = 5 });
        }

        private static void AddColor(IColorService colorService)
        {
            colorService.Add(new Color() { ColorName = "test" });
        }

        private static void GetCarById(ICarService carService)
        {
            var result = carService.GetCarById(5);
            foreach (var car in result)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarGetAll(ICarService carService)
        {
            var result = carService.GetAll();
            foreach (var car in result)
            {
                Console.WriteLine(car.CarName + " " + car.Description);
            }
        }


        private static void AddCar(ICarService carService)
        {
            carService.Add(new Car()
                { CarName = "test5", BrandId = 1, ColorId = 1, DailyPrice = 11, ModelYear = 111, Description = "test5" });
        }

        private static void DeleteCar(ICarService carService)
        {
            carService.Delete(new Car() { CarId = 1006 });
        }

        private static void UpdateCar(ICarService carService)
        {
            carService.Update(new Car()
            {
                CarId = 1,
                Description = "updated",
                DailyPrice = 2247,
                CarName = "test",
                ColorId = 1,
                ModelYear = 1999,
                BrandId = 1
            });
        }
    }
    


}




