using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using IoTDeviceManager.Models;
using IoTDeviceManager.Services;
using System.Windows;

namespace IoTDeviceManager.ViewModels
{
#nullable enable

    public class MainViewModel : INotifyPropertyChanged, IDisposable
    {
        public ObservableCollection<DeviceModel> Devices { get; } = new();
        public ObservableCollection<LogEntry> Logs { get; } = new();

        private DeviceModel? _selected;
        public DeviceModel? SelectedDevice
        {
            get => _selected;
            set { _selected = value; OnPropertyChanged(); UpdateCommandStates(); }
        }

        private readonly DeviceSimulator _sim;

        public RelayCommand AddCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand ToggleStatusCommand { get; }
        public RelayCommand StartSimCommand { get; }
        public RelayCommand StopSimCommand { get; }

        public MainViewModel()
        {
            // Seed data
            Devices.Add(new DeviceModel { Id = 1, Name = "Thermo-01", Type = "Thermal Sensor", IsOnline = true });
            Devices.Add(new DeviceModel { Id = 2, Name = "Gate-Alpha", Type = "Gateway", IsOnline = false });
            Devices.Add(new DeviceModel { Id = 3, Name = "Cam-02", Type = "Camera", IsOnline = true });

            _sim = new DeviceSimulator(Devices);
            _sim.Telemetry += (s, e) =>
                App.Current.Dispatcher.Invoke(() =>
                    Logs.Add(new LogEntry { Action = "Telemetry", Details = $"{e.Device.Name}: temp={e.Temperature}°C" }));

            _sim.Disconnected += (s, d) =>
                App.Current.Dispatcher.Invoke(() =>
                    Logs.Add(new LogEntry { Action = "Disconnected", Details = $"{d.Name} went offline" }));

            AddCommand = new RelayCommand(_ => Add());
            UpdateCommand = new RelayCommand(_ => Update(), _ => SelectedDevice != null);
            DeleteCommand = new RelayCommand(_ => Delete(), _ => SelectedDevice != null);
            ToggleStatusCommand = new RelayCommand(_ => Toggle(), _ => SelectedDevice != null);
            StartSimCommand = new RelayCommand(_ => _sim.Start());
            StopSimCommand = new RelayCommand(_ => _sim.Stop());
        }

        private void Add()
        {
            var nextId = Devices.Any() ? Devices.Max(d => d.Id) + 1 : 1;
            var d = new DeviceModel { Id = nextId, Name = $"Device-{nextId}", Type = "Generic", IsOnline = true };
            Devices.Add(d);
            Logs.Add(new LogEntry { Action = "Add", Details = $"{d.Name} added" });
        }

        private void Update()
        {
            if (SelectedDevice == null) return;
            // Example update: append " (edited)"
            SelectedDevice.Name = SelectedDevice.Name.EndsWith(" (edited)") ? SelectedDevice.Name : SelectedDevice.Name + " (edited)";
            Logs.Add(new LogEntry { Action = "Update", Details = $"{SelectedDevice.Name} updated" });
        }

        private void Delete()
        {
            if (SelectedDevice == null) return;
            var name = SelectedDevice.Name;
            Devices.Remove(SelectedDevice);
            Logs.Add(new LogEntry { Action = "Delete", Details = $"{name} deleted" });
            SelectedDevice = null;
        }

        private void Toggle()
        {
            if (SelectedDevice == null) return;
            SelectedDevice.IsOnline = !SelectedDevice.IsOnline;
            Logs.Add(new LogEntry { Action = "ToggleStatus", Details = $"{SelectedDevice.Name} is now {(SelectedDevice.IsOnline ? "Online" : "Offline")}" });
        }

        private void UpdateCommandStates()
        {
            UpdateCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
            ToggleStatusCommand.RaiseCanExecuteChanged();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? p = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

        public void Dispose() => _sim?.Dispose();
    }
}
