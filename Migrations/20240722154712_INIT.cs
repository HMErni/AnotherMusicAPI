using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnotherMusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class INIT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    MusicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.MusicId);
                    table.ForeignKey(
                        name: "FK_Musics_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumMusic",
                columns: table => new
                {
                    AlbumsAlbumId = table.Column<int>(type: "int", nullable: false),
                    MusicsMusicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMusic", x => new { x.AlbumsAlbumId, x.MusicsMusicId });
                    table.ForeignKey(
                        name: "FK_AlbumMusic_Albums_AlbumsAlbumId",
                        column: x => x.AlbumsAlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumMusic_Musics_MusicsMusicId",
                        column: x => x.MusicsMusicId,
                        principalTable: "Musics",
                        principalColumn: "MusicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistMusic",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    MusicsMusicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMusic", x => new { x.ArtistsId, x.MusicsMusicId });
                    table.ForeignKey(
                        name: "FK_ArtistMusic_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMusic_Musics_MusicsMusicId",
                        column: x => x.MusicsMusicId,
                        principalTable: "Musics",
                        principalColumn: "MusicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMusic_MusicsMusicId",
                table: "AlbumMusic",
                column: "MusicsMusicId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMusic_MusicsMusicId",
                table: "ArtistMusic",
                column: "MusicsMusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_GenreId",
                table: "Musics",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumMusic");

            migrationBuilder.DropTable(
                name: "ArtistMusic");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
