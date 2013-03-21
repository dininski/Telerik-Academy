using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Galaxian.Common
{
    class Menu
    {
        public const int XCoord = 15;
        public const int YCoord = 10;
        IMenuInterface menu;
        public int Choosen;
        public bool noChoice = true;
        public Menu(IMenuInterface menu)
        {
            this.menu = menu;
        }
        public void ConnectController()
        {
            menu.OnChoiceUp += (sender, eventInfo) =>
            {
                this.MoveUp();
            };

            menu.OnChoiceDown += (sender, eventInfo) =>
            {
                this.MoveDown();
            };

            menu.onChoosen += (sender, eventInfo) =>
            {
                this.Enter();
            };
        }
        public void MoveUp()
        {
            if (this.menu.Choice > 0)
            {
                this.menu.Choice--;
            }
        }

        public void MoveDown()
        {
            if (this.menu.Choice<2)
            {
                this.menu.Choice++;
            }
        }

        public void Enter()
        {
            Choosen = this.menu.Choice;
            noChoice = false;
        }

        public void ShowMenu()
        {
            ConnectController();
            while (noChoice)
            {
                Thread.Sleep(25);
                if (Console.KeyAvailable)
                {
                    menu.ProcessInput();
                    Console.Clear();
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(XCoord, YCoord);
                Console.Write("Start New Game");
                Console.SetCursorPosition(XCoord, YCoord + 1);
                Console.Write("High Scores");
                Console.SetCursorPosition(XCoord, YCoord + 2);
                Console.Write("Quit");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(XCoord-4, menu.Choice + YCoord);
                Console.Write("[|}>");
            }
        }
    }

}