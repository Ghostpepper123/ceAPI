﻿// <auto-generated />
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataModel.Migrations
{
    [DbContext(typeof(WorldCitiesContext))]
    [Migration("20241004224300_initial2")]
    partial class initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModel.City", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("countryID");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<double>("Lat")
                        .HasColumnType("float")
                        .HasColumnName("lat");

                    b.Property<double>("Lng")
                        .HasColumnType("float")
                        .HasColumnName("lng");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Population")
                        .HasColumnType("int")
                        .HasColumnName("population");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DataModel.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Iso2")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .HasColumnName("iso2")
                        .IsFixedLength();

                    b.Property<string>("Iso3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nchar(3)")
                        .HasColumnName("iso3")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_country");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DataModel.City", b =>
                {
                    b.HasOne("DataModel.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_Cities_Countries1");

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
