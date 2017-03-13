using System;
using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Model.Dao
{
    public class UserDao
    {
        ShoeShopDbContext db = null;
        public UserDao()
        {
            db = new ShoeShopDbContext();
        }

        public bool Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return true;
        }
       
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                user.UserName = entity.UserName;
              
               
                user.Email = entity.Email;
                user.PhoneNumber = entity.PhoneNumber;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

      

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(string id)
        {
            return db.Users.Find(id);
        }
        
        public bool Login(string userName, string passWord)
        {
                    
           var result = db.Users.Count(x => x.UserName == userName && x.PasswordHash == passWord );
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       

       
        public bool Delete(string id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

   

        public IEnumerable<User> ListAllUser()
        {
            return db.Users.ToList();
        }
    }
}
