using System;

namespace FlappyBird
{
    class GreenField
    {
        public string[,] Field { get; set; }
        public int XStartPosition { get; set; }
        public int YStartForWhole { get; set; }

        public static int WidthSizeOfField { get; set; }
        public static int HeightOfWholeInField { get; set; }
        public static int StartYPositionForWhole { get; set; }
        public static int StartPositonFirstField { get; set; }
        public static int NumberOfPositionBetweenEachField { get; set; }

        public GreenField(int xposition)
        {
            XStartPosition = xposition;
            Field = new string[Program.HeightOfGameWindow, WidthSizeOfField];
            YStartForWhole = SetStartYWholeInField();
            for (int y = 0; y < Program.HeightOfGameWindow; y++)
            {
                for (int x = 0; x < WidthSizeOfField; x++)
                {
                    if (y >= YStartForWhole && y < YStartForWhole + HeightOfWholeInField)
                    {
                        Field[y, x] = " ";
                    }
                    else { Field[y, x] = "\u2736"; }
                }
            }
        }
        public static void SetStartPositionOneStepBack() // Flytta metoden till Program, då den bara har referenser dit.
        {

            Program.Field1.XStartPosition--;
            if (Program.Field1.XStartPosition == 0 - WidthSizeOfField)
            { Program.Field1 = new GreenField(Program.Field5.XStartPosition + NumberOfPositionBetweenEachField); }
            if (Program.Field1.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { Program.Points++; }

            Program.Field2.XStartPosition--;
            if (Program.Field2.XStartPosition == 0 - WidthSizeOfField)
            {
                Program.Field2 = new GreenField(Program.Field1.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (Program.Field2.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { Program.Points++; }

            Program.Field3.XStartPosition--;
            if (Program.Field3.XStartPosition == 0 - WidthSizeOfField)
            {
                Program.Field3 = new GreenField(Program.Field2.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (Program.Field3.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { Program.Points++; }

            Program.Field4.XStartPosition--;
            if (Program.Field4.XStartPosition == 0 - WidthSizeOfField)
            {
                Program.Field4 = new GreenField(Program.Field3.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (Program.Field4.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { Program.Points++; }

            Program.Field5.XStartPosition--;
            if (Program.Field5.XStartPosition == 0 - WidthSizeOfField)
            {
                Program.Field5 = new GreenField(Program.Field4.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (Program.Field5.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { Program.Points++; }
        }
        
        private int SetStartYWholeInField()
        {
            Random random = new Random();
            int number = random.Next(StartYPositionForWhole, Program.HeightOfGameWindow - (StartYPositionForWhole + HeightOfWholeInField));
            return number;
        }
    }
}
