using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Backend.CarManagement.API;
using CarRent.Backend.CarManagement.Application;
using CarRent.Backend.Common.Infrastructure.Mapper;
using CarRent.Backend.Common.Interfaces;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarRent.Test.CarManagement
{
    public class TestCarController
    {
        private readonly IMapper _mapper;
        private readonly ICarService _service;

        private readonly Mock<IRepository<Car, Guid>> _repository;

        private readonly List<Car> _cars;
        public TestCarController()
        {
        
            var carClasses = new List<CarClass>()
            {
                CarRentData.CarRentData.BaseCarClass,
                CarRentData.CarRentData.MediumCarClass,
                CarRentData.CarRentData.LuxuryCarClass
            };
            _cars = new List<Car>()
            {
                CarRentData.CarRentData.Car
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CarProfile));
            }));

            _repository = new Mock<IRepository<Car, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_cars);
            _repository.Setup(x => x.Insert(It.IsAny<Car>()));

            _service = new CarService(_repository.Object);
        }

        [Fact]
        public void TestGetAll()
        {
            var controller = new CarController(_service, _mapper);
            
            var result = controller.Get();
            
            result.Should().NotBeEmpty().And.BeEquivalentTo(_cars, o=> o.ExcludingMissingMembers());
        }

        [Fact]
        public void TestAdd()
        {
            var controller = new CarController(_service,_mapper);

            var carToAdd = CarRentData.CarRentData.CarDto;

            controller.Post(carToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<Car>()));
        }
    }
}
