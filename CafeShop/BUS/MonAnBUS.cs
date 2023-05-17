using CafeShop.Data;
using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.BUS
{
    public class MonAnBUS : BaseBUS
    {

        public string TaoMoiMa(string prefix)
        {
            var ma = Db.MonAns
                .Select
                (
                    x => x.MaMon.Substring(prefix.Length)
                )
                .ToList();

            int max = 0;

            if (ma.Count > 0)
            {
                max = ma.Select(x => int.Parse(x)).Max();
            }

            return prefix + (max + 1).ToString("0000");
        }

        public List<MonAn> GetAll()
        {
            return Db.MonAns.ToList();
        }

        public MonAn GetByMa(string maMon)
        {
            return Db.MonAns.Find(maMon);
        }

        public bool Them(MonAn monAn)
        {
            try
            {
                Db.MonAns.Add(monAn);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool trungMon(string maMon)
        {
            return Db
                .MonAns
                .Any(m => m.MaMon == maMon);
        }
    }
}
