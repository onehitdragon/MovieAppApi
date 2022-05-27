using System;
using Microsoft.AspNetCore.Mvc;
using MovieAppApi.DataBase;
using MovieAppApi.Model;
using MovieAppApi.Repository;

namespace MovieAppApi.Controllers{
    [Route("api/[Controller]")]
    public class FeedBackController : Controller{
        private IFeedBackRepository feedBackRepository;
        public FeedBackController(){
            feedBackRepository = new FeedBackRepository();
        }

        [Route("SendFeedBack")]
        [HttpPost]
        public void SendFeedBack(string email, string content){
            feedBackRepository.addFeedBack(email, content);
        }
    }
}