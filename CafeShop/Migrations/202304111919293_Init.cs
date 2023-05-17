namespace CafeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 128),
                        MaMon = c.String(nullable: false, maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaMon })
                .ForeignKey("dbo.HoaDons", t => t.MaHD, cascadeDelete: true)
                .ForeignKey("dbo.MonAns", t => t.MaMon, cascadeDelete: true)
                .Index(t => t.MaHD)
                .Index(t => t.MaMon);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 128),
                        MaKH = c.String(maxLength: 128),
                        MaNV = c.String(maxLength: 128),
                        NgayLap = c.DateTime(nullable: false),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH)
                .ForeignKey("dbo.NhanViens", t => t.MaNV)
                .Index(t => t.MaKH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        GioiTinh = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        GioiTinh = c.Boolean(nullable: false),
                        MatKhau = c.String(),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.MonAns",
                c => new
                    {
                        MaMon = c.String(nullable: false, maxLength: 128),
                        TenMon = c.String(),
                        MaLoai = c.String(maxLength: 128),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HinhAnh = c.String(),
                    })
                .PrimaryKey(t => t.MaMon)
                .ForeignKey("dbo.LoaiMons", t => t.MaLoai)
                .Index(t => t.MaLoai);
            
            CreateTable(
                "dbo.LoaiMons",
                c => new
                    {
                        MaLoai = c.String(nullable: false, maxLength: 128),
                        TenLoai = c.String(),
                    })
                .PrimaryKey(t => t.MaLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDons", "MaMon", "dbo.MonAns");
            DropForeignKey("dbo.MonAns", "MaLoai", "dbo.LoaiMons");
            DropForeignKey("dbo.HoaDons", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDons", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHD", "dbo.HoaDons");
            DropIndex("dbo.MonAns", new[] { "MaLoai" });
            DropIndex("dbo.HoaDons", new[] { "MaNV" });
            DropIndex("dbo.HoaDons", new[] { "MaKH" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaMon" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHD" });
            DropTable("dbo.LoaiMons");
            DropTable("dbo.MonAns");
            DropTable("dbo.NhanViens");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ChiTietHoaDons");
        }
    }
}
