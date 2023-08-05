
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
- **GET /admin/apartments/{id}:** Get an apartment by ID.
- **PUT /admin/apartments/{id}:** Update an existing apartment.
- **DELETE /admin/apartments:** Delete an apartment by ID.
- **GET apartments/{id}:** Get all the apartments belonging to the user.

### BillController

- **POST - /admin/bills:** Create Bill
- **POST - /admin/bills/monthly-bill:** Create Monthly Bill
- **GET - /admin/bills:** Get All Bills
- **GET - /admin/bills/{id}:** Get A Bill by Id
- **GET - /admin/bills/paid-bills:** Get Paid Bills
- **GET - /admin/bills/unpaid-bills:** Get Unpaid Bills
- **GET - /admin/bills/paid-bills-costs:** Get Total Cost of Paid Bills
- **GET - /admin/bills/unpaid-bills-costs:** Get Total Cost of Unpaid Bills
- **PUT - /admin/bills/{id}:** Update Bill
- **DELETE - /admin/bills/{id}:** Delete Bill

### DebtController

- **GET - /admin/debts:** Get All Debts
- **GET - /admin/debts/unpaid-debts:** Get All Unpaid Debts
- **GET - /admin/debts/paid-debts:** Get All Paid Debts
- **GET - /admin/debts/{id}:** Get A Debt by Id
- **POST - /admin/debts:** Create Debt
- **PUT - /admin/debts/{id}:** Update Debt
- **GET - /admin/debts/paid-debts-total-costs:** Get Total Cost of Paid Debts
- **GET - /admin/debts/unpaid-debts-total-costs:** Get Total Cost of Unpaid Debts
- **GET - /admin/debts/debts-total-costs:** Get Total Cost of All Debts
- **DELETE - /admin/debts/{id}:** Delete Debt

### MessageController

- **GET - /admin/messages:** Get All Messages
- **GET - /admin/messages/{id}:** Get A Message by Id
- **GET - /admin/messages/unread-messages:** Get Unread Messages
- **POST - /admin/messages/{id}:** Sending Message

### UserController

- **POST - /admin/users:** Create User
- **GET - /admin/users:** Get All Users
- **PUT - /admin/users/{id}:** Update User
- **DELETE - /admin/users:** Delete User

### ApartmentController (User-specific):

- **GET - /apartments/{id}:** Get All Apartments for a User

### BillController (User-specific):

- **GET - /bills/{id}:** Get All Bills for a User
- **PUT - /bills/{id}:** Pay a Bill

### CardController (User-specific):

- **GET - /cards/{id}:** Get All Cards for a User
- **POST - /cards/{id}:** Add a Card for a User
- **PUT - /cards/{id}:** Update a Card

### Authentication

The API uses token-based authentication. To access protected endpoints, you need to include an access token in the Authorization header of your HTTP requests.

### Usage

Once the API is running, you can use tools like Postman or your preferred HTTP client to interact with the various endpoints.

### Contributing

Contributions to the Apartment Management API are welcome! If you find any issues or want to add new features, please submit a pull request.

### License

The Apartment Management API is licensed under the MIT License. Feel free to use and modify the code as needed.