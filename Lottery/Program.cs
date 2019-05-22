using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n\tLOTTERY");
            ResetColor();

            List<LotteryTicket> lotteryTickets = new List<LotteryTicket>();
            string option;

            try
            {
                do
                {
                    WriteLine("\n===============================================");
                    WriteLine("Select an option:");
                    WriteLine("1. Create a ticket \n2. Start lottery");
                    option = ReadLine();
                    WriteLine("\n===============================================");
                    if (option == "1")
                    {
                        WriteLine("How many tickets you want?");
                        int ticketNumber;
                        while(!int.TryParse(ReadLine(), out ticketNumber))
                        {
                            WriteLine("Wrong entry! Please try again.");
                        }

                        WriteLine("\nDo you want to generate numbers or enter yourself? \n1 - Generate Numbers \n2 - Enter Combination");
                        int answer;
                        while (!int.TryParse(ReadLine(), out answer))
                        {
                            WriteLine("Wrong entry! Please try again.");
                        }

                        WriteLine("\n===============================================");
                        if (answer == 1)
                        {
                            WriteLine("Enter place?");
                            string location = ReadLine();
                            WriteLine("Enter name?");
                            string name = ReadLine();
                            WriteLine("Enter last name?");
                            string lastName = ReadLine();
                            WriteLine("Enter phone?");
                            string phone = ReadLine();
                            WriteLine("\n===============================================");

                            Person p = new Person(name, lastName, phone);

                            for (int i = 0; i < ticketNumber; i++)
                            {
                                int serialNumber = rnd.Next(100, 999);
                                LotteryTicket lt = new LotteryTicket($"TIK-{serialNumber}", location, DateTime.Now, p, rnd);
                                lotteryTickets.Add(lt);
                            }
                        }
                        else if (answer == 2)
                        {
                            WriteLine("Enter place?");
                            string location = ReadLine();
                            WriteLine("Enter name?");
                            string name = ReadLine();
                            WriteLine("Enter last name?");
                            string lastName = ReadLine();
                            WriteLine("Enter phone?");
                            string phone = ReadLine();
                            WriteLine("\n===============================================");

                            Person p = new Person(name, lastName, phone);

                            for (int i = 0; i < ticketNumber; i++)
                            {
                                List<int> myCombination = new List<int>();
                                WriteLine($"Enter numbers for {i + 1} combination: ");

                                do
                                {
                                    int myNumber;
                                    while (!int.TryParse(ReadLine(), out myNumber))
                                    {
                                        WriteLine("Wrong entry! Please try again.");
                                    }

                                    if (myNumber > 39 || myNumber <= 0)
                                    {
                                        WriteLine("Enter numbers 1-39. Please enter again.");
                                    }

                                    if (!myCombination.Contains(myNumber))
                                    {
                                        myCombination.Add(myNumber);
                                    }
                                    else
                                    {
                                        WriteLine("Number already exists, enter another");
                                    }

                                } while (myCombination.Count < 7);
                                
                                int serialNumber = rnd.Next(100, 999);
                                LotteryTicket lt = new LotteryTicket($"TIK-{serialNumber}", location, myCombination, DateTime.Now, p);
                                lotteryTickets.Add(lt);
                            }
                        }
                        else
                        {
                            WriteLine("Wrong entry!");
                        }

                        foreach (LotteryTicket lt in lotteryTickets)
                        {
                            ForegroundColor = ConsoleColor.Blue;
                            lt.PrintLotteryTicket();
                            ResetColor();
                        }
                    }
                }while (option != "2") ;

                WriteLine("\n===============================================\n");
                WriteLine("Lottery numbers are:");
                //Thread.Sleep(50);
                List<int> numbers = LotteryNumbers(rnd);

                WriteLine("\n===============================================");
                foreach (LotteryTicket lt in lotteryTickets)
                {
                    List<int> sameNumbers = lt.CheckNumbers(numbers);

                    if (sameNumbers.Count < 3)
                    {
                        WriteLine("No winnings {0}", lt.LotteryTicketNumber);
                    }
                    else if (sameNumbers.Count >= 3)
                    {
                        WriteLine("Same numbers for the ticket {0}: {1} is same numbers.",
                            lt.LotteryTicketNumber, sameNumbers.Count);
                        Winning w = new Winning(sameNumbers);
                        w.PrintWinning();
                    }
                }
                WriteLine("\n===============================================");
            }
            catch(Exception e)
            {
                WriteLine(e);
            }

            ReadKey();
        }
        
        public static List<int> LotteryNumbers(Random rnd)
        {
            List<int> lotteryNumbers = new List<int>();
            int number;

            do
            {
                number = rnd.Next(1, 39);
                if (!lotteryNumbers.Contains(number))
                {
                    lotteryNumbers.Add(number);
                    ForegroundColor = ConsoleColor.Red;
                    Write($"{number} ");
                    ResetColor();
                }
            } while (lotteryNumbers.Count < 7);

            return lotteryNumbers;
        }
    }
}
