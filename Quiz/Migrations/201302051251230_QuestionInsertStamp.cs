namespace Quiz.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionInsertStamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "InsertStamp", c => c.DateTime());
            DropColumn("Questions", "NewTest");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "InsertStamp");
            AddColumn("Questions", "NewTest", c=>c.Byte());
        }
    }
}
