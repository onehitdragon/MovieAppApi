using MovieAppApi.Model;

namespace MovieAppApi.Repository{
    interface IAccountRepository{
        bool EmailExist(Account account);
        bool IsValidAccount(Account account);
        void AddUser(User user);
        User GetUser(string email);
        void UpdatePassword(string email, string newPassword);
    }
}