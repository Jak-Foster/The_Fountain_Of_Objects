using The_Fountain_Of_Objects.Enumerations;

namespace The_Fountain_Of_Objects
{

    public static class TextColour
    {
        public static void HandleText(TextEnumeration Text, string PrintedText = "")
        {
            if (Text == TextEnumeration.NarrativeText) Console.ForegroundColor = ConsoleColor.Magenta;
            if (Text == TextEnumeration.DescriptiveText) Console.ForegroundColor= ConsoleColor.White;
            if (Text == TextEnumeration.UserInputText)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                return;
            }
                if (Text == TextEnumeration.EntranceText) Console.ForegroundColor = ConsoleColor.Yellow;
            if (Text == TextEnumeration.FountainText) Console.ForegroundColor = ConsoleColor.Blue;
            if (Text == TextEnumeration.OtherText) Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(PrintedText);
        }
    }
}
