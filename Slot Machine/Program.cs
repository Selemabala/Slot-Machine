namespace Slot_Machine;

class Program
{
    static void Main(string[] args)
    {
        const string CONTINUE_PLAY = "yes";
        const int NO_MONEY = 0;
        const int GRIDROWS = 3;
        const int GRIDCOLUMNS = 3;
        const int LOOP_START = 0;
        const int LOOPEND = 3;
        const int GRIDSTART = 1;
        const int GRIDEND = 4;
        const int FIRSTVALUE = 0;
        const int SECOND_VALUE = 1;
        const int PARTIAL_WIN = 1;
        const int WIN = 2;

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
                for (int insideloop = LOOP_START; insideloop < LOOPEND; insideloop++)
                {
                    //getting random numbers between 1,4
                    grid[outerloop, insideloop] = random.Next(GRIDSTART, GRIDEND);
                }
            }
            //Outputting the grid
            Console.WriteLine("Slot Machine Grid");
            for (int outerloop = LOOP_START; outerloop < LOOPEND; outerloop++)
            {
                for (int inside = LOOP_START; inside < LOOPEND; inside++)
                {
                    Console.Write(grid[outerloop, inside] + " ");
                }
                Console.WriteLine();
            }
            //checking if the horinzontal and Vertical are all the same
            int gridRowLenghth = grid.GetLength(0);
            int gridColumnLenghth = grid.GetLength(1);
            bool match = false;
            int innerloop = 0;
            for (int outerloop = FIRSTVALUE; outerloop < gridRowLenghth; outerloop++)
            {
                int holizontalMatch = 0;
                int verticalMatch = 0;
                int horizontalValue = grid[outerloop, FIRSTVALUE];
                int verticalValue = grid[FIRSTVALUE, outerloop];
                for (innerloop = SECOND_VALUE; innerloop < gridColumnLenghth; innerloop++)
                {
                    if (horizontalValue == grid[outerloop, innerloop])

                    {
                        holizontalMatch= holizontalMatch + PARTIAL_WIN;
                    }

                    if (verticalValue == grid[innerloop, outerloop])
                    {
                        verticalMatch=verticalMatch+PARTIAL_WIN;
                    }
                }

                if(holizontalMatch==WIN)
                {
                        Console.WriteLine($"Conglatulation you won by matching {horizontalValue} at row {outerloop}");
                        match = true;
                        //adding wager amount to the total money
                        money = money + wager;
                }

                if (holizontalMatch < WIN)

                {
                    Console.WriteLine($"Sorry, you didnt win anything in row {outerloop}");
                }
                if (verticalMatch==WIN)
                {
                        Console.WriteLine($"Conglatulation you won by matching {verticalValue} at colomn {outerloop}");
                        match = true;
                        //adding wager amount to the total money
                        money = money + wager;
                }

                if (verticalMatch < WIN)
                {
                    Console.WriteLine($"Sorry, you didnt win anything in colomn {outerloop}");
                }
            }

            int diagnolValues = grid[FIRSTVALUE, FIRSTVALUE];
            if (diagnolValues == grid[SECOND_VALUE, SECOND_VALUE] && diagnolValues == grid[gridRowLenghth-GRIDSTART, gridColumnLenghth-GRIDSTART])
            {
                Console.WriteLine($"Conglatulation you won by matching {diagnolValues} from top left to bottom left");
                money = money + wager;
            }

            int secondDiagnalValues = grid[FIRSTVALUE, gridRowLenghth-GRIDSTART];
            if (secondDiagnalValues == grid[SECOND_VALUE, SECOND_VALUE] && secondDiagnalValues == grid[gridRowLenghth-GRIDSTART,FIRSTVALUE ])
            {
                Console.WriteLine($"Conglatulation you won by matching {secondDiagnalValues} from top right to bottom left");
                money = money + wager;
            }

            //informing the total amount of money
            Console.WriteLine($"Currently, your total money is {money}");

            //quitting the game if the money is o
            if (money <= NO_MONEY)
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
                Console.Write("Alright, lets keep going");
            }
            //exiting the loop game if the answer is not yes
            else
            {
                Console.Write("The game ends here");
                break;
            }
            Console.WriteLine("Thank you so much for playing");
        }  
    }            
}


