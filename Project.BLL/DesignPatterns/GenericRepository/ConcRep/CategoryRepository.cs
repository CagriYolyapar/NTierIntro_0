using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep
{
    public class CategoryRepository:BaseRepository<Category>
    {
        //Eger Kategoriye özel bir metot istiyorsak

        /// <summary>
        /// Bu metot Kategori eklerken elinizde eger veritabanında hazır ürünler varsa direkt onların kategorisini yeni eklenen kategori yapacaktır...
        /// </summary>
        /// <param name="item">Eklenecek Kategori</param>
        /// <param name="products">Veritabanındaki ürünler</param>
        public void CategorySpecialMethod(Category item,List<Product> products)
        {
            _db.Categories.Add(item);
            foreach (Product pro in products)
            {
                pro.CategoryID = item.ID;
            }
            Save();
            
        }

    }
}
