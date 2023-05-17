using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class QuyenBUS : BaseBUS
    {
        public List<Quyen> GetAll()
        {
            return Db.Quyens.ToList();
        }
    }
}
