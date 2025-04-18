# Ordem de Serviço API

Este é um projeto simples de API para gerenciamento de ordens de serviço, desenvolvido com **C#**, **PostgreSQL** e **Angular**.

## Tecnologias Utilizadas

- **Backend**: ASP.NET Core
- **Banco de Dados**: PostgreSQL
- **Frontend**: Angular
- **ORM**: Entity Framework Core
- **Documentação**: Swagger

---

## Funcionalidades

- **CRUD de Usuários**: Gerenciamento de usuários do sistema.
- **CRUD de Serviços**: Gerenciamento de serviços disponíveis.
- **CRUD de Ordens de Serviço**: Gerenciamento de ordens de serviço associadas a usuários e serviços.
- **Autenticação e Autorização**: Implementação de autenticação baseada em JWT.
- **Relacionamentos**:
  - Uma ordem de serviço está associada a um usuário.
  - Uma ordem de serviço pode conter múltiplos serviços.

---

## Estrutura do Projeto

```plaintext
OrdemServicoAPI
├── backend
│   ├── Controllers       # Controladores da API
│   ├── Models            # Modelos de dados
│   ├── Repositories      # Repositórios para acesso ao banco de dados
│   ├── Services          # Lógica de negócios
│   ├── Program.cs        # Configuração do pipeline da aplicação
│   ├── Startup.cs        # Configuração de serviços
│   └── appsettings.json  # Configurações da aplicação
├── database
│   ├── migrations        # Migrations do Entity Framework
│   └── scripts.sql       # Scripts SQL para inicialização do banco
├── frontend
│   ├── src
│   │   ├── app           # Componentes e serviços do Angular
│   │   ├── assets        # Recursos estáticos
│   │   └── environments  # Configurações de ambiente
│   ├── angular.json      # Configuração do Angular CLI
│   ├── package.json      # Dependências do projeto Angular
│   └── tsconfig.json     # Configuração do TypeScript
└── README.md             # Documentação do projeto