﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sirbu_Iulia_Lab2.Models;
using System;

namespace Sirbu_Iulia_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }

                // Adaugă autori
                var authors = new Author[]
                    {
                    new Author{FirstName="Mihail",LastName="Sadoveanu"},
                    new Author{FirstName="George",LastName="Calinescu"},
                    new Author{FirstName="Mircea",LastName="Eliade"},
                    new Author{FirstName="Cella",LastName="Serghi"},
                    new Author{FirstName="Guillame",LastName="Musso"},
                    new Author{FirstName="Jerome David",LastName="Salinger"}
                    };

                    context.Author.AddRange(authors);
                    context.SaveChanges();

                    // Adaugă genuri
                    context.Genre.AddRange(
                        new Genre { Name = "Roman" },
                        new Genre { Name = "Nuvelă" },
                        new Genre { Name = "Poezie" }
                    );
                    context.SaveChanges();

                    // Adaugă cărți
                    var books = new Book[]
                    {
                    new Book{Title="Baltagul", AuthorID=authors.Single(a => a.LastName == "Sadoveanu").ID, Price=22M},
                    new Book{Title="Enigma Otiliei", AuthorID=authors.Single(a => a.LastName == "Calinescu").ID, Price=18M},
                    new Book{Title="Maytrei", AuthorID=authors.Single(a => a.LastName == "Eliade").ID, Price=27M},
                    new Book{Title="Panza de paianjen", AuthorID=authors.Single(a => a.LastName == "Serghi").ID, Price=45M},
                    new Book{Title="Fata de hartie", AuthorID=authors.Single(a => a.LastName == "Musso").ID, Price=38M},
                    new Book{Title="De veghe in lanul de secara", AuthorID=authors.Single(a => a.LastName == "Salinger").ID, Price=28M},
                    };

                    context.Book.AddRange(books);
                    context.SaveChanges();

                // Adaugă clienți
                var customers = new Customer[]
              {
                 new Customer{Name="Popescu Marcela",Adress="Str. Plopilor 25, Ploiesti",BirthDate=DateTime.Parse("1979-09-01")},
                 new Customer{Name="Mihailescu Cornel",Adress="Str. M. Eminescu 5, ClujNapoca",BirthDate=DateTime.Parse("1969-07-08")},
              };

                //foreach (Customer c in customers)
                {
                    //context.Customer.Add(c);
                }
                context.SaveChanges();

                var orders = new Order[]
                 {
                  new Order{BookID=1,CustomerID=customers.Single(c => c.Name == "Popescu Marcela").CustomerID,OrderDate=DateTime.Parse("2024-02-25")},
                  new Order{BookID=3,CustomerID=customers.Single(c => c.Name == "Popescu Marcela").CustomerID,OrderDate=DateTime.Parse("2024-09-28")},
                   new Order{BookID=1,CustomerID=customers.Single(c => c.Name == "Popescu Marcela").CustomerID,OrderDate=DateTime.Parse("2024-10-28")},
                   new Order{BookID=2,CustomerID=customers.Single(c => c.Name == "Mihailescu Cornel").CustomerID,OrderDate=DateTime.Parse("2024-09-28")},
                   new Order{BookID=4,CustomerID=customers.Single(c => c.Name == "Mihailescu Cornel").CustomerID,OrderDate=DateTime.Parse("2024-09-28")},
                    new Order{BookID=6,CustomerID=customers.Single(c => c.Name == "Mihailescu Cornel").CustomerID, OrderDate=DateTime.Parse("2024-10-28")},
                 };
                foreach (Order e in orders)
                {
                    context.Order.Add(e);
                }
                context.SaveChanges();

                var publishers = new Publisher[]
                 {
                 new Publisher{PublisherName="Humanitas",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
                 new Publisher{PublisherName="Nemira",Adress="Str. Plopilor, nr. 35, Ploiesti"},
                 new Publisher{PublisherName="Paralela 45",Adress="Str. Cascadelor, nr. 22, ClujNapoca"},
                 };
                foreach (Publisher p in publishers)
                {
                    context.Publisher.Add(p);
                }
                context.SaveChanges();

                var publishedbooks = new PublishedBook[]
                 {
                 new PublishedBook {
                 BookID = books.Single(c => c.Title == "Maytrei" ).ID,
                 PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                 },
                 new PublishedBook {
                 BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID,
                 PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                 },
                 new PublishedBook {
                 BookID = books.Single(c => c.Title == "Baltagul" ).ID,
                 PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID
                 },
                 new PublishedBook {
                 BookID = books.Single(c => c.Title == "Fata de hartie" ).ID,
                 PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                 },
                 new PublishedBook {
                     BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID,
                     PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                     },
                 new PublishedBook {
                 BookID = books.Single(c => c.Title == "De veghe in lanul de secara" ).ID,
                 PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                 },
                 };
                foreach (PublishedBook pb in publishedbooks)
                {
                    context.PublishedBook.Add(pb);
                }
                context.SaveChanges();

            }
        }
    }
}