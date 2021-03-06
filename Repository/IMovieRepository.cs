using System.Collections.Generic;
using MovieAppApi.Model;

namespace MovieAppApi.Repository{
    interface IMovieRepository{
        List<Movie> GetNewestMovieList(int amount);
        List<Movie> GetListMovieByGenre(Genre genre);
        List<Movie> Search(string key);
    }
}