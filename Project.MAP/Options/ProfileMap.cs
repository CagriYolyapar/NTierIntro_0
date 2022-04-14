using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ProfileMap:BaseMap<AppUserProfile>
    {
        public ProfileMap()
        {
            Property(x => x.FirstName).HasColumnName("Isim");
            Property(x => x.LastName).HasColumnName("SoyIsim");
            ToTable("Profiller");
        }
    }
}
