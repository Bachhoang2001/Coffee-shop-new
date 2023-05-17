using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class NhanVienBUS : BaseBUS
    {

        public string TaoMoiMa(string prefix)
        {
            var ma = Db.NhanViens
                .Select
                (
                    x => x.MaNV.Substring(prefix.Length)
                )
                .ToList();

            int max = 0;

            if (ma.Count > 0)
            {
                max = ma.Select(x => int.Parse(x)).Max();
            }

            return prefix + (max + 1).ToString("0000");
        }


        public List<NhanVien> GetAll()
        {
            return Db.NhanViens.ToList();
        }
        public NhanVien GetByMaNV(string maNV)
        {
            return Db.NhanViens.FirstOrDefault(x => x.MaNV == maNV);
        }
        public bool Add(NhanVien nv)
        {
            try
            {
                Db.NhanViens.Add(nv);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(NhanVien nv)
        {
            try
            {
                var nhanVien = GetByMaNV(nv.MaNV);
                nhanVien.HoTen = nv.HoTen;
                nhanVien.DiaChi = nv.DiaChi;
                nhanVien.SDT = nv.SDT;
                nhanVien.GioiTinh = nv.GioiTinh;
                nhanVien.MatKhau = nv.MatKhau;
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string maNV)
        {
            try
            {
                var nhanVien = GetByMaNV(maNV);
                Db.NhanViens.Remove(nhanVien);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }   

        public NhanVien GetUserInfoByLogin(string maNV, string matKhau)
        {
            var nhanVien = Db.NhanViens.Where(x => x.MaNV == maNV 
                && x.MatKhau == matKhau).FirstOrDefault();
            return nhanVien;
        }
    }
}
