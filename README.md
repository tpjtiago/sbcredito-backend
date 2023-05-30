# SBcredito

Neste desafio, aplicamos uma abordagem arquitetural em camadas, dividindo o projeto em Arquitetura de API, Dados, Domínio e Testes. Utilizamos padrões de projeto e boas práticas para garantir a manutenibilidade, legibilidade e design das classes.

Nosso código segue os princípios de Clean Code e SOLID, visando uma estrutura clara e de fácil compreensão. Para assegurar a qualidade do código, foram realizados testes unitários tanto na camada de Controller quanto na de Service.

Adotamos o conceito de repositório genérico, permitindo uma abstração eficiente da persistência de dados. Além disso, utilizamos o conceito de Entidades e Modelos para fornecer uma resposta personalizada ao front-end, sem a inclusão de propriedades desnecessárias. A abordagem code-first foi empregada, e para a persistência dos dados, escolhemos o banco SQL Server, utilizando o conceito de DB Context.

Para rodar o projeto localmente, basta executar a migração e o comando "update-database". O ambiente utilizado no projeto inclui .NET 6 e C#, juntamente com as tecnologias AutoMapper, Entity Framework, SqlServer, Fluent Validations e documentação com Swagger.

Com essa abordagem robusta e moderna, buscamos desenvolver um código limpo, de fácil manutenção e com uma arquitetura escalável.
