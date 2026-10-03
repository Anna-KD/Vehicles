using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    public abstract class Vehicle
    {
        public string Make { get; }
        public string Model { get; }
        public double Odometer { get; protected set; }

        protected Vehicle(string make, string model)
        {
            Make = make;
            Model = model;
            Odometer = 0;
        }

        public abstract string Move(double km);

        public override string ToString()
        {
            return $"{Make} {Model}";
        }
    }
}