using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Backend.Common.Interfaces;
using CarRent.Model.CarManagement.Domain;

namespace CarRent.Backend.CarManagement.Application
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car, Guid> _repository;

        public CarService(IRepository<Car, Guid> repository)
        {
            _repository = repository;
        }

        public List<Car> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Car> GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public List<Car> GetByType(CarClassType type)
        {
            return GetAll().Where(x => x.Class.Type == type).ToList();
        }

        public void Add(Car car)
        {
            _repository.Insert(car);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public void Delete(Car entity)
        {
            _repository.Remove(entity);
        }

        public void Update(Car car)
        {
            _repository.Update(car);
        }
    }
}
