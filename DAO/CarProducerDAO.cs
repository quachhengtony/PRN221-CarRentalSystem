using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class CarProducerDAO : IDAO<CarProducer>
    {
        private static CarProducerDAO instance = null;
        private static readonly object instanceLock = new object();
        private static CarRentalSystemDBContext dbContext;

        private CarProducerDAO() { }
        
        public static CarProducerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarProducerDAO();
                        dbContext = new CarRentalSystemDBContext();
                    }
                    return instance;
                }
            }
        }

        public void Delete(CarProducer t)
        {
            dbContext.CarProducers.Remove(t);
            SaveChanges();
        }

        public CarProducer RetrieveById(string id)
        {
            return dbContext.CarProducers.Find(id);
        }

        public List<CarProducer> Retrieve()
        {
            return dbContext.CarProducers.ToList();
        }

        public void Create(CarProducer t)
        {
            dbContext.CarProducers.Add(t);
            SaveChanges();
        }

        public void Update(CarProducer t)
        {
            dbContext.CarProducers.Update(t);
            SaveChanges();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
