﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.DataAccess.Data;

#nullable disable

namespace Store.DataAccess.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Models.Models.CArticle", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"));

                    b.Property<string>("ArticleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ArticlePrice")
                        .HasColumnType("float");

                    b.HasKey("ArticleId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            ArticleId = 1,
                            ArticleDescription = "Lapiz para dibujo ilustrativo",
                            ArticleImage = "image.png",
                            ArticleName = "Lapiz B II",
                            ArticlePrice = 7.0
                        },
                        new
                        {
                            ArticleId = 2,
                            ArticleDescription = "Libreta con personajes de anime en la portada",
                            ArticleImage = "image.png",
                            ArticleName = "Libreta Cuadro chico",
                            ArticlePrice = 17.0
                        },
                        new
                        {
                            ArticleId = 3,
                            ArticleDescription = "Cartulina standar varios colores",
                            ArticleImage = "image.png",
                            ArticleName = "Cartulina fluorescente",
                            ArticlePrice = 5.3499999999999996
                        },
                        new
                        {
                            ArticleId = 4,
                            ArticleDescription = "Mica para credenciales o tarjetas ",
                            ArticleImage = "image.png",
                            ArticleName = "Mica suave",
                            ArticlePrice = 8.5
                        });
                });

            modelBuilder.Entity("Store.Models.Models.CCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerAddress = "Geranios 27",
                            CustomerName = "Armando Acosta"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerAddress = "Geranios 27",
                            CustomerName = "Gabriela Gutierrex"
                        });
                });

            modelBuilder.Entity("Store.Models.Models.CShopingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("CArticleArticleId")
                        .HasColumnType("int");

                    b.Property<int>("CCustomerCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMovement")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CArticleArticleId");

                    b.HasIndex("CCustomerCustomerId");

                    b.ToTable("ShopingCarts");
                });

            modelBuilder.Entity("Store.Models.Models.CStore", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("StoreAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            StoreAddress = "Insurgentes sur 1025 ",
                            StoreName = "Sucursal Pacifico"
                        },
                        new
                        {
                            StoreId = 2,
                            StoreAddress = "Paseo de la reforma 2545",
                            StoreName = "Sucursal Mediterraneo"
                        });
                });

            modelBuilder.Entity("Store.Models.Models.CStoresArticles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArticleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("Exists")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("StoreId");

                    b.ToTable("CStoresArticles");
                });

            modelBuilder.Entity("Store.Models.Models.CUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Store.Models.Models.CShopingCart", b =>
                {
                    b.HasOne("Store.Models.Models.CArticle", "CArticle")
                        .WithMany()
                        .HasForeignKey("CArticleArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Models.Models.CCustomer", "CCustomer")
                        .WithMany()
                        .HasForeignKey("CCustomerCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CArticle");

                    b.Navigation("CCustomer");
                });

            modelBuilder.Entity("Store.Models.Models.CStoresArticles", b =>
                {
                    b.HasOne("Store.Models.Models.CArticle", "CArticle")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Models.Models.CStore", "CStore")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CArticle");

                    b.Navigation("CStore");
                });
#pragma warning restore 612, 618
        }
    }
}
