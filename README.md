# CityBreaks - Razor Pages, EF Core & SQLite

Este é um projeto ASP.NET Core Razor Pages desenvolvido como parte de estudos da matéria de Desenvolvimento Web com .NET e Bases de Dados para praticar conceitos como:

- Razor Pages
- Entity Framework Core (EF Core)
- SQLite
- Injeção de Dependência
- Filtros de busca com múltiplos critérios
- Soft delete (exclusão lógica)
- Relações entre entidades (ex: Propriedades e Cidades)

---

## 🔧 Tecnologias Utilizadas

- .NET
- Razor Pages
- EF Core
- SQLite
- Git

---

## 📦 Funcionalidades

- Cadastro de Cidades e Propriedades
- Filtro de Propriedades por:
  - Preço mínimo
  - Preço máximo
  - Nome da cidade
  - Nome da propriedade
- Exclusão lógica de propriedades (`DeletedAt`)
- Relacionamento `City -> Properties`
- Interface `IPropertyService` implementada com injeção de dependência

---

## 📁 Estrutura

CityBreaks.Web/
├── Data/
│ └── CityBreaksContext.cs
├── Models/
│ ├── City.cs
│ ├── Country.cs
│ └── Property.cs
├── Pages/
│ └── FilterProperties.cshtml
├── Services/
│ ├── ICityService.cs
│ ├── IPropertyService.cs
│ ├── CityService.cs
│ └── PropertyService.cs


---



