using System;
using System.Collections.Generic;
using System.Drawing;

namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const string CONTINUE_PLAY = "yes";
        const int NO_MONEY_LEFT = 0;
        const int GRID_ROWS = 3;
        const int GRID_COLUMNS = 3;
        const int LOOP_START = 0;
        const int LOOP_END = 3;
        const int GRID_START = 1;
        const int GRID_END = 4;
        const int FIRST_GRID_VALUE = 0;
        const int SECOND_GRID_VALUE = 1;
        const int WIN = 3;
        const int MIDDLE_LINE = 1;
        const int ALL_HORIZONTALS = 2;
        const int ALL_VERTICALS = 3;
        const int BOTH_DIAGNALS = 4;
        const int EVERYTHING_ON_THE_GRID = 5;
        bool isWin = false;



        Console.WriteLine("Hello, Welcome let us play the game Slot Machine!");
        Console.WriteLine("You will be rewarded the same amount of the money that you will wage");
        Console.WriteLine("The game will automatically end once you are left with no money");
        //The starting money
        int money = 10;

        Random random = new Random();
        // 3 x 3 grid for the slot machine
        int[,] grid = new int[GRID_COLUMNS, GRID_ROWS];
        // creating an infinite loop to only to be stoped after the user types exit
        while (true)
        {
            //giving the user an option to choose what to play
            Console.WriteLine("Choose where do you want to play");
            Console.WriteLine($"Press {MIDDLE_LINE}  for the middle line, {ALL_HORIZONTALS} for all horizontals,  {ALL_VERTICALS} for all verticals,  {BOTH_DIAGNALS} for both diagnals,  and  {EVERYTHING_ON_THE_GRID} for everything in the grid");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nYou have {money} as the amount of money, how much would you like to wager? type amount and press enter");
            int wager = Convert.ToInt32(Console.ReadLine());
            if (wager > money)
            {
                Console.WriteLine("You dont have enough money to wager");
                continue;
            }
            //deducting money from the wager
            money -= wager; //(I could also use money-=wager)

            //filling the grid with random numbers
            int outerloop = 0;
            for (outerloop = LOOP_START; outerloop < LOOP_END; outerloop++)
            {
                for (int insideloop = LOOP_START; insideloop < LOOP_END; insideloop++)
                {
                    //getting random numbers between 1,4
                    grid[outerloop, insideloop] = random.Next(GRID_START, GRID_END);
                }
            }
            //Outputting the grid
            Console.WriteLine("Slot Machine Grid");

            for (outerloop = LOOP_START; outerloop < LOOP_END; outerloop++)
            {
                for (int inside = LOOP_START; inside < LOOP_END; inside++)
                {
                    Console.Write(grid[outerloop, inside] + " ");
                }
                Console.WriteLine();
            }
            //checking if the middle line and horinzontal are all the same
            int firstGridElement = grid.GetLength(0);
            int gridColumnLenghth = grid.GetLength(1);

            int holizontalLineWin = 0;
            for (outerloop = FIRST_GRID_VALUE; outerloop < firstGridElement; outerloop++)
            {
                int holizontalMatch = 0;
                int horizontalValue = grid[outerloop, FIRST_GRID_VALUE];

                for (int innerloop = SECOND_GRID_VALUE; innerloop < gridColumnLenghth; innerloop++)
                {
                    if (horizontalValue == grid[outerloop, innerloop])

                    {
                        holizontalMatch++;
                    }

                }

                if (holizontalMatch == WIN)

                {
                    isWin = true;
                    holizontalLineWin++;
                }

            }

            if (choice == MIDDLE_LINE)
            {
                if (outerloop == MIDDLE_LINE && isWin)
                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }
                else
                {
                    Console.WriteLine("Sorry you did not win");
                }
            }

            if (choice == ALL_HORIZONTALS)
            {
                if (holizontalLineWin == WIN)

                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }

                else
                {
                    Console.WriteLine("Sorry you did not win");
                }

            }

            //checking if the Vertical are all the same
            int verticalLineWin = 0;

            for (outerloop = FIRST_GRID_VALUE; outerloop < firstGridElement; outerloop++)
            {
                int verticalMatch = 0;
                int verticalValue = grid[FIRST_GRID_VALUE, outerloop];

                for (int innerloop = SECOND_GRID_VALUE; innerloop < gridColumnLenghth; innerloop++)
                {
                    if (verticalValue == grid[innerloop, outerloop])

                    {
                        verticalMatch++;
                    }

                }

                if (verticalMatch == WIN)

                {
                    isWin = true;
                    verticalLineWin++;
                }

            }


            if (choice == ALL_VERTICALS)
            {
                if (verticalLineWin == WIN)
                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }

                else
                {
                    Console.WriteLine("Sorry you did not win");
                }
            }



            if (choice == EVERYTHING_ON_THE_GRID)
            {
                if (verticalLineWin == WIN && holizontalLineWin == WIN)
                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }

                else
                {
                    Console.WriteLine("Sorry you did not win");
                }

            }


            //checking if the diagnal are all the same
            int diagnolValues = grid[FIRST_GRID_VALUE, FIRST_GRID_VALUE];
            int secondDiagnalMatch = 0;
            int diagnolaMatch = 0;
            int actualGridRowLenght = firstGridElement - 1;
            int secondDiagnalValues = grid[FIRST_GRID_VALUE, firstGridElement - GRID_START];
            for (outerloop = FIRST_GRID_VALUE; outerloop < firstGridElement; outerloop++)
            {
                for (int innerloop = SECOND_GRID_VALUE; innerloop < gridColumnLenghth; innerloop++)
                {
                    if (diagnolValues == grid[innerloop, innerloop])
                    {
                        diagnolaMatch++;
                    }
                    if (diagnolaMatch == WIN)
                    {
                        isWin = true;
                    }

                    if (secondDiagnalValues == grid[outerloop, actualGridRowLenght - outerloop])
                    {
                        secondDiagnalMatch++;
                    }
                    if (secondDiagnalMatch == WIN)
                    {
                        isWin = true;
                    }

                }

            }
            if (choice == BOTH_DIAGNALS)
            {
                if (diagnolaMatch == WIN && secondDiagnalMatch == WIN)
                {
                    Console.WriteLine($"Conglatulation you won");
                    //adding wager amount to the total money
                    money = money + wager;
                }
                else
                {
                    Console.WriteLine("Sorry you did not win");
                }
            }




            //informing the total amount of money
            Console.WriteLine($"Currently, your total money is {money}");

            //quitting the game if the money is o
            if (money <= NO_MONEY_LEFT)
            {
                Console.Write("Your money now is 0, the game ends here");
                break;
            }
            //asking if the user wants to play more
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("Please type yes if you want to play and no if you dont want to play");
            string userchoice = Console.ReadLine();
            if (userchoice.ToLower() == CONTINUE_PLAY)
            {
                Console.WriteLine("Alright, lets keep going");
            }
            //exiting the loop game if the answer is not yes
            else
            {
                Console.Write("The game ends here");
                Console.WriteLine("Thank you so much for playing");
                break;
            }
        }
    }
}