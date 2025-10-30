using System;
using System.Collections.Generic;
using System.Timers;
using IoTDeviceManager.Models;

namespace IoTDeviceManager.Services
{
#nullable enable

    public class DeviceTelemetryEventArgs : EventArgs
    {
        public DeviceModel Device { get; }
        public double Temperature { get; }
        public double Humidity { get; }

        public DeviceTelemetryEventArgs(DeviceModel device, double temp, double humidity)
        {
            Device = device;
            Temperature = temp;
            Humidity = humidity;
        }
    }

    public class DeviceSimulator : IDisposable
    {
        private readonly Timer _timer;
        private readonly Random _rand = new();
        private readonly IList<DeviceModel> _devices;

        public event EventHandler<DeviceTelemetryEventArgs>? TelemetryReceived;
        public event EventHandler<DeviceModel>? DeviceDisconnected;
        public event EventHandler<string>? ErrorOccurred;

        public DeviceSimulator(IList<DeviceModel> devices, double intervalMs = 2000)
        {
            _devices = devices;
            _timer = new Timer(intervalMs);
            _timer.Elapsed += Tick;
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();

        private void Tick(object? sender, ElapsedEventArgs e)
        {
            foreach (var d in _devices)
            {
                try
                {
                    // 10% chance to simulate network drop
                    if (_rand.NextDouble() < 0.10)
                    {
                        d.IsOnline = false;
                        DeviceDisconnected?.Invoke(this, d);
                        continue;
                    }

                    if (d.IsOnline)
                    {
                        d.LastUpdated = DateTime.Now;
                        double temp = Math.Round(20 + _rand.NextDouble() * 10, 2);
                        double hum = Math.Round(40 + _rand.NextDouble() * 20, 2);

                        TelemetryReceived?.Invoke(this, new DeviceTelemetryEventArgs(d, temp, hum));
                    }
                }
                catch (Exception ex)
                {
                    ErrorOccurred?.Invoke(this, $"Error communicating with {d.Name}: {ex.Message}");
                }
            }
        }

        public void Dispose() => _timer.Dispose();
    }
}
