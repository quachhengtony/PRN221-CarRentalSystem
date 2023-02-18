using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class CarRepository : IRepository<Car>
    {
        public void Delete(Car t)
        {
            CarDAO.Instance.Delete(t);
        }

        public Car RetrieveById(string id)
        {
            return CarDAO.Instance.RetrieveById(id);
        }

        public List<Car> Retrieve()
        {
            return CarDAO.Instance.Retrieve();
        }
        
        public List<Car> SearchByString(string search)
        {
            return CarDAO.Instance.SearchByString(search);
        }

        public List<Car> RetrieveAvailableCarsByDate(DateTime startDate, DateTime endDate)
        {
            List<Car> cars = CarDAO.Instance.Retrieve();
            List<Car> availableCars = new List<Car>();
            List<CarRental> carRentals = CarRentalDAO.Instance.Retrieve();

            foreach (var car in cars)
            {
                if (CarRentalDAO.Instance.IsAvailableByDate(car.CarId, startDate, endDate))
                {
                    availableCars.Add(car);
                }
            }
            return availableCars;
        }

        public void Create(Car t)
        {
            CarDAO.Instance.Create(t);
        }

        public void Update(Car t)
        {
            CarDAO.Instance.Update(t);
        }

        public Boolean existById(string id)
        {
            return CarDAO.Instance.RetrieveById(id) != null;
        }
    }
}
