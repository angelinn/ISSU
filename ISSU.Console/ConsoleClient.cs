using System.Linq;
using System.Data.Entity;

using ISSU.Data;
using ISSU.Models;
using ISSU.Data.Migrations;
using System.Net;

namespace ISSU.Console
{
    public class ConsoleClient
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ISSUContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ISSUContext, Configuration>());

            string result = SUSIConnecter.Login("abnedelche", "78765290");
            if (result == HttpStatusCode.BadRequest.ToString())
            {
                System.Console.WriteLine("okay");   
            }

            System.Console.WriteLine(result);
        }
    }
}
