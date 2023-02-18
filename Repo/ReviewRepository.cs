using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAO;

namespace Repo
{
    public class ReviewRepository : IRepository<Review>
    {
        public void Delete(Review t)
        {
            ReviewDAO.Instance.Delete(t);
        }

        public Review RetrieveById(string id)
        {
            return ReviewDAO.Instance.RetrieveById(id);
        }

        public List<Review> Retrieve()
        {
            return ReviewDAO.Instance.Retrieve();
        }

        public void Create(Review t)
        {
            ReviewDAO.Instance.Create(t);
        }

        public void Update(Review t)
        {
            ReviewDAO.Instance.Update(t);
        }
    }
}
