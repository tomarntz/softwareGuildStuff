namespace HeroSaga.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Battles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        MonsterId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        IsMonsterDefeated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Monsters", t => t.MonsterId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.MonsterId);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RaceId = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Discription = c.String(),
                        Alignment = c.Int(nullable: false),
                        Monster_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Monsters", t => t.Monster_Id)
                .Index(t => t.RaceId)
                .Index(t => t.Monster_Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monsters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Battles", "MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.Characters", "Monster_Id", "dbo.Monsters");
            DropForeignKey("dbo.Characters", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Battles", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Characters", new[] { "Monster_Id" });
            DropIndex("dbo.Characters", new[] { "RaceId" });
            DropIndex("dbo.Battles", new[] { "MonsterId" });
            DropIndex("dbo.Battles", new[] { "CharacterId" });
            DropTable("dbo.Monsters");
            DropTable("dbo.Races");
            DropTable("dbo.Characters");
            DropTable("dbo.Battles");
        }
    }
}
