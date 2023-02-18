using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;
namespace Repo
{
    public class CarProducerRepository : IRepository<CarProducer>
    {
        public void Delete(CarProducer t)
        {
            CarProducerDAO.Instance.Delete(t);
        }

        public CarProducer RetrieveById(string id)
        {
            return CarProducerDAO.Instance.RetrieveById(id);
        }

        public List<CarProducer> Retrieve()
        {
            return CarProducerDAO.Instance.Retrieve();
        }

        public void Create(CarProducer t)
        {
            CarProducerDAO.Instance.Create(t);
        }

        public void Update(CarProducer t)
        {
            CarProducerDAO.Instance.Update(t);
        }
    }
}
