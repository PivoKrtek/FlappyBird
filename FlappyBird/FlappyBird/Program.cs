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

        public static GreenField Field1 { get; set; }
        public static GreenField Field2 { get; set; }
        public static GreenField Field3 { get; set; }
        public static GreenField Field4 { get; set; }
        public static GreenField Field5 { get; set; }

        static void Main(string[] args)
        {
            Console.SetWindowSize(95, 28);
            Console.OutputEncoding = Encoding.Unicode;
            HeightOfGameWindow = 25;
            WidhtOfGameWindow = 94;
            bool playAgain = true;
            GreenField.StartYPositionForWhole = 3;
            GreenField.HeightOfWholeInField = 6;
            GreenField.WidthSizeOfField = 8;
            GreenField.NumberOfPositionBetweenEachField = 22;
            GreenField.StartPositonFirstField = 40;
            while (playAgain)
            {
                playAgain = false;
                LapNumber = 0;
                Points = 0;
                Bird.Alive = true;
                Bird.XStartPosition = 12;
                Bird.YStartPosition = 10;
                Screen.XHere = 0;
                                
                Field1 = new GreenField(GreenField.StartPositonFirstField);
                Field2 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField);
                Field3 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField * 2);
                Field4 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField * 3);
                Field5 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField * 4);
                Bird.CreateBird();
                Screen.StringsMakingScreen = new string[Program.HeightOfGameWindow, Program.WidhtOfGameWindow];

                Screen.StartGame();
                
                while (Bird.Alive)
                {
                    LapNumber++;
                    Console.SetCursorPosition(0, 0);

                    if (LapNumber < 1000)
                    {
                        if (LapNumber % 2 == 0)
                        { GreenField.SetStartPositionOneStepBack(); }
                    }
                    else if (LapNumber > 1000 && LapNumber < 2000)
                    {
                        if (LapNumber % 2 == 0 || LapNumber % 3 == 0)
                        { GreenField.SetStartPositionOneStepBack(); }
                    }
                    else
                    { GreenField.SetStartPositionOneStepBack(); }

                    if (LapNumber % 2 == 0)
                    {
                        Bird.YStartPosition++;
                        if (Bird.YStartPosition + Bird.BirdSizeY > 26)
                        { Bird.Alive = false; }
                    }
                    if (Bird.YStartPosition < 0)
                    { Bird.Alive = false; }
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
                                    Bird.Alive = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    Screen.CreateScreen();
                    Screen.PrintScreen();
                   
                    System.Threading.Thread.Sleep(15);
                }
                
                Console.SetCursorPosition(0, 0);
                Screen.EndGame();
                Highscore.OpenAndPrintHighscore();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\t\tYou got {Program.Points} points.\n");
                int maybeHighscore = Highscore.SeeIfHighscore();
                if (maybeHighscore < 11)
                {
                    Console.WriteLine("\t\t\t\tCongratulations, you made it to the list!");
                    Highscore.PutHighScoreInList(maybeHighscore);
                    Highscore.PutHighScoreInFile();
                    Highscore.OpenAndPrintHighscore();
                }
                else
                {
                    Console.WriteLine("\t\t\t\tBetter luck next time!\n\n");
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t\tWant to play again?");
                Console.WriteLine("\t\t\t\t[1] --> YES!");
                Console.WriteLine("\t\t\t\t[0] --> NO.");
                Console.Write("\t\t\t\t");
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
