using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class StaffAccountDAO : IDAO<StaffAccount>
    {
        private static StaffAccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private static CarRentalSystemDBContext dbContext;

        private StaffAccountDAO() { }
        
        public static StaffAccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StaffAccountDAO();
                        dbContext = new CarRentalSystemDBContext();
                    }
                    return instance;
                }
            }
        }

        public void Delete(StaffAccount t)
        {
            dbContext.StaffAccounts.Remove(t);
            SaveChanges();
        }

        public StaffAccount RetrieveById(string id)
        {
            return dbContext.StaffAccounts.Where(s => s.Email.Equals(id)).FirstOrDefault();
        }

        public List<StaffAccount> Retrieve()
        {
            return dbContext.StaffAccounts.ToList();
        }

        public void Create(StaffAccount t)
        {
            dbContext.StaffAccounts.Add(t);
            SaveChanges();
        }

        public void Update(StaffAccount t)
        {
            dbContext.StaffAccounts.Update(t);
            SaveChanges();
        }

        public List<StaffAccount> SearchByString(string searchString)
        {
            return dbContext.StaffAccounts.Where(i => i.FullName.Contains(searchString) || i.StaffId.Contains(searchString)).ToList();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
