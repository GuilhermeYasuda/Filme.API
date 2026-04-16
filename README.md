# FilmeApi.API

API REST para gerenciamento de filmes (CRUD) construída com ASP.NET Core e Entity Framework Core.

## Descrição

Aplicação de exemplo que implementa operações CRUD para filmes. Projeto direcionado ao .NET 10 e inspirado no tutorial do CodeWithMukesh.

## Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (opcional: outro provedor EF Core)

## Pré-requisitos

- .NET 10 SDK
- Visual Studio 2022/2026 ou VS Code
- Instância do banco de dados (por exemplo, SQL Server)

## Instalação e execução

1. Clone o repositório:

   git clone https://github.com/GuilhermeYasuda/Filme.API.git

2. Abra a solução no Visual Studio ou via linha de comando no diretório do projeto `FilmeApi.API`.

3. Configure a connection string no appsettings.json (ou no Secret Manager / variáveis de ambiente):

   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR;Database=FilmeDb;Trusted_Connection=True;"
   }

4. Execute as migrations (EF Core) e atualize o banco de dados:

   dotnet ef database update --project FilmeApi.API

   (Caso não existam migrations, crie uma com `dotnet ef migrations add InitialCreate --project FilmeApi.API`)

5. Execute a aplicação:

   dotnet run --project FilmeApi.API

Ou inicie pelo Visual Studio (F5).

## Endpoints principais

Exemplos (assumindo base URL http://localhost:5000 ou o URL exibido ao executar):

- GET /api/filmes - listar filmes
- GET /api/filmes/{id} - obter filme por id
- POST /api/filmes - criar novo filme (JSON no corpo)
- PUT /api/filmes/{id} - atualizar filme
- DELETE /api/filmes/{id} - apagar filme

Exemplo CURL para criar filme:

curl -X POST http://localhost:5000/api/filmes -H "Content-Type: application/json" -d "{ \"titulo\": \"Meu Filme\", \"genero\": \"Ação\", \"duracao\": 120 }"

## Testes

Se houver testes automatizados no repositório, execute-os via Test Explorer do Visual Studio ou:

dotnet test

## Contribuição

Pull requests são bem-vindos. Abra uma issue para discutir mudanças maiores antes de implementá-las.

## Licença

Verifique o arquivo LICENSE no repositório ou adicione a licença desejada.

## Agradecimentos

Este projeto foi implementado seguindo o tutorial "ASP.NET Core WebAPI CRUD with Entity Framework Core (Full Course)" de Mukesh Murugan. Mais informações e o conteúdo original do tutorial: https://codewithmukesh.com/blog/aspnet-core-webapi-crud-with-entity-framework-core-full-course/
