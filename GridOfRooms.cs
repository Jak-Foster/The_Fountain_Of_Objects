
using The_Fountain_Of_Objects.Enumerations;
using The_Fountain_Of_Objects.Rooms;

namespace The_Fountain_Of_Objects
{
    public class GridOfRooms
    {        
        private IRoom[,] Rooms { get; set; }
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
        public bool FountainIsEnabled { get; set; } = false;
        private int SizeBoundary { get; set; } 
        public GridOfRooms(int SizeOfGrid)
        {
            SizeBoundary = SizeOfGrid - 1;
            Rooms = new IRoom[SizeOfGrid, SizeOfGrid];
            Rooms[SizeBoundary, 0] = new EntranceRoom(SizeBoundary, 0);
            Rooms[0, SizeOfGrid / 2] = new FountainRoom(0, SizeOfGrid / 2);
            CurrentRow = SizeBoundary;
            CurrentColumn = 0;

            for (int I = SizeOfGrid; I--> 0;)
            {
                for (int J = SizeOfGrid; J-- > 0;)
                {
                    if(Rooms[I, J] == null) Rooms[I, J] = new EmptyRoom(I, J);
                }
            }
        }

        public IRoom GetCurrentRoom()
        {
            return Rooms[CurrentRow, CurrentColumn];
        }

        public DirectionEnumeration? HandleUserInput()
        {
            TextColour.HandleText(TextEnumeration.UserInputText);

            string ? UserInput = (Console.ReadLine() ?? "").ToLower();

            if (Enum.TryParse<DirectionEnumeration>(UserInput, ignoreCase: true, out DirectionEnumeration Direction))
            {
                return Direction;
            }
            else if (GetCurrentRoom() is FountainRoom FountainRoom && UserInput == "enable fountain")
            {
                FountainRoom.FountainIsEnabled = true;
                FountainIsEnabled = true;
                return null;
            }
            else if (UserInput == "enable fountain")
            {
                TextColour.HandleText(TextEnumeration.DescriptiveText, "You are not in the fountain room! Nice try...");
                return null;
            }
            else
            {
                TextColour.HandleText(TextEnumeration.DescriptiveText, "Invalid direction provided. You must specify North, South, East, or West.");
                return null;
            }
        }
        public void UpdateRoom(DirectionEnumeration? Direction)
        {
            if (Direction == null) return;
            if (Direction == DirectionEnumeration.North && CurrentRow > 0)
            {
                CurrentRow--;
            }
            else if (Direction == DirectionEnumeration.South && CurrentRow < SizeBoundary)
            {
                CurrentRow++;
            }
            else if (Direction == DirectionEnumeration.West && CurrentColumn > 0)
            {
                CurrentColumn--;
            }
            else if (Direction == DirectionEnumeration.East && CurrentColumn < SizeBoundary)
            {
                CurrentColumn++;
            }
            else TextColour.HandleText(TextEnumeration.DescriptiveText, "You hit a wall! Try another direction.");
        }
    }
}
