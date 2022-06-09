using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium.Migrations
{
    public partial class betterMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumIdAlbum",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "MusicianTrack");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AlbumIdAlbum",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AlbumIdAlbum",
                table: "Tracks");

            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_IdMusicAlbum",
                table: "Tracks",
                column: "IdMusicAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks",
                column: "IdMusicAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_IdMusicAlbum",
                table: "Tracks");

            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbumIdAlbum",
                table: "Tracks",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumIdAlbum",
                table: "Tracks",
                column: "AlbumIdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTrack_TracksIdTrack",
                table: "MusicianTrack",
                column: "TracksIdTrack");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumIdAlbum",
                table: "Tracks",
                column: "AlbumIdAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
