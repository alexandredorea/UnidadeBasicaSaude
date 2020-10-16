## Infra: Camada de acesso a dados

Esta camada é responsável por prover os dados para a aplicação.

## Objetivo

Importar o arquivo `ubs.csv` fornecido no diretório `docs` do projeto (seja usando um provedor de banco de dados em memória), ou uma lista, ou uma coleção para que seja consultada pela camada de serviços por meio de um repositório.

### Requisitos:

1. Carregar o arquivo em anexo (`ubs.csv`) para uma lista/coleção de objetos (ver classe `UnidadeSaude.cs`) e retornar por meio de um repositório os dados para serem utilizados pela camada de serviço (ver classe `UnidadeBasicaServico.cs`).

### DICAS:

- Use algum provedor de dados em memória ou mesmo arquivo. 
- A fonte de dados está disponível no arquivo `ubs.csv` no diretório `docs` deste projeto e incluído na solução.
- Não esquecer de usar Injeção de Dependência;
- Esta camada não deve ser acessada diretamente pela Web API. Qualquer acesso a esta camada de dados deve ser feita por meio da camada de serviços.
- Você pode usar qualquer componente que seja necessário para a sua implementação funcionar desde que este componente possa ser instalável via Nuget e esteja disponível na web.
- Caso você use uma fonte de dados externa a aplicação, inclua todos os componentes que sejam necessários para a execução da aplicação em outro ambiente sem que ela pare de funcionar.
- Quanto mais completa esta camapa com mapeamentos das entidades relacionais, etc, mais completo será o seu exercício e mais pontos ele somará.
