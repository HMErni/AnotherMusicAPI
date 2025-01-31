﻿// <auto-generated />
using AnotherMusicAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnotherMusicAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlbumMusic", b =>
                {
                    b.Property<int>("AlbumsAlbumId")
                        .HasColumnType("int");

                    b.Property<int>("MusicsMusicId")
                        .HasColumnType("int");

                    b.HasKey("AlbumsAlbumId", "MusicsMusicId");

                    b.HasIndex("MusicsMusicId");

                    b.ToTable("AlbumMusic");
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlbumId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.Music", b =>
                {
                    b.Property<int>("MusicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusicId"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("MusicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusicId");

                    b.HasIndex("GenreId");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.PlaylistMusic", b =>
                {
                    b.Property<int>("MusicId")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.HasKey("MusicId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("PlaylistMusic");
                });

            modelBuilder.Entity("ArtistMusic", b =>
                {
                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<int>("MusicsMusicId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsId", "MusicsMusicId");

                    b.HasIndex("MusicsMusicId");

                    b.ToTable("ArtistMusic");
                });

            modelBuilder.Entity("AlbumMusic", b =>
                {
                    b.HasOne("AnotherMusicAPI.Model.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsAlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnotherMusicAPI.Model.Music", null)
                        .WithMany()
                        .HasForeignKey("MusicsMusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.Music", b =>
                {
                    b.HasOne("AnotherMusicAPI.Model.Genre", "Genre")
                        .WithMany("Musics")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.PlaylistMusic", b =>
                {
                    b.HasOne("AnotherMusicAPI.Model.Music", null)
                        .WithMany()
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnotherMusicAPI.Model.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtistMusic", b =>
                {
                    b.HasOne("AnotherMusicAPI.Model.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnotherMusicAPI.Model.Music", null)
                        .WithMany()
                        .HasForeignKey("MusicsMusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnotherMusicAPI.Model.Genre", b =>
                {
                    b.Navigation("Musics");
                });
#pragma warning restore 612, 618
        }
    }
}
