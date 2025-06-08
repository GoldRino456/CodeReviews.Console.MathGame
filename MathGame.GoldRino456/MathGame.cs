using System;

class MathGame
{
    static void Main()
    {
        var inputHandler = new InputHandler();
        var menu = new Menu();

        while(true)
        {
            menu.ProcessMenu(inputHandler);
            break;
        }
    }
}