namespace The_Fountain_Of_Objects.Rooms
{
    public interface IRoom
    {
        public int Row { get; }
        public int Column { get; }
        public void PrintRoomDescription();
    }
}
