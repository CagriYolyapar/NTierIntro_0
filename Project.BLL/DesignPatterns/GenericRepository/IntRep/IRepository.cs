using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T:BaseEntity
    {
        //List Commands

        List<T> GetAll(); //bu metot ilgili T neyse o yapıdaki tüm verileri getirecek...
        List<T> GetActives();//bu metot sadece Aktif kullanımda olan verileri getirecek...
        List<T> GetPassives(); // bu metot sadece Pasif olan verileri getirecek...
        List<T> GetModifieds(); //bu metot sadece güncellenmiş olan verileri getirecek

        //Modification Commands
        void Add(T item);
        void AddRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<T> list);


        /// <summary>
        /// Bu metot argüman olarak verdiginiz veriyi pasife ceker
        /// </summary>
        /// <param name="item">Pasife cekilecek olan veri</param>
        void Delete(T item);
        void DeleteRange(List<T> list);

        /// <summary>
        /// Bu metot argüman olarak verdiginiz veriyi siler
        /// </summary>
        /// <param name="item">Silinmesini istediginiz veri</param>
        void Destroy(T item);
        void DestroyRange(List<T> list);

        //Linq Expressions

        List<T> Where(Expression<Func<T,bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);

        // Find Commands

        T Find(int id);
        

       

    }
}
