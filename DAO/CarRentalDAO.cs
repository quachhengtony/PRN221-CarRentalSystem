using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class CarRentalDAO : IDAO<CarRental>
    {
        private static CarRentalDAO instance = null;
        private static readonly object instanceLock = new object();
        private static CarRentalSystemDBContext dbContext;

        private CarRentalDAO() { }

        public static CarRentalDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarRentalDAO();
                        dbContext = new CarRentalSystemDBContext();
                    }
                    return instance;
                }
            }
        }

        public void Delete(CarRental t)
        {
            dbContext.CarRentals.Remove(t);
            SaveChanges();
        }

        public CarRental RetrieveById(string id)
        {
            return dbContext.CarRentals.Find(id);
        }

        public List<CarRental> Retrieve()
        {
            return dbContext.CarRentals.Include(c => c.Car).Include(c => c.Customer).ToList();
        }

        public List<CarRental> SearchByString(string carId)
        {
            return dbContext.CarRentals.Where(cr => cr.CarId == carId).ToList();    
        }

        public bool IsAvailableByDate(string carId, DateTime startDate, DateTime endDate)
        {
            return dbContext.CarRentals
                .Where(i => i.CarId == carId)
                .Where(
                    i =>
                    (i.PickupDate <= startDate && endDate <= i.ReturnDate) // Middle
                    || (startDate <= i.PickupDate && endDate <= i.PickupDate) // Left
                    || (i.ReturnDate >= startDate && i.ReturnDate <= endDate)) // Right
                .Count() == 0;
        }

        public void Create(CarRental t)
        {
            dbContext.CarRentals.Add(t);
            SaveChanges();
        }

        public void Update(CarRental t)
        {
            dbContext.CarRentals.Update(t);
            SaveChanges();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
