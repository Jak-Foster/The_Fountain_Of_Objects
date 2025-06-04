
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
        private int HalfSize {  get; set; }
        public int SizeOfGrid { get; set; }
        public GridOfRooms(int SizeOfGrid)
        {
            this.SizeOfGrid = SizeOfGrid;
            SizeBoundary = SizeOfGrid - 1;
            HalfSize = SizeOfGrid / 2;

            Rooms = new IRoom[SizeOfGrid, SizeOfGrid];
            Rooms[SizeBoundary, 0] = new EntranceRoom(SizeBoundary, 0);
            Rooms[0, HalfSize] = new FountainRoom(0, HalfSize);

            if(SizeOfGrid == 4) Rooms[1, HalfSize] = new PitRoom(1, HalfSize);
            else if (SizeOfGrid == 6)
            {
                Rooms[1, HalfSize] = new PitRoom(1, HalfSize);
                Rooms[HalfSize, HalfSize] = new PitRoom(HalfSize, HalfSize);
            }
            else
            {
                Rooms[1, HalfSize] = new PitRoom(1, HalfSize);
                Rooms[HalfSize, 1] = new PitRoom(HalfSize, 1);
                Rooms[HalfSize, HalfSize] = new PitRoom(HalfSize, HalfSize);
                Rooms[(HalfSize) - 1, (HalfSize) - 1] = new PitRoom((HalfSize) - 1, (HalfSize) - 1);
            }

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

        public bool CheckForPit(IRoom Room)
        {
            if (Room is PitRoom)
            {
                return true;
            }
            return false;
        }
        public void CheckAdjacentRooms()
        {
            int[][] Directions = [
                [1, 0], [-1, 0],
                [0, 1], [0, -1],
                [1, 1], [-1, -1],
                [1, -1], [-1, 1]
            ];

            foreach (int[] Direction in Directions)
            {
                int AdjacentRow = CurrentRow + Direction[0];
                int AdjacentCol = CurrentColumn + Direction[1];

                if (AdjacentRow >= 0 && AdjacentRow < SizeOfGrid && AdjacentCol >= 0 && AdjacentCol < SizeOfGrid)
                {
                    IRoom Room = Rooms[AdjacentRow, AdjacentCol];
                    if (CheckForPit(Room))
                    {
                        TextColour.HandleText(TextEnumeration.DescriptiveText, "You feel a draft. There is a pit in a nearby room.");
                    }
                }
            }
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
