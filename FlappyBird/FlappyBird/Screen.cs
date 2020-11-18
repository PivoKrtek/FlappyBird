using System;
using System.Collections.Generic;

namespace FlappyBird
{
    class Screen
    {
        public static char[,] CharsMakingScreen { get; set; }
        public static int XHere { get; set; }
                      
        public static void CreateScreen(int heightWindow, int widhtWindow, List<GreenField> listOfFields, int widthSizeField) 
        {
            for (int y = 0; y < heightWindow; y++)
            {
                for (int x = 0; x < widhtWindow; x++)
                {
                    XHere = 0;
                    
                    for (int i = 0; i < listOfFields.Count; i++)
                    {
                        if (x >= listOfFields[i].XStartPosition && x < listOfFields[i].XStartPosition + widthSizeField)
                        {
                            
                            CharsMakingScreen[y, x] = listOfFields[i].Field[y, x - listOfFields[i].XStartPosition];
                            if (listOfFields[i].Field[y, x - listOfFields[i].XStartPosition] == '\u2736')
                            { XHere++; }
                        }
                    }
                    if (XHere < 1)
                    {
                        CharsMakingScreen[y, x] = ' ';
                    }
                }
            }
        }
        public static void PutBirdOnScreen(int birdXStartPosition, int birdYPosition, char[,] bird, int birdSizeX, int birdSizeY)
        {
            for (int y = 0; y < birdSizeY; y++)
            {
                for (int x = 0; x < birdSizeX; x++)
                {
                    if (bird[y, x] != ' ' && CharsMakingScreen[birdYPosition + y, birdXStartPosition + x] != '\u2736')
                    { CharsMakingScreen[birdYPosition + y, birdXStartPosition + x] = bird[y, x]; }
                    else if (CharsMakingScreen[birdYPosition + y, birdXStartPosition + x] == '\u2736')
                    { Bird.TheBirdDied(); }
                }
            }
        }

        public static void PrintScreen(int heightOfWindow, int widhtOfWindow)
        {
            for (int y = 0; y < heightOfWindow; y++)
            {
                for (int x = 0; x < widhtOfWindow; x++)
                {
                    if (CharsMakingScreen[y, x] == '\u2736')
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (CharsMakingScreen[y, x] == '@')
                    {
                        if (!Bird.Alive)
                        {
                            CharsMakingScreen[y, x] = '+';
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else { Console.ForegroundColor = ConsoleColor.Blue; }
                    }
                    else if (CharsMakingScreen[y, x] == '>' || CharsMakingScreen[y, x] == '\"')
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (CharsMakingScreen[y, x] != ' ')
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    Console.Write(CharsMakingScreen[y, x]);

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\tPOINTS: {Program.Points}");
        }

        public static void PlayAgain()
        {
            Console.WriteLine("\t\t\t\tWant to play again?");
            Console.WriteLine("\t\t\t\t[1] --> YES!");
            Console.WriteLine("\t\t\t\t[0] --> NO.");
            Console.Write("\t\t\t\t");
        }

        public static void BetterLuck()
        {
            Console.WriteLine("\t\t\t\tBetter luck next time!\n\n");
        }

        public static void YouMadeItToList()
        {
            Console.WriteLine("\t\t\t\tCongratulations, you made it to the list!");
        }

        public static void StartGame()
        {
        Console.WriteLine("\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        _______ _____   _______ ______ ______ ___ ___      ______ _______ ______ _____");
            Console.WriteLine("       |    ___|     |_|   _   |   __ \\   __ \\   |   |    |   __ \\_     _|   __ \\     \\");
            Console.WriteLine("       |    ___|       |       |    __/    __/\\     /     |   __ <_|   |_|      <  --  |");
            Console.WriteLine("       |___|   |_______|___|___|___|  |___|    |___|      |______/_______|___|__|_____/ ");
 
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                                UP ARROW --> Fly two steps up");
            Console.WriteLine("                                 SPACE --> Fly three steps up\n");
           
            Console.WriteLine("                               START GAME pressing any key...");
            Console.ReadKey(true);
        }
        public static void EndGame()
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
         

            Console.WriteLine("\n\n\n");

            Console.WriteLine("                                         YOU DIED...");
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                               PRESS ENTER to see HIGHSCORE");
            Console.ReadLine();
        }
        public static void PrintPoints(int points)
        {
            Console.WriteLine($"\t\t\t\tYou got {points} points.\n");
        }
    }
}
