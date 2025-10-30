# IoTDeviceManager

# IoT Device Manager – SMSC Software Engineer (IoT) Assessment
**Author:** Muhammad Qawiem Bin Zulkefli  
**Date:** October 2025  

## Overview
This project is a WPF desktop application developed in C# (.NET Framework 4.8) that simulates IoT device management.  
It demonstrates fundamental IoT software engineering principles: device state management, real-time telemetry, logging, and MVVM architecture.

## Features
- **Device CRUD Operations:** Add, Update, Delete, and Toggle device online/offline states.  
- **Real-Time Simulation:** A background timer randomly updates device telemetry and connection status.  
- **Live Logging:** All device actions and telemetry updates are displayed in a log panel.  
- **MVVM Architecture:** Clean separation of View (UI), ViewModel (logic), and Model (data).  
- **Reactive UI:** Data binding via `INotifyPropertyChanged` ensures the interface updates automatically.

## 🧱 Architecture
