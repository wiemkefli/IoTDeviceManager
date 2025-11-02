# IoTDeviceManager – Desktop IoT Simulation App

## Overview
**IoTDeviceManager** is a WPF desktop application developed in **C# (.NET Framework)** that simulates communication between multiple IoT devices and a central management system.  
It allows users to **add, update, delete, toggle device status**, and **view real-time telemetry logs** such as temperature, humidity, and connection events.  

This project demonstrates practical knowledge of **event-driven programming**, **MVVM architecture**, and **simulated IoT device communication**.

---

## Features
- **Device CRUD Operations:** Add, Update, Delete, and Toggle device online/offline states.  
- **Real-Time Simulation:** A background timer randomly updates device telemetry and connection status.  
- **Live Logging:** All device actions and telemetry updates are displayed in a log panel.  
- **MVVM Architecture:** Clean separation of View (UI), ViewModel (logic), and Model (data).  
- **Reactive UI:** Data binding via `INotifyPropertyChanged` ensures the interface updates automatically.

---

## Setup / Build Instructions

### **Requirements**
| Component | Version / Notes |
|------------|-----------------|
| **IDE** | Visual Studio 2022 or newer |
| **.NET Framework** | 4.8 (WPF Desktop App) |
| **Language** | C# |
| **Platform** | Windows OS |
| **Optional Tools** | Git, draw.io (for diagrams) |

---

### **Steps to Build and Run**
1. **Clone or extract** the project folder:
   ```bash
   git clone https://github.com/wiemkefli/IoTDeviceManager.git

Or open the provided ZIP folder in Visual Studio.

2. **Open Solution**
   -Launch Visual Studio
   -Open the solution file:
   ```bash
   IoTDeviceManager.sln

3. **Restore & Build**
    - Ensure the target framework is .NET Framework 4.8 .
    - Go to Build → Build Solution (or press Ctrl + Shift + B).
    
4. **Run the Application**
    - Press F5 (Start Debugging) or Ctrl + F5 (Start Without Debugging).
    - The main window (MainWindow.xaml) will appear with a seeded list of devices.
  
---

### **Summary of Completed Items**
| Module | Description | Status |
|-------:|-------------|:------:|
| **Device Management** | Add, update, delete IoT devices dynamically | Completed |
| **Real-Time Simulation** | Timer-based random telemetry (Temp, Humidity) | Completed |
| **Event Handling** | `TelemetryReceived`, `DeviceDisconnected`, `ErrorOccurred` | Completed |
| **Logging System** | Live logs via `ObservableCollection<LogEntry>` | Completed |
| **UI (WPF)** | MVVM-based interface bound to `MainViewModel` | Completed |
| **Flowchart & Architecture Diagram** | Included as images/PDF | Completed |
| **Error Handling** | Graceful handling of simulated failures | Completed |
| **Future Extension Plan** | Lightweight cloud extension proposal | Documented |

---

### **Tools / Libraries Used**
| Tool / Library | Purpose |
|----------------|---------|
| **C# (.NET Framework 4.8)** | Core application and models |
| **WPF (XAML)** | UI layer & data binding |
| **MVVM Pattern** | Separation of concerns (View, ViewModel, Model) |
| **System.Timers** | Periodic telemetry simulation |
| **ObservableCollection\<T\>** | Real-time UI updates |
| **INotifyPropertyChanged** | Property change notifications |
| **Dispatcher.Invoke** | Thread-safe UI updates from background timer |
| **draw.io / diagrams.net** | Flowchart & architecture diagrams |
| **Visual Studio Debugger** | Breakpoints, Watches, Output window |

---

## Architecture Summary

### **Pattern**
**MVVM (Model–View–ViewModel)**

### **Layers**
| Layer | Components | Description |
|------:|-----------|-------------|
| **Model** | `DeviceModel`, `LogEntry` | Represents device and log domain objects |
| **ViewModel** | `MainViewModel` | Holds state, commands, and event wiring |
| **View** | `MainWindow.xaml` | UI layout, bindings to `MainViewModel` |
| **Service** | `DeviceSimulator` | Emits telemetry & disconnection events on a timer |

---

### **Key Classes**
| File | Responsibility |
|-----:|----------------|
| `DeviceSimulator.cs` | Generates random telemetry, raises events, simulates disconnects |
| `MainViewModel.cs` | Manages device list, command handling, logs, and subscribes to simulator events |
| `RelayCommand.cs` | Lightweight command implementation for WPF buttons |

---

## Application Flow

- App starts → **seeded devices** are displayed  
- **Start Simulation** → the simulator emits telemetry **every 2 seconds**  
- UI updates via **`ObservableCollection`** + **property change notifications**  
- User may **Add / Update / Delete / Toggle** devices at any time  
- **Random disconnects** are simulated and recorded in **logs**



---

