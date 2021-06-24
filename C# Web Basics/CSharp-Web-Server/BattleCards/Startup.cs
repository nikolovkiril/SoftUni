namespace BattleCards
{
    using MyWebServer;
    using BattleCards.Data;
    using Microsoft.EntityFrameworkCore;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using System.Threading.Tasks;
    using BattleCards.Services;

    public class Startup 
    {
        public static async Task Main()
             => await HttpServer
                 .WithRoutes(routes => routes
                     .MapStaticFiles()
                     .MapControllers())
                 .WithServices(services => services
                     .Add<BattleCardsDbContext>()
                     .Add<IValidator, Validator>()
                     .Add<IPasswordHasher, PasswordHasher>()
                     .Add<IViewEngine, CompilationViewEngine>())
                 .WithConfiguration<BattleCardsDbContext>(context => context
                     .Database.Migrate())
                 .Start();
    }
}
