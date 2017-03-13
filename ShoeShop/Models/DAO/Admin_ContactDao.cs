using System;
using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Models.DAO
{
    public class Admin_ContactDao
    {
        ShoeShopDbContext db = null;
        public Admin_ContactDao()
        {
            db = new ShoeShopDbContext();
        }
        public bool Insert(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Contact entity)
        {
            try
            {
                var contact = db.Contacts.Find(entity.Id);
                contact.Content = entity.Content;
                contact.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }

        public Contact ViewContact(long id)
        {
            return db.Contacts.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Contact> ListAllContact()
        {
            return db.Contacts.ToList();
        }
    }
}
