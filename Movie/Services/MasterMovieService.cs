using Movie.EntityFramework;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Services
{
    public interface IMasterMovieService
    {
        //GetAll
        IEnumerable<MasterMovie> GetAll();

        // GetById
        MasterMovie GetById(int id);

        // AddMovie
        MasterMovie AddMovie(MasterMovie item);

        // GetEditMovie
        MasterMovie GetEditMovie(int id);

        // PostEditMovie
        MasterMovie PostEditMovie(MasterMovie item);

        // Delete
        MasterMovie DeleteMovie(int id);
    }

    public class MasterMovieService : IMasterMovieService
    {
        private readonly MovieContext _movieContext;

        public MasterMovieService(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        // GetAll
        public IEnumerable<MasterMovie> GetAll()
        {
            var movies = _movieContext.MasterMovies.ToList();
            return movies;
        }

        // GetById
        public MasterMovie GetById(int id)
        {
            var item = _movieContext.MasterMovies.Find(id);
            return item;
        }

        // AddMovie
        public MasterMovie AddMovie(MasterMovie item)
        {
            _movieContext.Add(item);
            _movieContext.SaveChanges();
            return item;
        }
        // GetEditMovie
        public MasterMovie GetEditMovie(int id)
        {
            MasterMovie item = _movieContext.MasterMovies.Find(id);
            return item;
        }
        // PostEditMovie
        public MasterMovie PostEditMovie(MasterMovie item)
        {
            _movieContext.Update(item);
            _movieContext.SaveChanges();
            return item;
        }

        // Delete
        public MasterMovie DeleteMovie(int id)
        {
            MasterMovie item =  _movieContext.MasterMovies.Find(id);
            if (item != null)
            {
                _movieContext.MasterMovies.Remove(item);
                _movieContext.SaveChanges();
            }
            return item;
        }
    }
}
