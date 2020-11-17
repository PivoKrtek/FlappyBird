namespace FlappyBird
{
    class Bird // Bör vara static eftersom den bara har static medlemmar. Lätt att glömma ;)
    {
        public static bool Alive { get; set; }

        public static string[,] BirdStrings { get; set; }
        public static int XStartPosition { get; set; }
        public static int YStartPosition { get; set; }
        public static int BirdSizeX { get; set; }
        public static int BirdSizeY { get; set; }

        public static void CreateBird() 
            // Snyggt att bara skapa arrayen en gång. Fundera dock på att flytta koden till en statisk konstruktor,
            // och att bara ha "get" på dina props.
        {
            BirdSizeY = 3; // använd const istället för en mutable property, eftersom värdet är hårdkodat i vilket fall.
            BirdSizeX = 4;
            BirdStrings = new string[BirdSizeY, BirdSizeX];
            BirdStrings[0, 0] = " ";
            BirdStrings[0, 1] = "(";
            BirdStrings[0, 2] = "@";
            BirdStrings[0, 3] = ">";
            BirdStrings[1, 0] = "{";
            BirdStrings[1, 1] = "<";
            BirdStrings[1, 2] = "D";
            BirdStrings[1, 3] = " ";
            BirdStrings[2, 0] = " ";
            BirdStrings[2, 1] = "\"";
            BirdStrings[2, 2] = "\"";
            BirdStrings[2, 3] = " ";

        }
        // Jag brukar också bygga mina ascii figurer i en kommentar, så jag gillar nedanstående! :D

        //  (@>  
        // {<D
        //  ""
    }
}
