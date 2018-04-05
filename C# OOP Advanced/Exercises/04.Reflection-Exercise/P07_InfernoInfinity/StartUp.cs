using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using P07_InfernoInfinity.Attributes;
using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core;
using P07_InfernoInfinity.Factories;
using P07_InfernoInfinity.Models.Repositories;
using P07_InfernoInfinity.Models.Weapons;

namespace P07_InfernoInfinity
{
    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            ICommandInterpreter commandInterpreter = new CommandIntepreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();

            //GetCustumAttributes();
        }

        private static void GetCustumAttributes()
        {
            Type type = typeof(Weapon);

            InfoAttribute attribute = (InfoAttribute) type.GetCustomAttributes(false).FirstOrDefault();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attribute.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"Revision: {attribute.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class description: {attribute.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                        break;
                    default:
                        break;
                }
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddSingleton<IWeaponRepository, WeaponRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
