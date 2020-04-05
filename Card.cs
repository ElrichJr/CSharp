using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public enum RankE { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    struct Card
    {
        public RankE Rank { get; set; }
        public char Suit { get; set; }
        public int Value { get; set; }
        public int Owner { get; set; }
    }
}
