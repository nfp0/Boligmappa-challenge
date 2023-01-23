﻿// <auto-generated />
using Boligmappa_challenge_library.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Boligmappachallenge.Migrations
{
    [DbContext(typeof(BoligmappaDbContext))]
    partial class BoligmappaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Boligmappa_challenge_library.DataLayer.PostInfo", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PostId"));

                    b.Property<bool>("HasFictionTag")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasFrenchTag")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasMoreThanTwoReactions")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("PostId");

                    b.ToTable("PostInfo");
                });

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
