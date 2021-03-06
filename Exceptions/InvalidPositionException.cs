using System;
using DroneDelivery.Providers;

namespace DroneDelivery.Exceptions
{
    [Serializable]
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException(int droneId) :
        base($"Invalid position for drone {droneId}, Max value is: {Constants.Application.MAX_BLOCKS}")
        {
        }

    }
}