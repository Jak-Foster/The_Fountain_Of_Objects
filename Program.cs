using The_Fountain_Of_Objects;
using The_Fountain_Of_Objects.Enumerations;

internal class Program
{
    private static void Main()
    {        
        Game Game = new(GameSize.HandleGameSize());

        while(!Game.GameIsWonOrLost)
        {
            TextColour.HandleText(TextEnumeration.OtherText, "------------------------------------------------------------\r\n");
            Game.DisplayUserLocation();
            Game.DisplayRoomInformation();
            if (Game.HandleGameIsWonOrLost()) continue;
            Game.GridOfRooms.CheckAdjacentRooms();
            Game.AskForUserInput();
            Game.HandleUserAction();
            TextColour.HandleText(TextEnumeration.OtherText, "\r\n------------------------------------------------------------");
        }
    }
}