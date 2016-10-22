namespace MediaPlayer.Data.Migrations.ApplicationIdentityDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsShared = c.Boolean(nullable: false),
                        SingerId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Singers", t => t.SingerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SingerId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PlaylistId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        SingerId = c.Int(nullable: false, identity: true),
                        SingerName = c.String(),
                    })
                .PrimaryKey(t => t.SingerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TrackGenres",
                c => new
                    {
                        Track_TrackId = c.Int(nullable: false),
                        Genre_GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Track_TrackId, t.Genre_GenreId })
                .ForeignKey("dbo.Tracks", t => t.Track_TrackId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .Index(t => t.Track_TrackId)
                .Index(t => t.Genre_GenreId);
            
            CreateTable(
                "dbo.PlaylistTracks",
                c => new
                    {
                        Playlist_PlaylistId = c.Int(nullable: false),
                        Track_TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistId, t.Track_TrackId })
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Track_TrackId, cascadeDelete: true)
                .Index(t => t.Playlist_PlaylistId)
                .Index(t => t.Track_TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Playlists", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Tracks", "SingerId", "dbo.Singers");
            DropForeignKey("dbo.PlaylistTracks", "Track_TrackId", "dbo.Tracks");
            DropForeignKey("dbo.PlaylistTracks", "Playlist_PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.TrackGenres", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.TrackGenres", "Track_TrackId", "dbo.Tracks");
            DropIndex("dbo.PlaylistTracks", new[] { "Track_TrackId" });
            DropIndex("dbo.PlaylistTracks", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.TrackGenres", new[] { "Genre_GenreId" });
            DropIndex("dbo.TrackGenres", new[] { "Track_TrackId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Playlists", new[] { "User_Id" });
            DropIndex("dbo.Tracks", new[] { "User_Id" });
            DropIndex("dbo.Tracks", new[] { "SingerId" });
            DropTable("dbo.PlaylistTracks");
            DropTable("dbo.TrackGenres");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Singers");
            DropTable("dbo.Playlists");
            DropTable("dbo.Tracks");
            DropTable("dbo.Genres");
        }
    }
}
