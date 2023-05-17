using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Data
{
    public class CafeShopInitilizer: DropCreateDatabaseIfModelChanges<CafeShopDbContext>
    {
    }
}
