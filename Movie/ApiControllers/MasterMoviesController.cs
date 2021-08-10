using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.EntityFramework;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ApiControllers
{
    [Route("api/mastermovies")]
    [ApiController]
    public class MasterMoviesController : ControllerBase
    {
        //public string WhoAmI()
        //{
        //    return "Miw";
        //}

        private readonly MovieContext _movieContext;

        public MasterMoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        [Route("getall")]
        public IEnumerable<MasterMovie> GetAll()
        {
            var movies = _movieContext.MasterMovies.ToList();
            return movies;
        }

        [Route("getbyid/{id?}")]
        public MasterMovie GetById(int id)
        {
            var item = _movieContext.MasterMovies.Find(id);
            return item;
        }
    }
}
