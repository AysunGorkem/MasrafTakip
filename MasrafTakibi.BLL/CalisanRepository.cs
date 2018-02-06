using MasrafTakibi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasrafTakibi.BLL
{
    public class CalisanRepository : IRepository<Calisan>
    {
        MasrafDBEntities db = new MasrafDBEntities();
        public void Delete(int itemID)
        {
            db.Calisan.Remove(db.Calisan.Find(itemID));
            db.SaveChanges();
        }

        public void Insert(Calisan item)
        {
            db.Calisan.Add(item);
            db.SaveChanges();
        }

        public List<Calisan> SelectAll()
        {
            return db.Calisan.ToList();
        }

        public List<MasrafTakibi.DAL.Calisan> SelectByCalisanID(int ID)
        {
            return db.Calisan.Where(c => c.CalisanID == ID).ToList();
        }

        public Calisan SelectById(int İtemID)
        {
            return db.Calisan.Find(İtemID);
        }

        public void Update(Calisan item)
        {
            Calisan guncelle = db.Calisan.Find(item.CalisanID);
            db.Entry(guncelle).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
