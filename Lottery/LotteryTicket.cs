using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Lottery
{
    class LotteryTicket
    {
        public string LotteryTicketNumber { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public List<int> MyLotteryNumbers { get; set; }
        public Person Payer { get; set; }
        
        public LotteryTicket() { }

        public LotteryTicket(string lotteryTicketNumber, string place, DateTime date, Person payer, Random rnd)
        {
            LotteryTicketNumber = lotteryTicketNumber;
            Place = place;
            Date = date;
            MyLotteryNumbers = GenerateCombination(rnd);
            Payer = payer;
        }

        public LotteryTicket(string lotteryTicketNumber, string place, List<int> myLotteryNumbers, DateTime date, Person payer)
        {
            LotteryTicketNumber = lotteryTicketNumber;
            Place = place;
            Date = date;
            MyLotteryNumbers = myLotteryNumbers;
            Payer = payer;
        }

        private List<int> GenerateCombination(Random rnd)
        {
            //Thread.Sleep(50);
            List<int> lotteryNumbers = new List<int>();

            do
            {
                int number = rnd.Next(1, 39);
                if (!lotteryNumbers.Contains(number))
                {
                    lotteryNumbers.Add(number);
                }
            } while (lotteryNumbers.Count < 7);

            return lotteryNumbers;
        }

        private string PrintCombination(List<int> myLotteryNumbers)
        {
            string str = "[";
            foreach(int number in myLotteryNumbers)
            {
                str += $"{number} "; 
            }
            str += "]";
            return str;
        }

        public List<int> CheckNumbers(List<int> lotteryNumbers)
        {
            List<int> sameNumbers = new List<int>();

            foreach(int number in MyLotteryNumbers)
            {
                if (lotteryNumbers.Contains(number))
                {
                    sameNumbers.Add(number);
                }
            }
            return sameNumbers;
        }

        public void PrintLotteryTicket()
        {
            WriteLine ($"{LotteryTicketNumber}, {Place}, {Date}, {PrintCombination(MyLotteryNumbers)}, {Payer.ToString()}");
        }
    }
}
