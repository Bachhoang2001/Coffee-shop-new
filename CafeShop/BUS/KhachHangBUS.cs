using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class KhachHangBUS : BaseBUS
    {
        public List<KhachHang> GetAll()
        {
            return Db.KhachHangs.ToList();
        }
        public KhachHang GetByMaKH(string maKH)
        {
            return Db.KhachHangs.FirstOrDefault(x => x.MaKH == maKH);
        }
        public bool Add(KhachHang kh)
        {
            try
            {
                Db.KhachHangs.Add(kh);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(KhachHang kh)
        {
            try
            {
                var khachHang = GetByMaKH(kh.MaKH);
                khachHang.HoTen = kh.HoTen;
                khachHang.DiaChi = kh.DiaChi;
                khachHang.SDT = kh.SDT;
                khachHang.GioiTinh = kh.GioiTinh;
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string maKH)
        {
            try
            {
                var khachHang = GetByMaKH(maKH);
                Db.KhachHangs.Remove(khachHang);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string TaoMoiMa(string prefix)
        {
            var ma = Db.KhachHangs
               .Select
               (
                   x => x.MaKH.Substring(prefix.Length)
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
