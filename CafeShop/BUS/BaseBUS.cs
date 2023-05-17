using CafeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class BaseBUS : IDisposable
    {
        public CafeShopDbContext Db { get; set; }

        public BaseBUS()
        {
            Db = new CafeShopDbContext();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
