namespace MediaPlayer.Data.Migrations.ApplicationIdentityDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomFile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrackGenres", "Track_TrackId", "dbo.Tracks");
            DropForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Tracks");
            DropPrimaryKey("dbo.Tracks");
            CreateTable(
                "dbo.CustomFiles",
                c => new
                    {
                        CustomFileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Content = c.Binary(),
                        ContentType = c.String(),
                        TrackId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomFileId);
            
            AddColumn("dbo.Tracks", "CustomFileId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tracks", "TrackId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tracks", "TrackId");
            CreateIndex("dbo.Tracks", "TrackId");
            AddForeignKey("dbo.Tracks", "TrackId", "dbo.CustomFiles", "CustomFileId");
            AddForeignKey("dbo.TrackGenres", "Track_TrackId", "dbo.Tracks", "TrackId", cascadeDelete: true);
            AddForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Tracks", "TrackId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Tracks");
            DropForeignKey("dbo.TrackGenres", "Track_TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Tracks", "TrackId", "dbo.CustomFiles");
            DropIndex("dbo.Tracks", new[] { "TrackId" });
            DropPrimaryKey("dbo.Tracks");
            AlterColumn("dbo.Tracks", "TrackId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Tracks", "CustomFileId");
            DropTable("dbo.CustomFiles");
            AddPrimaryKey("dbo.Tracks", "TrackId");
            AddForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Tracks", "TrackId", cascadeDelete: true);
            AddForeignKey("dbo.TrackGenres", "Track_TrackId", "dbo.Tracks", "TrackId", cascadeDelete: true);
        }
    }
}
