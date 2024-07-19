using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnotherMusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlbumModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumMusic_Album_AlbumsAlbumId",
                table: "AlbumMusic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumMusic_Albums_AlbumsAlbumId",
                table: "AlbumMusic",
                column: "AlbumsAlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumMusic_Albums_AlbumsAlbumId",
                table: "AlbumMusic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumMusic_Album_AlbumsAlbumId",
                table: "AlbumMusic",
                column: "AlbumsAlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
