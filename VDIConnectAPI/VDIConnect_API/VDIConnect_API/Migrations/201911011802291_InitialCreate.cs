namespace VDIConnect_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        Phone = c.String(),
                        City = c.String(),
                        RoleId = c.Int(nullable: false),
                        AccountArchive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commentaries", "TypeCommentaireId", "dbo.TypeCommentaries");
            DropForeignKey("dbo.Commentaries", "IdEvent", "dbo.Events");
            DropForeignKey("dbo.Events", "IdPersonne", "dbo.People");
            DropForeignKey("dbo.People", "RoleId", "dbo.Roles");
            DropIndex("dbo.People", new[] { "RoleId" });
            DropIndex("dbo.Events", new[] { "IdPersonne" });
            DropIndex("dbo.Commentaries", new[] { "IdEvent" });
            DropIndex("dbo.Commentaries", new[] { "TypeCommentaireId" });
            DropTable("dbo.TypeCommentaries");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            DropTable("dbo.Events");
            DropTable("dbo.Commentaries");
        }
    }
}
