using MovieAppApi.DataBase;
using System.Collections.Generic;
using MovieAppApi.Model;
using System.Data;
using System;

namespace MovieAppApi.Repository{
    class MovieRepository : IMovieRepository{
        private DataProvider dataProvider;
        public MovieRepository(){
            dataProvider = new DataProvider();
        }
        public List<Movie> GetNewestMovieList(int amount){
            List<Movie> listNewestMovie = new List<Movie>();
            string query = $"SELECT * FROM Movie JOIN Director ON Movie.director_id = Director.id ORDER BY ReleaseYear DESC LIMIT {amount}";
            DataTable movieTable = dataProvider.GetDataTable(query);
            foreach(DataRow movieRow in movieTable.Rows){
                Movie movie = createMovieFromDataRow(movieRow);
                listNewestMovie.Add(movie);
            }

            return listNewestMovie;
        }
        private Movie createMovieFromDataRow(DataRow movieRow){
            Movie movie = new Movie(
                int.Parse(movieRow[0].ToString()),
                new Director(int.Parse(movieRow[10].ToString()), movieRow[11].ToString()),
                movieRow[2].ToString(),
                movieRow[3].ToString(),
                movieRow[4].ToString(),
                int.Parse(movieRow[5].ToString()),
                movieRow[6].ToString(),
                float.Parse(movieRow[7].ToString()),
                movieRow[8].ToString(),
                int.Parse(movieRow[9].ToString())
            );
            movie.ListGenre = GetGenreList(movie);
            movie.ListActor = GetActorList(movie);
            movie.ListEpisode = GetListEpisode(movie);

            return movie;
        }
        private List<Genre> GetGenreList(Movie movie){
            List<Genre> listGenre = new List<Genre>();
            string query = $"SELECT Genre.* FROM MovieGenre JOIN Genre ON MovieGenre.genre_id = Genre.id WHERE MovieGenre.movie_id = {movie.Id}";
            DataTable genreTable = dataProvider.GetDataTable(query);
            foreach(DataRow genreRow in genreTable.Rows){
                Genre genre = new Genre(
                    int.Parse(genreRow[0].ToString()),
                    genreRow[1].ToString()
                );
                listGenre.Add(genre);
            }

            return listGenre;
        }
        private List<Actor> GetActorList(Movie movie){
            List<Actor> listActor = new List<Actor>();
            string query = $"SELECT Actor.* FROM MovieActor JOIN Actor ON MovieActor.actor_id = Actor.id WHERE MovieActor.movie_id = {movie.Id}";
            DataTable actorTable = dataProvider.GetDataTable(query);
            foreach(DataRow actorRow in actorTable.Rows){
                Actor actor = new Actor(
                    int.Parse(actorRow[0].ToString()),
                    actorRow[1].ToString(),
                    actorRow[2].ToString()
                );
                listActor.Add(actor);
            }

            return listActor;
        }
        private List<Episode> GetListEpisode(Movie movie){
            List<Episode> listEpisode = new List<Episode>();
            string query = $"SELECT * FROM Episode WHERE Movie_id = {movie.Id}";
            DataTable episodeTable = dataProvider.GetDataTable(query);
            foreach(DataRow episodeRow in episodeTable.Rows){
                Episode episode = new Episode(
                    int.Parse(episodeRow[1].ToString()),
                    episodeRow[2].ToString()
                );
                listEpisode.Add(episode);
            }

            return listEpisode;
        }
        public List<Movie> GetListMovieByGenre(Genre genre){
            List<Movie> listMovie = new List<Movie>();
            string query = $"SELECT Movie.*, Director.* FROM Movie JOIN MovieGenre ON Movie.id = MovieGenre.movie_id JOIN Director ON Movie.id = Director.id WHERE MovieGenre.genre_id = {genre.Id}";
            DataTable movieTable = dataProvider.GetDataTable(query);
            foreach(DataRow movieRow in movieTable.Rows){
                Movie movie = createMovieFromDataRow(movieRow);
                listMovie.Add(movie);
            }

            return listMovie;
        }
        public List<Movie> Search(string key){
            List<Movie> listResult = new List<Movie>();
            string query = $"SELECT * FROM Movie JOIN Director ON Movie.director_id = Director.id WHERE LOWER(title) LIKE LOWER('%{key}%') OR LOWER(engtitle) LIKE LOWER('%{key}%')";
            DataTable movieTable = dataProvider.GetDataTable(query);
            foreach(DataRow movieRow in movieTable.Rows){
                Movie movie = createMovieFromDataRow(movieRow);
                listResult.Add(movie);
            }

            return listResult;
        }
    }
}