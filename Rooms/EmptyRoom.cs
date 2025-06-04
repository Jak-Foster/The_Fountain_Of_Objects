
using The_Fountain_Of_Objects.Enumerations;

namespace The_Fountain_Of_Objects.Rooms
{
    public class EmptyRoom(int Row, int Column) : IRoom
    {
        public int Row { get; } = Row;
        public int Column { get; } = Column;
        public void PrintRoomDescription()
        {
            TextColour.HandleText(TextEnumeration.DescriptiveText, "You sense nothing.");
        }
    }
}
