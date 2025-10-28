using System;
using System.Collections.Generic;
using System.Timers;
using IoTDeviceManager.Models;

namespace IoTDeviceManager.Services
{
    public class DeviceTelemetryEventArgs : EventArgs
    {
        public DeviceModel Device { get; set; }
        public double Temperature { get; set; }
        public DeviceTelemetryEventArgs(DeviceModel device, double temp)
        { Device = device; Temperature = temp; }
    }

    public class DeviceSimulator : IDisposable
    {
        private readonly Timer _timer;
        private readonly Random _rand = new Random();
        private readonly IList<DeviceModel> _devices;

        public event EventHandler<DeviceTelemetryEventArgs>? Telemetry;
        public event EventHandler<DeviceModel>? Disconnected;

        public DeviceSimulator(IList<DeviceModel> devices, double intervalMs = 2000)
        {
            _devices = devices;
            _timer = new Timer(intervalMs);
            _timer.Elapsed += Tick;
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();

        private void Tick(object? s, ElapsedEventArgs e)
        {
            foreach (var d in _devices)
            {
                // 15% chance to flip connectivity
                if (_rand.NextDouble() < 0.15) d.IsOnline = !d.IsOnline;

                if (d.IsOnline)
                {
                    d.LastUpdated = DateTime.Now;
                    var temp = Math.Round(20 + _rand.NextDouble() * 10, 2);
                    Telemetry?.Invoke(this, new DeviceTelemetryEventArgs(d, temp));
                }
                else
                {
                    Disconnected?.Invoke(this, d);
                }
            }
        }

        public void Dispose() => _timer?.Dispose();
    }
}
