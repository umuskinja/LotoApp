using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player.ServiceReference;
using System.Threading;
using System.ServiceModel;
using Library;

namespace Player
{
    public class Callback : IPlayerCallback
    {
        public void MessageRecieved(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Program
    {
        static string ReadName()
        {
            Console.Write("Username: ");
            return Console.ReadLine();
        }

        public static int[] ReadNumbers()
        {
            int[] numbers = new int[2];
            int count = 0;

            Console.WriteLine("\nEnter your 2-number combination (numbers must be between 1 and 10 and not the same).");

            while (count < 2)
            {
                Console.Write($"\nEnter number {count + 1}: ");
                string input = Console.ReadLine();
                try
                {
                    int number = int.Parse(input);

                    if (number >= 1 && number <= 10)
                    {
                        if (count == 1 && number == numbers[0])
                        {
                            Console.WriteLine("\nNumbers can't be the same!");
                        }
                        else
                        {
                            numbers[count] = number;
                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNumbers must be from 1 to 10!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease input integer values! ");
                }
            }

            return numbers;
        }

        public static double ReadDeposit()
        {
            double deposit = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter the deposit amount: ");
                string input = Console.ReadLine();
                try
                {
                    deposit = double.Parse(input);

                    if (deposit > 0)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("\nThe deposit has to be a positive value!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease enter a valid number.");
                }

            }

            return deposit;
        }

        static PlayerClient playerClient;

        static void Main(string[] args)
        {
            InstanceContext ic = new InstanceContext(new Callback());
            playerClient = new PlayerClient(ic);

            string name = ReadName();
            bool continuePlaying = true;

            do
            {
                PlayRound(name);

                // Wait for 10 seconds before the next round
                Thread.Sleep(10 * 1000);
                Console.ReadKey();

            } while (continuePlaying);
        }

        static void PlayRound(string name)
        {
            var numbers = ReadNumbers();
            var deposit = ReadDeposit();

            playerClient.NewTicket(name, new Ticket(numbers, deposit));
        }
    }
}
