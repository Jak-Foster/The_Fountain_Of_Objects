
using The_Fountain_Of_Objects.Enumerations;

namespace The_Fountain_Of_Objects.Rooms
{
    public class FountainRoom(int Row, int Column) : IRoom
    {
        public int Row { get; } = Row;
        public int Column { get; } = Column;

        public bool FountainIsEnabled { get; set; } = false;
        public void PrintRoomDescription()
        {
            if (!FountainIsEnabled)
            {
                TextColour.HandleText(TextEnumeration.FountainText, "You hear water dripping in this room. The Fountain of Objects is here!");
            }
            else
            {
                TextColour.HandleText(TextEnumeration.FountainText, "You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            }
        }
    }
}
