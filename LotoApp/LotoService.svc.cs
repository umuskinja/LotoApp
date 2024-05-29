using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Library;

namespace LotoApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LotoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LotoService.svc or LotoService.svc.cs at the Solution Explorer and start debugging.
    public class LotoService : ILotoService, IPlayer
    {
        delegate void MessageRecievedDelegate(string message);

        static Dictionary<string, Player> players = new Dictionary<string, Player>();
        static Dictionary<string, Ticket> tickets = new Dictionary<string, Ticket>();
        static Dictionary<string, MessageRecievedDelegate> notifiers = new Dictionary<string, MessageRecievedDelegate>();

        static bool firstRound = true;

        public void NewTicket(string name, Ticket ticket)
        {
            if (!players.ContainsKey(name))
            {
                RegisterNewPlayer(name, ticket);
            }
            else if (!tickets.ContainsKey(name))
            {
                RegisterNewTicket(name, ticket);
            }
            else
            {
                SendWarning(name, "\nTicket already exists in this round.");
            }
        }

        private void RegisterNewPlayer(string name, Ticket ticket)
        {
            players[name] = new Player(name);
            tickets[name] = ticket;

            var callback = OperationContext.Current?.GetCallbackChannel<ICallBack>();
            if (callback != null)
            {
                notifiers[name] = callback.MessageRecieved;
                SendMessage(notifiers[name], $"\nUser and ticket registered! \n\t{players[name]} \n\t{ticket}");
            }
            else
            {
                // Handle the case where the callback is null
                Console.WriteLine("\nCallback channel is null.");
            }
        }

        private void RegisterNewTicket(string name, Ticket ticket)
        {
            tickets[name] = ticket;
            SendMessage(notifiers[name], $"\nTicket registered! \n\t{ticket}");
        }

        private void SendWarning(string name, string message)
        {
            if (notifiers.ContainsKey(name))
            {
                SendMessage(notifiers[name], message);
            }
            else
            {
                // Handle the case where the notifier does not exist
                Console.WriteLine($"\nNotifier for {name} does not exist.");
            }
        }

        private void SendMessage(MessageRecievedDelegate notifier, string message)
        {
            notifier?.Invoke(message);
        }

        private void BroadcastMessage(string message)
        {
            foreach (var notifier in notifiers.Values)
            {
                notifier?.Invoke(message);
            }
        }


        public void Start(int[] numbers)
        {
            if (firstRound)
            {
                BroadcastMessage($"\n=== LOTO, Who plays, wins... ===\n");
                firstRound = false;
                return;
            }

            if (numbers == null || numbers.Length != 2)
            {
                throw new ArgumentException("\nTwo numbers must be provided.");
            }

            BroadcastMessage($"\nDrawn numbers: {numbers[0]} and {numbers[1]}");

            var rankings = RankPlayers();
            foreach (var ticketEntry in tickets)
            {
                string playerName = ticketEntry.Key;
                Ticket ticket = ticketEntry.Value;

                int matches = Compare(numbers, ticket.Numbers);
                Player player = players[playerName];
                player.Profit += CalculateEarnings(matches, ticket.Deposit);

                int rankingPosition = rankings.Values.ToList().IndexOf(player) + 1;

                SendMessage(notifiers[playerName],
                    $"\tRanking: {rankingPosition}, Matches: {matches}, Profit: {player.Profit}");
            }

            BroadcastMessage($"\n===== LOTO =====\n");
            BroadcastMessage($"---------TABLE---------\n{GetScoreTable()}");
            tickets.Clear();
        }

        private int Compare(int[] bingo, int[] ticket)
        {
            return bingo.Count(value => ticket.Contains(value));
        }

        private double CalculateEarnings(int match, double deposit)
        {
            var prizeMultipliers = new Dictionary<int, double>
            {
                { 0, -1 },
                { 1, 1 },
                { 2, 5 }
            };

            return deposit * (prizeMultipliers.ContainsKey(match) ? prizeMultipliers[match] : 0);
        }

        private Dictionary<string, Player> RankPlayers()
        {
            return players
                .OrderByDescending(kvp => kvp.Value.Profit)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        private string GetScoreTable()
        {
            var table = new StringBuilder();
            var rankedPlayers = RankPlayers().Values.ToList();

            for (int i = 0; i < rankedPlayers.Count; i++)
            {
                table.AppendLine($"\t{i + 1}. {rankedPlayers[i]}");
            }

            return table.ToString();
        }
    }
}
