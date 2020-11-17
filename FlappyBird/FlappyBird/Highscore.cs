using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlappyBird
{
    class Highscore
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public static List<Highscore> HighscoreList { get; set; }
        public Highscore(string name, int points)
        {
            Name = name;
            Points = points;
        }
        public static void OpenHighscores()
        {
            if (!File.Exists("flappybirdhighscore.txt"))
            {
                StreamWriter sw = File.CreateText("flappybirdhighscore.txt");
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("---;0");
                }
                sw.Close();
            }
            string[] lines = File.ReadAllLines("flappybirdhighscore.txt");
            List<Highscore> highscoreList = new List<Highscore>();

            foreach (string line in lines)
            {
                string[] nameAndPoints = line.Split(';');
                int points = int.Parse(nameAndPoints[1]);
                highscoreList.Add(new Highscore(nameAndPoints[0], points));

            }
            HighscoreList = highscoreList;
        }
        public static void PrintOutHighscores()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t~*~~~~*~~~~HIGHSCORE FLAPPY BIRD~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\t-------------------------------------------");
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var line in Highscore.HighscoreList)
            {
                Console.WriteLine($"\t\t\t\t{counter}. {line.Name}, {line.Points} poäng.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\t-------------------------------------------");
        }

        public static int SeeIfHighscore()
        {
            int counter = 0;
            foreach (var points in Highscore.HighscoreList)
            {
                if (points.Points < Program.Points)
                { return counter; }
                counter++;
            }
            return 100;
        }

        public static string GetName()
        {
            Console.Write("\t\t\t\tWrite your name: ");
            string name = Console.ReadLine();
            return name;
        }
        public static void PutHighScoreInFile()
        {
            int counter = 0;
            StreamWriter sw = File.CreateText("flappybirdhighscore.txt");
            foreach (var line in Highscore.HighscoreList)
            {


                sw.WriteLine($"{line.Name};{line.Points}");
                counter++;
                if (counter == 10)
                { break; }
            }
            sw.Close();
        }
        public static void OpenAndPrintHighscore()
        {
            Console.Clear();
            Highscore.OpenHighscores();
            Highscore.PrintOutHighscores();
            Console.WriteLine();
        }
        public static void PutHighScoreInList(int place)
        {
            Highscore highscore = new Highscore(Highscore.GetName(), Program.Points);

            Highscore.HighscoreList.Insert(place, highscore);
        }
    }
}

