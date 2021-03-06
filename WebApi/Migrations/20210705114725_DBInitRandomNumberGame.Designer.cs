// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.DBContexts;

namespace WebApi.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210705114725_DBInitRandomNumberGame")]
    partial class DBInitRandomNumberGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("ClassLibrary.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Turns")
                        .HasColumnType("int");

                    b.Property<string>("guid")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("userGuess")
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("Name")
                        .HasDatabaseName("name");

                    b.ToTable("players");
                });
#pragma warning restore 612, 618
        }
    }
}
