# 🛰️ IoTDeviceManager – Desktop IoT Simulation App

## 🧭 Overview
**IoTDeviceManager** is a WPF desktop application developed in **C# (.NET Framework)** that simulates communication between multiple IoT devices and a central management system.  
It allows users to **add, update, delete, toggle device status**, and **view real-time telemetry logs** such as temperature, humidity, and connection events.  

This project demonstrates practical knowledge of **event-driven programming**, **MVVM architecture**, and **simulated IoT device communication**.

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
