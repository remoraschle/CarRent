using System;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;
using CarRent.Model.CustomerManagement.Domain;
using CarRent.Model.ReservationManagement.Domain;

namespace CarRent.Test.CarRentData
{
    public class CarRentData
    {

        public static readonly CarClass BaseCarClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 12,
            Type = CarClassType.Basic
        };
        public static readonly CarClass MediumCarClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 20,
            Type = CarClassType.Medium
        };
        public static readonly CarClass LuxuryCarClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 130,
            Type = CarClassType.Luxury
        };

        public static readonly Guid ZipID = Guid.NewGuid();

        public static readonly ZipCode ZipCode =  new ZipCode()
        {
                Id = ZipID,
                Country = "Switzerland",
                Town = "Wildhaus",
                Zip = "9658"
         };
       

        public static readonly Customer Customer = new Customer()
        {
                Id = Guid.NewGuid(),
                Firstname = "Remo",
                Lastname = "Raschle",
                Street = "Strasse",
                Zip = ZipCode,
                ZipId = ZipID
         };
        

        public static Car Car = new Car()
        {
                Id = Guid.NewGuid(),
                Brand = "Renault Kadjar",
                Class = BaseCarClass,
                ClassId = BaseCarClass.Id,
                Type = "PW"
         };

        public static CarDto CarDto = new CarDto()
        {
            Id = Guid.NewGuid(),
            Brand = "Renault Kadjar",
            ClassId = BaseCarClass.Id,
            Type = "PW"
        };

        public static Reservation Reservation = new Reservation()
        {
            Id = Guid.NewGuid(),
            Car = Car,
            CarId = Car.Id,
            Customer = Customer,
            CustomerId = Customer.Id,
            Start = DateTime.Now,
            End = (DateTime.Now + TimeSpan.FromDays(2)),
            Status = ReservationStatus.Reserved
        };


    }
}

