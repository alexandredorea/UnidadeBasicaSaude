## Domínio: Camada de orquestração ou mediação (Mediator)

Esta camada é responsável por orquestrar/mediar o que é solicitado entre a Web API e o serviço, com a intenção de isola o acesso direto a outros modulos.

### Objetivo

Você deve orquestra/mediar as requisições entre a Web API e a camada de serviços.

### Requisitos:

1. A Web API deve encaminhar um comando/contrato (`command`) ao mediador, e, esta requisição deve ser recebida nesta camada para o serviço disponível tratar as informações;

### DICAS:

- Esta camada deve ser a única visível pela Web API.