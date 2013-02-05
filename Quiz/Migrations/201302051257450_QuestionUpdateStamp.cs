namespace Quiz.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionUpdateStamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "UpdateStamp", c => c.DateTime());
            DropColumn("dbo.Questions", "InsertStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "InsertStamp", c => c.DateTime());
            DropColumn("dbo.Questions", "UpdateStamp");
        }
    }
}
