using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class CarRentalRepository : IRepository<CarRental>
    {
        public void Delete(CarRental t)
        {
            CarRentalDAO.Instance.Delete(t);
        }

        public CarRental RetrieveById(string id)
        {
            return CarRentalDAO.Instance.RetrieveById(id);
        }

        public List<CarRental> Retrieve()
        {
            return CarRentalDAO.Instance.Retrieve();
        }

        public List<CarRental> SearchByString(string searchString)
        {
            return CarRentalDAO.Instance.SearchByString(searchString);
        }

        public void Create(CarRental t)
        {
            CarRentalDAO.Instance.Create(t);
        }

        public void Update(CarRental t)
        {
            CarRentalDAO.Instance.Update(t);
        }
    }
}
