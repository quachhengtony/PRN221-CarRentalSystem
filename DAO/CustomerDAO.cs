using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class CustomerDAO : IDAO<Customer>
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();
        private static CarRentalSystemDBContext dbContext;

        private CustomerDAO() { }

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                        dbContext = new CarRentalSystemDBContext();
                    }
                    return instance;
                }
            }
        }

        public void Delete(Customer t)
        {
            dbContext.Customers.Remove(t);
            SaveChanges();
        }

        public Customer RetrieveById(string id)
        {
            //return dbContext.Customers.Find(id);
            return dbContext.Customers.Where(c => c.CustomerEmail.Equals(id)).FirstOrDefault();
        }

        public List<Customer> Retrieve()
        {
            return dbContext.Customers.ToList();
        }

        public List<Customer> SearchByString(string searchString)
        {
            return dbContext.Customers.Where(i => i.CustomerId.Contains(searchString) || i.CustomerName.Contains(searchString)).ToList();
        }

        public void Create(Customer t)
        {
            dbContext.Customers.Add(t);
            SaveChanges();
        }

        public void Update(Customer t)
        {
            dbContext.Customers.Update(t);
            SaveChanges();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
