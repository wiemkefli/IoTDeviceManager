# 🛰️ IoTDeviceManager – Desktop IoT Simulation App

## 🧭 Overview
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

## ⚙️ a) Setup / Build Instructions

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
   git clone https://github.com/yourusername/IoTDeviceManager.git
or open the provided ZIP folder in Visual Studio.

Open Solution:

Launch Visual Studio

Open the solution file:

Copy code
IoTDeviceManager.sln
Restore & Build:

Ensure the target framework is .NET Framework 4.8

Go to Build → Build Solution (or press Ctrl + Shift + B)

Run the Application:

Press F5 (Start Debugging) or Ctrl + F5 (Start Without Debugging)

The main window (MainWindow.xaml) will appear with a seeded list of devices

🧩 b) Summary of Completed Items
Module	Description	Status
Device Management	Add, update, delete IoT devices dynamically	✅ Completed
Real-Time Simulation	Timer-based random telemetry (Temp, Humidity)	✅ Completed
Event Handling	TelemetryReceived, DeviceDisconnected, ErrorOccurred	✅ Completed
Logging System	Live logs via ObservableCollection<LogEntry>	✅ Completed
UI (WPF)	MVVM-based interface bound to MainViewModel	✅ Completed
Flowchart & Architecture Diagram	Included as images/PDF	✅ Completed
Error Handling	Graceful handling of simulated failures	✅ Completed
Future Extension Plan	Lightweight cloud extension proposal	✅ Documented

🧠 c) Tools / Libraries Used
Tool / Library	Purpose
C# (.NET Framework 4.8)	Core application and models
WPF (XAML)	UI layer & data binding
MVVM Pattern	Separation of concerns (View, ViewModel, Model)
System.Timers	Periodic telemetry simulation
ObservableCollection<T>	Real-time UI updates
INotifyPropertyChanged	Property change notifications
Dispatcher.Invoke	Thread-safe UI updates from background timer
draw.io / diagrams.net	Flowchart & architecture diagrams
Visual Studio Debugger	Breakpoints, Watches, Output window

🧱 Architecture Summary
Pattern: MVVM (Model–View–ViewModel)

Layer	Components	Description
Model	DeviceModel, LogEntry	Represents device and log domain objects
ViewModel	MainViewModel	Holds state, commands, and event wiring
View	MainWindow.xaml	UI layout, bindings to ViewModel
Service	DeviceSimulator	Emits telemetry & disconnection events on a timer

Key Classes

DeviceSimulator.cs → Generates random telemetry, raises events, simulates disconnects

MainViewModel.cs → Manages device list, command handling, logs, and subscribes to simulator events

RelayCommand.cs → Lightweight command implementation for WPF buttons

📜 Application Flow
Main Flow

App starts → seeded devices are displayed

Start Simulation → the simulator emits telemetry every 2 seconds

UI updates via ObservableCollection + property change notifications

User may Add / Update / Delete / Toggle devices at any time

Random disconnects are simulated and recorded in logs

🧭 System Flow / Architecture Diagram
Files Included: ArchitectureDiagram.pdf, Flowchart.png

Simulation Flow

scss
Copy code
DeviceSimulator (Random Data)
     ↓
Event Handlers (Telemetry / Error)
     ↓
MainViewModel (ObservableCollection)
     ↓
MainWindow.xaml (UI Display)
Future Cloud Extension Flow

pgsql
Copy code
IoT Device (e.g., ESP32)
   ↓  sends data via Wi-Fi (JSON/MQTT)
Firebase / Online Database
   ↓
Desktop App or Web Dashboard
   ↓
Display Live Status + Store Logs
🔧 Commands (Cheatsheet)
powershell
Copy code
# Build (from Developer PowerShell for VS)
msbuild .\IoTDeviceManager.sln /t:Build /p:Configuration=Release

# Run (from Visual Studio)
F5  # Start Debugging
🧾 Troubleshooting & Debugging Plan
No real-time updates?

Ensure Start Simulation was clicked

Check Output window for exceptions from DeviceSimulator.Tick()

UI freezes / cross-thread issues?

Verify UI updates happen via Application.Current.Dispatcher.Invoke(...)

Devices never come back online?

Current simulator includes disconnects but no auto-reconnect logic (by design).
You can add a simple reconnect rule in Tick() if needed.

Example Debug Trace

csharp
Copy code
System.Diagnostics.Debug.WriteLine(
    $"[{DateTime.Now:HH:mm:ss}] {d.Name} Online={d.IsOnline}");
🚀 Future Improvements (Fresh-Grad Friendly Roadmap)
Priority	Feature	Notes
High	User authentication for admin actions	Local or Firebase Auth
High	Cloud data storage	Firebase/Firestore or hosted MySQL
Medium	Basic alerts	Email/FCM when device offline or temp high
Medium	Web dashboard	React/Blazor to mirror WPF status & logs
Low	Mobile companion app	Flutter read-only dashboard
Low	Trends & charts	Rolling charts for temperature/uptime

📁 Included Files
File	Description
MainWindow.xaml	UI layout
MainWindow.xaml.cs	View code-behind (DataContext wiring)
MainViewModel.cs	Core logic, commands, event subscriptions
DeviceSimulator.cs	Timer-based telemetry + disconnect simulation
DeviceModel.cs	Device properties with INotifyPropertyChanged
LogEntry.cs	Log model with timestamp
RelayCommand.cs	Simple command implementation
App.xaml, App.xaml.cs	App entry and resources
ArchitectureDiagram.pdf	Architecture overview
Flowchart.png	Operation flowchart
README.md	This documentation

🎥 Optional Demo Video
If available, include a short screen recording showing:

Adding a device

Starting the simulation

Telemetry & disconnection logs appearing in real time

👤 Author
Name: Muhammad Qawiem Bin Zulkefli
Role: Developer / Fresh Graduate
Tech Stack: C# WPF (.NET Framework), MVVM, IoT Simulation
Institution: Moscow Aviation Institute (MAI)
Year: 2025
