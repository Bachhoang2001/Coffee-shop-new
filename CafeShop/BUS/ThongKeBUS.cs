using CafeShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class ThongKeBUS : BaseBUS
    {
        public ThongKeBUS() : base() { }

        public List<DoanhThuViewModel> GetDoanhThu(DateTime date)
        {
            string sql = "SELECT ma.MaLoai, lm.TenLoai, SUM(ct.SoLuong * ct.DonGia) AS [DoanhThu] FROM ChiTietHoaDons ct INNER JOIN HoaDons hd\r\nON ct.MaHD = hd.MaHD INNER JOIN MonAns ma ON ct.MaMon = ma.MaMon \r\nINNER JOIN LoaiMons lm ON ma.MaLoai = lm.MaLoai\r\nWHERE cast(NgayLap AS DATE) = CAST('{0}' AS DATE)\r\nGROUP BY ma.MaLoai, lm.TenLoai";
            sql = string.Format(sql, date.ToString("yyyy/MM/dd"));
            return Db.Database.SqlQuery<DoanhThuViewModel>(sql).ToList();
        }
    }
}
