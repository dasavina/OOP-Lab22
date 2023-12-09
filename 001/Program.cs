namespace BookShop
{
    using _001;
    using BookShop.Data;
    using BookShop.Initializer;

    class StartUp
    {
        static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);


                string ageRestriction = Console.ReadLine();
                Console.WriteLine(Queries.GetBooksByAgeRestriction(db, ageRestriction));
                Console.WriteLine(Queries.GetGoldenBooks(db));
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine(Queries.GetBooksNotRealeasedIn(db, year));
                string input = Console.ReadLine();
                Console.WriteLine(Queries.GetBooksByCategory(db, input));
                string date = Console.ReadLine();
                Console.WriteLine(Queries.GetBooksReleasedBefore(db, date));
                input = Console.ReadLine();
                Console.WriteLine(Queries.GetAuthorNamesEndingIn(db, input));
                input = Console.ReadLine();
                Console.WriteLine(Queries.GetBookTitlesContaining(db, input));
                input = Console.ReadLine();
                Console.WriteLine(Queries.GetBooksByAuthor(db, input));
                var length = int.Parse(Console.ReadLine());
                Console.WriteLine(Queries.CountBooks(db, length));
                Console.WriteLine(Queries.CountCopiesByAuthor(db));
                Console.WriteLine(Queries.GetTotalProfitByCategory(db));
                Console.WriteLine(Queries.GetMostRecentBooks(db));
                Queries.IncreasePrices(db);
                Console.WriteLine($"{Queries.RemoveBooks(db)} books were deleted");
            }
        }
    }
}