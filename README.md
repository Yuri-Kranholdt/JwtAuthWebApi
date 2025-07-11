# 🔐 Web API de Autenticação com JWT e OAuth2 (.NET 9)

API RESTful desenvolvida com ASP.NET Core 8.0 para **cadastro e login de usuários**, utilizando **JWT** para autenticação e **OAuth2** integrado via Swagger (Swashbuckle).

---

## Tecnologias Utilizadas

- .NET 9.0 (ASP.NET Core)
- ASP.NET Identity (ou autenticação customizada)
- JWT (JSON Web Token)
- OAuth2 
- Swagger (via Swashbuckle)
- SQL Server 
- Entity Framework Core

---

## Funcionalidades

- Cadastro de novos usuários
- Login com geração de token JWT
- Autenticação com Bearer Token
- Proteção de rotas com `[Authorize]`
- Testes interativos via Swagger com OAuth2

---

## Como usar

### 1. Configurar o banco de dados

va em appsettings.json e modifique a connection string e adicione uma chave token no campo token

### 2. Faça as migrações
```bash
dotnet ef database update
```

### 3. Rode a aplicação

```
dotnet run
```

Acesse em:

`https://localhost:7248/swagger`
