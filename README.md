# 🚀 ASP.NET Core Custom Middleware Login

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Middleware-5C2D91?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)

A simple ASP.NET Core project demonstrating how to build a **Custom Conventional Middleware** that handles user login without using Controllers or Minimal APIs.

The middleware intercepts HTTP POST requests, reads the request body manually, validates user credentials, and returns the appropriate HTTP response.

---

# 📖 Project Overview

This project was built while learning the **Middleware Pipeline** in ASP.NET Core.

Instead of using Controllers, all request processing is handled inside a custom middleware to better understand how ASP.NET Core processes HTTP requests internally.

---

# ✨ Features

- ✅ Custom Conventional Middleware
- ✅ Middleware Extension Method
- ✅ Read Request Body Manually
- ✅ Parse Form Data
- ✅ Validate Email & Password
- ✅ Return Proper HTTP Status Codes
- ✅ Handle GET & POST Requests
- ✅ Clean Middleware Pipeline

---

# 🏗️ Project Structure

```
AspNetCore-Custom-Middleware-Login
│
├── CustomMiddleware
│   └── LoginMiddleware.cs
│
├── Program.cs
│
├── Properties
│
├── appsettings.json
│
└── README.md
```

---

# 🔄 Middleware Pipeline

```
                HTTP Request
                     │
                     ▼
        LoginMiddleware
             │
             ├──────────────┐
             │              │
             ▼              ▼
      POST "/"          Any Other Request
             │              │
             ▼              ▼
    Read Request Body     Next Middleware
             │
             ▼
      Validate Input
             │
             ▼
     Check Credentials
             │
      ┌──────┴───────┐
      ▼              ▼
 Success         Invalid Login
      │              │
      ▼              ▼
HTTP 200         HTTP 400
```

---

# ⚙️ How It Works

The middleware performs the following steps:

1. Intercepts every incoming request.
2. Checks whether the request is:

```
POST /
```

3. Reads the request body.
4. Parses:

- email
- password

5. Validates required fields.
6. Compares credentials.
7. Returns the appropriate HTTP response.

---

# 📮 API Testing

## ✅ GET Request

```
GET /
```

Response

```
200 OK

Hello from the next middleware!
```

---

## ✅ Valid Login

Request

```
POST /
```

Body

```
email=saif@saif.com
password=admin123
```

Response

```
200 OK

Login Successfully
```

---

## ❌ Invalid Login

Body

```
email=test@test.com
password=123
```

Response

```
400 Bad Request

Invalid Email or Password
```

---

## ❌ Missing Email

Body

```
password=admin123
```

Response

```
400 Bad Request

Email is required
```

---

## ❌ Missing Password

Body

```
email=saif@saif.com
```

Response

```
400 Bad Request

Password is required
```

---

## ❌ Empty Body

Response

```
400 Bad Request

Email is required
Password is required
```

---

# 🧪 Testing Tool

The project was tested using:

- Postman

---

# 💻 Technologies Used

- ASP.NET Core
- C#
- Custom Middleware
- RequestDelegate
- HttpContext
- StreamReader
- QueryHelpers
- Postman

---

# 📚 What I Learned

Through this project I learned:

- How ASP.NET Core Middleware works
- The Request Pipeline
- Conventional Middleware
- Middleware Extension Methods
- RequestDelegate
- HttpContext
- Reading the Request Body manually
- Parsing Form Data
- Returning custom HTTP Status Codes

---

# 🚀 Future Improvements

- JWT Authentication
- Password Hashing
- Logging Middleware
- Exception Middleware
- Dependency Injection
- Database Integration
- ASP.NET Core Identity

---

# 📷 Preview

> Add your Postman testing screenshot here.

Example:

```
README.md
images/
    middleware-testing.png
```

---

# 🤝 Connect With Me

### GitHub

https://github.com/Saifahmed3993

### LinkedIn

www.linkedin.com/in/saif-aldin-ahmed-abdelbar

---

⭐ If you found this project useful, consider giving it a star.
