using DroneDelivery.Exceptions;
using DroneDelivery.Models;

namespace DroneDelivery.Providers
{
    public class ActionsProvider
    {
        public void ExecuteA(Drone drone)
        {
            //La letra A corresponde a un movimiento hacia adelante.
            switch (drone.CurrentPosition.cardinalPoint)
            {
                case Constants.CardinalPoint.Norte:
                    drone.CurrentPosition.coordinates.Y++;
                    break;
                case Constants.CardinalPoint.Sur:
                    drone.CurrentPosition.coordinates.Y--;
                    break;
                case Constants.CardinalPoint.Oriente:
                    drone.CurrentPosition.coordinates.X++;
                    break;
                case Constants.CardinalPoint.Occidente:
                    drone.CurrentPosition.coordinates.X--;
                    break;
                default:
                    break;
            }
            if (!isCurrentPositionValid(drone.CurrentPosition))
            {
                throw new InvalidPositionException(drone.id);
            }
        }

        public void ExecuteI(Drone drone)
        {
            //La letra I corresponde a un giro de 90 grados del dron a la izquierda.
            switch (drone.CurrentPosition.cardinalPoint)
            {
                case Constants.CardinalPoint.Norte:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Occidente;
                    break;
                case Constants.CardinalPoint.Sur:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Oriente;
                    break;
                case Constants.CardinalPoint.Oriente:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Norte;
                    break;
                case Constants.CardinalPoint.Occidente:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Sur;
                    break;
                default:
                    break;
            }
        }
        public void ExecuteD(Drone drone)
        {
            //La letra D corresponde a un giro de 90 grados del dron a la derecha.
            switch (drone.CurrentPosition.cardinalPoint)
            {
                case Constants.CardinalPoint.Norte:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Oriente;
                    break;
                case Constants.CardinalPoint.Sur:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Occidente;
                    break;
                case Constants.CardinalPoint.Oriente:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Sur;
                    break;
                case Constants.CardinalPoint.Occidente:
                    drone.CurrentPosition.cardinalPoint = Constants.CardinalPoint.Norte;
                    break;
                default:
                    break;
            }
        }

        private bool isCurrentPositionValid(Position currentPosition)
        {
            return currentPosition.coordinates.X <= Constants.Application.MAX_BLOCKS
                    && currentPosition.coordinates.X >= -Constants.Application.MAX_BLOCKS
                    && currentPosition.coordinates.Y <= Constants.Application.MAX_BLOCKS
                    && currentPosition.coordinates.Y >= -Constants.Application.MAX_BLOCKS;
        }
    }
}