
using The_Fountain_Of_Objects.Enumerations;

namespace The_Fountain_Of_Objects
{
    public static class GameSize
    {
        public static int HandleGameSize()
        {
            TextColour.HandleText(TextEnumeration.NarrativeText, "Do you want to play a small, medium, or large game? Enter your choice: ");
            TextColour.HandleText(TextEnumeration.UserInputText);
            
            string UserChosenSize = (Console.ReadLine() ?? "").ToLower();

            if (UserChosenSize == "small") return 4;
            if (UserChosenSize == "medium") return 6;
            if (UserChosenSize == "large") return 8;

            TextColour.HandleText(TextEnumeration.DescriptiveText, "Invalid size chosen. Game defaulted to small.");
            return 4;
        }
    }
}
