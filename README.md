# Alura Searcher RPA

|||
|---|---|
| **Desenvolvido em** | .NET 8(C# 12.0) |
| **IDE** | Visual Studio 2022 Comunity(17.10.1^) |

# Passo a passo para inicialização do processo

## 1. Criação da tabela

 - Para criar a tabela utilizada na aplicação, basta executar o arquivo **create_schema.sql** presente em **sql\postgres**
    ```sql
    CREATE TABLE SearchResult (
        Id SERIAL PRIMARY KEY,
        SearchedValue VARCHAR(255) NOT NULL,
        SearchDate TIMESTAMP,
        Title VARCHAR(255) NOT NULL,
        Instructor VARCHAR(255),
        Duration VARCHAR(10),
        Description VARCHAR(255)
    );
    ```
 - Após criar a tabela na base de dados desejada, basta configurar a string de conexão presente no **appsettings.json** da aplicação(A conexão configurada é uma conexão padrão para um banco postgres local)
    ```json
    "ConnectionStrings": {
        "DbConnection": "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres;"
    },
    ```

## 2. Configurar caminho do webdriver
 - Por padrão a aplicação está utilizando o caminho vazio, que aponta para o chromedriver gerado automaticamente pela aplicação(atualmente na versão 130)
 - Caso seja necessário o apontamento para outra versão ou localização do navegador, basta incluir o caminho no **WebdriverPath** do arquivo **appsetting.json**
    ```json
    "WebdriverPath": ""
    ```

## 3. Inicializando a aplicação
 - Após as configurações realizadas, basta iniciar a aplicação com o projeto de inicialização sendo o **AluraSearcherRPA.Presentation**
