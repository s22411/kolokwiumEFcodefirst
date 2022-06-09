using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    IdMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.IdMusician);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMusicLabel = table.Column<int>(type: "int", nullable: false),
                    MusicLabelIdMusicLabel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albums_MusicLabels_MusicLabelIdMusicLabel",
                        column: x => x.MusicLabelIdMusicLabel,
                        principalTable: "MusicLabels",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IdMusicAlbum = table.Column<int>(type: "int", nullable: false),
                    AlbumIdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Tracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(type: "int", nullable: false),
                    IdMusician = table.Column<int>(type: "int", nullable: false),
                    TrackIdTrack = table.Column<int>(type: "int", nullable: true),
                    MusicianIdMusician = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Tracks", x => new { x.IdTrack, x.IdMusician });
                    table.ForeignKey(
                        name: "FK_Musician_Tracks_Musicians_MusicianIdMusician",
                        column: x => x.MusicianIdMusician,
                        principalTable: "Musicians",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Musician_Tracks_Tracks_TrackIdTrack",
                        column: x => x.TrackIdTrack,
                        principalTable: "Tracks",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicianTrack",
                columns: table => new
                {
                    MusiciansIdMusician = table.Column<int>(type: "int", nullable: false),
                    TracksIdTrack = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianTrack", x => new { x.MusiciansIdMusician, x.TracksIdTrack });
                    table.ForeignKey(
                        name: "FK_MusicianTrack_Musicians_MusiciansIdMusician",
                        column: x => x.MusiciansIdMusician,
                        principalTable: "Musicians",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianTrack_Tracks_TracksIdTrack",
                        column: x => x.TracksIdTrack,
                        principalTable: "Tracks",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "MusicLabelIdMusicLabel", "PublishDate" },
                values: new object[,]
                {
                    { 1, "Album 1", 1, null, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Album 2", 2, null, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Album 3", 3, null, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[,]
                {
                    { 1, "Music Label 1" },
                    { 2, "Music Label 2" },
                    { 3, "Music Label 3" }
                });

            migrationBuilder.InsertData(
                table: "Musician_Tracks",
                columns: new[] { "IdMusician", "IdTrack", "MusicianIdMusician", "TrackIdTrack" },
                values: new object[,]
                {
                    { 3, 3, null, null },
                    { 1, 3, null, null },
                    { 3, 2, null, null },
                    { 2, 2, null, null },
                    { 1, 1, null, null },
                    { 3, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[,]
                {
                    { 4, "John", "Lennon", "JLennon" },
                    { 3, "Bob", "Dylan", "BDylan" },
                    { 2, "Mary", "Jane", "MJane" },
                    { 1, "John", "Smith", "JSmith" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "AlbumIdAlbum", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[,]
                {
                    { 1, null, 120f, 1, "Track 1" },
                    { 2, null, 180f, 1, "Track 2" },
                    { 3, null, 240f, 1, "Track 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MusicLabelIdMusicLabel",
                table: "Albums",
                column: "MusicLabelIdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Tracks_MusicianIdMusician",
                table: "Musician_Tracks",
                column: "MusicianIdMusician");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Tracks_TrackIdTrack",
                table: "Musician_Tracks",
                column: "TrackIdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTrack_TracksIdTrack",
                table: "MusicianTrack",
                column: "TracksIdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumIdAlbum",
                table: "Tracks",
                column: "AlbumIdAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musician_Tracks");

            migrationBuilder.DropTable(
                name: "MusicianTrack");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "MusicLabels");
        }
    }
}
