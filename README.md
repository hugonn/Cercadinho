# Cercadinho
Cercadinho com meus projetos modelos que vou implementando ao longo do tempo! 

## 1 - System File Watcher
Aplicação que monitora a criação de arquivos .DAT em uma pasta " %HOMEPATH%/in ", faz o processamento desses dados, que estão em um formato específico, e grava em um arquivo de saída na pasta " %HOMEPATH%/out ".

### Tecnologias:
 - .NET6
 - C#
 
### Padrões e Princípios:
 - [Clean Architecture](https://blog.cleancoder.com/)
 - [Ports and Adapter Pattern](https://alistair.cockburn.us/hexagonal-architecture/)
 - [SOLID](https://blog.cleancoder.com/uncle-bob/2020/10/18/Solid-Relevance.html)


 ## 2 - RabbitMQSender
Aplicação que faz o envio de mensagens via RabbitMQ

### Tecnologias:
 - .NET 6
 - C#

 ### Padrões e Princípios:
 - [Ports and Adapter Pattern](https://alistair.cockburn.us/hexagonal-architecture/)
 - [Dependency Injection](https://stackify.com/dependency-injection/)
 
 ## 3 - S3 Localstack
Aplicação que faz upload de arquivo no S3 utilizando o localstack para reproduzir ambiente da aws

### Tecnologias:
 - .NET Framework 4.8
 - C#

 ### Padrões e Princípios:
 - [SOLID](https://blog.cleancoder.com/uncle-bob/2020/10/18/Solid-Relevance.html)

### Tecnologias:
 - Java

## 4 - RDFunctions
Pasta que contém as funções desenvolvidas em .NET Core que são hospedadas no Google Cloud e fazem chamadas para a API do RD Station retornando os dados requisitados.

###  - RDApiToBigQuery

Função que faz a chamadas da API de CRM do RD Station 

### - RDTokenFunctionCallback

Função de callback para a API de Marketing que possui AUTH 2.0

### - RDToken

Função que faz a chamada para a RD Station recuperar o Token

### Tecnologias:
 - .NET 3.1
 - C#
 - Google Cloud Functions Framework
 - Google Cloud BigQuery V2

