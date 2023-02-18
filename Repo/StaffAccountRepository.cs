using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class StaffAccountRepository : IRepository<StaffAccount>
    {
        public void Delete(StaffAccount t)
        {
            StaffAccountDAO.Instance.Delete(t);
        }

        public StaffAccount RetrieveById(string id)
        {
            return StaffAccountDAO.Instance.RetrieveById(id);
        }

        public List<StaffAccount> Retrieve()
        {
            return StaffAccountDAO.Instance.Retrieve();
        }

        public void Create(StaffAccount t)
        {
            StaffAccountDAO.Instance.Create(t);
        }

        public void Update(StaffAccount t)
        {
            StaffAccountDAO.Instance.Update(t);
        }

        public List<StaffAccount> SearchByString(string searchString)
        {
            return StaffAccountDAO.Instance.SearchByString(searchString);
        }
    }
}
