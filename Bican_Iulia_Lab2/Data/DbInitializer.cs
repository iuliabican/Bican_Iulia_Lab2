using Bican_Iulia_Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using static System.Reflection.Metadata.BlobBuilder;
using Publisher = Bican_Iulia_Lab2.Models.Publisher;

namespace Bican_Iulia_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return; // BD a fost creata anterior
                }

                //context.Authors.AddRange(
                //    new Author{ FirstName = "Mihail", LastName = "Sadoveanu"},
                //    new Author{ FirstName = "George", LastName = "Calinescu"},
                //    new Author{ FirstName = "Mircea", LastName = "Eliade"}
                //);

                //context.SaveChanges();
                //context.Books.AddRange(
                //new Book
                //{
                //    Title = "Baltagul",
                //    Price = Decimal.Parse("22"),
                //    AuthorID = context.Authors.Single(author => author.LastName == "Sadoveanu").ID

                //},

                //new Book
                //{
                //    Title = "Enigma Otiliei",
                //    Price = Decimal.Parse("18"),
                //    AuthorID = context.Authors.Single(author => author.LastName == "Calinescu").ID
                //},

                //new Book
                //{
                //    Title = "Maytrei",
                //    Price = Decimal.Parse("27"),
                //    AuthorID = context.Authors.Single(author => author.LastName == "Eliade").ID
                //}

                //);

                //context.Customers.AddRange(
                //new Customer
                //{
                //    Name = "Popescu Marcela",
                //    Address = "Str. Plopilor, nr. 24",
                //    BirthDate = DateTime.Parse("1979-09-01")
                //},
                //new Customer
                //{
                //    Name = "Mihailescu Cornel",
                //    Address = "Str. Bucuresti, nr. 45, ap. 2",
                //    BirthDate = DateTime.Parse("1969 - 07 - 08")
                //}

                //);

                var orders = new Order[]{
                    new Order{BookID=1,CustomerID=1050,OrderDate=DateTime.Parse("2021-02-25")},
                    new Order{BookID=3,CustomerID=1045,OrderDate=DateTime.Parse("2021-09-28")},
                    new Order{BookID=1,CustomerID=1045,OrderDate=DateTime.Parse("2021-10-28")},
                    new Order{BookID=2,CustomerID=1050,OrderDate=DateTime.Parse("2021-09-28")},
                    new Order{BookID=4,CustomerID=1050,OrderDate=DateTime.Parse("2021-09-28")},
                    new Order{BookID=6,CustomerID=1050,OrderDate=DateTime.Parse("2021-10-28")}};

                foreach (Order e in orders)
                {
                    context.Orders.Add(e);
                }
                context.SaveChanges();

                var publishers = new Publisher[]{
                    new Publisher{PublisherName="Humanitas",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
                    new Publisher{PublisherName="Nemira",Adress="Str. Plopilor, nr. 35, Ploiesti"},
                    new Publisher{PublisherName="Paralela 45",Adress="Str. Cascadelor, nr. 22, Cluj-Napoca"},
                };

                foreach (Publisher p in publishers)
                {
                    context.Publishers.Add(p);
                }
                context.SaveChanges();
                //var books = context.Books;

                var publishedbooks = new PublishedBook[]{
                    new PublishedBook { BookID = books.Single(c => c.Title == "Maytrei" ).ID, PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID},
                    new PublishedBook { BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID,PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID},
                    new PublishedBook { BookID = books.Single(c => c.Title == "Baltagul" ).ID, PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID},
                    new PublishedBook { BookID = books.Single(c => c.Title == "Fata de hartie" ).ID, PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID},
                    new PublishedBook { BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID, PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID},
                    new PublishedBook { BookID = books.Single(c => c.Title == "De veghe in lanul de secara" ).ID, PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID}
                };

                foreach (PublishedBook pb in publishedbooks)
                {
                    context.PublishedBooks.Add(pb);
                }



                context.SaveChanges();
            }
        }
    }
    }
