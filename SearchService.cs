using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sport
{
    public class SearchService
    {
        private const int COUNT_IN_PAGE = 3;
        private readonly Context context;

        public SearchService(Context context)
        {
            this.context = context;
        }

        public void ShowAllPlayers()
        {
            var pageNumber = 1;
            var isExit = false;
            var players = context.Players.ToList();
            if (players.Count == 0)
            {
                Console.WriteLine("Игроков нет!");
                return;
            }
            ShowOnePage(players);
            while (!isExit)
            {
                Console.Write("Введите номер страницы или цифру -1 для выхода: ");
                if (int.TryParse(Console.ReadLine(), out pageNumber) && GetPageCount(players) >= pageNumber && pageNumber > 0)
                {

                    ShowOnePage(players, pageNumber);
                }
                else if (pageNumber == -1)
                {
                    isExit = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }

        private void ShowOnePage(List<Player> players, int pageNumber = 1)
        {
            var onePagePlayers = players.Skip(COUNT_IN_PAGE * --pageNumber).Take(COUNT_IN_PAGE).ToList();
            Console.Clear();
            onePagePlayers.ForEach(x => Console.WriteLine($"Name: {x.FullName}\nTeam: {x.Team.Name}\n"));
            ShowPages(players, ++pageNumber);
        }

        private void ShowPages(List<Player> players, int pageNumber = 1)
        {
            Console.WriteLine($" {pageNumber} | {GetPageCount(players)}");
        }

        private int GetPageCount(List<Player> players)
        {
            return (int)Math.Ceiling(players.Count / (double)COUNT_IN_PAGE);
        }
    }
}
