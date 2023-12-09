namespace BookShop.Initializer.Generators
{
    using BookShop.Models;

    internal class AuthorGenerator
    {
        internal static Author[] CreateAuthors()
        {
            string[] authorNames = new string[]
            {
                "Nayden Vitanov",
                "Deyan Tanev",
                "Desislav Petkov",
                "Dyakon Hristov",
                "Milen Todorov",
                "Aleksander Kishishev",
                "Ilian Stoev",

            };

            int authorCount = authorNames.Length;

            Author[] authors = new Author[authorCount];

            for (int i = 0; i < authorCount; i++)
            {
                string[] authorNameTokens = authorNames[i].Split();

                Author author = new Author()
                {
                    FirstName = authorNameTokens[0],
                    LastName = authorNameTokens[1],
                };

                authors[i] = author;
            }

            return authors;
        }
    }
}