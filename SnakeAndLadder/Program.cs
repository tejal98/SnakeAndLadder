using System;

namespace SnakeAndLadder
{
    class Program
    {
        static int PlayOptions(int diceRoll, int dicePostion, int option, int endPosition)
        {
            switch (option)
            {
                case 0:
                    dicePostion -= diceRoll;
                    break;
                case 1:
                    dicePostion += diceRoll;
                    break;
                default:
                    break;
            }
            return CheckEndPosition(dicePostion, endPosition, diceRoll);
        }
        static int CheckEndPosition(int playerPositionReached, int END_POSITION, int playerDiceRoll)
        {
            if (playerPositionReached > END_POSITION)
            {
                playerPositionReached -= playerDiceRoll;
            }
            return playerPositionReached;
        }
        static void Main(string[] args)
        {
            int START_POSITION = 0;
            int END_POSITION = 100;
            Random random = new Random();
            Console.WriteLine("Welcome to Snake and Ladder Game \n");

            string[] chooseOption = { "Snake", "Ladder", "Noplay" };

            int playerOnePositionReached = START_POSITION;
            int playerTwoPositionReached = START_POSITION;

            while (true)
            {
                if (playerOnePositionReached < START_POSITION)
                {
                    playerOnePositionReached = START_POSITION;
                }
                else if (playerTwoPositionReached < START_POSITION)
                {
                    playerTwoPositionReached = START_POSITION;
                }
                
                int player1DiceRoll = random.Next(1, 7);
                Console.WriteLine("Player 1 dice value is :" + player1DiceRoll );
                int player1_Option = random.Next(0, 3);
                
                int player2DiceRoll = random.Next(1, 7);
                Console.WriteLine("Player 2 dice value is :" + player2DiceRoll + "\n");
                int player2_Option = random.Next(0, 3);
                
                if (player1_Option == 1)
                {
                    Console.WriteLine("Player 1 got:" + chooseOption[player1_Option]);
                    playerOnePositionReached = PlayOptions(player1DiceRoll, playerOnePositionReached, player1_Option, END_POSITION);
                    Console.WriteLine("player 1 roll again as it came ladder");
                    Console.WriteLine("Position reached by player 1 after dice roll: " + playerOnePositionReached + "\n");
                }
                else if (player2_Option == 1)
                {
                    Console.WriteLine("Player 2 got:" + chooseOption[player2_Option]);
                    playerTwoPositionReached = PlayOptions(player2DiceRoll, playerTwoPositionReached, player2_Option, END_POSITION);
                    Console.WriteLine("player 2 roll again as it came ladder");
                    Console.WriteLine("Position reached by player 2 after dice roll: " + playerTwoPositionReached + "\n");
                }
                else
                {
                    Console.WriteLine("Player 1 got:" + chooseOption[player1_Option]);
                    playerOnePositionReached = PlayOptions(player1DiceRoll, playerOnePositionReached, player1_Option, END_POSITION);
                    Console.WriteLine("Position reached by player 1 after dice roll: " + playerOnePositionReached + "\n");

                    Console.WriteLine("Player 2 got:" + chooseOption[player2_Option]);
                    playerTwoPositionReached = PlayOptions(player2DiceRoll, playerTwoPositionReached, player2_Option, END_POSITION);
                    Console.WriteLine("Position reached by player 2 after dice roll: " + playerTwoPositionReached + "\n");
                }
                if (playerOnePositionReached == END_POSITION)
                {
                    Console.WriteLine("Player 1 have reached to :" + playerOnePositionReached + "\n ***PLAYER 1 WON THE GAME***");
                    break;
                }
                else if (playerTwoPositionReached == END_POSITION)
                {
                    Console.WriteLine("Player 2 have reached to :" + playerTwoPositionReached + "\n ***PLAYER 2 WON THE GAME***");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
