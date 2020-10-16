## Domínio: Camada de serviços (Services)

Esta camada é responsável por criar ou obter os dados provenientes da camada de acesso a dados (Infra) e disponibilizá-los para a Web API.

### Objetivo

Criar um método que retorne a lista de UBSs para a Web API com os valores preenchidos nas propriedades do objeto de retorno (ver classe `RetornoUnidadeSaudeContrato.cs`): 

* Nome; 
* Endereco;
* Avaliacao;

- Este método deve receber os valores de latitude e longitude fornecidos pelo método HTTP GET da Web API e filtrar as 5 UBS mais próximas das coordenadas passadas.
- O endereço deve ser uma combinação dos campos `dsc_endereco`, `dsc_bairro` e `dsc_cidade` (ver cabeçalho do arquivo `ubs.csv`).
- O campo `dsc_estrut_fisic_ambiencia` contém a avaliação de desempenho para cada UBS (ver cabeçalho do arquivo `ubs.csv`). Use os dados deste campo ou defina o seu próprio mapeamente de avaliação para retornar as UBSs ordenadas por desempenho do mais alto para o mais baixo.

### Requisitos:

1. Implementar os provedores para que suas dependências sejam injetadas e utilizadas na Web API.
2. Injetar qualquer dependência necessária para o uso da camada de acesso a dados, pois os objetos devem estar desacoplados entre as camadas.

### DICAS:

- Você pode fazer uso de uma API externa, site, serviço ou implementar o seu próprio algoritmo de cálculo de distância entre as coordenadas (latitude e longitude).
- Lembre-se de criar o que for necessário para a injeção de dependência na Web API.
- Qualquer acesso a camada de dados deve ser feita por meio desta camada.
- Você pode usar qualquer componente que seja necessário para a sua implementação funcionar desde que este componente possa ser instalável via Nuget e esteja disponível na web.