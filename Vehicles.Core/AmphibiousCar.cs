using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public class AmphibiousCar : Vehicle, IDriveable, ISwimmable
    {
        public AmphibiousCar(string make, string model)
            : base(make, model)
        {
        }

        public string Drive(double km)
        {
            return Move(km);
        }

        public string Swim(double km)
        {
            return Move(km);
        }

        public override string Move(double km)
        {
            if (km <= 0)
                throw new ArgumentException("Distance must be greater than zero.");

            Odometer += km;

            return $"{Make} {Model} moved {km} km. Odometer: {Odometer} km.";
        }
    }
}