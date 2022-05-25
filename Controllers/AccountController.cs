using System;
using Microsoft.AspNetCore.Mvc;
using MovieAppApi.DataBase;
using MovieAppApi.Model;
using MovieAppApi.Repository;

namespace MovieAppApi.Controllers{
    [Route("api/[Controller]")]
    public class AccountController : Controller{
        private DataProvider dataProvider;
        private IAccountRepository accountRepository;
        public AccountController(){
            dataProvider = new DataProvider();
            accountRepository = new AccountRepository();
        }
        [Route("Check")]
        [HttpPost]
        public IActionResult Check(string email, string password){
            Account account = new Account(email, password);
            bool emailIsValid = false;
            bool passwordIsValid = false;
            if(accountRepository.EmailExist(account)){
                emailIsValid = true;
            }
            if(emailIsValid){
                if(accountRepository.IsValidAccount(account)){
                    passwordIsValid = true;
                }
            }

            return Json(new {
                emailIsValid = emailIsValid,
                passwordIsValid = passwordIsValid
            });
        }
        [Route("Register")]
        [HttpPost]
        public void Register(User user){
            Console.WriteLine(user.BirthDay.ToString());
            accountRepository.AddUser(user);
        }

        [Route("GetUser")]
        public IActionResult GetUser(string email){
            User user = accountRepository.GetUser(email);
            return Json(user);
        }

        [Route("ChangePassword")]
        [HttpPost]
        public void ChangePassword(string email, string newPassword){
            accountRepository.UpdatePassword(email, newPassword);
        }
    }
}