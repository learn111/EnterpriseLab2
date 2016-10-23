namespace MediaPlayer.Data.Migrations.ApplicationIdentityDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TrackGenres", newName: "GenreTracks");
            DropPrimaryKey("dbo.GenreTracks");
            AddPrimaryKey("dbo.GenreTracks", new[] { "Genre_GenreId", "Track_TrackId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GenreTracks");
            AddPrimaryKey("dbo.GenreTracks", new[] { "Track_TrackId", "Genre_GenreId" });
            RenameTable(name: "dbo.GenreTracks", newName: "TrackGenres");
        }
    }
}
