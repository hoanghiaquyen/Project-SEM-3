using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Admin_FeedbackDao
    {
        ShoeShopDbContext db = null;
        public Admin_FeedbackDao()
        {
            db = new ShoeShopDbContext();
        }
        

        



        

        public Feedback ViewDetail(long id)
        {
            return db.Feedbacks.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var Fb = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(Fb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Feedback> ListAllFeedback()
        {
            return db.Feedbacks.ToList();
        }
    }
}
