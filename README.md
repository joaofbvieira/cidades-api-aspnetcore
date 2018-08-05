# cidades-api-aspnetcore

## Requisitos
.NET Core 2.0

## Como executar a API
A solução deve ter como projeto principal `Cidades.WebApi`.
Para visualizar a documentação da API, deverá acessar a url `./swagger`.

## Base de dados
A base de dados não depende de SGBD instalado na máquina, pois utiliza o Entity Framework Core 2, utilizando uma base de dados em memória.

## Testes unitários
Todos os testes unitários de encontram no projeto `Cidades.Application.Tests`, classe `CidadesServiceTest`.

## Realizar testes com a API
**Obter	a	lista	de	cidades	que	são	capitais	ordenadas	por	nome**
   - GET
   - Url: api/Capitais
   
**Obter	a	lista	e	quantidade de cidades	filtradas	por	um	atributo**
   - GET
   - Url: api/Cidades
   - Parâmetros (todos opcionais):
      - ibge
      - nome
      - uf
      - microRegiao
      - mesorregiao
      
**Obter	o	estado	com	a	maior	e	menor	quantidade	de	cidades	e	a	quantidade	de	cidades**
   - GET
   - Url: api/Estados

**Obter	uma	página da lista	total	de cidades**
   - GET
   - Url: api/Cidades

**Permitir remover	uma	cidade existente**
   - DELETE
   - Url: api/Cidades
   - Parâmetro (obrigatório):
      - ibge
