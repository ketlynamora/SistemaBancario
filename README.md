# SistemaBancario

> Sistema Bancario no qual uma conta de banco está vinculada ao titular, sendo possível realizar alguns métodos de cadastros, atualização, saque, deposito, exclusão, salvando no banco de dados PostgreSQL, validando as operações pelo Swagger.

# Usage
### windows
* .NET Core 
* Docker
* API REST
* SWAGGER
* PostgreSQL

## Docker

Gerado o ambiente de pgAdmin 4 e de uma de uma instância do PostgreSQL através de containers.

## PgAdmin 4

Url:
```sh
http://localhost:16543
```
Login:
```sh
ketlyn.dev@gmail.com
```
Senha:
```sh
PgAdmin2019!
```
<img width=600 src="https://user-images.githubusercontent.com/77113613/132099684-3f3efa92-017f-4df9-8a34-261c1254b468.png">

Fornecendo as credenciais de acesso que estavam no arquivo docker-compose.yml aparecerá então o painel de gerenciamento do pgAdmin 4:

<img width=600 src="https://user-images.githubusercontent.com/77113613/132099820-1962ba80-a21c-44cd-b1d5-e5af6265f278.png">


Ao criar a conexão para acesso à instância do PostgreSQL levar em conta as seguintes considerações:

## PostgreSQL
Host name:
```sh
banking-system-postgres
```
Port:
```sh
5432
```
UserName:
```sh
postgres
```
Senha:
```sh
PgAdmin2019!
```

## Melhorias

* Implementar testes unitários no projeto, usando xUnit.

## Referências para criar o ambiente no Docker

<a href="https://renatogroffe.medium.com/postgresql-pgadmin-4-docker-compose-montando-rapidamente-um-ambiente-para-uso-55a2ab230b89">Artigo Renato Groffe</a>

