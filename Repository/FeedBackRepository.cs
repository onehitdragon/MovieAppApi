using MovieAppApi.DataBase;
using MovieAppApi.Model;
using System;
using System.Data;

namespace MovieAppApi.Repository{
    public class FeedBackRepository : IFeedBackRepository{
        private DataProvider dataProvider;
        private IAccountRepository accountRepository;
        public FeedBackRepository(){
            dataProvider = new DataProvider();
            accountRepository = new AccountRepository();
        }
        public void addFeedBack(string email, string content){
            User user = accountRepository.GetUser(email);
            if(user == null) return;
            string query = $"INSERT INTO FeedBack(User_Id, Content, TimeCreated) VALUES ({user.Id}, '{content}', now())";
            dataProvider.ExcuteQuery(query);
        }
    }
}