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

## 4 - Escalonador
Projeto de faculdade que simula o funcionamento de um escalonador

### Tecnologias:
 - Java

## 5 - RDtoBigQuery
Função hospedada no Google Cloud que busca dados da  API do RD Station e envia para o Big Query

### Tecnologias:
 - .NET 3.1
 - C#
 - Google Cloud Functions Framework
 - Google Cloud BigQuery V2

## 6 - RabbitMQSender
Aplicação faz autenticação 2.0 na API do RD Station e retorna os contatos da api.

### Tecnologias:
 - .NET 6
 - C#

 ### Padrões e Princípios:
 - [Ports and Adapter Pattern](https://alistair.cockburn.us/hexagonal-architecture/)
 - [Dependency Injection](https://stackify.com/dependency-injection/)