namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const string CONTINUE_PLAY = "yes";
        const int NO_MONEY = 0;
        const int GRIDROWS = 3;
        const int GRIDCOLUMNS = 3;
        const int THIRDROW = 2;
        const int LOOP_START = 0;
        const int LOOPEND = 3;
        const int GRIDSTART = 1;
        const int GRIDEND = 4;
        const int WIN_MATCHES = 2;
        const int ONE_WIN = 1;

        Console.WriteLine("Hello, Welcome let us play the game Slot Machine!");
        Console.WriteLine("You will be rewarded the same amount of the money that you will wage");
        Console.WriteLine("The game will automatically end once you are left with no money");
        //The starting money
        int money = 10;

        Random random = new Random();
        // 3 x 3 grid for the slot machine
        int[,] grid = new int[GRIDCOLUMNS, GRIDROWS];
        // creating an infinite loop to only to be stoped after the user types exit
        while (true)
        {
            Console.WriteLine($"\nYou have {money} as the amount of money) how much would you like to wager? type amount and press enter");
            int wager = Convert.ToInt32(Console.ReadLine());
            if (wager > money)
            {
                Console.WriteLine("You dont have enough money to wager");
                continue;
            }
            //deducting money from the wager
            money = money - wager; //(I could also use money-=wager)

            //filling the grid with random numbers

            for (int outerloop = LOOP_START; outerloop < LOOPEND; outerloop++)
            {
                for (int innerloop = LOOP_START; innerloop < LOOPEND; innerloop++)
                {
                    //getting random numbers between 1,4
                    grid[outerloop, innerloop] = random.Next(GRIDSTART, GRIDEND);
                }
            }
            //Outputting the grid
            Console.WriteLine("Slot Machine Grid");
            for (int outerloop = LOOP_START; outerloop < LOOPEND; outerloop++)
            {
                for (int innerloop = LOOP_START; innerloop < LOOPEND; innerloop++)
                {
                    Console.Write(grid[outerloop, innerloop] + " ");
                }
                Console.WriteLine();
            }
            //checking if the horinzontal and Vertical are all the same
            int firstValue = 0;
            bool match = false;
            int secondvalue = 1;
            int win = 0;
            int won = 0;
            int horizontalWin = 0;
            int verticalWon = 0;
            for (int outerloop = LOOP_START; outerloop < LOOPEND; outerloop++)
            {
                int horizontalValue = grid[outerloop, firstValue];
                int verticalValue = grid[firstValue, outerloop];

                for (int innerloop = secondvalue; innerloop < LOOPEND; innerloop++)
                {
                    if (grid[outerloop, innerloop] == horizontalValue)
                    {
                        win = ONE_WIN;
                    }

                    if (grid[innerloop, outerloop] == verticalValue)
                    {
                        won = ONE_WIN; 
                    }
                    horizontalWin = horizontalWin+ win;
                    verticalWon = verticalWon + won;

                    if (horizontalWin == WIN_MATCHES)
                    {
                        match = true;
                        Console.WriteLine($"Conglatulation you won by matching {horizontalValue} at row {outerloop++}");
                        //adding wager amount to the total money
                        money = money + wager;
                    }

                    if (verticalWon == WIN_MATCHES)
                    {
                        match = true;
                        Console.WriteLine($"Conglatulation you won by matching {verticalValue} at colomn {outerloop++}");
                        //adding wager amount to the total money
                        money = money + wager;
                    }
                }

            }


            int diagnalLeftRight = grid[LOOP_START, LOOP_START];
            int firstdiagnalMatch = 0;
            int diagnalRightLeft = grid[LOOP_START, THIRDROW];
            int seconddiagnalMatch = 0;
            int thirddiagnalMatch = 0;
            for (int outerloop = secondvalue; outerloop < THIRDROW; outerloop++)
            {
                if (grid[secondvalue, secondvalue] == diagnalLeftRight)
                {
                    firstdiagnalMatch=ONE_WIN;
                }

                if (grid[THIRDROW - secondvalue, THIRDROW] == diagnalRightLeft)
                {
                    seconddiagnalMatch = ONE_WIN; 
                }

                if (grid[THIRDROW, LOOP_START] == diagnalRightLeft)
                {
                    thirddiagnalMatch = ONE_WIN;
                }
                int completeMatchLeftRight = firstdiagnalMatch + seconddiagnalMatch;
                int completeMatchRightLeft = firstdiagnalMatch + thirddiagnalMatch;


                if (completeMatchLeftRight == WIN_MATCHES)
                {
                    match = true;
                    Console.WriteLine($"Conglatulations yu won in the left right diagnal by having same numbers of {diagnalLeftRight}");
                    //adding wager amount to the total money
                    money = money + wager;
                }

                if (completeMatchRightLeft == WIN_MATCHES)
                {
                    match = true;
                    Console.WriteLine($"Conglatulations yu won in the right left diagnal by having same numbers of {diagnalRightLeft}");
                    //adding wager amount to the total money
                    money = money + wager;
                }
            }

            if (!match)
            {
                Console.WriteLine("Sorry, you didnt win anything");
            }

            //informing the total amount of money
            Console.WriteLine($"Currently, your total money is {money}");

            //quitting the game if the money is o
            if (money <= NO_MONEY)
            {
                break;
            }

            //asking if the user wants to play more
            Console.WriteLine("Do you want to play again?");
            Console.WriteLine("Please type yes if you want to play and no if you dont want to play");
            string userchoice = Console.ReadLine();
            if (userchoice.ToLower() == CONTINUE_PLAY)
            {
                Console.Write("Alright, lets keep going");
            }
            //exiting the loop game if the answer is not yes
            else
            {
                break;
            }

        }
        Console.WriteLine("Thank you so much for playing");
    }
}

