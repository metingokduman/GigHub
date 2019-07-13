namespace GigHubWithM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES (1,'Nazl�')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (2,'Metin')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (3,'G�kduman')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (4,'U�ur')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN(1,2,3,4)");
        }
    }
}
