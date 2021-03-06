namespace DroneDelivery.Models
{
    public class Drone
    {
        public readonly int id;
        public string inputFile { get; set; }
        public string outputFile { get; set; }
        public Position CurrentPosition { get; set; }

        public Drone(int _id)
        {
            id = _id;
            CurrentPosition = new Position
            {
                coordinates = new Coordinates { X = 0, Y = 0 },
                cardinalPoint = Constants.CardinalPoint.Norte
            };
        }
    }
}