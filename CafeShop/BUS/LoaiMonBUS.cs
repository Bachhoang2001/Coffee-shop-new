using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class LoaiMonBUS : BaseBUS
    {
        public string TaoMoiMa(string prefix)
        {
            var ma = Db.LoaiMons
                .Select
                (
                    x => x.MaLoai.Substring(prefix.Length)
                )
                .ToList();

            int max = 0;

            if (ma.Count > 0)
            {
                max = ma.Select(x => int.Parse(x)).Max();
            }

            return prefix + (max + 1).ToString("0000");
        }

        public List<LoaiMon> GetAll()
        {
            return Db.LoaiMons.ToList();
        }
        public LoaiMon GetByMaLoai(string maLoai)
        {
            return Db.LoaiMons.Find(maLoai);
        }
        public bool Insert(LoaiMon loaiMon)
        {
            try
            {
                Db.LoaiMons.Add(loaiMon);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(LoaiMon loaiMon)
        {
            try
            {
                var old = Db.LoaiMons.Find(loaiMon.MaLoai);
                old.TenLoai = loaiMon.TenLoai;
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var old = Db.LoaiMons.Find(id);
                Db.LoaiMons.Remove(old);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }   
    }
}
