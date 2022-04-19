using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
       protected  MyContext _db;


        public BaseRepository()
        {
            _db = DBTool.DBInstance;

           
          
        }

        protected void Save()
        {
            _db.SaveChanges();
        }


        //Set metodunuz kendisine generic olarak ne tip verilirse gidip kendisini o tipe göre ayarlar...Yani bu SQL'de kendisini ilgili tipin denk düstügü tabloya göre ayarlaması demektir...
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(Find(item.ID));
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);

        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            T guncellenecek = Find(item.ID);

            //Entry metodu veritabanında bir güncelleme yapılacagını bildirerek giriş(baglantı) yapılmasını saglayan bir metottur...

            _db.Entry(guncellenecek).CurrentValues.SetValues(item);
            //Entry metodu Veritabanına bir modifikasyon girişi var demektedir ve bu metodun bu işlemini hangi veri üzerinden gerçekleştirecegini bilmesi gerekir...BU veriyi ID üzerinden yakalayarak onun güncellenmesi gerektigini söylüyoruz...Onun orijinal degerlerine kendi gönderdigimiz item'in degerlerini atıyoruz...
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        public void SetActive(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Inserted;
            item.ModifiedDate = DateTime.Now;

            Save();
        }
    }
}
