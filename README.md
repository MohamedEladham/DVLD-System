# DVLD-System

A Driving & Vehicle License Department (DVLD) Management System built with **C#**, **Windows Forms**, **SQL Server**, and **3-Tier Architecture**.

**Project Status:** Under Development

## Overview

DVLD-System is a desktop application designed to manage driving license department operations.

The project follows a 3-Tier Architecture to separate the presentation layer, business logic, and data access responsibilities.

## Technologies

- C#
- Windows Forms
- .NET Framework 4.8
- SQL Server
- ADO.NET
- Visual Studio 2022

## Solution Structure

The solution consists of six projects:

- **DVLD** – Windows Forms presentation layer.
- **DVLD_BL** – Business logic layer.
- **DVLD_DAL** – Data access layer.
- **DVLD_Models** – Data models.
- **DVLD_Infrastructure** – Infrastructure and shared technical components.
- **DVLD_Shared** – Shared components.

Internal project dependencies use Visual Studio Project References.

## Current Functionality

The implemented functionality includes:

- People management.
- User management.
- Roles and permissions management.
- Applications management.
- First-time driving license application processing.

The project is still under development, and additional functionality may be added in future updates.

## Database

The repository includes SQL scripts to help initialize the database:

- `Database/01_Create_DB_DVLD2_Schema.sql` – Creates the database and its schema.
- `Database/02_SeedData.sql` – Inserts the required initial reference data.
- `Database/03_CreateAdminAccount.sql` – Creates the initial administrator account.

## Getting Started

For development environment requirements, database initialization, connection configuration, and application startup instructions, see:

**[SETUP_GUIDE.md](SETUP_GUIDE.md)**

## Notes

- The project targets **.NET Framework 4.8**.
- SQL Server is required to run the application.
- The application is under active development and is not presented as a production-ready system.
