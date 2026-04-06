# 🎓 Student Management API

## 📌 Overview

This is a **Student Management System API** built using **ASP.NET Core Web API**.
It provides full **CRUD operations (Create, Read, Update, Delete)** for managing student data.

The project follows a **clean layered architecture (Controller → Service → Repository)** and demonstrates real-world backend development practices.

---

## 🚀 Features

* Add new student
* Retrieve all students
* Update student details
* Delete student by ID
* JWT Authentication (Secure APIs)
* Swagger API documentation
* SQL Server with Stored Procedures
* Clean and maintainable code structure
* High performance using Dapper

---

## 🛠️ Technologies Used

* ASP.NET Core Web API
* C#
* SQL Server
* Dapper
* JWT Authentication
* Swagger

---

## ⚙️ Setup & Run (Step-by-Step)

### 1. Clone Repository

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
```

### 2. Open Project

Open the project in **Visual Studio** or **VS Code**

### 3. Setup Database

* Open SQL Server
* Create database: `ZestIndia`
* Run `database.sql` file (included in project)

### 4. Configure Connection String

Update in `appsettings.json`:

```json
"ConnectionStrings": {
  "constr": "Server=.;Database=ZestIndia;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 5. Run Migration (Identity Setup)

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

If migration already exists:

```bash
dotnet ef database update
```

✔ Identity tables are handled using EF Core
✔ Student data is handled using Dapper + Stored Procedures

### 6. Run Project

```bash
dotnet run
```

OR run using **Visual Studio (F5)**

### 7. Open Swagger

Open in browser:

```
https://localhost:xxxx/swagger
```

---

## 🔐 JWT Authentication

Sample credentials:

* Email: [admin@test.com](mailto:admin@test.com)
* Password: 123456

Steps:

1. Call Login API to get token
2. Click **Authorize** in Swagger
3. Enter:

```
Bearer YOUR_TOKEN
```

---

## 📡 API Endpoints

| Method | Endpoint          | Description      |
| ------ | ----------------- | ---------------- |
| POST   | /api/student      | Create student   |
| GET    | /api/student      | Get all students |
| PUT    | /api/student      | Update student   |
| DELETE | /api/student/{id} | Delete student   |

---

## 📁 Database Script

* File: `database.sql`
* Includes table creation and stored procedures

---

## 🎯 Key Concepts Used

* Layered Architecture
* Dependency Injection
* JWT Authentication
* Dapper with Stored Procedures
* Clean Code Principles

---

## 📌 Author

Vivek Pratap Kanaujiya

---

> 💡 Note:
> You can run migrations using either **.NET CLI** or **Visual Studio Package Manager Console**:
>
> - CLI:
>   ```bash
>   dotnet ef migrations add InitialCreate
>   dotnet ef database update
>   ```
>
> - Visual Studio:
>   ```powershell
>   Add-Migration InitialCreate
>   Update-Database
>   ```
>
> Both commands perform the same operation.
