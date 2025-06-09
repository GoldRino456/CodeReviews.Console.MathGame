using System;

public class Menu
{
    private Dictionary<int, string> _gameTypes = new Dictionary<int, string> { { 1, "Addition (+)" }, { 2, "Subtraction (-)" }, { 3, "Multiplication (*)" }, { 4, "Division (/)" }, { 5, "Random! (?)" } };
    private const string _titleText = " ____    ____       _     _________  ____  ____ \r\n|_   \\  /   _|     / \\   |  _   _  ||_   ||   _|\r\n  |   \\/   |      / _ \\  |_/ | | \\_|  | |__| |  \r\n  | |\\  /| |     / ___ \\     | |      |  __  |  \r\n _| |_\\/_| |_  _/ /   \\ \\_  _| |_    _| |  | |_ \r\n|_____||_____||____| |____||_____|__|____||____|\r\n .' ___  |     / \\     |_   \\  /   _||_   __  | \r\n/ .'   \\_|    / _ \\      |   \\/   |    | |_ \\_| \r\n| |   ____   / ___ \\     | |\\  /| |    |  _| _  \r\n\\ `.___]  |_/ /   \\ \\_  _| |_\\/_| |_  _| |__/ | \r\n `._____.'|____| |____||_____||_____||________| ";
    private const string _lineBreak = "----------";

    public int ProcessMenu(InputHandler inputHandler, GameHistory gameHistory)
    {
        int selection = -1;
        bool isInputValid = true;

        while(true)
        {
            Console.Clear();
            Console.WriteLine(_titleText + "\n" + _lineBreak);
            Console.WriteLine("1- Start Game\n2- View Previous Scores\n0- Quit");
            Console.WriteLine(_lineBreak + "\n");

            if(!isInputValid)
            {
                inputHandler.NotifyInvalidInputInt();
            }

            selection = inputHandler.PromptForInputInt();

            switch(selection)
            {
                case 1:
                    int gameChoice = ProcessGameSelection(inputHandler);
                    if(gameChoice != 0)
                    {
                        return gameChoice;
                    }
                    else
                    {
                        break;
                    }

                case 2:
                     ProcessViewPreviousScores(inputHandler, gameHistory);
                     break;

                case 0:
                     return ProcessQuitGame();

                default:
                     isInputValid = false;
                     break;
            }
        }
    }

    private int ProcessGameSelection(InputHandler inputHandler)
    {
        int selection = -1;
        List<int> validGameChoices = new List<int> {1, 2, 3, 4, 5};
        bool isInputValid = true;

        while(true)
        {
            Console.Clear();
            Console.WriteLine("Select A Game\n" + _lineBreak);
            Console.WriteLine("1- Addition (+)\n2- Subtraction (-)\n3- Multiplication (*)\n4- Division (/)\n5- Random! (?)\n0- Go Back");
            Console.WriteLine(_lineBreak + "\n");

            if (!isInputValid)
            {
                inputHandler.NotifyInvalidInputInt();
            }

            selection = inputHandler.PromptForInputInt();

            if(validGameChoices.Contains(selection))
            {
                return selection;
            }
            else if(selection == 0)
            {
                return 0;
            }
            else
            {
                isInputValid = false;
            }
        }
    }

    private void ProcessViewPreviousScores(InputHandler inputHandler, GameHistory gameHistory)
    {
        Console.Clear();
        Console.WriteLine("Past Scores\n" + _lineBreak);

        var recentScores = gameHistory.GetGameHistory();
        if(recentScores == null)
        {
            Console.WriteLine("No scores to display yet!");
            Console.Write("Press enter to return to the menu...");
            Console.ReadLine();
        }
        else
        {
            int idx = 1;
            foreach(var score in recentScores)
            {
                Console.WriteLine($"{idx}- {_gameTypes[score.GameType]}, Score: {score.Score}");
                idx++;
            }

            Console.Write("Press enter to return to the menu...");
            Console.ReadLine();
        }
    }

    private int ProcessQuitGame()
    {
        Console.WriteLine("Closing...");
        return 0;
    }
}
