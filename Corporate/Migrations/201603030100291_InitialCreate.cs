namespace Corporate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationID = c.Int(nullable: false, identity: true),
                        DonorID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Confirmation = c.String(),
                    })
                .PrimaryKey(t => t.DonationID);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        EmailUpdateFlag = c.Boolean(nullable: false),
                        Employer = c.String(),
                        Occupation = c.String(),
                        OccupationStatus = c.String(),
                    })
                .PrimaryKey(t => t.DonorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donors");
            DropTable("dbo.Donations");
        }
    }
}
