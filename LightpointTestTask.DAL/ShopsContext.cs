using LightpointTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LightpointTestTask.DAL
{
    public class ShopsContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public ShopsContext()
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LightpointTaskDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var products = new List<Product>
            {
                new Product{ProductId = 1, Name = "Хлебушек", Description = "Мягонький, вкусненький", ShopId = 1},
                new Product{ProductId = 2, Name = "Рыбка", Description = "Скользкая, пахучая",ShopId = 1},
                new Product{ProductId = 3, Name = "Сухарики", Description = "Солёные, хрустящие", ShopId = 1},

                new Product{ProductId = 4, Name = "Костюм \"Берёзка\"", Description = "Дёшево и сердито", ShopId =2},
                new Product{ProductId = 5, Name = "Бинокль", Description = "Большой и чёрный",ShopId = 2},
                new Product{ProductId = 6, Name = "Оленьи рога", Description = "Если охота не удалась", ShopId = 2},

                new Product{ProductId = 7, Name = "Стул", Description = "На нём сидят", ShopId = 3},
                new Product{ProductId = 8, Name = "Стол", Description = "На нём едят",ShopId = 3},
                new Product{ProductId = 9, Name = "Ковёр", Description = "Никогда не выйдет из моды", ShopId = 3},

                new Product{ProductId = 10, Name = "Венок", Description = "Большой, с красивой ленточкой", ShopId = 4},
                new Product{ProductId = 11, Name = "Гроб", Description = "Просторный, мягкий и удобный",ShopId = 4},
                new Product{ProductId = 12, Name = "Крест", Description = "Похож на плюсик", ShopId = 4},

                new Product{ProductId = 13, Name = "Цветок", Description = "Очень красивый", ShopId = 5},
                new Product{ProductId = 14, Name = "Ваза", Description = "Можно использовать как графин",ShopId = 5},
                new Product{ProductId = 15, Name = "Удобрения", Description = "Однозначно несъедобны", ShopId = 5},
            };
            var shops = new Shop[]
            {
                    new Shop{ShopId = 1, Name = "Гастроном", Adress = "Минск, ул. Ленина 7",
                        WorkingHours = "Пн-пт: 9:00-20:00; сб-вс: 10:00-18:30"
                    },
                    new Shop{ShopId = 2, Name = "Охотник", Adress = "Бобруйск, ул. Гагарина 12",
                        WorkingHours = "Пн-пт: 9:00-20:00; сб-вс: выходной"
                    },
                    new Shop{ShopId = 3, Name = "Мебель", Adress = "Нижний Новгород, ул. Фрунзе 54к1",
                        WorkingHours = "Пн-вс: 10:00-20:00, каждый первый понедельник месяца - выходной"
                    },
                    new Shop{ShopId = 4, Name = "Ритуальные услуги", Adress = "Молодечно, ул. Радужная 69",
                        WorkingHours = "Пн-пт: 8:00-13:00, 14:00-19:00; сб-вс: 10:00-15:30"
                    },
                    new Shop{ShopId = 5, Name = "Флорист", Adress = "Гомель, ул. 10 лет Окбября 35",
                        WorkingHours = "Пн-сб: 11:00-18:00; вс: выходной"
                    }
            };

            modelBuilder.Entity<Shop>().HasData(shops);
            modelBuilder.Entity<Product>().HasData(products);
            base.OnModelCreating(modelBuilder);

        }
    }
}
