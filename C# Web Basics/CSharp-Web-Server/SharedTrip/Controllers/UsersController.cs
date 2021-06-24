namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        //[HttpPost]
        //public HttpResponse Login(LoginInputModel input)
        //{

        //}

        public HttpResponse Register()
        {
            return this.View();
        }

        //[HttpPost]
        //public HttpResponse Register(RegisterInputModel input)
        //{
        //    return this.View();
        //}
    }
}
