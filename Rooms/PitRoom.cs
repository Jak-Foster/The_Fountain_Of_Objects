using The_Fountain_Of_Objects.Enumerations;
namespace The_Fountain_Of_Objects.Rooms
{
    public class PitRoom(int Row, int Column) : IRoom
    {
        public int Row { get; } = Row;
        public int Column { get; } = Column;
        public void PrintRoomDescription()
        {
            TextColour.HandleText(TextEnumeration.NarrativeText, "You entered a bottomless pit and died. Game Over");
        }
    }
}
