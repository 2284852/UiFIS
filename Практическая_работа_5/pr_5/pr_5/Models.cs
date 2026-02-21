using System;

namespace pr_5
{
    public class Models
    {
        public enum DeviceType { PC, Switch }


        public class Device
        {
            public string Name { get; set; }
            public DeviceType Type { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsActive { get; set; }

            public Device(string name, DeviceType type, int x, int y)
            {
                Name = name;
                Type = type;
                X = x;
                Y = y;
                IsActive = false;
            }
        }


        public class Packet
        {
            public int Id { get; set; }
            public Device Source { get; set; }
            public Device Destination { get; set; }
            public int Size { get; set; }
            public DateTime SentTime { get; set; }
            public DateTime? ReceivedTime { get; set; }
            public int CurrentX { get; set; }
            public int CurrentY { get; set; }
            public bool IsAtSwitch { get; set; }
            public bool HasReachedSwitch { get; set; }

            public Packet(int id, Device source, Device destination)
            {
                Id = id;
                Source = source;
                Destination = destination;
                Size = new Random().Next(100, 1000);
                SentTime = DateTime.Now;
                CurrentX = source.X;
                CurrentY = source.Y;
                IsAtSwitch = false;
                HasReachedSwitch = false;
            }


            public int? GetDelay()
            {
                if (ReceivedTime.HasValue)
                    return (int)(ReceivedTime.Value - SentTime).TotalMilliseconds;
                return null;
            }
        }
    }
}

