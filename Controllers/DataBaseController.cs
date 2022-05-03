using Microsoft.AspNetCore.Mvc;
using MovieAppApi.DataBase;

namespace MovieAppApi.Controllers{
    [Route("api/[Controller]")]
    public class DataBaseController : Controller{
        private DataBaseInit dataBaseInit;
        public DataBaseController(){
            dataBaseInit = new DataBaseInit();
        }
        [Route("init")]
        public string Init(){
            dataBaseInit.Init();
            return "init";
        }
        [Route("drop")]
        public string Drop(){
            dataBaseInit.Drop();
            return "drop";
        }
    }
}