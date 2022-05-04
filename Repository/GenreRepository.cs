using System.Collections.Generic;
using MovieAppApi.Model;
using MovieAppApi.DataBase;
using System.Data;

namespace MovieAppApi.Repository{
    class GenreRepository : IGenreRepository{
        private DataProvider dataProvider;
        public GenreRepository(){
            dataProvider = new DataProvider();
        }
        public List<Genre> GetListGenre(){
            List<Genre> listGenre = new List<Genre>();
            string query = $"SELECT Genre.id, Genre.genrename FROM Genre JOIN MovieGenre ON Genre.id = MovieGenre.genre_id GROUP BY Genre.id, Genre.genrename ORDER BY Genre.id";
            DataTable genreTable = dataProvider.GetDataTable(query);
            foreach(DataRow genreRow in genreTable.Rows){
                Genre genre = new Genre(int.Parse(genreRow[0].ToString()), genreRow[1].ToString());
                listGenre.Add(genre);
            }
            
            return listGenre;
        }
    }
}