﻿// <auto-generated />
using System;
using AdamTaskApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdamTaskApplication.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20190226154307_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdamTaskApplication.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("AdamTaskApplication.Data.Models.Board", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoardType");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<long?>("ProjectId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("boards");
                });

            modelBuilder.Entity("AdamTaskApplication.Data.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CityID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FilesId");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("JobTitle");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName");

                    b.Property<string>("ModifiedBy");

                    b.Property<int?>("Nationalty1");

                    b.Property<int?>("Nationalty2");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("applicationUserId");

                    b.HasKey("Id");

                    b.HasIndex("FilesId");

                    b.HasIndex("applicationUserId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("AdamTaskApplication.Data.Models.Files", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttachmentType");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeID");

                    b.Property<string>("FileExtension");

                    b.Property<string>("FileName");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerType");

                    b.HasKey("Id");

                    b.ToTable("files");
                });

            modelBuilder.Entity("AdamTaskApplication.Data.Models.Projects", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FilesId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("FilesId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("AdamTaskApplication.Data.Models.Board", b =>
                {
                    b.HasOne("AdamTaskApplication.Data.Models.Projects", "Project")
                        .WithMany("boards")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("AdamTaskApplication.Data.Models.Employee", b =>
                {
                    b.HasOne("AdamTaskApplication.Data.Models.Files", "Files")
                        .WithMany()
                        .HasForeignKey("FilesId");

                    b.HasOne("AdamTaskApplication.Data.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("applicationUserId");
                });

            modelBuilder.Entity("AdamTaskApplication.Data.Models.Projects", b =>
                {
                    b.HasOne("AdamTaskApplication.Data.Models.Files", "Files")
                        .WithMany()
                        .HasForeignKey("FilesId");
                });
#pragma warning restore 612, 618
        }
    }
}
