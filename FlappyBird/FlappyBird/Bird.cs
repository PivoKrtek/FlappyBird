namespace FlappyBird
{
    static class Bird
    {
        public static bool Alive { get; set; }
        public static char[,] BirdChars { get; set; }
        public static int XStartPosition { get; }
        public static int YStartPosition { get; set; }

        public const int BirdSizeX = 4;

        public const int BirdSizeY = 3;
        static Bird()
        {
            Alive = true;
            XStartPosition = 12;
            YStartPosition = 10;
            BirdChars = new char[BirdSizeY, BirdSizeX];
            BirdChars[0, 0] = ' ';
            BirdChars[0, 1] = '(';
            BirdChars[0, 2] = '@';
            BirdChars[0, 3] = '>';
            BirdChars[1, 0] = '{';
            BirdChars[1, 1] = '<';
            BirdChars[1, 2] = 'D';
            BirdChars[1, 3] = ' ';
            BirdChars[2, 0] = ' ';
            BirdChars[2, 1] = '\"';
            BirdChars[2, 2] = '\"';
            BirdChars[2, 3] = ' ';
        }
        public static void TheBirdDied()
        {
            Alive = false;
        }
        //  (@>  
        // {<D
        //  ""
    }
}
