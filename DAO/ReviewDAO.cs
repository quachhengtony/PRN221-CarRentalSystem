using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAO
{
    public class ReviewDAO : IDAO<Review>
    {
        private static ReviewDAO instance = null;
        private static readonly object instanceLock = new object();
        private static CarRentalSystemDBContext dbContext;

        private ReviewDAO() { }

        public static ReviewDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReviewDAO();
                        dbContext = new CarRentalSystemDBContext();
                    }
                    return instance;
                }
            }
        }

        public void Delete(Review t)
        {
            dbContext.Reviews.Remove(t);
            SaveChanges();
        }

        public Review RetrieveById(string id)
        {
            return dbContext.Reviews.Find(id);
        }

        public List<Review> Retrieve()
        {
            return dbContext.Reviews.ToList();
        }

        public void Create(Review t)
        {
            dbContext.Reviews.Add(t);
            SaveChanges();
        }

        public void Update(Review t)
        {
            dbContext.Reviews.Update(t);
            SaveChanges();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
