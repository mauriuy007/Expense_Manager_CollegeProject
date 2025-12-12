# 💼 Sistema de Gestión de Gastos — Backend (API + Clean Architecture)

Backend del obligatorio de **Programación 3**, implementado con **C# (.NET 8)** siguiendo los principios de **Clean Architecture**, con separación total de capas, casos de uso, repositorios desacoplados, JWT Authentication y sistema de auditoría.

Este repositorio contiene **únicamente el servidor (API + lógica de negocio)**.  
El cliente (interfaz de usuario) se encuentra en **otro repositorio**.

---

## 🧠 Descripción General

El backend permite gestionar:

- Usuarios  
- Equipos  
- Gastos  
- Pagos  
- Logs de auditoría

Incluye:

- API REST completa  
- Autenticación JWT  
- Casos de uso aislados  
- Repositorios implementados con EF Core  
- Validaciones en Dominio + Aplicación  
- Logs automáticos por cada operación  

---

# 🏗️ Arquitectura del Backend

Estructura basada en **Clean Architecture**, organizada así:

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

# 🔌 Endpoints Disponibles

## 🔐 Auth
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/auth/login` | Retorna un JWT válido para acceder al resto de la API |

---

## 👤 Users
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/users` | Crear usuario |
| GET | `/api/users` | Listar usuarios |
| GET | `/api/users/{id}` | Obtener un usuario |

---

## 👥 Teams
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/teams` | Crear equipo |
| GET | `/api/teams` | Listar equipos |
| GET | `/api/teams/{teamId}/users` | Usuarios de un equipo |

---

## 💸 Expenses
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/expenses` | Crear gasto |
| GET | `/api/expenses` | Obtener todos los gastos |
| GET | `/api/expenses/{id}` | Gasto por ID |

---

## 🧾 Payments
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | `/api/payments` | Crear pago |
| GET | `/api/payments` | Listar pagos |
| GET | `/api/payments/{id}` | Obtener pago por ID |

---

## 📑 Logs
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/logs/{expenseId}` | Logs de un gasto |
| GET | `/api/logs/payment/{paymentId}` | Logs de un pago |

---

# 📑 Sistema de Auditoría

Cada caso de uso que crea o modifica una entidad genera un log automático con:

- ID de la entidad  
- Tipo de entidad  
- Fecha/hora  
- Tipo de operación  
- Datos relevantes  

Ejemplo:

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

## 🛠️ Tecnologías Utilizadas

- C# (.NET 8)
- ASP.NET Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Clean Architecture
- Dependency Injection
- LINQ
- DTO Pattern

---

## 🚀 Cómo Ejecutar el Backend

1. Clonar repositorio:

```bash
git clone https://github.com/tuusuario/backend-p3.git
```

2. Configurar connection string en `appsettings.json`

3. Aplicar migraciones:

```bash
dotnet ef database update
```

4. Ejecutar la API:

```bash
dotnet run
```

5. Probar endpoints con Postman, Thunder Client o Swagger (si está habilitado).

---

## 🧑‍💻 Autor

Desarrollado por **Mauricio Parodi** 🇺🇾  
Backend del obligatorio de **Programación 3 – Universidad ORT**.
