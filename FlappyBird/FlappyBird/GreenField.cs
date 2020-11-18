using System;
using System.Collections.Generic;

namespace FlappyBird
{
    class GreenField
    {
        public char[,] Field { get; set; }
        public int XStartPosition { get; set; }
        public int YStartForWhole { get; set; }
        public static int WidthSizeOfField { get; set; }
        public static int HeightOfWholeInField { get; set; }
        public static int StartYPositionForWhole { get; set; }
        public static int StartPositonFirstField { get; set; }
        public static int NumberOfPositionBetweenEachField { get; set; }
        public static List<GreenField> ListOfGreenFields { get; set; }

        public GreenField(int xposition, int heightOfWindow)
        {
            XStartPosition = xposition;
            Field = new char[heightOfWindow, WidthSizeOfField];
            YStartForWhole = SetStartYWholeInField(heightOfWindow);
            for (int y = 0; y < heightOfWindow; y++)
            {
                for (int x = 0; x < WidthSizeOfField; x++)
                {
                    if (y >= YStartForWhole && y < YStartForWhole + HeightOfWholeInField)
                    {
                        Field[y, x] = ' ';
                    }
                    else { Field[y, x] = '\u2736'; }
                }
            }
        }
        public static void SetValuesGreenField()
        {
            StartYPositionForWhole = 3;
            HeightOfWholeInField = 6;
            WidthSizeOfField = 8;
            NumberOfPositionBetweenEachField = 22;
            StartPositonFirstField = 40;
        }
        public static void CreateGreenFields(int heightOfWindow)
        {
            ListOfGreenFields = new List<GreenField>();
            ListOfGreenFields.Add(new GreenField(StartPositonFirstField, heightOfWindow));
            ListOfGreenFields.Add(new GreenField(StartPositonFirstField + NumberOfPositionBetweenEachField, heightOfWindow));
            ListOfGreenFields.Add(new GreenField((StartPositonFirstField + NumberOfPositionBetweenEachField * 2), heightOfWindow));
            ListOfGreenFields.Add(new GreenField((StartPositonFirstField + NumberOfPositionBetweenEachField * 3), heightOfWindow));
            ListOfGreenFields.Add(new GreenField((StartPositonFirstField + NumberOfPositionBetweenEachField * 4), heightOfWindow));
        }
              
        public static bool IfBirdHasPassedTheField(int birdXStartPosition)
        {
            foreach (var field in ListOfGreenFields)
            {
                if (field.XStartPosition == birdXStartPosition - WidthSizeOfField)
                    return true;
            }
            return false;
            
        }
        public static void SetStartPositionOneStepBack(int heightOfWindow)
        {
            for (int i = 0; i < ListOfGreenFields.Count; i++)
            {
                ListOfGreenFields[i].XStartPosition--;
                if (ListOfGreenFields[i].XStartPosition == 0 - WidthSizeOfField)
                { ListOfGreenFields[i] = new GreenField(ListOfGreenFields[(i == 0 ? 4 : i-1)].XStartPosition + NumberOfPositionBetweenEachField, heightOfWindow); }
            }
        }
        private int SetStartYWholeInField(int heightOfWindow)
        {
            Random random = new Random();
            int number = random.Next(StartYPositionForWhole, heightOfWindow - (StartYPositionForWhole + HeightOfWholeInField));
            return number;
        }
    }
}
