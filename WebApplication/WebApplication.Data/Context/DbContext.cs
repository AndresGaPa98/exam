using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using WebApplication.Entities.Entities;

namespace WebApplication.Data.Context
{
    public class AppDbContext : IdentityDbContext<Client>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleClient> ArticleClients { get; set; }
        public DbSet<ArticleStore> ArticleStores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<Client>();

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");
                entity.HasData(
                    new Client //Client user
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                        FirstName = "Andres Esteban",
                        LastName = "Garcia Pacheco",
                        Address = "C. 5 #100. Col. Centro, Merida, Yucatan, Mexico",
                        Email = "andres@gmail.com",
                        NormalizedEmail = "ANDRES@GMAIL.COM",
                        UserName = "andres@gmail.com",
                        NormalizedUserName = "ANDRES@GMAIL.COM",
                        PasswordHash = hasher.HashPassword(null, "User1234@")
                    },
                    new Client //super-adming user
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdc9", // primary key
                        FirstName = "Super",
                        LastName = "Admin",
                        Address = "N/A",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        UserName = "admin@admin.com",
                        NormalizedUserName = "ADMIN@ADMIN.COM",
                        PasswordHash = hasher.HashPassword(null, "Admin1234@")
                    }
                    ); 
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasData(
                    new IdentityRole
                    {
                        Id = "9e445865-a24d-4543-a6c6-9443d048cda9", // primary key
                        Name = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = "3e445865-a24d-4543-a6c6-9443d048cde9", // primary key
                        Name = "Client"
                    }
                    );
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "9e445865-a24d-4543-a6c6-9443d048cda9",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdc9"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "3e445865-a24d-4543-a6c6-9443d048cde9",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                    }
                    );
            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("stores");
                entity.HasData(
                    new Store
                    {
                        Address = "C. 50 #100 Col. Centro, Merida, Yucatan, Mexico.",
                        BranchName = "Abarrotes la continental",
                        StoreId = 1,
                    }
                    );
            });
            modelBuilder.Entity<ArticleClient>(entity =>
            {
                entity.ToTable("clients_articles");
            });
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasMany(x => x.Clients).WithMany(x => x.Articles).UsingEntity<ArticleClient>(
                    l => l.HasOne<Client>().WithMany().HasForeignKey(e => e.ClientId));
                entity.HasMany(x => x.Stores).WithMany(x => x.Articles).UsingEntity<ArticleStore>().ToTable("stores_articles");
                entity.ToTable("article");
                entity.HasData(
                    new Article
                    {
                        ArticleId = 1,
                        Code = "REF-001",
                        Description = "Refresco de 2.5Lt",
                        Price = 30.99M,
                        Stock = 12,
                        UrlImage = "https://tiendasneto.com.mx/media/catalog/product/cache/cb1e6b076f68ee0ac6e5e542f63310fa/1/0/1050002729-1_14.jpg"
                    },
                    new Article 
                    {
                        ArticleId = 2,
                        Code = "COM-001",
                        Description = "Sopa instantanea sabor camaron",
                        Price = 12.50M,
                        UrlImage = "https://chedrauimx.vtexassets.com/arquivos/ids/15811769/41789001857_02.jpg?v=638235036340670000"
                    }
                    );
            });
            modelBuilder.Entity<ArticleStore>(entity =>
            {
                entity.HasData(
                    new ArticleStore
                    {
                        Id = 1,
                        StoreId = 1,
                        ArticleId = 1,
                        Date = DateTime.Now
                    },
                    new ArticleStore
                    {
                        Id = 2,
                        StoreId = 1,
                        ArticleId = 2,
                        Date = DateTime.Now
                    }
                    );
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
