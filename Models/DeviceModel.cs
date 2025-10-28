using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IoTDeviceManager.Models
{
    public class DeviceModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name = "";
        private string _type = "";
        private bool _isOnline;
        private DateTime _lastUpdated = DateTime.Now;

        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string Type { get => _type; set { _type = value; OnPropertyChanged(); } }
        public bool IsOnline { get => _isOnline; set { _isOnline = value; OnPropertyChanged(); } }
        public DateTime LastUpdated { get => _lastUpdated; set { _lastUpdated = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
