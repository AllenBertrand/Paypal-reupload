namespace Corporate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionSuccess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "SuccessFlag", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donations", "SuccessFlag");
        }
    }
}
