using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T:BaseEntity
    {

        //C#'ta referans tipler siz müdahale etmediginizde Sql'e otomatik olarak null gecilebilir gider, deger tipler ise siz müdahale etmediginizde otomatik olarak null gecilemez gider...Bir deger tipinin SQL tarafında null gecilebilmesini istiyorsanız ilgili tipin nullable olarak işaretlenmesini saglamalısınız...
        public BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Yaratılma Tarihi").HasColumnType("datetime2");
            Property(x => x.ModifiedDate).HasColumnName("Guncelleme Tarihi").HasColumnType("datetime2");
            Property(x => x.DeletedDate).HasColumnName("Silme Tarihi").HasColumnType("datetime2");
            Property(x => x.Status).HasColumnName("Veri Durumu");
        }
    }
}
