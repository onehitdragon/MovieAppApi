namespace MovieAppApi.Model{
    class Actor{
        private int id;
        private string avatarUrl;
        private string fullName;
        public int Id{
            get{
                return id;
            }
            set{
                id = value;
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
        public string FullName{
            get{
                return fullName;
            }
            set{
                fullName = value;
            }
        }
        public Actor(int id, string avatarUrl, string fullName){
            this.id = id;
            this.avatarUrl = avatarUrl;
            this.fullName = fullName;
        }
    }
}