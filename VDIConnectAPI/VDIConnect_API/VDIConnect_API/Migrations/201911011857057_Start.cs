namespace VDIConnect_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enterprises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        IdCreator = c.Int(nullable: false),
                        NbSeat = c.Int(nullable: false),
                        Address = c.String(),
                        PostCode = c.String(),
                        City = c.String(),
                        IdHote = c.Int(),
                        IdVDI = c.Int(),
                        IdTypeInterest = c.Int(nullable: false),
                        IdEvent = c.Int(),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.IdEvent)
                .ForeignKey("dbo.TypeInterests", t => t.IdTypeInterest, cascadeDelete: true)
                .Index(t => t.IdTypeInterest)
                .Index(t => t.IdEvent);
            
            CreateTable(
                "dbo.TypeInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VDIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEnterprise = c.Int(nullable: false),
                        IdPerson = c.Int(nullable: false),
                        Archive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enterprises", t => t.IdEnterprise, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.IdPerson, cascadeDelete: true)
                .Index(t => t.IdEnterprise)
                .Index(t => t.IdPerson);
            
            AddColumn("dbo.People", "Session_Id", c => c.Int());
            CreateIndex("dbo.People", "Session_Id");
            AddForeignKey("dbo.People", "Session_Id", "dbo.Sessions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VDIs", "IdPerson", "dbo.People");
            DropForeignKey("dbo.VDIs", "IdEnterprise", "dbo.Enterprises");
            DropForeignKey("dbo.Sessions", "IdTypeInterest", "dbo.TypeInterests");
            DropForeignKey("dbo.People", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "IdEvent", "dbo.Events");
            DropIndex("dbo.VDIs", new[] { "IdPerson" });
            DropIndex("dbo.VDIs", new[] { "IdEnterprise" });
            DropIndex("dbo.Sessions", new[] { "IdEvent" });
            DropIndex("dbo.Sessions", new[] { "IdTypeInterest" });
            DropIndex("dbo.People", new[] { "Session_Id" });
            DropColumn("dbo.People", "Session_Id");
            DropTable("dbo.VDIs");
            DropTable("dbo.TypeInterests");
            DropTable("dbo.Sessions");
            DropTable("dbo.Enterprises");
        }
    }
}
