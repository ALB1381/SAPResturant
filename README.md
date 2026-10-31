
# SAPResturant

**SAPResturant** is a distributed, multi-tenant restaurant management system designed to maintain high availability and seamless data synchronization across multiple physical stations (Cashier, Kitchen, Bar) during active service hours.

## 🏗 System Architecture

The core infrastructure minimizes reliance on external internet stability by operating primarily over a localized network.

* **Localized Synchronization:** Utilizes SQL Server localized synchronization over an internal router network to ensure data consistency across all nodes.
* **Multi-Tenancy:** Structured to isolate and manage data for different restaurant operations or branches independently.
* **Decoupled Architecture:** Built using a clean, layered architecture in C#/.NET to separate data access, business logic, and API endpoints.

## 📁 Repository Structure

The solution is divided into several focused projects to maintain a clean separation of concerns:

* **`SAPResturant.API`**: The entry point for the application. Contains the REST endpoints (or Minimal APIs) that handle incoming requests from the client terminals (KDS, Cashier, Bar) and route them to the application layer.
* **`SAPResturant.Application`**: The core business logic layer. It processes commands and queries, enforcing restaurant-specific rules before interacting with the database.
* **`SAPResturant.Application.PublicDTO`**: Contains Data Transfer Objects (DTOs) used to pass data safely between the API and the client applications without exposing internal database models.
* **`SAPResturant.Data`**: The data access layer. Contains the Entity Framework configurations, database contexts, and migrations required to manage the SQL Server databases.
* **`MyApplication`**: The client-side application or front-end implementation interacting with the API to provide user interfaces for staff.

## 🚀 Workflows (In Progress)

The system is currently being built to support the following zone-specific workflows:

1. **Front-of-House (Cashiers):** Handle order entry, table assignments, and payments. Captures initial transactions and syncs tickets to preparation zones.
2. **Kitchen Display System (KDS):** Receives food-specific orders in real-time, allowing kitchen staff to track and update preparation statuses.
3. **Bar Terminal:** Routes beverage items directly to the bar queue, separating drink fulfillment from the main kitchen traffic.

## 🛠 Tech Stack

* **Language:** C#
* **Framework:** .NET
* **Database:** SQL Server (with localized sync capabilities)
* **ORM:** Entity Framework Core

## 📋 Development Roadmap

* [x] Establish solution structure and layered architecture.
* [x] Configure Entity Framework contexts (`SAPResturant.Data`).
* [ ] Finalize internal router network configurations for node discovery.
* [ ] Implement robust SQL Server synchronization logic for offline/local environments.
* [ ] Complete multi-tenant database partitioning logic.
* [x] Persist kitchen order transitions from Pending to Cooking to Ready.
* [ ] Finalize real-time UI updates for `MyApplication` (Kitchen and Bar dashboards).
