using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class Car : Vehicle, IDriveable
    {
        public Car(string make, string model)
            : base(make, model)
        {
        }

        public string Drive(double km)
        {
            return Move(km);
        }

        public override string Move(double km)
        {
            if (km <= 0)
                throw new ArgumentException("Distance must be greater than zero.");

            Odometer += km;

            return $"{Make} {Model} drove {km} km. Odometer: {Odometer} km.";
        }
    }
}
