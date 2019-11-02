namespace VDIConnect_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commentaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Sender = c.String(nullable: false),
                        TypeCommentaireId = c.Int(),
                        IdEvent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.IdEvent, cascadeDelete: true)
                .ForeignKey("dbo.TypeCommentaries", t => t.TypeCommentaireId)
                .Index(t => t.TypeCommentaireId)
                .Index(t => t.IdEvent);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IdPersonne = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.IdPersonne)
                .Index(t => t.IdPersonne);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Lastname = c.String(nullable: false),
                        Firstname = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(),
                        City = c.String(),
                        RoleId = c.Int(nullable: false),
                        AccountArchive = c.Boolean(nullable: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.RoleId)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeCommentaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VDIs", "IdPerson", "dbo.People");
            DropForeignKey("dbo.VDIs", "IdEnterprise", "dbo.Enterprises");
            DropForeignKey("dbo.Sessions", "IdTypeInterest", "dbo.TypeInterests");
            DropForeignKey("dbo.People", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "IdEvent", "dbo.Events");
            DropForeignKey("dbo.Commentaries", "TypeCommentaireId", "dbo.TypeCommentaries");
            DropForeignKey("dbo.Commentaries", "IdEvent", "dbo.Events");
            DropForeignKey("dbo.Events", "IdPersonne", "dbo.People");
            DropForeignKey("dbo.People", "RoleId", "dbo.Roles");
            DropIndex("dbo.VDIs", new[] { "IdPerson" });
            DropIndex("dbo.VDIs", new[] { "IdEnterprise" });
            DropIndex("dbo.Sessions", new[] { "IdEvent" });
            DropIndex("dbo.Sessions", new[] { "IdTypeInterest" });
            DropIndex("dbo.People", new[] { "Session_Id" });
            DropIndex("dbo.People", new[] { "RoleId" });
            DropIndex("dbo.Events", new[] { "IdPersonne" });
            DropIndex("dbo.Commentaries", new[] { "IdEvent" });
            DropIndex("dbo.Commentaries", new[] { "TypeCommentaireId" });
            DropTable("dbo.VDIs");
            DropTable("dbo.TypeInterests");
            DropTable("dbo.Sessions");
            DropTable("dbo.Enterprises");
            DropTable("dbo.TypeCommentaries");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            DropTable("dbo.Events");
            DropTable("dbo.Commentaries");
        }
    }
}
