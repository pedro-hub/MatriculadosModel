# MatriculadosModel

Projeto web em **ASP.NET Core MVC (.NET 5)** para cadastro de alunos, cursos e controle de matrículas, usando **Entity Framework Core** com **SQL Server**.

## O que foi feito

O sistema foi estruturado com padrão MVC e repositórios para persistência dos dados:

- **Módulo de Alunos**: cadastrar, listar, editar e excluir alunos.
- **Módulo de Cursos**: cadastrar, listar, editar e excluir cursos.
- **Módulo de Matrículas**: relacionar aluno + curso + data de início, além de listar, editar e excluir matrículas.
- **Banco de dados relacional** com as tabelas:
  - `Alunos`
  - `Cursos`
  - `MatriculadosModel` (com chaves estrangeiras para aluno e curso)
- **Navegação principal** na interface para: Início, Alunos, Cursos e Matriculados.

## Tecnologias usadas

- ASP.NET Core MVC 5.0
- Entity Framework Core 5.0
- SQL Server
- Razor Views + Bootstrap

## Como usar o sistema

### 1) Pré-requisitos

- .NET SDK 5.0
- SQL Server (ex.: SQL Server Express)
- (Opcional) `dotnet-ef` para aplicar migrations via CLI

### 2) Configurar conexão com banco

No arquivo:

`AlunoECursos/appsettings.json`

ajuste a string de conexão em `ConnectionStrings:Database` para a instância do seu SQL Server.

### 3) Restaurar dependências

No diretório do projeto:

`AlunoECursos`

execute:

```bash
dotnet restore
```

### 4) Criar/atualizar o banco de dados

Com o `dotnet-ef` instalado, execute no mesmo diretório:

```bash
dotnet ef database update
```

Isso aplica as migrations existentes e cria as tabelas necessárias.

### 5) Executar a aplicação

Ainda no diretório `AlunoECursos`, execute:

```bash
dotnet run
```

A aplicação será iniciada normalmente em:

- `https://localhost:5001`
- `http://localhost:5000`

## Fluxo de uso na interface

1. Acesse a página inicial.
2. Vá em **Alunos** para cadastrar os alunos.
3. Vá em **Cursos** para cadastrar os cursos.
4. Vá em **Matriculados** para criar as matrículas vinculando aluno e curso.
5. Use os botões de **Alterar** e **Excluir** para manutenção dos registros.
