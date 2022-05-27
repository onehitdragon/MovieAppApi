namespace MovieAppApi.Model{
    public class FeedBack{
        private User user;
        private string content;
        public User User{
            get{
                return user;
            }
            set{
                user = value;
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
        public FeedBack(User user, string content){
            this.user = user;
            this.content = content;
        }
    }
}