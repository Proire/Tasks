using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Xml.Linq;

namespace ADO.NetTestCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------Introduction to ADO.NET----------------------------------------\n");
            Console.WriteLine("----- Connected Architecture ------\n\n");
            IConfiguration configuration = GetAppSettingsFile();
            PlayerLayer player = new PlayerLayer(configuration);
            //player.CreatePlayersTable();
            player.AddPlayer();
            Console.ReadKey();
            player.GetPlayers();
            Console.ReadKey();
            player.UpdatePlayer();
            Console.ReadKey();
            player.GetPlayers();
            Console.ReadKey();
            player.DeletePlayer();

        }
        
        static IConfiguration GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration _iconfiguration = builder.Build();
            return _iconfiguration;
        }

    }
}
