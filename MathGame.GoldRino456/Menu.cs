using System;

public class Menu
{
    private const string _titleText = " ____    ____       _     _________  ____  ____ \r\n|_   \\  /   _|     / \\   |  _   _  ||_   ||   _|\r\n  |   \\/   |      / _ \\  |_/ | | \\_|  | |__| |  \r\n  | |\\  /| |     / ___ \\     | |      |  __  |  \r\n _| |_\\/_| |_  _/ /   \\ \\_  _| |_    _| |  | |_ \r\n|_____||_____||____| |____||_____|__|____||____|\r\n .' ___  |     / \\     |_   \\  /   _||_   __  | \r\n/ .'   \\_|    / _ \\      |   \\/   |    | |_ \\_| \r\n| |   ____   / ___ \\     | |\\  /| |    |  _| _  \r\n\\ `.___]  |_/ /   \\ \\_  _| |_\\/_| |_  _| |__/ | \r\n `._____.'|____| |____||_____||_____||________| ";
    private const string _lineBreak = "----------";

    public int ProcessMenu(InputHandler inputHandler)
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
                    return ProcessGameSelection();
                case 2:
                    ProcessViewPreviousScores();
                    break;
                case 0:
                    return ProcessQuitGame();
                default:
                    isInputValid = false;
                    break;
            }
        }
    }

    private int ProcessGameSelection()
    {
        Console.Clear();
        Console.WriteLine("Game Selection goes here.");
        return -1;
    }

    private void ProcessViewPreviousScores()
    {
        Console.Clear();
        Console.WriteLine("Press Enter To Continue...");
        Console.ReadLine();
    }

    private int ProcessQuitGame()
    {
        Console.WriteLine("Closing...");
        return 0;
    }
}
