using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lottery
{
    class Winning
    {
        public string WinningType { get; set; }
        public int Amount { get; set; }

        public Winning() { }

        public Winning(string winningType, int amount)
        {
            WinningType = winningType;
            Amount = amount;
        }

        public Winning(List<int> hitNumbers)
        {
            switch (hitNumbers.Count)
            {
                case (int)HitNumbersEnum.HITS3:
                    WinningType = Enum.GetName(typeof(HitNumbersEnum), 3);
                    Amount = 60;
                    break;
                case (int)HitNumbersEnum.HITS4:
                    WinningType = Enum.GetName(typeof(HitNumbersEnum), 4);
                    Amount = 600;
                    break;
                case (int)HitNumbersEnum.HITS5:
                    WinningType = Enum.GetName(typeof(HitNumbersEnum), 5);
                    Amount = 6000;
                    break;
                case (int)HitNumbersEnum.HITS6:
                    WinningType = Enum.GetName(typeof(HitNumbersEnum), 6);
                    Amount = 300000;
                    break;
                case (int)HitNumbersEnum.HITS7:
                    WinningType = Enum.GetName(typeof(HitNumbersEnum), 7);
                    Amount = 5000000;
                    break;
                default:
                    WriteLine("No winnings.");
                    break;
            }
        }

        public void PrintWinning()
        {
            WriteLine($"{WinningType} - {Amount}");
        }
    }

    enum HitNumbersEnum
    {
        HITS3 = 3,
        HITS4,
        HITS5,
        HITS6,
        HITS7
    }
}
