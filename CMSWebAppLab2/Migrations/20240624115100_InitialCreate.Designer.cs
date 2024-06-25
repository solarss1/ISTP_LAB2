﻿// <auto-generated />
using System;
using CMSWebAppLab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMSWebAppLab2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240624115100_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CMSWebAppLab2.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CinemaName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Cinemas$PrimaryKey");

                    b.HasIndex(new[] { "Address" }, "Cinemas$Address")
                        .IsUnique();

                    b.HasIndex(new[] { "CinemaName" }, "Cinemas$CinemaName")
                        .IsUnique();

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("HallName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaxPlaces")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(30);

                    b.HasKey("Id")
                        .HasName("Halls$PrimaryKey");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("Duration")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)90);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ReleaseYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1914);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Movies$PrimaryKey");

                    b.HasIndex(new[] { "Title" }, "Movies$Title")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TookPartAs")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("Persons$PrimaryKey");

                    b.HasIndex(new[] { "Id" }, "Persons$MoviePersonId")
                        .IsUnique();

                    b.HasIndex(new[] { "PersonName" }, "Persons$PersonName")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.PersonsToMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PersonsToMovies$PrimaryKey");

                    b.HasIndex(new[] { "MovieId" }, "PersonsToMovies$PersonToMovieMovieId");

                    b.HasIndex(new[] { "PersonId" }, "PersonsToMovies$PersonToMoviePersonId");

                    b.ToTable("PersonsToMovies");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HallId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime>("StartTime")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Id")
                        .HasName("Sessions$PrimaryKey");

                    b.HasIndex(new[] { "HallId" }, "Sessions$SessionsHallId");

                    b.HasIndex(new[] { "MovieId" }, "Sessions$SessionsMovieId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SoldTime")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Id")
                        .HasName("Tickets$PrimaryKey");

                    b.HasIndex(new[] { "SeatNumber" }, "Tickets$Place");

                    b.HasIndex(new[] { "SessionId" }, "Tickets$TicketsSessionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Hall", b =>
                {
                    b.HasOne("CMSWebAppLab2.Models.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Halls$CinemasHalls");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.PersonsToMovie", b =>
                {
                    b.HasOne("CMSWebAppLab2.Models.Movie", "Movie")
                        .WithMany("PersonsToMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PersonsToMovies$MoviesPersonsToMovies");

                    b.HasOne("CMSWebAppLab2.Models.Person", "Person")
                        .WithMany("PersonsToMovies")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("PersonsToMovies$PersonsPersonsToMovies");

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Session", b =>
                {
                    b.HasOne("CMSWebAppLab2.Models.Hall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Sessions$HallsSessions");

                    b.HasOne("CMSWebAppLab2.Models.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("Sessions$MoviesSessions");

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Ticket", b =>
                {
                    b.HasOne("CMSWebAppLab2.Models.Session", "Session")
                        .WithMany("Tickets")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Tickets$SessionsTickets");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Cinema", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Hall", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Movie", b =>
                {
                    b.Navigation("PersonsToMovies");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Person", b =>
                {
                    b.Navigation("PersonsToMovies");
                });

            modelBuilder.Entity("CMSWebAppLab2.Models.Session", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}