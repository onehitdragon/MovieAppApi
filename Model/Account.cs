namespace MovieAppApi.Model{
    public class Account{
        private string email;
        private string password;
        public string Email{
            get{
                return email;
            }
            set{
                email = value;
            }
        }
        public string Password{
            get{
                return password;
            }
            set{
                password = value;
            }
        }
        public Account(){}
        public Account(string email, string password){
            this.email = email;
            this.password = password;
        }
    }
}