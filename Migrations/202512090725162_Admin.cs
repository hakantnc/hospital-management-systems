namespace HospitalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Users", "TCKN", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "TCKN", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String());
        }
    }
}
