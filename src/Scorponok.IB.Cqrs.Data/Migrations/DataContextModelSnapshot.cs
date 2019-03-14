﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scorponok.IB.Cqrs.Data.Context;

namespace Scorponok.IB.Cqrs.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scorponok.IB.Domain.Models.Churchs.Church", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnName("Photo")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Church");
                });

            modelBuilder.Entity("Scorponok.IB.Domain.Models.Contributions.Contribution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnName("DeliveryDate");

                    b.Property<Guid>("MemberId");

                    b.Property<DateTime>("Registered")
                        .HasColumnName("Registered");

                    b.Property<int>("TypeContribution")
                        .HasColumnName("TypeContribution");

                    b.Property<double>("Value")
                        .HasColumnName("Value");

                    b.HasKey("Id")
                        .HasName("ContributionId");

                    b.HasIndex("MemberId");

                    b.ToTable("Contribution");
                });

            modelBuilder.Entity("Scorponok.IB.Domain.Models.Members.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Scorponok.IB.Domain.Models.Churchs.Church", b =>
                {
                    b.OwnsOne("Scorponok.IB.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ChurchId");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Email");

                            b1.HasKey("ChurchId");

                            b1.ToTable("Church");

                            b1.HasOne("Scorponok.IB.Domain.Models.Churchs.Church")
                                .WithOne("Email")
                                .HasForeignKey("Scorponok.IB.Core.ValueObjects.Email", "ChurchId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Scorponok.IB.Core.ValueObjects.Telephone", "MobileTelephone", b1 =>
                        {
                            b1.Property<Guid>("ChurchId");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("PhoneMobile");

                            b1.HasKey("ChurchId");

                            b1.ToTable("Church");

                            b1.HasOne("Scorponok.IB.Domain.Models.Churchs.Church")
                                .WithOne("MobileTelephone")
                                .HasForeignKey("Scorponok.IB.Core.ValueObjects.Telephone", "ChurchId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Scorponok.IB.Core.ValueObjects.Telephone", "TelephoneFixed", b1 =>
                        {
                            b1.Property<Guid>("ChurchId");

                            b1.Property<string>("Number")
                                .HasColumnName("PhoneFixed");

                            b1.HasKey("ChurchId");

                            b1.ToTable("Church");

                            b1.HasOne("Scorponok.IB.Domain.Models.Churchs.Church")
                                .WithOne("TelephoneFixed")
                                .HasForeignKey("Scorponok.IB.Core.ValueObjects.Telephone", "ChurchId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Scorponok.IB.Domain.Models.Contributions.Contribution", b =>
                {
                    b.HasOne("Scorponok.IB.Domain.Models.Members.Member", "Member")
                        .WithMany("Contributions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}