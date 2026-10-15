using System;
using System.Collections.Generic;

namespace Vehicles.Core
{
    public class Garage<T> where T : Vehicle
    {
        private readonly List<T> items = new();

        public event Action<string>? LogMessage;

        public void Add(T vehicle)
        {
            items.Add(vehicle);

            LogMessage?.Invoke($"{vehicle} added to garage.");

            foreach (var v in items)
            {
                if (!ReferenceEquals(v, vehicle))
                {
                    LogMessage?.Invoke($"{v} signals.");
                }
            }
        }

        public void Remove(T vehicle)
        {
            items.Remove(vehicle);

            LogMessage?.Invoke($"{vehicle} removed from garage.");

            foreach (var v in items)
            {
                LogMessage?.Invoke($"{v} flashes lights.");
            }
        }

        public IReadOnlyList<T> Items => items;
    }
}