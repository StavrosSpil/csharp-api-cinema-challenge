﻿using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace api_cinema_challenge.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        public CinemaRepository()
        {
        
        }

        public Customer AddCustomer(Customer customer)
        {
            using (var db = new CinemaContext())
            {
                customer.CreatedAt = DateTime.UtcNow;
                db.Customers.Add(customer);
                db.SaveChanges();
                return customer;
            }
        }

        public Movie AddMovie(Movie movie)
        {
            using (var db = new CinemaContext())
            {
                movie.CreatedAt = DateTime.UtcNow;
                db.Movies.Add(movie);
                db.SaveChanges();
                return movie;
            }
        }

        public Screening AddScreening(Screening screening, int movieId)
        {
            using (var db = new CinemaContext())
            {
                screening.CreatedAt = DateTime.UtcNow;
                screening.MovieId = movieId;
                screening.Movie = db.Movies.FirstOrDefault(x => x.Id == movieId);
                db.Screenings.Add(screening);
                db.SaveChanges();
                return screening;
            }
        }

        public Customer DeleteCustomer(int id)
        {
            using (var db = new CinemaContext())
            {
                var customer = db.Customers.FirstOrDefault(c => c.Id == id);
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    return customer;
                }
                return null;
            }
        }

        public Movie DeleteMovie(int id)
        {
            using (var db = new CinemaContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.Id == id);
                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                    return movie;
                }
                return null;
            }
        }

        public Screening DeleteScreening(int id)
        {
            using (var db = new CinemaContext())
            {
                var screening = db.Screenings.FirstOrDefault(s => s.Id == id);
                if (screening != null)
                {
                    db.Screenings.Remove(screening);
                    db.SaveChanges();
                    return screening;
                }
                return null;
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (var db = new CinemaContext() )
            {
                return db.Customers.ToList();
            }
        }

        public IEnumerable<Movie> GetMovies()
        {
            using (var db = new CinemaContext())
            {
                return db.Movies.ToList();
            }
        }

        public IEnumerable<Screening> GetScreenings()
        {
            using (var db = new CinemaContext())
            {
                return db.Screenings.Include(s => s.Movie).ToList();
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            using (var db = new CinemaContext())
            {
                customer.UpdatedAt = DateTime.UtcNow;
                db.Customers.Update(customer);
                db.SaveChanges();
                return customer;
            }
        }

        public Movie UpdateMovie(Movie movie)
        {
            using (var db = new CinemaContext())
            {
                movie.UpdatedAt = DateTime.UtcNow;
                db.Movies.Update(movie);
                db.SaveChanges();
                return movie;
            }
        }

        public Screening UpdateScreening(Screening screening)
        {
            using (var db = new CinemaContext())
            {
                screening.UpdatedAt = DateTime.UtcNow;
                db.Screenings.Update(screening);
                db.SaveChanges();
                return screening;
            }
        }
    }
}
