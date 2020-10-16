# Desafio: Unidades Básicas de Saúde (UBS) :pill:

[![GitHub issues][ImagemProblema]][Defeito] [![GitHub license][ImagemLicenca]][Licenca]

[//]: # (Links de referências para os badges deste repositório)

[ImagemProblema]: <https://img.shields.io/github/issues/alexandredorea/UBS.svg?style=flat-square>
[ImagemLicenca]: <https://img.shields.io/github/license/alexandredorea/UBS.svg?style=flat-square>


## Introdução

**Este projeto reflete uma adaptação de um desafio/teste** realizado no ano de 2018, como parte de um processo seletivo ao qual participei para vaga de Desenvolvedor DotNET.

Buscou-se atender os requisitos solicitados originalmente, além de ter sido adicionado conhecimentos (não solicitados) concernentes a [metodologia ágil][Projeto], gestão de projetos, gerência de configuração, analises de sistemas, DevOps e etc neste repositório **apenas para fins de estudos**.


## Os recursos utilizados no desenvolvimento do desafio:

|Recurso e Ferramentas                     |Documentos                                           |Download                   |
|------------------------------------------|-----------------------------------------------------|---------------------------|
|Conceitos de DDD (Domain Driven Design)   |[Tutorial][GuiaDDD]                                  |N/A                        |
|Repositório de Dados (Repository Pattern) |[Tutorial][GuiaRepositoryPattern]                    |N/A                        |
|Mediação (Mediator Pattern)               |[Tutorial][GuiaMediator1] e [Tutorial][GuiaMediator2]|N/A                        |
|Documentacao com o Swagger                |[Tutorial][GuiaSwagger1] e [Tutorial][GuiaSwagger2]  |N/A                        |
|GeoCoordinate.NetCore                     |[Guia][GuiaGeoCoordinate]                            |[Release][DownloadGeoCoord]|
|Visual Studio 2019                        |[Guia][GuiaVS2019]                                   |[IDE][IDEVS2019]           |
|SQL Server 2019                           |[Guia][GuiaSQL2019]                                  |[IDE][IDESQL2019]          |
|Linguagem C#                              |[Guia][GuiaCSharp]                                   |N/A                        |
|NET Core 3.1                              |[Guia][GuiaNetCore]                                  |[Release][DownloadNetCore] |
|NET Standard 2.0                          |[Guia][GuiaNetStandard1] e [Guia][GuiaNetStandard2]  |N/A                        |
|EF Core 3.1                               |[Guia][GuiaEntityCore]                               |N/A                        |

[//]: # (Links de referências para o quadro de recursos utilizados)

[GuiaDDD]: <http://www.agileandart.com/2010/07/16/ddd-introducao-a-domain-driven-design/>
[GuiaRepositoryPattern]: <https://medium.com/@renicius.pagotto/entendendo-o-repository-pattern-fcdd0c36b63b>
[GuiaMediator1]: <https://medium.com/qualyteam-engineering/design-pattern-mediator-6b4722b5a1ce>
[GuiaMediator2]: <https://medium.com/jundevelopers/mediator-pattern-com-mediatr-asp-net-core-2-2-6d8d2e3dc3c5>
[GuiaSwagger1]: <https://medium.com/@arikardnoir/porque-usar-swagger-na-sua-api-e80c4ed15190>
[GuiaSwagger2]: <https://gabrielschade.github.io/2018/06/18/swagger.html>
[GuiaGeoCoordinate]: <https://github.com/ghuntley/geocoordinate>
[DownloadGeoCoord]: <https://www.nuget.org/packages/GeoCoordinate.NetCore/1.0.0.1>
[GuiaVS2019]: <https://docs.microsoft.com/pt-br/visualstudio/ide/>
[IDEVS2019]: <https://www.visualstudio.com/pt-br/downloads/>
[GuiaSQL2019]: <https://docs.microsoft.com/pt-br/sql/sql-server/sql-server-technical-documentation>
[IDESQL2019]: <https://www.microsoft.com/pt-br/sql-server/sql-server-downloads>
[GuiaCSharp]: <https://docs.microsoft.com/pt-br/dotnet/csharp/>
[GuiaNetCore]: <https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=netcore31>
[DownloadNetCore]: <https://dotnet.microsoft.com/download/dotnet-core/3.1>
[GuiaNetStandard1]: <https://docs.microsoft.com/pt-br/dotnet/standard/net-standard>
[GuiaNetStandard2]: <https://docs.microsoft.com/pt-br/archive/msdn-magazine/2017/september/net-standard-demystifying-net-core-and-net-standard>
[GuiaEntityCore]: <https://docs.microsoft.com/pt-br/ef/core/>


## O Cenário

Você trabalha para o Ministério da Saúde e o atual Ministro, decidiu que chegou a hora de implementar um novo projeto, cuja proposta
é uma API para ajudar população brasilera em geral a localizar a **Unidade Básica de Saúde (UBS)** *mais próxima* de sua localização 
ou localização informada.

Sua função é implementar uma API que permita consultar e listas as 5 Unidades Básicas de Saúde (UBSs) mais próximas das coordenadas 
de latitude e longitude fornecidas como parâmetro. Por fim, o resultado deverá ser apresentedo ordenado pela avaliação de desempenho 
dessas unidades da mais alta para a mais baixa.


## A Documentação

Cada projeto (assembly) contém um arquivo README.md com mais detalhes sobre a implementação deste desafio.
E eles foram divididos e estruturados da seguinte forma:


## A Divisão e Estrutura do Projeto

**A solução está divida nas seguintes camadas:**

* **Host**:
  - [WebApi][ProjetoWebApi]: Expõe um método HTTP GET para retornar os dados solicitados no cenário descrito.
* **Domínio**:
  - [Domínio][ProjetoDominio]: Camada responsável por conter entidades/modelos com um domínio rico (metodos, atributos e comportamentos), as regras de negócio, etc para atender o cenário descrito acima.
  - [Mediador][ProjetoMediador]: Camada que faz mediação entre a WebApi e a camanda de serviço, e isola o acesso direto a outros modulos.
  - [Serviço][ProjetoServico]: Camada responsável por solicita as informações à camada de acesso a dados.
* **Infra**: 
  - [Banco de Dados][ProjetoDados]: Camada de acesso a dados, a qual é responsável por prover os dados para a aplicação.
* **Testes**:
  - [Teste][ProjetoTeste]: Camada que garante os testes funcionais da aplicação e do que foi solicitado no cenário;


[//]: # (Links de referências para documentação)

[ProjetoWebApi]: <https://github.com/alexandredorea/UnidadeBasicaSaude/tree/develop/src/Modelo.Usb.WebApi>
[ProjetoDominio]: <https://github.com/alexandredorea/UnidadeBasicaSaude/tree/develop/src/Modelo.Usb.Dominio>
[ProjetoMediador]: <https://github.com/alexandredorea/UnidadeBasicaSaude/tree/develop/src/Modelo.Usb.Dominio.Mediador>
[ProjetoServico]: <https://github.com/alexandredorea/UnidadeBasicaSaude/tree/develop/src/Modelo.Usb.Dominio.Servico>
[ProjetoDados]: <https://github.com/alexandredorea/UnidadeBasicaSaude/tree/develop/src/Modelo.Usb.Infra.BancoDeDados>
[ProjetoTeste]: <https://github.com/alexandredorea/UnidadeBasicaSaude/tree/develop/test/Modelo.Usb.Teste>

**A estrutura do projeto:**

```
├── 0. doc
│   
├── 1. src
│   │
│   ├── 1.1. Host
│   │   │
│   │   └── Modelo.Ubs.WebApi
│   │   
│   ├── 1.2. Domínio
│   │   │
│   │   ├── Modelo.Ubs.Dominio
│   │   ├── Modelo.Ubs.Dominio.Mediador
│   │   └── Modelo.Ubs.Dominio.Servico
│   │   
│   └── 1.3. Infra
│       │
│       └── Modelo.Ubs.Infra.BancoDeDados
└── 2. test
    │
    └── Modelo.Ubs.Test
```

## Observação

1. O desafio foi resolvido observando as boas práticas de desenvolvimento web;
2. O código "server-side" foi desenvolvido buscando seguir as convenções RESTful (ainda que parcialmente com apenas o HTTP GET);
3. Para as Injeções de Dependências (onde é relacionado as interfaces com as classes e registrados no container), buscou-se observar como a Microsoft sugere hoje de boa prática em projeto Net Core;
4. Como conhecimento extra a este desafio (não foi solicitado), foram aplicado conceitos de Metodologia Ágil [Kanban e Scrum][Projeto], os quais foram definidas as *tasks* para uma melhor organização.

--------------

## Andamento do Projeto

Para se ter uma ideia do andamento do projeto [clique aqui][Projeto] e tenha acesso ao **quadro Kanban** para ver as *tasks*.

[//]: # (Links de referências o quadro Kanban do projeto)

[Projeto]: <https://github.com/alexandredorea/UnidadeBasicaSaude/projects/1>


## Tem perguntas ou sugestão de melhoria?

Sinta-se à vontade em abrir um [Issue][Defeito] ou [Pull Request][PullRequest], este último usando o Padrão Gitflow (preferencialmente).

[//]: # (Links de referências aos problemas neste projeto)

[Defeito]: <https://github.com/alexandredorea/UnidadeBasicaSaude/issues>
[PullRequest]: <https://github.com/alexandredorea/UnidadeBasicaSaude/pulls>
[Licenca]: <https://github.com/alexandredorea/UnidadeBasicaSaude/blob/master/LICENSE>

--------------

## :star: Deixe uma estrela 

Se você gostou deste projeto ou te ajudou de alguma forma com algum conceito, clica na estrelinha, isso ajuda muito.