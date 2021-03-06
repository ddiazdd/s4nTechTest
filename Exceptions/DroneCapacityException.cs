using System;
using DroneDelivery.Providers;

namespace DroneDelivery.Exceptions
{
    [Serializable]
    public class DroneCapacityException : Exception
    {
        public DroneCapacityException(int droneId ) : 
        base($"Drone capacity exceded for drone {droneId}, Default value is: {Constants.Application.DRONE_CAPACITY}")
        {
        }
    }
}