using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CarRent.Backend.Common.Infrastructure.Context;
using CarRent.Backend.Common.Interfaces;
using CarRent.Model.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Backend.ReservationManagement.Infrastructure
{
    public class ReservationRepository : IRepository<Reservation, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public ReservationRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<Reservation> GetAll()
        {
            return _carRentDbContext.Reservations.Include(x => x.Car).Include(x => x.Customer).ToList();
        }

        public List<Reservation> FindById(Guid id)
        {
            return _carRentDbContext.Reservations.Include(x => x.Car).Include(x => x.Customer).Where(x => x.Id.Equals(id)).ToList();
        }

        public void Insert(Reservation entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(Reservation entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id).FirstOrDefault());
        }

        public void Remove(Reservation entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
