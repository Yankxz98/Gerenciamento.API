# Gerenciador de CPF/CNPJ

Este projeto é um sistema CRUD (Create, Read, Update, Delete) para gerenciamento de CPFs e CNPJs. Ele permite adicionar, alterar, excluir e listar registros.

## Funcionalidades

- **Adicionar**: Insira novos registros de CPF ou CNPJ no sistema.
- **Alterar**: Atualize informações de registros existentes.
- **Excluir**: Remova registros desnecessários ou desatualizados.
- **Listar**: Visualize todos os registros armazenados.

## Pré-requisitos

Antes de iniciar, certifique-se de que você tem o .NET Core SDK instalado em sua máquina. Além disso, você precisará de um SQL Server/PostGreSql disponível para hospedar o banco de dados.

## Configuração do Projeto

1. Clone o repositório do projeto para sua máquina local.
2. Crie um banco de dados SQL Server ou PostGreSql e configure a string de conexão no arquivo `appsettings.json` do projeto, utilizando a chave "DefaultConnection".

## Instalação e Execução

Para configurar e iniciar o projeto, siga os passos abaixo:

1. Abra o terminal ou cmd do Visual Studio.
2. Navegue até a pasta do projeto.
3. Execute os comandos para criar o banco de dados através das migrations:

    ```
    dotnet ef database update
    ```

    Caso encontre algum erro, tente criar uma migration inicial com:

    ```
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

4. Após a configuração do banco de dados, inicie a aplicação com:

    ```
    dotnet run
    ```

5. Acesse a aplicação através do navegador no endereço indicado pelo terminal.

## Uso

Para começar a usar a aplicação:

1. Adicione um usuário através da interface de registro.
2. Faça login com as credenciais do usuário criado.
3. Comece a gerenciar CPFs/CNPJs através da interface do usuário.