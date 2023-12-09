﻿namespace BookShop.Initializer.Generators
{
    using BookShop.Models;
    using System;
    using System.Globalization;

    class BookGenerator
    {
        #region Book Description
        private static string bookDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
            "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
            "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit " +
            "in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
            "Excepteur sint occaecat cupidatat non proident, " +
            "sunt in culpa qui officia deserunt mollit anim id est laborum.";
        #endregion

        internal static Book[] CreateBooks()
        {
            string[] booksInput = new string[]
            {
                "1 20/01/1998 27274 15.31 2 Absalom",
                "0 14/09/1998 16159 35.56 0 After Many a Summer Dies the Swan",
                "0 13/03/1999 29025 23.71 0 Ah",
                "2 12/3/1993 9998 5.26 2 Wilderness!",
                "2 22/10/2014 18832 5.69 2 Alien CornÂ (play)",
                "0 18/02/2003 28741 34.56 2 The Alien CornÂ (short story)",
                "1 11/10/1991 20471 7.18 1 All Passion Spent",
                "2 29/03/1996 9457 45.6 0 All the King's Men",
                "2 30/11/2000 17327 14.99 0 Alone on a Wide",
                "0 23/04/1998 3226 24.37 1 Wide Sea",
            };

            int bookCount = booksInput.Length;

            Category[] categories = CategoryGenerator.CreateCategories();

            Author[] authors = AuthorGenerator.CreateAuthors();

            Book[] books = new Book[bookCount];

            for (int i = 0; i < bookCount; i++)
            {
                string[] bookTokens = booksInput[i].Split();

                int edition = int.Parse(bookTokens[0]);
                DateTime releaseDate = DateTime.ParseExact(bookTokens[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                int copies = int.Parse(bookTokens[2]);
                double price = double.Parse(bookTokens[3], CultureInfo.InvariantCulture);
                int ageRestriction = int.Parse(bookTokens[4]);
                string title = String.Join(" ", bookTokens, 5, bookTokens.Length - 5);
                Category category = categories[i / 10];
                Author author = authors[i / 5];

                Book book = new Book()
                {
                    Title = title,
                    ReleaseDate = releaseDate,
                    Description = bookDescription,
                    EditionType = (EditionType)edition,
                    Price = price,
                    Copies = copies,
                    AgeRestriction = (AgeRestriction)ageRestriction,
                    Author = author,
                };

                BookCategory bookCategory = new BookCategory()
                {
                    Category = category,
                    Book = book
                };

                book.BookCategories.Add(bookCategory);

                books[i] = book;
            }

            return books;
        }
    }
}