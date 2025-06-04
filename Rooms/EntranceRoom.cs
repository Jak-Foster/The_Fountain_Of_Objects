
using The_Fountain_Of_Objects.Enumerations;

namespace The_Fountain_Of_Objects.Rooms
{
    public class EntranceRoom(int Row, int Column) : IRoom
    {
        public int Row { get; } = Row;
        public int Column { get; } = Column;
        public void PrintRoomDescription()
        {
            TextColour.HandleText(TextEnumeration.EntranceText, "You see light coming from the cavern entrance.");
        }
    }
}
