﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TodoCleanArchitecture.Infrastructure;

#nullable disable

namespace TodoCleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(ToDoCleanDbContext))]
    [Migration("20250218104944_InitialDb_v3")]
    partial class InitialDb_v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MemberTicket", b =>
                {
                    b.Property<int>("MembersMemberId")
                        .HasColumnType("integer");

                    b.Property<int>("TicketsId")
                        .HasColumnType("integer");

                    b.HasKey("MembersMemberId", "TicketsId");

                    b.HasIndex("TicketsId");

                    b.ToTable("MemberTicket");
                });

            modelBuilder.Entity("TodoCleanArchitecture.Domain.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManagerName = "John 1"
                        },
                        new
                        {
                            Id = 2,
                            ManagerName = "John 2"
                        },
                        new
                        {
                            Id = 3,
                            ManagerName = "John 3"
                        });
                });

            modelBuilder.Entity("TodoCleanArchitecture.Domain.Entities.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MemberId"));

                    b.Property<int>("ManagerId")
                        .HasColumnType("integer");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MemberId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("TodoCleanArchitecture.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MemberTicket", b =>
                {
                    b.HasOne("TodoCleanArchitecture.Domain.Entities.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoCleanArchitecture.Domain.Entities.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TodoCleanArchitecture.Domain.Entities.Member", b =>
                {
                    b.HasOne("TodoCleanArchitecture.Domain.Entities.Manager", "Manager")
                        .WithMany("Members")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("TodoCleanArchitecture.Domain.Entities.Manager", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
