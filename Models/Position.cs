using DroneDelivery.Constants;

namespace DroneDelivery.Models
{
    public class Position
    {
        public Coordinates coordinates { get; set; }
        public CardinalPoint cardinalPoint { get; set; }

        public override string ToString()
        {
            return "(" + coordinates.X + ", " + coordinates.Y + ") dirección " + cardinalPoint.ToString();
        }
    }
}