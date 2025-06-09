using System;

class MathGame
{
    static void Main()
    {
        var inputHandler = new InputHandler();
        var menu = new Menu();
        var gameManager = new GameManager();
        var gameHistory = new GameHistory();

        while(true)
        {
            int choice = menu.ProcessMenu(inputHandler, gameHistory);
            
            if(choice == 0)
            {
                break;
            }
            else
            {
                GameHistoryEntry newEntry = gameManager.StartGame(choice, inputHandler);
                gameHistory.AddEntryToHistory(newEntry);
            }
        }
    }
}