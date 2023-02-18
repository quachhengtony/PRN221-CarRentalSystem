using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Delete(Customer t)
        {
            CustomerDAO.Instance.Delete(t);
        }

        public Customer RetrieveById(string id)
        {
            return CustomerDAO.Instance.RetrieveById(id);
        }

        public List<Customer> Retrieve()
        {
            return CustomerDAO.Instance.Retrieve();
        }

        public List<Customer> SearchByString(string search)
        {
            return CustomerDAO.Instance.SearchByString(search);
        }

        public void Create(Customer t)
        {
            CustomerDAO.Instance.Create(t);
        }

        public void Update(Customer t)
        {
            CustomerDAO.Instance.Update(t);
        }

        public Boolean existById(string id)
        {
            return CustomerDAO.Instance.RetrieveById(id) != null;
        }
    }
}
