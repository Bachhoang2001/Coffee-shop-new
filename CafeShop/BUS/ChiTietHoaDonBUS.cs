using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class ChiTietHoaDonBUS : BaseBUS
    {
        List<ChiTietHoaDon> LayTheoMaHoaDon(string maHD)
        {
            // lấy tất cả hoá đơn theo mã hoá đơn
            return Db.ChiTietHoaDons.Where(x => x.MaHD == maHD).ToList(); 
        }

        
        public bool XoaTheoMaHD(string maHD)
        {
            var results = Db.ChiTietHoaDons.RemoveRange(LayTheoMaHoaDon(maHD));
            return results.Count() > 0;
        }
    }
}
