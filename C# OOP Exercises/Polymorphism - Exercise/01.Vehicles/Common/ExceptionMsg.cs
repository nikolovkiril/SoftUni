using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Common
{
    public static class ExceptionMsg
    {
        public static string NotEnoughFuelExceptionMsg = "{0} needs refueling";

        public static string InvalidVehicleTypeMsg = "Invalid vehicle type!";

        public static string TankCapacityExceptionMsg = "Cannot fit {0} fuel in the tank";

        public static string FuelMustBePositiveExceptionMsg = "Fuel must be a positive number";
    }
}
