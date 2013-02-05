namespace Quiz.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("Questions", "NewTest", c=>c.Byte());
        }
        
        public override void Down()
        {
            DropColumn("Questions", "NewTest");
        }
    }
}
