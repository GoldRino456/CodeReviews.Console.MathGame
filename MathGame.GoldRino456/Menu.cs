using System;

public class Menu
{
    private const string _titleText = " ____    ____       _     _________  ____  ____ \r\n|_   \\  /   _|     / \\   |  _   _  ||_   ||   _|\r\n  |   \\/   |      / _ \\  |_/ | | \\_|  | |__| |  \r\n  | |\\  /| |     / ___ \\     | |      |  __  |  \r\n _| |_\\/_| |_  _/ /   \\ \\_  _| |_    _| |  | |_ \r\n|_____||_____||____| |____||_____|__|____||____|\r\n .' ___  |     / \\     |_   \\  /   _||_   __  | \r\n/ .'   \\_|    / _ \\      |   \\/   |    | |_ \\_| \r\n| |   ____   / ___ \\     | |\\  /| |    |  _| _  \r\n\\ `.___]  |_/ /   \\ \\_  _| |_\\/_| |_  _| |__/ | \r\n `._____.'|____| |____||_____||_____||________| ";

    public int ProcessMenu()
    {
        return 0;
    }
    private void DisplayMenu()
    {
        Console.WriteLine("----------");
        Console.WriteLine("1 - Start Game\n2 - View High Scores\n\n0 - Quit");
        Console.WriteLine("----------");
    }

    private int ProcessGameSelection()
    {
        int gameSelection = -1;
        DisplayGameSelection();

        while (true)
        {
            gameSelection = PromptGameSelection();

            if (gameSelection > -1)
            {
                break;
            }
        }
        
        return gameSelection;
    }

    private void DisplayGameSelection()
    {
        Console.WriteLine("----------");
        Console.WriteLine("Select A Game: ");
        Console.WriteLine("1 - Addition\n2 - Subtraction\n3 - Multiplication\n4 - Division\n5 - Random Mode");
        Console.WriteLine("----------");
    }

    private int PromptGameSelection()
    {
        int gameSelection = -1;

        Console.Write("Please Make A Selection: ");
        string? input = Console.ReadLine();
        bool isValidInteger = int.TryParse(input, out gameSelection);
        
        if(isValidInteger)
        {
            Console.WriteLine($"Valid Input: {gameSelection}");
            return gameSelection;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return -1;
        }
    }
}
