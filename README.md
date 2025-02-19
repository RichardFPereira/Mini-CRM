# Mini CRM - ASP.NET Core
Este projeto representa um mini CRM (Customer Relationship Management) desenvolvido em C# com ASP.NET Core para gerenciamento de Clientes, Contatos, Endereços e Situações de cliente. A aplicação expõe uma API REST que realiza operações de CRUD (Create, Read, Update, Delete), além de retornar dados relacionados (Contatos e Endereços) através do Entity Framework Core.

## Funcionalidades Principais
* Cadastro de Clientes: armazenamento de informações básicas (Nome, CNPJ, Data de Cadastro, Situação).
* Cadastro de Contatos: cada cliente pode ter vários contatos (nome, telefone, e-mail).
* Cadastro de Endereços: cada cliente pode ter vários endereços (CEP, Logradouro, etc.).
* Situação do Cliente: tabela auxiliar para indicar status (ATIVO, INATIVO, EM PAUSA).
* Validação de Dados: uso de Data Annotations (Required, StringLength, Regex etc.) para validar as entradas.
* Documentação via Swagger (pode ser acessado em `/swagger`) para testar e consultar os endpoints.

## Tecnologias Utilizadas
* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server / Azure SQL

## Estrutura de Pastas (Simplificada)
``` mathematica
MiniCRM
┣ Controllers
│   ┣ ClienteController.cs
│   ┣ ContatoController.cs
│   ┣ EnderecoController.cs
│   ┗ SituacaoClienteController.cs
┣ DTOs
│   ┣ ClienteDTOs
│   ┣ ContatoDTOs
│   ┣ EnderecoDTOs
│   ┗ SituacaoClienteDTOs
┣ Entities
│   ┣ Cliente.cs
│   ┣ Contato.cs
│   ┣ Endereco.cs
│   ┗ SituacaoCliente.cs
┣ Context
│   ┗ MiniCRMContext.cs
┣ Migrations
┣ Program.cs
┣ appsettings.json
┗ README.md
```
## Endpoints Principais

### Clientes
![image](https://github.com/user-attachments/assets/b3e47c8d-fbb6-47a8-a89e-852e039b72a3)

### Contatos
![image](https://github.com/user-attachments/assets/cfbc3e71-159f-4076-8593-46bd05ce8dad)

### Endereços
![image](https://github.com/user-attachments/assets/da4215b4-ef20-4485-8408-b68344428312)

### Situação
![image](https://github.com/user-attachments/assets/2b69607d-c3ab-41bb-a142-864207c7f77a)

