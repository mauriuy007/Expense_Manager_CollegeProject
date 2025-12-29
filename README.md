# 💼 Expense Management System — Backend (API + Clean Architecture)

Backend for the Programming 3 mandatory assignment, implemented in C# (.NET 8) following Clean Architecture principles, with full layer separation, isolated use cases, decoupled repositories, JWT Authentication, and an auditing system.

This repository contains only the server (API + business logic).
**The client (user interface) is located in a separate repository.**

---

## 🧠 Overview

The backend allows managing:
-Users
-Teams
-Expenses
-Payments
-Audit logs

It includes:
-Complete REST API
-JWT authentication
-Isolated use cases
-Repositories implemented with EF Core
-Domain + Application validations
-Automatic logs for every operation

---

# 🏗️ Arquitectura del Backend

Structure based on **Clean Architecture**, organized as follows:
```
📦 ObligatorioP3-Backend/
│
├── 📁 LibreriaLogicaNegocio        # Capa de Dominio
│   ├── Entities/                   # Entidades del dominio
│   ├── VO/                         # Value Objects
│   ├── DomainInterfaces/           # Interfaces implementadas por entidades
│   ├── RepoInterfaces/             # Interfaces de repositorios
│   ├── Exceptions/                 # Excepciones personalizadas
│   └── ApplicationInterfaces/      # Interfaces de los casos de uso
│
├── 📁 LibreriaLogicaAplicacion     # Capa de Aplicación
│   ├── DTOs/                       # Transferencia de datos
│   ├── Mapper/                     # Conversión Entidad <-> DTO
│   └── CU/                         # Use Cases
│       ├── ExpenseCu/
│       ├── PaymentCu/
│       ├── TeamCu/
│       ├── UserCu/
│       └── LogCu/
│
├── 📁 Infraestructura              # Infraestructura + Datos
│   ├── EF/
│   │   ├── Context.cs             # DbContext
│   │   └── Config/                # Config de tablas
│   ├── Repos/                     # Implementación de repositorios
│   └── Migrations/
│
└── 📁 API                          # API REST (ASP.NET)
    ├── Controllers/               # Endpoints
    ├── Models/
    ├── Program.cs                 # DI + Jwt + EF
    └── appsettings.json           # Connection string
```



---

# 🔌 Available endpoints

## 🔐 Auth
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/login` | Returns a valid JWT to access the rest of the API |

---

## 👤 Users
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/users` | Creates user |
| GET | `/api/users` | List users |
| GET | `/api/users/{id}` | Get one user by id |

---

## 👥 Teams
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/teams` | Create team |
| GET | `/api/teams` | List teams |
| GET | `/api/teams/{teamId}/users` | Users from one team |

---

## 💸 Expenses
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/expenses` | Create an expense |
| GET | `/api/expenses` | Get all the expenses |
| GET | `/api/expenses/{id}` | Expense by id |

---

## 🧾 Payments
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/payments` | Create payment |
| GET | `/api/payments` | List payments |
| GET | `/api/payments/{id}` | Get payment by id |

---

## 📑 Logs
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/logs/{expenseId}` | Logs per expense |
| GET | `/api/logs/payment/{paymentId}` | Logs per payment |

---

# 📑 Auditing System

Every use case that creates or modifies an entity automatically generates a log containing:

-Entity ID
-Entity type
-Date/time
-Operation type
-Relevant data

Example:

```json
{
  "entityId": 5,
  "entityType": "Expense",
  "operation": "CREATE",
  "timestamp": "2025-11-03T12:45:00Z",
  "data": "Expense created successfully."
}
```

---

## 🛠️ Technologies Used

-C# (.NET 8)
-ASP.NET Web API
-Entity Framework Core
-SQL Server
-JWT Authentication
-Clean Architecture
-Dependency Injection
-LINQ
-DTO Pattern
-Azure for deployment

---

## 🚀 How to run

1. Clone repository:

2. Setting connection string on `appsettings.json` (Can be local or deployed)

3. Apply migrations:

```bash
dotnet ef database update
```

4. Run api:

```bash
dotnet run
```

5. Test endpoints on Postman or Swagger (For Swagger it must be enabled on Program.cs).

---

## 🧑‍💻 Author

Developed by Mauricio Parodi 🇺🇾
Backend for the Programming 3 mandatory assignment – ORT University.
