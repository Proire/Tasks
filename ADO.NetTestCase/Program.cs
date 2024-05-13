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
            IConfiguration configuration = GetAppSettingsFile();  // same database for both architecture
            Console.WriteLine("Choose \n1 for Connected Architecture\n2 for Disconnected Architecturefor \n");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            if (choice == 1)
            {
                Console.WriteLine("----- Connected Architecture ------\n\n");
                PlayerLayer player = new PlayerLayer(configuration);
                while (true)
                {
                    Console.WriteLine("\nEnter a Choice:");
                    Console.WriteLine("1. Add a new player");
                    Console.WriteLine("2. Get all players");
                    Console.WriteLine("3. Update an existing player");
                    Console.WriteLine("4. Delete a player");
                    Console.WriteLine("5. Exit\n");

                    Console.Write("Enter your choice: ");
                    string UserChoice = Console.ReadLine();

                    switch (UserChoice)
                    {
                        case "1":
                            player.AddPlayer();
                            break;
                        case "2":
                            player.GetPlayers();
                            break;
                        case "3":
                            player.UpdatePlayer();
                            break;
                        case "4":
                            player.DeletePlayer();
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    Console.WriteLine();
                }
            }
            else if (choice == 2)
            {

                Console.WriteLine("\n----- Disconnected Architecture ------\n\n");
                CarLayer car = new(configuration);
                while (true)
                {
                    Console.WriteLine("\nEnter a Choice:");
                    Console.WriteLine("1. Add a new car");
                    Console.WriteLine("2. Update an existing car");
                    Console.WriteLine("3. Display all cars");
                    Console.WriteLine("4. Delete a car");
                    Console.WriteLine("5. Exit\n");

                    Console.Write("Enter your choice: ");
                    string UserChoice = Console.ReadLine();

                    switch (UserChoice)
                    {
                        case "1":
                            car.AddCar();
                            break;
                        case "2":
                            car.UpdateCar();
                            break;
                        case "3":
                            car.DisplayCars();
                            break;
                        case "4":
                            car.DeleteCar();
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Wrong Choice");
            }

            Console.WriteLine("------ Thank you for visiting ------");
        }
        
        static IConfiguration GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration _iconfiguration = builder.Build();
            return _iconfiguration;
        }

    }
}
