using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlappyBird
{
    class Program
    {
        public static int HeightOfGameWindow { get; set; }
        public static int WidhtOfGameWindow { get; set; }
        public static int LapNumber { get; set; }
        public static int Points { get; set; }
        static void Main(string[] args)
        {
            Console.SetWindowSize(95, 28);
            Console.OutputEncoding = Encoding.Unicode;
            HeightOfGameWindow = 25;
            WidhtOfGameWindow = 94;
            bool playAgain = true;
            GreenField.SetValuesGreenField();
            
            while (playAgain)
            {
                playAgain = false;
                LapNumber = 0;
                Points = 0;
                Bird.Alive = true;
                Bird.YStartPosition = 10;
                GreenField.CreateGreenFields(HeightOfGameWindow);
                Screen.CharsMakingScreen = new char[HeightOfGameWindow, WidhtOfGameWindow];
                Screen.StartGame();

                while (Bird.Alive)
                {
                    LapNumber++;
                    Console.SetCursorPosition(0, 0);

                    if (LapNumber < 1000)
                    {
                        if (LapNumber % 2 == 0)
                        {
                            GreenField.SetStartPositionOneStepBack(HeightOfGameWindow);
                            if (GreenField.IfBirdHasPassedTheField(Bird.XStartPosition))
                            { Points++; }
                        }
                    }
                    else if (LapNumber > 1000 && LapNumber < 2000)
                    {
                        if (LapNumber % 2 == 0 || LapNumber % 3 == 0)
                        {
                            GreenField.SetStartPositionOneStepBack(HeightOfGameWindow);
                            if (GreenField.IfBirdHasPassedTheField(Bird.XStartPosition))
                            { Points++; }
                        }
                    }
                    else
                    {
                        GreenField.SetStartPositionOneStepBack(HeightOfGameWindow);
                        if (GreenField.IfBirdHasPassedTheField(Bird.XStartPosition))
                        { Points++; }
                    }

                    if (LapNumber % 2 == 0)
                    {
                        Bird.YStartPosition++;
                        if (Bird.YStartPosition + Bird.BirdSizeY > 26)
                        { Bird.TheBirdDied(); }
                    }
                    if (Bird.YStartPosition < 0)
                    { Bird.TheBirdDied(); }
                    if (Console.KeyAvailable)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.UpArrow:
                                {
                                    Bird.YStartPosition = Bird.YStartPosition - 2;
                                }
                                break;
                            case ConsoleKey.Spacebar:
                                {
                                    Bird.YStartPosition = Bird.YStartPosition - 3;
                                }
                                break;
                            case ConsoleKey.Escape:
                                {
                                    Bird.TheBirdDied();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    Screen.CreateScreen(HeightOfGameWindow, WidhtOfGameWindow, GreenField.ListOfGreenFields, GreenField.WidthSizeOfField);
                    Screen.PutBirdOnScreen(Bird.XStartPosition, Bird.YStartPosition, Bird.BirdChars, Bird.BirdSizeX, Bird.BirdSizeY);
                    Screen.PrintScreen(HeightOfGameWindow, WidhtOfGameWindow);
                    System.Threading.Thread.Sleep(15);
                }
                Console.SetCursorPosition(0, 0);
                Screen.EndGame();
                Highscore.OpenAndPrintHighscore();
                Console.ForegroundColor = ConsoleColor.Red;
                Screen.PrintPoints(Points);

                int maybeHighscore = Highscore.SeeIfHighscore(Points);
                if (maybeHighscore < 11)
                {
                    Screen.YouMadeItToList();
                    Highscore.PutHighScoreInList(maybeHighscore);
                    Highscore.PutHighScoreInFile();
                    Highscore.OpenAndPrintHighscore();
                }
                else
                {
                    Screen.BetterLuck();
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Screen.PlayAgain();
                int choice = InputNumber(0, 1);
                if (choice == 1)
                { playAgain = true; }
                Console.Clear();

            }
            Console.Clear();
            Console.ReadLine();
        }
        public static int InputNumber(int minimumchoice, int maxchoice)
        {
            bool ok;
            int inputNumber = 0;

            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out inputNumber);
                if (!ok || inputNumber < minimumchoice || inputNumber > maxchoice)
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
                else { break; }
            }
            return inputNumber;
        }
        

    }
}
