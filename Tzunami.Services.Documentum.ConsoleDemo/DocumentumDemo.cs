using Serilog;
using System;
using Emc.Documentum.Rest;
using Properities = Emc.Documentum.Rest.Constants.PropertiesConstants;
using Tables = Emc.Documentum.Rest.Constants.TableNames;
using Emc.Documentum.Rest.Builders;

namespace Tzunami.Docushare.ConsoleDemo
{
    public class DocumentumDemo
    {
        private const string _serviceUrl = "http://demo-server:8080/dctm-rest/";
        private readonly DocumentumService _service = new DocumentumService();
        public void Run()
        {
            //RunSystemInfoDemo();
            //RunGetRepositoriesDemo();
            //RunAuthorizationDemo();
            //RunGetRepoDemo();
            //RunDQLDemo();
        }

        /// <summary>
        /// Demo that will require user input to run/interact
        /// </summary>
        public void InteractiveDemo()
        {
            while (true)
            {
                var selection = GetSelectedOption();
                if (selection == 1)
                {
                    RunSystemInfoDemo();
                }
                else if (selection == 2)
                {
                    RunGetRepositoriesDemo();
                }
                else if (selection == 3)
                {
                    RunAuthorizationDemo();
                }
                else if(selection == 4)
                {
                    RunGetRepoDemo();
                }
                else if(selection == 5)
                {
                    RunCabinetDemo();
                }
                else if(selection == 6)
                {
                    RunDQLDemo();
                }
                else if(selection == 7)
                {
                    return;
                }
            }
        }

        public int GetSelectedOption()
        {
            Console.WriteLine("1. System Info");
            Console.WriteLine("2. List Repositories");
            Console.WriteLine("3. Authenticate");
            Console.WriteLine("4. Current Repo");
            Console.WriteLine("5. Cabinets Demo");
            Console.WriteLine("6. DQL Demo");
            Console.WriteLine("7. Exit");

            while (true)
            {
                Console.Write("Please select a option: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int selection))
                {
                    if (selection < 8) return selection;
                }

                Console.WriteLine("Not a valid option");
            }
        }

        #region Demos
        public void RunCabinetDemo()
        {
            PrintHeader("Cabinets");
            var cabinets = _service.GetCabinets();
            foreach (var cabinet in cabinets.Entries)
            {
                Console.WriteLine("Name: {0}", cabinet.Title);
                Console.WriteLine("Properties:");
                foreach (var prop in cabinet.Content.Properties)
                {
                    Console.WriteLine("{0}: {1}", prop.Key, prop.Value);
                }
                Console.WriteLine();
            }
        }

        public void RunDQLDemo()
        {
            try
            {
                PrintHeader("DQL Demo");
                var query = new QueryBuilder()
                    .Select(Properities.ObjectId, Properities.ObjectName, Properities.ObjectType, Properities.ThumbnailUrl)
                    .From(Tables.SysObject)
                    .Build();
                Console.WriteLine("Query: {0}", query);
                var result = _service.QueryDQL(query);
                foreach (var entry in result.Entries)
                {
                    Console.WriteLine("ID: {0}", entry.Title);
                    Console.WriteLine("Properties:");
                    foreach (var property in entry.Content.Properties)
                    {
                        Console.WriteLine("{0} = {1}", property.Key, property.Value);
                    }
                    Console.WriteLine();
                }
                PrintFooter();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to execute dql query");
            }
        }

        public void RunGetRepoDemo()
        {
            try
            {
                PrintHeader(" Getting current repo ");
                var repo = _service.GetCurrentRepository();
                Console.WriteLine("Id: {0}", repo.Id);
                Console.WriteLine("Name: {0}", repo.Name);
                Console.WriteLine("Servers:");
                foreach (var server in repo.Servers)
                {
                    Console.WriteLine();
                    Console.WriteLine("Name: {0}", server.Name);
                    Console.WriteLine("Host: {0}", server.Host);
                    Console.WriteLine("DocBroker: {0}", server.Docbroker);
                    Console.WriteLine("Version: {0}", server.Version);
                }
                PrintFooter();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to authorize");
            }
        }

        public void RunAuthorizationDemo()
        {
            try
            {
                PrintHeader(" Authenticating for MyRepo... ");
                _service.Authorize(_serviceUrl, "dmadmin", "password", "MyRepo");
                Console.WriteLine("Authentication successfull");
                PrintFooter();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to authorize");
            }
        }

        public void RunSystemInfoDemo()
        {
            try
            {
                PrintHeader("System Info");
                var info = _service.GetSystemInfo(_serviceUrl);
                Console.WriteLine("Name: {0}", info.Properties.Product);
                Console.WriteLine("Version: {0}", info.Properties.ProductVersion);
                PrintFooter();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to get system info");
            }
        }

        public void RunGetRepositoriesDemo()
        {
            try
            {
                var repos = _service.GetRepositories(_serviceUrl);
                PrintHeader("List of repositories");
                foreach (var repo in repos)
                {
                    Console.WriteLine();
                    Console.WriteLine("Name: {0}", repo.Title);
                    Console.WriteLine("Id: {0}", repo.Id);
                }
                PrintFooter();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to get system info");
            }
        }
        #endregion

        #region Helpers
        private void PrintHeader(string header)
        {
            Console.WriteLine();
            Console.Write(new string('-', 15));
            Console.Write(header);
            Console.WriteLine(new string('-', 15));
        }

        private void PrintFooter()
        {
            Console.WriteLine(new string('-', 50));
        }
        #endregion
    }
}
