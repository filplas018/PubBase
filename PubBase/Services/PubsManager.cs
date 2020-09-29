using PubBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubBase.Services
{
    public class PubsManager
    {
        private AppDbContext _db;   
        public PubsManager(AppDbContext db)
        {
            _db = db;
        }
        public List<Pub> List(string name)
        {
            IQueryable<Pub> pubs = _db.Pubs;
            if (!String.IsNullOrEmpty(name)) pubs.Where(p => p.Name.Contains(name));
            return pubs.ToList();
        }
        public bool Create(Pub item)
        {
            try
            {
                _db.Pubs.Add(item);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }            
        }
        public Pub Read(int id)
        {
            return _db.Pubs.SingleOrDefault(p => p.Id == id);
        }
        public bool Delete(int id)
        {
            try
            {
                var pub = _db.Pubs.SingleOrDefault(p => p.Id == id);
                _db.Pubs.Remove(pub);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(int id, Pub item)
        {
            try
            {
                var pub = _db.Pubs.SingleOrDefault(p => p.Id == id);
                pub.Name = item.Name;
                pub.Municipality = item.Municipality;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
