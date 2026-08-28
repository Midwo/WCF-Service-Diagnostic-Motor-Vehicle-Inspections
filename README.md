# WCF Service – Diagnostic Motor Vehicle Inspections, Workshop & Vin InfoCar

This project contains the backend WCF Service for a multi‑module system handling vehicle diagnostics, workshop operations, and VIN‑based information lookup.
It is one part of a larger system and exposes service methods used by two separate Windows Forms client applications.

Client applications (with documentation) are available here:
https://github.com/Midwo/WCF-Client---Windows-Form---Diagnostic-Motor-Vehicle-Inspections

## 1. Tech Stack
* C#
* Visual Studio
* RazorEngine (template generation)
* MS SQL Server
* WCF Service
* ADO.NET

## 2. Overview

The WCF Service provides the communication layer between client applications and the SQL database.
It exposes methods for reading, writing, updating, and validating data related to:
* diagnostic inspections,
* workshop repairs,
* VIN information,
* user authentication,
* email notifications.

All operations are executed through WCF contracts, ensuring a clear separation between UI and backend logic.
    
## 3. Functionalities
### Read Operations

Uses service methods to retrieve data from the SQL database.
Returned values include DataSet, string, bool and other types depending on the operation.

### Write & Edit Operations

Provides methods for saving and editing diagnostic, workshop, and VIN‑related data.
All changes are executed through SQL queries inside the service layer.

### Authorization & Decryption

Implements authentication by decrypting encrypted login and password values.
Credentials are validated against the database.

###  Email Sending 

Supports sending email notifications (e.g., order confirmations, workshop updates) using RazorEngine templates.

## 4. Screenshots
### 1. WCF Service Overview
<img src="https://github.com/Midwo/WCF-Service-Diagnostic-Motor-Vehicle-Inspections/blob/master/WCFservice_diagnostic/WCF_service_carreview1.png" width="600" alt="Photo1">
<img src="https://github.com/Midwo/WCF-Service-Diagnostic-Motor-Vehicle-Inspections/blob/master/WCFservice_diagnostic/WCF_service_carreview2.png" width="600" alt="Photo2">

### 2. Authorization
<img src="https://github.com/Midwo/WCF-Service-Diagnostic-Motor-Vehicle-Inspections/blob/master/WCFservice_diagnostic/WCF_service_carreview3.png" width="700" alt="Photo3">

## 5. Architecture Role

The WCF Service is the backend layer of the system:
* receives requests from two Windows Forms clients,
* performs SQL operations,
* decrypts and validates credentials,
* generates email messages,
* returns structured responses to the UI.
  
This creates a clear Client → WCF Service → SQL Database workflow.

## 6. Summary

The Diagnostic Motor Vehicle Inspections, Workshop & Vin InfoCar WCF Service provides a complete backend communication layer for two client applications.
It handles data retrieval, updates, authentication, and email generation, forming the core logic of a multi‑module automotive system.

