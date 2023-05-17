using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class HoaDonBUS : BaseBUS
    {
        public List<HoaDon> GetList()
        {
            return Db.HoaDons.ToList();
        }
        public HoaDon Get(string id)
        {
            return Db.HoaDons.Find(id);
        }
        public bool Add(HoaDon hd)
        {
            try
            {
                Db.HoaDons.Add(hd);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Update(HoaDon hd)
        {
            try
            {
                var hdUpdate = Db.HoaDons.Find(hd.MaHD);
                hdUpdate.NgayLap = hd.NgayLap;
                hdUpdate.TongTien = hd.TongTien;
                hdUpdate.MaNV = hd.MaNV;
                hdUpdate.MaKH = hd.MaKH;
                hdUpdate.GhiChu = hd.GhiChu;
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var hdDelete = Db.HoaDons.Find(id);
                Db.HoaDons.Remove(hdDelete);
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string TaoMoiMa(string prefix)
        {
            var ma = Db.HoaDons
               .Select
               (
                   x => x.MaHD.Substring(prefix.Length)
               )
               .ToList();

            int max = 0;

            if (ma.Count > 0)
            {
                max = ma.Select(x => int.Parse(x)).Max();
            }

            return prefix + (max + 1).ToString("0000");
        }
    }
}
