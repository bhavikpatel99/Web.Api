# SaaS-Based Multi-Tenant API in .NET Core

## 🚀 Overview

This project is a **SaaS-based API** built using **.NET Core**, implementing **multi-tenancy with row-level security**. It provides **Tenant Management** and **User CRUD operations**, ensuring secure data access per tenant.

## 📌 Features

- Multi-Tenant Architecture
- Row-Level Security using **TenantId**
- CRUD operations for **Users**
- Middleware for **Exception Handling** & **Request Logging**
- Uses **Stored Procedures** for Database Access

## 🏗️ Project Structure

```
WebApi.Solution
│-- WebApi                  # API Project
│-- WebApi.Common           # Common Utilities
│-- WebApi.Entity           # Entity Models
│-- WebApi.Repository       # Data Access Layer
│-- WebApi.Service          # Business Logic Layer
│-- WebApi.Middleware       # Middleware for Logging & Exception Handling
```

## ⚡ Installation & Setup

### 1️⃣ Clone the Repository

```sh
git clone https://github.com/yourusername/your-repo.git
cd your-repo
```

### 2️⃣ Configure Database Connection

Update **appsettings.json** with your database connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;"
}
```

### 3️⃣ Run Database Migrations (If Applicable)

```sh
dotnet ef database update
```

### 4️⃣ Run the API

```sh
dotnet run --project WebApi
```

## 🛠️ API Endpoints

### **Tenant Management**

✅ **Create a Tenant**

```http
POST /api/tenant/create
```

**Request:**

```json
{
  "name": "Company A"
}
```

### **User Management**

✅ **Create a User**

```http
POST /api/user/create
```

**Request:**

```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "tenantId": "550e8400-e29b-41d4-a716-446655440000"
}
```

✅ **Get Users by Tenant**

```http
GET /api/user/{tenantId}
```

✅ **Update a User**

```http
PUT /api/user/update/{id}
```

✅ **Delete a User**

```http
DELETE /api/user/delete/{id}
```

## 🔧 Technologies Used

- **.NET Core** 8.0
- **Entity Framework Core**
- **SQL Server** (Stored Procedures)
- **Middleware for Logging & Security**
- **Swagger (API Documentation)**

## 📜 License

This project is licensed under the **MIT License**.

## 🤝 Contributing

1. Fork the repository 🍴
2. Create a new branch 📂 (`git checkout -b feature-branch`)
3. Commit your changes ✅ (`git commit -m 'Added new feature'`)
4. Push the branch 🚀 (`git push origin feature-branch`)
5. Create a Pull Request 🔄

---

🔹 **Author:** Bhavik Patel\
🔹 **GitHub:** bhavikpatel99\
🔹 **Email:** patel021299\@yahoo.com

