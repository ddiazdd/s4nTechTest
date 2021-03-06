using System;

namespace DroneDelivery.Exceptions
{
    [Serializable]
    public class InvalidActionException : Exception
    {
         public InvalidActionException(string input, int droneId ) : 
        base($"Invalid action in {input} for drone {droneId}")
        {
        }
    }
}