using BookShop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001
{
    class Queries
    {
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int ageRestriction = AgeRestriction.Minor.ToString().ToLower().Equals(command.ToLower()) ? 0 :
                AgeRestriction.Teen.ToString().ToLower().Equals(command.ToLower()) ? 1 :
                AgeRestriction.Adult.ToString().ToLower().Equals(command.ToLower()) ? 2 : 3;

            var booksTitles = context.Books
                .Where(b => (int)b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksTitles);
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksTitles);
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            return String.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }
    }
}
