
using The_Fountain_Of_Objects.Enumerations;
using The_Fountain_Of_Objects.Rooms;

namespace The_Fountain_Of_Objects
{
    public class Game
    {
        public bool GameIsWon { get; set; } = false;
        public GridOfRooms GridOfRooms { get; set; } = new(4);
        public void AskForUserInput()
        {
            TextColour.HandleText(TextEnumeration.DescriptiveText, "What do you want to do? ");
        }

        public void DisplayUserLocation()
        {
            TextColour.HandleText(TextEnumeration.DescriptiveText, $"You are in the room at (Row={GridOfRooms.CurrentRow}, Column={GridOfRooms.CurrentColumn}).");
        }

        public void DisplayRoomInformation()
        {
            GridOfRooms.GetCurrentRoom().PrintRoomDescription();
        }

        public void HandleUserAction()
        {
            GridOfRooms.UpdateRoom(GridOfRooms.HandleUserInput());
        }

        public bool HandleGameIsWon()
        {
            if (GridOfRooms.GetCurrentRoom() is EntranceRoom && GridOfRooms.FountainIsEnabled == true)
            {
                GameIsWon = true;
                TextColour.HandleText(TextEnumeration.NarrativeText, "The Fountain of Objects has been reactivated, and you have escaped with your life! \nYou win!");
                return true;
            }
            return false;
        }
    }
}
