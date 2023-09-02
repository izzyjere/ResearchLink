﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResearchLink.Core.DataAccess;

#nullable disable

namespace ResearchLink.Core.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230902135628_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResearchLink.Core.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Affliation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.AuthorResearch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("ResearchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ResearchId");

                    b.ToTable("AuthorResearch");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResearchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comment");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Comment");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ResearchLink.Core.Models.District", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("District");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResearchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResearchId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ProposedAuthor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ResearchGapId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ResearchGapId");

                    b.ToTable("ProposedAuthor");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Research", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResearchGapId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResearchMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResearchTopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ResearchGapId");

                    b.HasIndex("ResearchTopicId");

                    b.ToTable("Research");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchGap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proposer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProposerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReseaechTopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResearchTopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResearchTopicId");

                    b.ToTable("ResearchGap");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchTopic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Objective")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ResearchTopic");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchComment", b =>
                {
                    b.HasBaseType("ResearchLink.Core.Models.Comment");

                    b.HasIndex("ResearchId");

                    b.HasDiscriminator().HasValue("ResearchComment");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchGapComment", b =>
                {
                    b.HasBaseType("ResearchLink.Core.Models.Comment");

                    b.HasIndex("ResearchId");

                    b.HasDiscriminator().HasValue("ResearchGapComment");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Author", b =>
                {
                    b.OwnsOne("ResearchLink.Core.Shared.FileModel", "Avatar", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ContentType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("FileStore")
                                .HasColumnType("int");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AuthorId");

                            b1.ToTable("ProfileImages", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.AuthorResearch", b =>
                {
                    b.HasOne("ResearchLink.Core.Models.Author", "Author")
                        .WithMany("Researchs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResearchLink.Core.Models.Research", "Research")
                        .WithMany("Authors")
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Comment", b =>
                {
                    b.OwnsMany("ResearchLink.Core.Models.CommentReply", "Replies", b1 =>
                        {
                            b1.Property<Guid>("CommentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("User")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CommentId", "Id");

                            b1.ToTable("CommentReplies", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });

                    b.Navigation("Replies");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Document", b =>
                {
                    b.HasOne("ResearchLink.Core.Models.Research", "Research")
                        .WithMany()
                        .HasForeignKey("ResearchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Research");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ProposedAuthor", b =>
                {
                    b.HasOne("ResearchLink.Core.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResearchLink.Core.Models.ResearchGap", "ResearchGap")
                        .WithMany("ProposedAuthors")
                        .HasForeignKey("ResearchGapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("ResearchGap");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Research", b =>
                {
                    b.HasOne("ResearchLink.Core.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResearchLink.Core.Models.ResearchGap", "ResearchGap")
                        .WithMany()
                        .HasForeignKey("ResearchGapId");

                    b.HasOne("ResearchLink.Core.Models.ResearchTopic", "ResearchTopic")
                        .WithMany()
                        .HasForeignKey("ResearchTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ResearchLink.Core.Shared.FileModel", "Document", b1 =>
                        {
                            b1.Property<Guid>("ResearchId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ContentType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("FileStore")
                                .HasColumnType("int");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ResearchId");

                            b1.ToTable("ResearchDocuments", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ResearchId");
                        });

                    b.Navigation("District");

                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("ResearchGap");

                    b.Navigation("ResearchTopic");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchGap", b =>
                {
                    b.HasOne("ResearchLink.Core.Models.ResearchTopic", "ResearchTopic")
                        .WithMany()
                        .HasForeignKey("ResearchTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ResearchLink.Core.Shared.FileModel", "Document", b1 =>
                        {
                            b1.Property<Guid>("ResearchGapId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ContentType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("FileStore")
                                .HasColumnType("int");

                            b1.Property<string>("Path")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ResearchGapId");

                            b1.ToTable("ResearchGapDocuments", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ResearchGapId");
                        });

                    b.Navigation("Document");

                    b.Navigation("ResearchTopic");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchComment", b =>
                {
                    b.HasOne("ResearchLink.Core.Models.Research", "Research")
                        .WithMany("Comments")
                        .HasForeignKey("ResearchId");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchGapComment", b =>
                {
                    b.HasOne("ResearchLink.Core.Models.ResearchGap", "Research")
                        .WithMany("Comments")
                        .HasForeignKey("ResearchId");

                    b.Navigation("Research");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Author", b =>
                {
                    b.Navigation("Researchs");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.Research", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ResearchLink.Core.Models.ResearchGap", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ProposedAuthors");
                });
#pragma warning restore 612, 618
        }
    }
}