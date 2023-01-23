﻿// <auto-generated />
using Boligmappa_challenge_library.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Boligmappachallenge.Migrations
{
    [DbContext(typeof(BoligmappaDbContext))]
    [Migration("20230122030005_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Boligmappa_challenge_library.DataLayer.UserTotals", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<int>("NrPosts")
                        .HasColumnType("integer");

                    b.Property<int>("NrToDos")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("UserTotals");
                });
#pragma warning restore 612, 618
        }
    }
}