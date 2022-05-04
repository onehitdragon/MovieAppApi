using System.Collections.Generic;
using MovieAppApi.Model;

namespace MovieAppApi.Repository{
    interface IGenreRepository{
        List<Genre> GetListGenre();
    }
}