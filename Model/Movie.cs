using System.Collections.Generic;

namespace MovieAppApi.Model{
    class Movie{
        private int id;
        private Director director;
        private List<Actor> listActor;
        private List<Genre> listGenre;
        private string title;
        private string engTitle;
        private string avatarUrl;
        private int releaseYear;
        private string country;
        private float rating;
        private string content;
        private int movieLength;
        public int Id{
            get{
                return id;
            }
            set{
                id = value;
            }
        }
        public Director Director{
            get{
                return director;
            }
            set{
                director = value;
            }
        }
        public List<Actor> ListActor{
            get{
                return listActor;
            }
            set{
                listActor = value;
            }
        }
        public List<Genre> ListGenre{
            get{
                return listGenre;
            }
            set{
                listGenre = value;
            }
        }
        public string Title{
            get{
                return title;
            }
            set{
                title = value;
            }
        }
        public string EngTitle{
            get{
                return engTitle;
            }
            set{
                engTitle = value;
            }
        }
        public string AvatarUrl{
            get{
                return avatarUrl;
            }
            set{
                avatarUrl = value;
            }
        }
        public int ReleaseYear{
            get{
                return releaseYear;
            }
            set{
                releaseYear = value;
            }
        }
        public string Country{
            get{
                return country;
            }
            set{
                country = value;
            }
        }
        public float Rating{
            get{
                return rating;
            }
            set{
                rating = value;
            }
        }
        public string Content{
            get{
                return content;
            }
            set{
                content = value;
            }
        }
        public int MovieLength{
            get{
                return movieLength;
            }
            set{
                movieLength = value;
            }
        }
        public Movie(int id, Director director, string title, string engTitle, string avatarUrl, int releaseYear, string country, float rating, string content, int movieLength){
            this.id = id;
            this.director = director;
            this.title = title;
            this.engTitle = engTitle;
            this.avatarUrl = avatarUrl;
            this.releaseYear = releaseYear;
            this.country = country;
            this.rating = rating;
            this.content = content;
            this.movieLength = movieLength;
        }
    }
}