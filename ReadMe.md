
# Apartment Management API Documentation

The Apartment Management API is a RESTful web service designed to facilitate the management of apartments, bills, debts, messages, users, and payments in an apartment complex.

### Table of Contents

    1. Introduction
    2. Technologies
    3. Installation
    4. API Endpoints
    5. Authentication
    6. Usage
    7. Contributing
    8. License

## Introduction

The Apartment Management API allows property managers and residents to perform various operations related to their apartment complex. It provides endpoints to add, update, retrieve, and delete apartments, bills, debts, messages, users, and more.

## Technologies

The API is built using the following technologies:

**ASP.NET Core:** A cross-platform, high-performance framework for building web applications.

**C#:** The primary language used for programming the API logic.

**Entity Framework Core:** A lightweight and extensible ORM (Object-Relational Mapping) for database access.

**AutoMapper:** A mapping library to simplify the mapping between DTOs (Data Transfer Objects) and entities.

**Microsoft SQL Server:** The chosen database engine to store and manage data.

**JWT (JSON Web Tokens):** Used for authentication and secure access to protected endpoints.

## Installation

To run the Apartment Management API locally, follow these steps:

    1. Clone the repository to your local machine.
    2. Make sure you have .NET Core SDK installed.
    3. Open the terminal or command prompt and navigate to the project's root directory.
    4. Run the following command to build and run the API:

```bash
  dotnet run
```

The API will start running at https://localhost:5001 (or http://localhost:5000).

## API Endpoints

The API provides the following endpoints:

### ApartmentController

- **POST /admin/apartments:** Create a new apartment.
- **GET /admin/apartments:** Get all apartments.
- **PUT /admin/apartments/{id}:** Update an existing apartment.
- **DELETE /admin/apartments:** Delete an apartment by ID.

### BillController

- **POST /admin/bills:** Create a new bill.
- **POST /admin/bills/monthly-bill:** Create monthly bills.
- **GET /admin/bills:** Get all bills.
- **GET /admin/bills/{id}:** Get a bill by ID.
- **GET /admin/bills/paid-bills:** Get all paid bills.
- **GET /admin/bills/unpaid-bills:** Get all unpaid bills.
- **GET /admin/bills/paid-bills-costs:** Get the total cost of paid bills.
- **GET /admin/bills/unpaid-bills-costs:** Get the total cost of unpaid bills.

### DebtController

- **GET /admin/debts:** Get all debts.
- **GET /admin/debts/unpaid-debts:** Get all unpaid debts.
- **GET /admin/debts/paid-debts:** Get all paid debts.
- **GET /admin/debts/{id}:** Get a debt by ID.
- **POST /admin/debts:** Create a new debt.
- **PUT /admin/debts/{id}:** Update an existing debt.
- **GET /admin/debts/paid-debts-total-costs:** Get the total cost of paid debts.
- **GET /admin/debts/unpaid-debts-total-costs:** Get the total cost of unpaid debts.
- **GET /admin/debts/debts-total-costs:** Get the total cost of all debts.

### MessageController

- **GET /admin/messages:** Get all messages.
- **GET /admin/messages/{id}:** Get a message by ID.
- **GET /admin/messages/unread-messages:** Get all unread messages.
- **POST /admin/messages:** Send a new message.

### UserController

- **POST /admin/users:** Create a new user.
- **GET /admin/users:** Get all users.
- **PUT /admin/users/{id}:** Update an existing user.
- **DELETE /admin/users:** Delete a user by ID.

### CardController

- **POST /cards:** Create a new card.

### GetMyBillsController

- **GET /getmybills/{id}:** Get all bills for a specific user.

### PayBillController

- **PUT /paybill/{id}:** Pay a bill.

### Authentication

The API uses token-based authentication. To access protected endpoints, you need to include an access token in the Authorization header of your HTTP requests.

### Usage

Once the API is running, you can use tools like Postman or your preferred HTTP client to interact with the various endpoints.

### Contributing

Contributions to the Apartment Management API are welcome! If you find any issues or want to add new features, please submit a pull request.

### License

The Apartment Management API is licensed under the MIT License. Feel free to use and modify the code as needed.