# 🏷️ CRUD Usuários API (EF InMemory)

---

## 🚧 Status do Projeto
![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-ASP.NET%20Core-239120?style=for-the-badge&logo=csharp&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-InMemory-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-UI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

---

## 📚 Índice
- [Sobre o Projeto](#-sobre-o-projeto)
- [Funcionalidades](#-funcionalidades)
- [Tecnologias](#-tecnologias)
- [Arquitetura](#arquitetura)
- [Como Rodar Localmente](#-como-rodar-localmente)
- [Rotas](#-rotas)
- [Estrutura de Pastas](#-estrutura-de-pastas)
- [Testes](#-testes)
- [Licença](#-licença)

---

## 📝 Sobre o Projeto
API REST desenvolvida em **C# / ASP.NET Core (.NET 8)** para **cadastro de usuários** com persistência em **Entity Framework Core + InMemoryDatabase**.

Campos cadastrados:
- Nome
- E-mail (**chave do recurso**)
- Senha
- Código de Pessoa
- Lembrete de Senha
- Idade
- Sexo

Swagger (local):
- `http://localhost:5154/swagger`

---

## ✨ Funcionalidades
- Criar usuário (**POST**)
- Listar todos os usuários (**GET**)
- Buscar usuário por e-mail (**GET**)
- Atualizar usuário por e-mail (**PUT**)
- Atualização parcial por e-mail (**PATCH**)
- Remover usuário por e-mail (**DELETE**)
- Banco **InMemory** (dados reiniciam a cada execução)

---

## 🛠 Tecnologias
- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **EF Core InMemory Provider**
- **Swagger / Swashbuckle**

---

## Arquitetura
Organização por responsabilidade:

- **Controllers/**  
  Endpoints HTTP (CRUD) e regras básicas de validação/resposta.

- **Data/**  
  `AppDbContext` (EF Core) configurado com **InMemoryDatabase**.

- **Models/**  
  Entidades do domínio (ex: `Usuario`).

- **Dtos/**  
  Contratos de entrada:
  - `UsuarioCreateRequest` (POST/PUT)
  - `UsuarioUpdateRequest` (PATCH)

---

## 🔧 Como Rodar Localmente

### Pré-requisitos
- **.NET SDK 8**

### Rodar a API
Na raiz do repositório:

```bash
cd backend/CadastroApiEF/CadastroApi
dotnet restore
dotnet run
```
A aplicação sobe em:
- `Now listening on: http://localhost:5154`

Acesse o Swagger:
- `http://localhost:5154/swagger`

---

## 🧭 Rotas

Base:
- `/api/Usuarios`

Endpoints:
- **POST** `/api/Usuarios` → cria usuário
- **GET** `/api/Usuarios` → lista todos
- **GET** `/api/Usuarios/{email}` → busca por e-mail
- **PUT** `/api/Usuarios/{email}` → substitui dados do usuário
- **PATCH** `/api/Usuarios/{email}` → atualiza parcialmente
- **DELETE** `/api/Usuarios/{email}` → remove usuário

---

## 📁 Estrutura de Pastas

```text
CRUD-USUARIOS-EF-INMEMORY/
├─ backend/
│  ├─ CadastroApiEF/
│  │  └─ CadastroApi/
│  │     ├─ Controllers/
│  │     │  └─ UsuariosController.cs
│  │     ├─ Data/
│  │     │  └─ AppDbContext.cs
│  │     ├─ Dtos/
│  │     │  ├─ UsuarioCreateRequest.cs
│  │     │  └─ UsuarioUpdateRequest.cs
│  │     ├─ Models/
│  │     │  └─ Usuario.cs
│  │     ├─ Properties/
│  │     │  └─ launchSettings.json
│  │     ├─ Program.cs
│  │     ├─ CadastroApi.csproj
│  │     ├─ CadastroApi.http
│  │     ├─ appsettings.json
│  │     └─ appsettings.Development.json
│  └─ testes_swagger/
│     └─ testes_Swagger.pdf
├─ .gitignore
├─ LICENSE
└─ README.md

```
---

## 🧪 Testes
Os testes do CRUD foram executados via **Swagger UI** e documentados em PDF:

- `backend/testes_swagger/testes_Swagger.pdf`

## 📄 Licença
Este projeto está sob a licença **MIT**. Veja o arquivo `LICENSE`.
