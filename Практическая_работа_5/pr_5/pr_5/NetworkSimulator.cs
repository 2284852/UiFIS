using System;
using System.Collections.Generic;
using System.Linq;
using static pr_5.Models;

namespace pr_5
{
    public class NetworkSimulator
    {
        private readonly Random _random = new Random();
        private readonly List<Device> _devices = new List<Device>();
        private readonly Device _switch;
        private int _packetCounter = 0;
        private readonly object _lock = new object();

        public List<Packet> ActivePackets { get; private set; } = new List<Packet>();
        public int TotalPacketsSent { get; private set; }
        public int TotalPacketsDelivered { get; private set; }

        public NetworkSimulator()
        {
            _devices.Add(new Device("ПК1", DeviceType.PC, 80, 80));
            _devices.Add(new Device("ПК2", DeviceType.PC, 540, 80));
            _devices.Add(new Device("ПК3", DeviceType.PC, 80, 340));
            _devices.Add(new Device("ПК4", DeviceType.PC, 540, 340));
            _switch = new Device("SWITCH", DeviceType.Switch, 310, 210);
        }

        public Packet GeneratePacket()
        {
            lock (_lock)
            {
                var pcs = _devices.Where(d => d.Type == DeviceType.PC).ToList();
                var source = pcs[_random.Next(pcs.Count)];
                var dest = pcs.Where(p => p != source).OrderBy(_ => _random.Next()).First();

                _packetCounter++;
                TotalPacketsSent++;
                var packet = new Packet(_packetCounter, source, dest);
                source.IsActive = true;
                return packet;
            }
        }

        public void UpdatePacketPosition(Packet packet, int step = 5)
        {
            lock (_lock)
            {
                Device targetDevice;
                if (!packet.IsAtSwitch)
                {
                    targetDevice = _switch;
                }
                else
                {
                    targetDevice = packet.Destination;
                }

                int dx = targetDevice.X - packet.CurrentX;
                int dy = targetDevice.Y - packet.CurrentY;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                if (distance < step)
                {
                    packet.CurrentX = targetDevice.X;
                    packet.CurrentY = targetDevice.Y;

                    if (!packet.IsAtSwitch)
                    {
                        packet.IsAtSwitch = true;
                        packet.HasReachedSwitch = true;
                        _switch.IsActive = true;
                    }
                    else
                    {
                        packet.ReceivedTime = DateTime.Now;
                        packet.Destination.IsActive = true;
                        TotalPacketsDelivered++;
                    }
                }
                else
                {
                    packet.CurrentX += (int)(dx / distance * step);
                    packet.CurrentY += (int)(dy / distance * step);
                }
            }
        }

        public List<Device> GetAllDevices()
        {
            var all = new List<Device>(_devices);
            all.Add(_switch);
            return all;
        }

        public void ResetStatistics()
        {
            lock (_lock)
            {
                TotalPacketsSent = 0;
                TotalPacketsDelivered = 0;
                _packetCounter = 0;
                foreach (var device in _devices)
                    device.IsActive = false;
                _switch.IsActive = false;
            }
        }
    }
}
