using MovieAppApi.DataBase;
using MovieAppApi.Model;
using System.Data;

namespace MovieAppApi.Repository{
    class AccountRepository : IAccountRepository{
        private DataProvider dataProvider;
        public AccountRepository(){
            dataProvider = new DataProvider();
        }
        public bool EmailExist(Account account){
            string query = $"SELECT * FROM Users WHERE email = '{account.Email}'";
            DataTable userTable = dataProvider.GetDataTable(query);
            if(userTable.Rows.Count > 0){
                return true;
            }
            return false;
        }
        public bool IsValidAccount(Account account){
            string query = $"SELECT * FROM Users WHERE email = '{account.Email}' AND password = MD5('{account.Password}')";
            DataTable userTable = dataProvider.GetDataTable(query);
            if(userTable.Rows.Count > 0){
                return true;
            }
            return false;
        }
        public void AddUser(User user){
            string query = $"INSERT INTO Users(FirstName, LastName, BirthDay, Gender, Email, Password, TimeCreated) VALUES(N'{user.FirstName}',N'{user.LastName}','{user.BirthDay.ToString()}',{(user.Gender ? 1 : 0)},'{user.Email}', MD5('{user.Password}'), now());";
            dataProvider.ExcuteQuery(query);
        }
    }
}