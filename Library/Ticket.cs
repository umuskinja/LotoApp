using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [DataContract]
    public class Ticket
    {
        [DataMember]
        public int[] Numbers { get; set; }

        [DataMember]
        public double Deposit { get; set; }

        public Ticket(int[] numbers, double deposit)
        {
            Numbers = numbers;
            Deposit = deposit;
        }

        public override string ToString()
        {
            return $"\nNumbers: {Numbers[0]}, {Numbers[1]}\n Deposit: {Deposit}";
        }
    }
}
