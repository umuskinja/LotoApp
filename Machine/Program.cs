using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.ServiceReference;
using System.Threading;
using Library;

namespace Machine
{
    class Program
    {
        static LotoServiceClient LotoClient = new LotoServiceClient();

        static void Main(string[] args)
        {

            while (true)
            {
                var numbers = GenerateNumbers(2);
                LotoClient.Start(numbers);
                Thread.Sleep(60 * 1000);
            }
        }

        private static int[] GenerateNumbers(int size)
        {
            var numbers = new int[size];
            numbers[0] = Generator.GenerateRandom(10);

            while (true)
            {
                numbers[1] = Generator.GenerateRandom(10);
                if (numbers[1] != numbers[0]) { return numbers; }
            }
        }
    }
}
