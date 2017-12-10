namespace WarframeDataParser.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        RewardTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RewardTypes", t => t.RewardTypeId, cascadeDelete: true)
                .Index(t => t.RewardTypeId);
            
            CreateTable(
                "dbo.Relics",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        RelicTierId = c.Long(nullable: false),
                        RelicStateId = c.Long(nullable: false),
                        RewardId = c.Long(nullable: false),
                        DropSourceId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DropSources", t => t.Id)
                .ForeignKey("dbo.DropSources", t => t.DropSourceId, cascadeDelete: true)
                .ForeignKey("dbo.RelicStates", t => t.RelicStateId, cascadeDelete: true)
                .ForeignKey("dbo.RelicTiers", t => t.RelicTierId, cascadeDelete: true)
                .ForeignKey("dbo.Rewards", t => t.RewardId, cascadeDelete: true)
                .ForeignKey("dbo.Rewards", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.RelicTierId)
                .Index(t => t.RelicStateId)
                .Index(t => t.RewardId)
                .Index(t => t.DropSourceId);
            
            CreateTable(
                "dbo.DropSources",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        DropSourceTypeId = c.Long(nullable: false),
                        MissionTypeId = c.Long(nullable: false),
                        PlanetId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DropSourceTypes", t => t.DropSourceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MissionTypes", t => t.MissionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Planets", t => t.PlanetId, cascadeDelete: true)
                .Index(t => t.DropSourceTypeId)
                .Index(t => t.MissionTypeId)
                .Index(t => t.PlanetId);
            
            CreateTable(
                "dbo.DropSourceTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RewardDrops",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RewardId = c.Long(nullable: false),
                        DropChance = c.Double(nullable: false),
                        Count = c.Int(nullable: false),
                        DropSources_Id = c.Long(),
                        Rotation_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DropSources", t => t.DropSources_Id)
                .ForeignKey("dbo.Rewards", t => t.RewardId, cascadeDelete: true)
                .ForeignKey("dbo.Rotations", t => t.Rotation_Id)
                .Index(t => t.RewardId)
                .Index(t => t.DropSources_Id)
                .Index(t => t.Rotation_Id);
            
            CreateTable(
                "dbo.Rotations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MissionTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelicStates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelicTiers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RewardTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rewards", "RewardTypeId", "dbo.RewardTypes");
            DropForeignKey("dbo.Relics", "Id", "dbo.Rewards");
            DropForeignKey("dbo.Relics", "RewardId", "dbo.Rewards");
            DropForeignKey("dbo.Relics", "RelicTierId", "dbo.RelicTiers");
            DropForeignKey("dbo.Relics", "RelicStateId", "dbo.RelicStates");
            DropForeignKey("dbo.Relics", "DropSourceId", "dbo.DropSources");
            DropForeignKey("dbo.DropSources", "PlanetId", "dbo.Planets");
            DropForeignKey("dbo.DropSources", "MissionTypeId", "dbo.MissionTypes");
            DropForeignKey("dbo.RewardDrops", "Rotation_Id", "dbo.Rotations");
            DropForeignKey("dbo.RewardDrops", "RewardId", "dbo.Rewards");
            DropForeignKey("dbo.RewardDrops", "DropSources_Id", "dbo.DropSources");
            DropForeignKey("dbo.Relics", "Id", "dbo.DropSources");
            DropForeignKey("dbo.DropSources", "DropSourceTypeId", "dbo.DropSourceTypes");
            DropIndex("dbo.RewardDrops", new[] { "Rotation_Id" });
            DropIndex("dbo.RewardDrops", new[] { "DropSources_Id" });
            DropIndex("dbo.RewardDrops", new[] { "RewardId" });
            DropIndex("dbo.DropSources", new[] { "PlanetId" });
            DropIndex("dbo.DropSources", new[] { "MissionTypeId" });
            DropIndex("dbo.DropSources", new[] { "DropSourceTypeId" });
            DropIndex("dbo.Relics", new[] { "DropSourceId" });
            DropIndex("dbo.Relics", new[] { "RewardId" });
            DropIndex("dbo.Relics", new[] { "RelicStateId" });
            DropIndex("dbo.Relics", new[] { "RelicTierId" });
            DropIndex("dbo.Relics", new[] { "Id" });
            DropIndex("dbo.Rewards", new[] { "RewardTypeId" });
            DropTable("dbo.RewardTypes");
            DropTable("dbo.RelicTiers");
            DropTable("dbo.RelicStates");
            DropTable("dbo.Planets");
            DropTable("dbo.MissionTypes");
            DropTable("dbo.Rotations");
            DropTable("dbo.RewardDrops");
            DropTable("dbo.DropSourceTypes");
            DropTable("dbo.DropSources");
            DropTable("dbo.Relics");
            DropTable("dbo.Rewards");
        }
    }
}
