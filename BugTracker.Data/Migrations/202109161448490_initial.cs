namespace BugTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bug",
                c => new
                    {
                        BugId = c.Int(nullable: false, identity: true),
                        BugName = c.String(nullable: false),
                        BugDescription = c.String(nullable: false),
                        IdentifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ProjectId = c.Int(nullable: false),
                        AssignedTo = c.Int(),
                        Status = c.Int(nullable: false),
                        ActiveProblem = c.Boolean(nullable: false),
                        Priority = c.Int(),
                        ExpectedResolutionUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ActualResolutionUTC = c.DateTimeOffset(precision: 7),
                        ResolutionSummary = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.BugId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        ProjectId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            DropColumn("dbo.Project", "CreatedBy");
            DropColumn("dbo.Project", "ModifiedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "ModifiedBy", c => c.Int());
            AddColumn("dbo.Project", "CreatedBy", c => c.Int(nullable: false));
            DropTable("dbo.Person");
            DropTable("dbo.Bug");
        }
    }
}
