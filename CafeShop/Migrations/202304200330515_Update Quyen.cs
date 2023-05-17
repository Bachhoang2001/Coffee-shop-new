namespace CafeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateQuyen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quyens",
                c => new
                    {
                        MaQuyen = c.String(nullable: false, maxLength: 128),
                        TenQuyen = c.String(),
                    })
                .PrimaryKey(t => t.MaQuyen);
            
            AddColumn("dbo.NhanViens", "MaQuyen", c => c.String(maxLength: 128));
            CreateIndex("dbo.NhanViens", "MaQuyen");
            AddForeignKey("dbo.NhanViens", "MaQuyen", "dbo.Quyens", "MaQuyen");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanViens", "MaQuyen", "dbo.Quyens");
            DropIndex("dbo.NhanViens", new[] { "MaQuyen" });
            DropColumn("dbo.NhanViens", "MaQuyen");
            DropTable("dbo.Quyens");
        }
    }
}
