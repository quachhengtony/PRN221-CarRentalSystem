using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class CarDAO : IDAO<Car>
    {
        private static CarDAO instance = null;
        private static readonly object instanceLock = new object();
        private static CarRentalSystemDBContext dbContext;

        private CarDAO() { }

        public static CarDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDAO();
                        dbContext = new CarRentalSystemDBContext();
                    }
                    return instance;
                }
            }
        }

        public void Delete(Car t)
        {
            dbContext.Cars.Remove(t);
            SaveChanges();
        }

        public Car RetrieveById(string id)
        {
            return dbContext.Cars.Find(id);
        }

        public List<Car> Retrieve()
        {
            return dbContext.Cars.ToList();
        }

        public List<Car> SearchByString(string searchString)
        {
            return dbContext.Cars.Where(i => i.CarId.Contains(searchString) || i.CarName.Contains(searchString)).ToList();
        }

        public void Create(Car t)
        {
            dbContext.Cars.Add(t);
            SaveChanges();
        }

        public void Update(Car t)
        {
            dbContext.Cars.Update(t);
            SaveChanges();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
