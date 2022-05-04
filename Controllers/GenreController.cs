using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieAppApi.Model;
using MovieAppApi.Repository;

namespace MovieAppApi.Controllers{
    [Route("api/[Controller]")]
    public class GenreController : Controller{
        private IGenreRepository genreRepository;
        public GenreController(){
            genreRepository = new GenreRepository();
        }

        [Route("ListGenre")]
        public IActionResult ListGenre(){
            List<Genre> listGenre = genreRepository.GetListGenre();

            return Json(listGenre);
        }
    }
}