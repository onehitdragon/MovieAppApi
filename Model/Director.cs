namespace MovieAppApi.Model{
    class Director{
        private int id;
        private string fullName;
        public int Id{
            get{
                return id;
            }
            set{
                id = value;
            }
        }
        public string FullName{
            get{
                return fullName;
            }
            set{
                fullName = value;
            }
        }
        public Director(int id, string fullName){
            this.id = id;
            this.fullName = fullName;
        }
    }
}