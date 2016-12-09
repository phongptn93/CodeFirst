namespace CodeFristProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Standards", newName: "StandardInfo");
            RenameTable(name: "dbo.Students", newName: "StudentInfo");
            CreateTable(
                "dbo.StudentInfoDetail",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        Photo = c.Binary(),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.StudentInfo", t => t.StudentID)
                .Index(t => t.StudentID);
            
            DropColumn("dbo.StudentInfo", "DateOfBirth");
            DropColumn("dbo.StudentInfo", "Photo");
            DropColumn("dbo.StudentInfo", "Height");
            DropColumn("dbo.StudentInfo", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentInfo", "Weight", c => c.Single(nullable: false));
            AddColumn("dbo.StudentInfo", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.StudentInfo", "Photo", c => c.Binary());
            AddColumn("dbo.StudentInfo", "DateOfBirth", c => c.DateTime());
            DropForeignKey("dbo.StudentInfoDetail", "StudentID", "dbo.StudentInfo");
            DropIndex("dbo.StudentInfoDetail", new[] { "StudentID" });
            DropTable("dbo.StudentInfoDetail");
            RenameTable(name: "dbo.StudentInfo", newName: "Students");
            RenameTable(name: "dbo.StandardInfo", newName: "Standards");
        }
    }
}
