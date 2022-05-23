using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoffeLand.Data;
using System;
using System.Linq;
namespace CoffeLand.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CoffeLandContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<CoffeLandContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.Coffe.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.Coffe.AddRange(
                new Coffe
                {
                    Title = "Atomic Habits",
                    ReleaseDate = DateTime.Parse("2018-10-16"),
                    Genre = "Self-Help",
                    Price = 11.98M,
                    Rating = "9.5"
                },
                new Coffe
                {
                    Title = "Dark Roads",
                    ReleaseDate = DateTime.Parse("2021-8-3"),
                    Genre = "Novel",
                    Price = 18.59M,
                    Rating = "8"
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}