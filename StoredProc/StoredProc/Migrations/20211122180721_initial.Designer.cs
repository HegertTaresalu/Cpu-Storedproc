// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoredProc.Data;

namespace StoredProc.Migrations
{
    [DbContext(typeof(StoredProcDbContext))]
    [Migration("20211122180721_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoredProc.Models.Cpu", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("BaseClock")
                        .HasColumnType("float");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CoreCount")
                        .HasColumnType("int");

                    b.Property<double?>("MaxBoostClock")
                        .HasColumnType("float");

                    b.Property<int?>("ThreadCount")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Cpu");
                });

            modelBuilder.Entity("StoredProc.Models.Employee", b =>
                {
                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("FirstName");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
