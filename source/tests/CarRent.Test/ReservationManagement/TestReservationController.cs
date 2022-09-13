using System;
using System.Collections.Generic;
using AutoMapper;
using CarRent.Backend.CarManagement.API;
using CarRent.Backend.CarManagement.Application;
using CarRent.Backend.Common.Infrastructure.Mapper;
using CarRent.Backend.Common.Interfaces;
using CarRent.Backend.ReservationManagement.API;
using CarRent.Backend.ReservationManagement.Application;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;
using CarRent.Model.CustomerManagement.Domain;
using CarRent.Model.ReservationManagement.Application;
using CarRent.Model.ReservationManagement.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarRent.Test.ReservationManagement
{
    public class TestReservationController
    {
        private readonly IMapper _mapper;
        private readonly IReservationService _service;

        private readonly Mock<IRepository<Reservation, Guid>> _repository;

        private readonly List<Reservation> _entities;

        public TestReservationController()
        {
            
            _entities = new List<Reservation>()
            {
                CarRentData.CarRentData.Reservation
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(ReservationProfile));
            }));

            _repository = new Mock<IRepository<Reservation, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_entities);
            _repository.Setup(x => x.Insert(It.IsAny<Reservation>()));

            _service = new ReservationService(_repository.Object);
        }

        [Fact]
        public void TestGetAll()
        {
            var controller = new ReservationController(_service, _mapper);
            
            var result = controller.Get();
            
            result.Should().NotBeEmpty().And.BeEquivalentTo(_entities, o=> o.ExcludingMissingMembers().Excluding(x => x.Status));
        }

        [Fact]
        public void TestAdd()
        {
            var controller = new ReservationController(_service,_mapper);

            var entityToAdd = new ReservationDto()
            {
                Id = Guid.NewGuid()
            };

            controller.Post(entityToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<Reservation>()));
        }
    }
}
