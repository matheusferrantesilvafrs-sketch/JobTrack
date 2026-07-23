<div align="center">

# 💼 JobTracker

Uma aplicação Full Stack desenvolvida para organizar e acompanhar candidaturas a vagas de emprego.

<img src="docs/jobtracker-preview.gif" alt="Preview do JobTracker" width="900"/>

</div>

---

## 📖 Sobre o projeto

O **JobTracker** nasceu com o objetivo de facilitar a organização de processos seletivos, reunindo em um único lugar informações importantes sobre cada candidatura.

A aplicação permite cadastrar, visualizar, editar e excluir candidaturas por meio de uma interface web integrada a uma API desenvolvida em ASP.NET Minimal API.

Além de servir como uma ferramenta de organização, o projeto também foi desenvolvido para colocar em prática conceitos de desenvolvimento Full Stack utilizando o ecossistema .NET.

---

## ✨ Funcionalidades

- 📄 Cadastro de candidaturas
- 📋 Listagem dinâmica
- ✏️ Edição de informações
- 🗑️ Exclusão de candidaturas
- 🔗 Link direto para a vaga
- 📅 Registro da data da candidatura
- 📊 Controle do status da candidatura

---

## 🛠 Tecnologias

### Backend

- C#
- ASP.NET Minimal API
- Entity Framework Core

### Frontend

- HTML5
- CSS3
- JavaScript

### Banco de Dados

- MySQL

---

## 🏗 Arquitetura

```text
Frontend (HTML + CSS + JavaScript)
                │
             Fetch API
                │
ASP.NET Minimal API (.NET)
                │
      Entity Framework Core
                │
             MySQL
```

---

## 🚀 Como executar

Clone o repositório

```bash
git clone https://github.com/SEU-USUARIO/JobTrack.git
```

Entre na pasta

```bash
cd JobTrack
```

Configure a Connection String no arquivo `appsettings.json`.

Execute as migrations

```bash
dotnet ef database update
```

Inicie a aplicação

```bash
dotnet run
```

Depois acesse

```
http://localhost:5000
```

---

## 📚 Conceitos praticados

Durante o desenvolvimento deste projeto foram aplicados conceitos como:

- Desenvolvimento de APIs REST
- CRUD completo
- Entity Framework Core
- Comunicação entre Front-end e Back-end
- Persistência de dados
- Consumo de APIs utilizando Fetch API
- Organização de aplicações Full Stack

---

## 📌 Próximas melhorias

- Pesquisa de candidaturas
- Filtros por status
- Dashboard com métricas
- Notificações
- Responsividade para dispositivos móveis

---

## 👨‍💻 Autor

**Matheus Ferrante Silva**

Estudante de Engenharia da Computação.

LinkedIn: www.linkedin.com/in/matheus-ferrante-silva-252b55369

