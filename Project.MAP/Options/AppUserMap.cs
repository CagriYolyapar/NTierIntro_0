using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap:BaseMap<AppUser>
    {

        public AppUserMap()
        {
            ToTable("Kullanıcılar");
            Property(x => x.UserName).HasColumnName("Kullanıcı Ismi").IsRequired();
            Property(x => x.Password).HasColumnName("Sifre").IsRequired().HasMaxLength(8);

            HasOptional(x => x.Profile).WithRequired(x => x.AppUser); //Birebir ilişkinin tamamlanması zorunludur...
        }
    }
}
