using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.EntityFramework;
using Movie.Models;
using Movie.Services;
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
        private readonly MasterMovieService _masterMovieService;

        public MasterMoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
            _masterMovieService = new MasterMovieService(_movieContext);
        }
        [Route("getall")]
        public IEnumerable<MasterMovie> GetAll()
        {
            var movies = _masterMovieService.GetAll();
            return movies;
        }

        [Route("getbyid/{id?}")]
        public MasterMovie GetById(int id)
        {
            var item = _masterMovieService.GetById(id);
            return item;
        }

        
        [HttpPost]
        public MasterMovie AddMovie([FromBody] MasterMovie item)
        {
            var mastermovie = _masterMovieService.AddMovie(item);
            return mastermovie;
        }

        [HttpPut]
        public MasterMovie PostEditMovie(MasterMovie item)
        {
            var mastermovie = _masterMovieService.PostEditMovie(item);
            return mastermovie;
        }

        [HttpDelete]
        public MasterMovie DeleteMovie(int id)
        {
            var mastermovie = _masterMovieService.DeleteMovie(id);
            return mastermovie;
        }
    }
}
