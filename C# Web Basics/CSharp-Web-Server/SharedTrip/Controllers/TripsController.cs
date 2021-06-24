namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TripsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
