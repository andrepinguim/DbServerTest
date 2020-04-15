# Teste DBServer

## 1. Para rodar o projeto

Antes da primeira execução, será necessário rodar o migrations.\
Na pasta **.\src\Dbst.Transaction.Infra.Data**, digite o seguinte comando:

`dotnet ef database update --startup-project ..\Dbst.Transaction.Api\`

(Caso seja necessário resetar a base de dados, simplesmente apague o arquivo .\src\Dbst.Transaction.Api\Transactions.db e rode o migrations novamente.)

Para rodar o projeto, entre na pasta **.\src** e digite:

`dotnet run`

Agora é só acessar [http://localhost:5000/swagger](http://localhost:5000/swagger) para acessar a API via swagger!\
Se preferir usar o Postman para fazer os requests, importe arquivo **DbServer-Test.postman_collection.json**.

## 2. Para rodar os testes

Na pasta **.\src** digite:

`dotnet test`

Caso queira ver os detalhes de cada teste via linha de comando, digite:

`dotnet test -v n`

Se desejar uma experiência melhor para visualização dos testes, use o plugin [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) para o Visual Studio Code.

## 3. Tecnologias utilizadas

- Visual Studio Code
- Asp.Net Core 2.2
- Swashbuckle/Swagger
- Entity Framework Core
- Sqlite
- XUnity
