using System;

namespace Sport
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=A-305-07;Database=SportTeam;Trusted_Connection=true;";
            using(var context = new Context(connectionString))
            {
                var searchService = new SearchService(context);
                searchService.ShowAllPlayers();
            }
        }
    }
}
