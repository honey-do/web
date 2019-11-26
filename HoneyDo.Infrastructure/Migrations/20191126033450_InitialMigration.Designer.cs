﻿// <auto-generated />
using System;
using HoneyDo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HoneyDo.Infrastructure.Migrations
{
    [DbContext(typeof(HoneyDoContext))]
    [Migration("20191126033450_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HoneyDo.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Picture");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("HoneyDo.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("HoneyDo.Domain.Entities.GroupAccount", b =>
                {
                    b.Property<Guid>("GroupId");

                    b.Property<Guid>("AccountId");

                    b.Property<Guid?>("AccountId1");

                    b.Property<Guid?>("GroupId1");

                    b.HasKey("GroupId", "AccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountId1");

                    b.HasIndex("GroupId1");

                    b.ToTable("GroupAccounts");
                });

            modelBuilder.Entity("HoneyDo.Domain.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AssigneeId");

                    b.Property<DateTime?>("CompletedDate");

                    b.Property<Guid>("CreatorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime?>("DueDate");

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("GroupId1");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupId1");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("HoneyDo.Infrastructure.Authentication.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<string>("Provider");

                    b.Property<string>("ProviderKey");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("HoneyDo.Domain.Entities.GroupAccount", b =>
                {
                    b.HasOne("HoneyDo.Domain.Entities.Account")
                        .WithMany("_groupAccounts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneyDo.Domain.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId1");

                    b.HasOne("HoneyDo.Domain.Entities.Group")
                        .WithMany("_groupAccounts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneyDo.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId1");
                });

            modelBuilder.Entity("HoneyDo.Domain.Entities.Todo", b =>
                {
                    b.HasOne("HoneyDo.Domain.Entities.Group", "Group")
                        .WithMany("_tasks")
                        .HasForeignKey("GroupId");

                    b.HasOne("HoneyDo.Domain.Entities.Group")
                        .WithMany("Tasks")
                        .HasForeignKey("GroupId1");
                });
#pragma warning restore 612, 618
        }
    }
}