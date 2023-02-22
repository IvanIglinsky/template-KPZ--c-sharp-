using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
   public class Program
    {  
        static int player = 1;
        static string[] arr= new string[10];
        static string[] XO = new string[2];
        static int[] result=new int[3];
        static int choice;
        static int flag = 0;

        static string[] Arr { get => arr; set => arr = value; }

        static  void Main(string[] args)
        {
            
            for (int i = 1; i < 10; i++)
            {
                Arr[i] = i.ToString();
            }
            if (result[1] + result[2] == 0)
            {
                XO[0] = "X";
                XO[1] = "O";
            }
            string GoEnd = "y";
            do
            {
                
                do
                {
                    Console.Clear();
                    Console.WriteLine("Let`s play Tic Tac Toe!");
                    Console.WriteLine("Player 1:{2}  [{0}]\nPlayer 2:{3}  [{1}]", result[1], result[2], XO[0], XO[1]);
                    Console.WriteLine("\n");
                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Player 2 turn");
                    }
                    else
                    {
                        Console.WriteLine("Player 1 turn");
                    }
                    Console.WriteLine("\n");
                    Board();
                    choice = Int32.Parse(Console.ReadLine());
                    if (choice >= 10 || choice <= 0)
                    {
                        Console.WriteLine("Please enter a valid number between 1 and 9");
                        Console.WriteLine("\n");
                        Console.WriteLine("Wait 2 seconds, board refresh.....");
                        Thread.Sleep(2000);
                    }

                    else
                    {

                        if (Arr[choice] != "X" && Arr[choice] != "O")
                        {
                            if (player % 2 == 0)
                            {
                                Arr[choice] = "O";
                                player++;
                            }
                            else
                            {
                                Arr[choice] = "X";
                                player++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cell \"{0}\" is already set \"{1}\"", choice, Arr[choice]);

                            Console.WriteLine("\n");
                            Console.WriteLine("Wait 2 seconds, board refresh..........");
                            Thread.Sleep(2000);
                        }
                        flag = CheckWin();
                    }
                }
                while (flag != 1 && flag != -1);
                Console.Clear();
                Board();
                if (flag == 1)
                {
                    Console.WriteLine("Player {0} win", (player % 2) + 1);
                    result[(player % 2) + 1]++;
                    Console.WriteLine("Do you want to play again? (y/n)");
                    GoEnd = Console.ReadLine();
                    for (int i = 1; i < 10; i++)
                    {
                        Arr[i] = i.ToString();
                    }
                    if (result[1] + result[2] % 2 == 0)
                    {
                        XO[0] = "X";
                        XO[1] = "O";
                       
                    }
                    else
                    {
                        XO[0] = "O";
                        XO[1] = "X";
                       
                    }
                }
                else
                {
                    Console.WriteLine("Draw");
                    Console.WriteLine("Do you want to play again? (y/n)");
                    GoEnd = Console.ReadLine();
                    for (int i = 1; i < 10; i++)
                    {
                        Arr[i] = i.ToString();
                    }
                }
              
            }
            while (GoEnd != "n");
            if (GoEnd == "n")
            {
                Console.WriteLine("End!");
                Environment.Exit(0);
            }

        }
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Arr[1], Arr[2], Arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Arr[4], Arr[5], Arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Arr[7], Arr[8], Arr[9]);
            Console.WriteLine("     |     |      ");
        }
        private static int CheckWin()
        {

            if (Arr[1] == Arr[2] && Arr[2] == Arr[3])
            {
                return 1;
            }

            else if (Arr[4] == Arr[5] && Arr[5] == Arr[6])
            {
                return 1;
            }

            else if (Arr[7] == Arr[7] && Arr[7] == Arr[9])
            {
                return 1;
            }


            else if (Arr[1] == Arr[4] && Arr[4] == Arr[7])
            {
                return 1;
            }

            else if (Arr[2] == Arr[5] && Arr[5] == Arr[8])
            {
                return 1;
            }

            else if (Arr[3] == Arr[6] && Arr[6] == Arr[9])
            {
                return 1;
            }

            else if (Arr[1] == Arr[5] && Arr[5] == Arr[9])
            {
                return 1;
            }
            else if (Arr[3] == Arr[5] && Arr[5] == Arr[7])
            {
                return 1;
            }


            else if (Arr[1] != "1" && Arr[2] != "2" && Arr[3] != "3" && Arr[4] != "4" && Arr[5] != "5" && Arr[6] != "6" && Arr[7] != "5" && Arr[8] != "6" && Arr[9] != "5")
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}