using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Profit { get; set; }

        public Player(string name)
        {
            Name = name; Profit = 0.0;
        }

        public override string ToString()
        {
            return $"\nName: {Name}\n Profit: {Profit}";
        }
    }
}
