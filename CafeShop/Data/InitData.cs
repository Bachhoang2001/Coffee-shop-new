using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Data
{
    public static class InitData
    {
        public static void Init()
        {
            using (var context = new CafeShopDbContext())
            {
                IList<LoaiMon> defaultLoaiMon = new List<LoaiMon>();
                defaultLoaiMon.Add(new LoaiMon() { MaLoai = "L0001", TenLoai = "Các loại khác" });
                defaultLoaiMon.Add(new LoaiMon() { MaLoai = "L0002", TenLoai = "Cà phê" });
                defaultLoaiMon.Add(new LoaiMon() { MaLoai = "L0003", TenLoai = "Sinh tố" });
                defaultLoaiMon.Add(new LoaiMon() { MaLoai = "L0004", TenLoai = "Nước ép" });
                defaultLoaiMon.Add(new LoaiMon() { MaLoai = "L0005", TenLoai = "Nước ngọt" });
                defaultLoaiMon.Add(new LoaiMon() { MaLoai = "L0006", TenLoai = "Bánh" });
                if (!context.LoaiMons.Any())
                {
                    context.LoaiMons.AddRange(defaultLoaiMon);
                    context.SaveChanges();
                }

            }
        }
    }
}
