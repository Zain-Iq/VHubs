# Vehicle Inventory Management System - WPF Application

This is a desktop-based **Vehicle Inventory Management System** built with **WPF (.NET Framework)** and **C#**. It simulates a rental company's internal tool to manage their vehicle inventory, supporting operations such as adding, editing, deleting, and viewing vehicle records.

## ✨ Features

- Maintain a collection of vehicles (Cars and Motorcycles)
- Dynamically assign unique vehicle IDs
- Add new vehicle records with details
- Edit or delete existing vehicle information
- Support for multiple vehicle categories and types using enums
- Easily reset the collection to its initial state
- Real-time form population and validation using WPF data-binding
- Fully in-memory operation (no persistent storage)

## 💻 Technologies Used

- C#
- WPF (.NET Framework)
- Object-Oriented Programming (OOP)
- Enums, Collections, and LINQ
- Visual Studio IDE

## 📷 UI Overview

The user interface includes:
- TextBoxes for Name, Rental Price, and ID (read-only)
- ComboBoxes for Category and Type selection
- RadioButtons to select vehicle type (Car or Motorcycle)
- ListBox for displaying vehicle names
- CheckBox to toggle reservation status
- Buttons for Add, Edit, Delete, Clear, Clear ListBox, and Reset

## 🚗 Vehicle Structure

The system models vehicles using an object-oriented hierarchy:

- **Vehicle** (abstract)
  - Fields: `Id`, `Name`, `RentalPrice`, `Category`, `Type`, `IsReserved`
  - Properties with validation and encapsulation
- **Car** : Vehicle
- **Motorcycle** : Vehicle

### Enums:
```csharp
public enum VehicleCategory { Hatchback, Sedan, SUV, Cruiser, Sports, Dirt }
public enum VehicleType { Standard, Exotic, Bike, Trike }
