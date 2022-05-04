using System;
using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Model;
using MovieAppApi.Repository;
using System.Collections.Generic;

namespace MovieAppApi.Controllers{
    [Route("api/[Controller]")]
    public class MovieController : Controller{
        private IMovieRepository movieRepository;
        public MovieController(){
            movieRepository = new MovieRepository();
        }
        [Route("ListNewestMovie")]
        public IActionResult ListNewestMovie(int amount = 5){
            List<Movie> listNewestMovie = movieRepository.GetNewestMovieList(amount);
            
            return Json(listNewestMovie);
        }
    }
}