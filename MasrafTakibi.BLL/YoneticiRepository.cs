using MasrafTakibi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasrafTakibi.BLL
{
    public class YoneticiRepository : IRepository<Yonetici>
    {
        MasrafDBEntities db = new MasrafDBEntities();
        public void Delete(int itemID)
        {
            db.Yonetici.Remove(db.Yonetici.Find(itemID));
            db.SaveChanges();
        }

        public void Insert(Yonetici item)
        {
            db.Yonetici.Add(item);
            db.SaveChanges();
        }

        public List<Yonetici> SelectAll()
        {
            return db.Yonetici.ToList();
        }
        public List<MasrafTakibi.DAL.Yonetici> SelectByYoneticiID(int ID)
        {
            return db.Yonetici.Where(c => c.YoneticiID == ID).ToList();
        }

        public Yonetici SelectById(int İtemID)
        {
            return db.Yonetici.Find(İtemID);
        }

        public void Update(Yonetici item)
        {
            Yonetici guncelle = db.Yonetici.Find(item.YoneticiID);
            db.Entry(guncelle).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
