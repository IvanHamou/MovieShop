using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    class Seeding
    {
        static void Main()
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);

                ctx.AddRange(new List<Customer> {
                    new Customer { Name = "Ivan" },
                    new Customer { Name = "Jonatan" },
                    new Customer { Name = "Axel" },
                });


                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\AvailableMovies\Movies.csv");
                for (int i = 1; i < 200; i++)
                {
                    var cells = lines[i].Split(',');

                    var url = cells[5].Trim('"');

                    try { var test = new Uri(url); }
                    catch (Exception) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url });
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();
            }
        }
    }
}
