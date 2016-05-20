using System.Data.Entity.Migrations;

namespace MrmTechTest.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Long(false, true),
                    Name = c.String(),
                    LastModified = c.DateTime(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Long(false, true),
                    Name = c.String(),
                    Description = c.String(),
                    LastModified = c.DateTime(false),
                    Category_Id = c.Long()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] {"Category_Id"});
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}