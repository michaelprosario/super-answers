﻿// <auto-generated />
using System;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(EfContext))]
    partial class EfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("App.Core.DbEntities.Question", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("QuestionTitle");

                    b.Property<string>("Tags");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("App.Core.DbEntities.QuestionAnswer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("QuestionId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("App.Core.DbEntities.QuestionAnswerVote", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("QuestionAnswerId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("QuestionAnswerVotes");
                });

            modelBuilder.Entity("App.Core.DbEntities.QuestionTag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("QuestionTags");
                });

            modelBuilder.Entity("App.Core.DbEntities.QuestionView", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("QuestionId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("QuestionViews");
                });

            modelBuilder.Entity("App.Core.DbEntities.QuestionVote", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("QuestionId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("QuestionVotes");
                });

            modelBuilder.Entity("App.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
