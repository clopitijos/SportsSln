using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            var seedProducts = new List<Product>
            {
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your field a professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficency by 75%",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded king",
                        Category = "Chess",
                        Price = 1200
                    }
                    ,
                    new Product
                    {
                        Name = "Running Shoes",
                        Description = "Lightweight shoes for everyday running",
                        Category = "Running",
                        Price = 89.99m
                    },
                    new Product
                    {
                        Name = "Horse Saddle",
                        Description = "Leather saddle providing comfort and control for riders",
                        Category = "Equestrian",
                        Price = 249.99m
                    },
                    new Product
                    {
                        Name = "Spurs",
                        Description = "Metal tools worn on the heels of riding boots to direct a horse",
                        Category = "Equestrian",
                        Price = 199.99m
                    }
            };
            bool added = false;
            foreach (var p in seedProducts)
            {
                if (!context.Products.Any(x => x.Name == p.Name))
                {
                    context.Products.Add(p);
                    added = true;
                }
            }
            if (added)
            {
                context.SaveChanges();
            }
        }
    }
}