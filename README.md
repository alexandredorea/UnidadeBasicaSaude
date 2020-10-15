
# Desafio: Unidades Básicas de Saúde (UBS) :pill:

[![GitHub issues][ImagemProblema]][Defeito] [![GitHub license][ImagemLicenca]][Licenca]

[//]: # (Links de referências para os badges deste repositório)

[ImagemProblema]: <https://img.shields.io/github/issues/alexandredorea/UBS.svg?style=flat-square>
[ImagemLicenca]: <https://img.shields.io/github/license/alexandredorea/UBS.svg?style=flat-square>


## Introdução

**Este projeto reflete uma adaptação de um desafio/teste** realizado como parte de um processo seletivo ao qual participei para vaga de Desenvolvedor DotNET.

Além da adaptação ao desafio, buscou-se atender os requisitos solicitados originalmente, além de ter sido adicionado conhecimentos concernentes a gestão de projetos, gerência de configuração, analises de sistemas, DevOps e etc, **apenas para fins de estudos**.

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

Você trabalha para o Ministério da Saúde e o Ministro da Saúde decidiu que chegou a hora de implementar uma nova funcionalidade que 
permita os usuários consultar Unidades Básicas de Saúde mais próximas deles para então tomar a decisão de qual a melhor unidade de 
poderá atendê-lo.

Sua função é implementar uma API que permita consultar e listas as 5 Unidades Básicas de Saúde (UBSs) mais próximas das coordenadas 
de latitude e longitude fornecidas como parâmetro. Por fim, o resultado deverá ser apresentedo ordenado pela avaliação de desempenho 
dessas unidades da mais alta para a mais baixa.


## A Documentação

Cada projeto (assembly) contém um arquivo README.md com mais detalhes sobre a implementação deste desafio.
E eles foram divididos da seguinte forma:

1. [Host][CamadaHost]
2. [Domínio][CamadaDominio]
3. [Infra][CamadaDominio]
4. [Teste][CamadaTeste]

[//]: # (Links de referências para documentação)

[CamadaHost]: <>
[CamadaDominio]: <>
[CamadaInfra]: <>
[CamadaTeste]: <>


## A Divisão e Estrutura do Projeto

**A solução está divida nas seguintes camadas:**

* **Host**:
  - WebApi: Expõe um método HTTP GET para retornar os dados solicitados no cenário descrito.
* **Domínio**:
  - Domínio: Camada responsável por conter entidades/modelos com um domínio rico (metodos, atributos e comportamentos), as regras de negócio, etc para atender o cenário descrito acima.
  - Mediador: Camada que faz mediação entre a WebApi e a camanda de serviço, e isola o acesso direto a outros modulos.
  - Serviço: Camada responsável por solicita as informações à camada de acesso a dados.
* **Infra**: Camada de acesso a dados, onde encontra-se o acesso aos dados da aplicação.
* **Testes**:
  - Teste: Camada que garante os testes funcionais da aplicação e do que foi solicitado no cenário;

**A estrutura do projeto da seguinte forma:**

* **Host**:
  - src\AMcom.Ubs.WebApi
* **Domínio**:
  - src\AMcom.Ubs.Dominio
  - src\AMcom.Ubs.Dominio.Mediador
  - src\AMcom.Ubs.Dominio.Servico
* **Infra**:
  - src\AMcom.Ubs.Infra.BancoDeDados
* **Testes**:
  - test\AMcom.Ubs.WebApi


## Observação

1. O desafio foi resolvido observando as boas práticas de desenvolvimento web;
2. O código "server-side" foi desenvolvido buscando seguir as convenções RESTful (ainda que parcialmente com apenas o HTTP GET);
3. Para as Injeções de Dependências (onde é relacionado as interfaces com as classes e registrados no container), buscou-se observar como a Microsoft sugere hoje de boa prática;
4. Como conhecimento extra a este desafio (não foi solicitado), foi aplicado conceitos de Metodologia Ágil [Kanban e Scrum][Projeto], os quais foram definidas as *tasks* para uma melhor organização.


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
