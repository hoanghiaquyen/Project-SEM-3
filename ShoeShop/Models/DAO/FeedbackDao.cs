using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class FeedbackDao
    {
        ShoeShopDbContext db = null;

        public FeedbackDao()
        {
            db = new ShoeShopDbContext();
        }

        public bool SendFeedback(Feedback obj)
        {
            try
            {
                db.Feedbacks.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
