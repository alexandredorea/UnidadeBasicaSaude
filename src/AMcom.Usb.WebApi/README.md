## Web API

É o local onde expõe um método HTTP GET para retornar os dados solicitados pelo usuário.

### Objetivo

Implementação da WebApi deve listar as Unidades Básicas de Saúde (UBS) conforme os requisitos abaixo:


### Requisitos:

1. Criar um método acessível por HTTP GET para expor os dados da WebApi.
2. Este método deverá retornar uma lista das 5 UBSs (Unidades Básicas de Saúde) mais próximas de um ponto (latitude e longitude) e ordenada por avaliação de desempenho (da mais alta para a mais baixa).
3. O retorno do método deve ser um array com somente 5 (ou menos) registros de objetos no formato JSON, como no exemplo abaixo:

```json
    [
      {
        "Nome": "UBS1",
        "Endereco": "R. das UBSs, 123",
        "Avaliacao": "Desempenho muito acima da média"
      },
      {
        "Nome": "UBS2",
        "Endereco": "R. das UBSs, 456",
        "Avaliacao": "Desempenho acima da média"
      },
      {
        "Nome": "UBS3",
        "Endereco": "R. das UBSs, 789",
        "Avaliacao": "Desempenho mediano ou um pouco abaixo da média"
      },
      ...
    ]
```

### Observação:

- Neste ponto, poderá ser usado o Postman ou qualquer Cliente REST para realizar os testes da WebApi;
- Poderá ser usado quaisquer recursos disponíveis (desde que sem custo) para executar os cálculos e a lógica necessária para realizar este exercício.
