using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium.Migrations
{
    public partial class betterMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Musicians_MusicianIdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_TrackIdTrack",
                table: "Musician_Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Tracks_MusicianIdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Tracks_TrackIdTrack",
                table: "Musician_Tracks");

            migrationBuilder.DropColumn(
                name: "MusicianIdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropColumn(
                name: "TrackIdTrack",
                table: "Musician_Tracks");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Tracks_IdMusician",
                table: "Musician_Tracks",
                column: "IdMusician");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Musicians_IdMusician",
                table: "Musician_Tracks",
                column: "IdMusician",
                principalTable: "Musicians",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks",
                column: "IdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Musicians_IdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Musician_Tracks_IdMusician",
                table: "Musician_Tracks");

            migrationBuilder.AddColumn<int>(
                name: "MusicianIdMusician",
                table: "Musician_Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrackIdTrack",
                table: "Musician_Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Tracks_MusicianIdMusician",
                table: "Musician_Tracks",
                column: "MusicianIdMusician");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Tracks_TrackIdTrack",
                table: "Musician_Tracks",
                column: "TrackIdTrack");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Musicians_MusicianIdMusician",
                table: "Musician_Tracks",
                column: "MusicianIdMusician",
                principalTable: "Musicians",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Tracks_TrackIdTrack",
                table: "Musician_Tracks",
                column: "TrackIdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
