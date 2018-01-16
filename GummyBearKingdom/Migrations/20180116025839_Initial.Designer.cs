using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GummyBearKingdom.Models;

namespace GummyBearKingdom.Migrations
{
    [DbContext(typeof(GummyBearKingdomDbContext))]
    [Migration("20180116025839_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("GummyBearKingdom.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ReviewId");

                    b.HasKey("PropertyId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("GummyBearKingdom.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Content");

                    b.Property<int>("Rating");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GummyBearKingdom.Models.Property", b =>
                {
                    b.HasOne("GummyBearKingdom.Models.Review", "Review")
                        .WithMany("Properties")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
