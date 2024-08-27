using Microsoft.EntityFrameworkCore;
using Store.Models.Models;

namespace Store.DataAccess.Data
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext>options):base(options)
        {
            
        }
        public DbSet<CCustomer> Customers { get; set; }
        public DbSet<CStore> Stores { get; set; }
        public DbSet<CArticle> Articles { get; set; }
        public DbSet<CShopingCart> ShopingCarts { get; set; }
        public DbSet<CStoresArticles> StoresArticles { get; set; }
        public DbSet<CUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CCustomer>().HasData(
                new CCustomer { CustomerId = 1, CustomerName = "Armando Acosta", CustomerAddress = "Geranios 27" },
                new CCustomer { CustomerId = 2, CustomerName = "Gabriela Gutierrex", CustomerAddress = "Geranios 27" }
                );

            modelBuilder.Entity<CStore>().HasData(
                new CStore { StoreId = 1, StoreName = "Sucursal Pacifico",StoreAddress="Insurgentes sur 1025 " },
                new CStore { StoreId = 2, StoreName = "Sucursal Mediterraneo",StoreAddress="Paseo de la reforma 2545" }
                );

            modelBuilder.Entity<CArticle>().HasData(
                new CArticle { ArticleId = 1, ArticleName = "Lapiz B II", ArticleDescription = "Lapiz para dibujo ilustrativo", ArticleImage = "image.png", ArticlePrice = 7.00},
                new CArticle { ArticleId = 2, ArticleName = "Libreta Cuadro chico", ArticleDescription = "Libreta con personajes de anime en la portada", ArticleImage = "image.png", ArticlePrice = 17.00},
                new CArticle { ArticleId = 3, ArticleName = "Cartulina fluorescente", ArticleDescription = "Cartulina standar varios colores", ArticleImage = "image.png", ArticlePrice = 5.35 },
                new CArticle { ArticleId = 4, ArticleName = "Mica suave", ArticleDescription = "Mica para credenciales o tarjetas ", ArticleImage = "image.png", ArticlePrice = 8.50 }
                );
        }
    }

}
