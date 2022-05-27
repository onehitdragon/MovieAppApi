using MovieAppApi.DataBase;
using MovieAppApi.Model;
using System;
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
        public User GetUser(string email){
            string query = $"SELECT lastName, firstName, birthDay, Gender, id FROM Users WHERE email = '{email}'";
            DataTable userTable = dataProvider.GetDataTable(query);
            if(userTable.Rows.Count == 0) return null;
            DataRow userRow = userTable.Rows[0];
            DateTime birthDay = DateTime.Parse(userRow[2].ToString());
            bool gender = int.Parse(userRow[3].ToString()) == 1 ? true : false;
            User user = new User("", "", userRow[0].ToString(), userRow[1].ToString(), birthDay, gender);
            user.Id = int.Parse(userRow[4].ToString());

            return user;
        }

        public void UpdatePassword(string email, string newPassword){
            string query = $"UPDATE Users SET password = md5('{newPassword}') WHERE email = '{email}'";
            dataProvider.ExcuteQuery(query);
        }
    }
}