namespace MovieAppApi.Model{
    class Genre{
        private int id;
        private string name;
        public int Id{
            get{
                return id;
            }
            set{
                id = value;
            }
        }
        public string Name{
            get{
                return name;
            }
            set{
                name = value;
            }
        }
        public Genre(int id){
            this.id = id;
        }
        public Genre(int id, string name){
            this.id = id;
            this.name = name;
        }
    }
}