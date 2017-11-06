namespace Carfinance.Phoenix.Kata.Angular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurant_Booking",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        TableNumber = c.Int(nullable: false),
                        ContactName = c.String(),
                        ContactNumber = c.String(),
                        NumberOfPeople = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurant_Booking");
        }
    }
}
