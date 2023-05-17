using CafeShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.Data
{
    public class CafeShopDbContext : DbContext
    {
        public CafeShopDbContext() 
            : base("CafeShopDbContext")
        {
            Database.SetInitializer<CafeShopDbContext>(new CafeShopInitilizer());
        }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LoaiMon> LoaiMons { get; set; }
        public DbSet<MonAn> MonAns { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<Quyen> Quyens { get;set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
