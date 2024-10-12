# Employee Management API

## Objetivo

Esta API foi desenvolvida para facilitar o cadastro, atualização, consulta e exclusão de funcionários. A API possibilita:
- Criar, editar, consultar e deletar registros de funcionários.
- Listar todos os funcionários ou filtrar por nome.

Cada funcionário contém os seguintes campos:
- **Nome**
- **E-mail**
- **CPF**
- **Telefone/Celular**
- **Data de Nascimento**
- **Tipo de Contratação** (PJ ou CLT)
- **Status** (Ativo ou Inativo)

## Stack Tecnológica

- **.NET Core** com **Entity Framework** para a criação dos endpoints e persistência de dados.
- **MySQL** para gerenciamento do banco de dados.
- **Swagger** para documentação da API e testes interativos.

## Endpoints da API

### Estrutura e Descrição

### Filosofia DDD 
``` bash
├───Controllers
├───Data
├───Entites
├───Migrations
├───Objects
│   ├───Enums
│   ├───Errors
│   ├───Request
│   │   └───EmployeeRequest
│   └───Response
│       ├───EmployeeResponse
│       └───Messages
├───Properties
├───publish
│   └───publish
├───Repositories
│   └───EmployeeRepo
└───Services
```
Abaixo está a lista dos principais endpoints implementados para o gerenciamento de funcionários:

- **`GET /GetAllEmployees`** - Retorna uma lista de todos os funcionários.
- **`GET /GetEmployeeByName`** - Retorna uma lista de todos os funcionários com o nome pesquisado.
- **`POST /AddEmployee`** - Cria um novo funcionário.
- **`PUT /UpdateEmployee`** - Atualiza os dados de um funcionário específico.
- **`DELETE /DeleteEmployee/{id}`** - Exclui um funcionário baseado no ID.

### Estrutura JSON de um Funcionário

A estrutura de dados para um funcionário no formato JSON segue o modelo abaixo:

```json
{
  "employeeId": "08dcea30-6639-47b2-8f29-120ad09a2c13",
  "name": "Fabio Alves Rodrigues",
  "email": "fabioalves.rodrigues@gmail.com",
  "cpf": "12345678901",
  "phone": "11987654321",
  "birthDate": "1989-01-12",
  "employeeContractType": 2, 
  "status": 0
}
```
# Banco de Dados

A API utiliza o MySQL para armazenamento e gerenciamento de dados, com o Entity Framework para mapeamento de dados e migrações.

## Estrutura do Banco de Dados

A tabela de funcionários `TB_Employees` inclui os seguintes campos:

| Campo               | Tipo      | Descrição                           |
| ------------------- | --------- | ----------------------------------- |
| `employeeId`        | `Guid`    | Identificador único do funcionário  |
| `name`              | `string`  | Nome do funcionário                 |
| `email`             | `string`  | E-mail válido                       |
| `cpf`               | `string`  | CPF com 11 dígitos                   |
| `phone`             | `string`  | Telefone/Celular                    |
| `birthDate`         | `DateTime`| Data de nascimento                  |
| `employeeContractType` | `int`  | Tipo de contratação (1 para CLT e 2 para PJ) |
| `status`            | `int`     | Status (0 para Inativo e 1 para Ativo) |
| `created_at`        | `DateTime`| Data de criação                     |


## Configuração do Projeto

### Requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [MySQL](https://www.mysql.com/downloads/) instalado e configurado

### Passos para Inicialização

1. **Clone este repositório:**

    ```bash
    git clone https://github.com/GabrielDesk/doQrApi.git
    ```

2. **Navegue até o diretório do projeto:**

    ```bash
    cd doQrApi
    ```

3. **Configure o banco de dados e as variáveis de ambiente:**
   
    - Atualize as strings de conexão e outras configurações conforme necessário.

  
> [!NOTE]
> Banco de dados hospedado no servidor AWS, caso precise rodar localmente, talvez seja necessário a configuração via SSH Tunel.

| Server Host         | Port      | Database                           |
| ------------------- | --------- | ----------------------------------- |
| `localhost`         | `3306`    | `doqrdatabase`                      |

| Username            | Password  |                            
| ------------------- | --------- | 
| `new_apiuser`       | `********`|

| Host/Ip             | Port      | User Name  |                            
| ------------------- | --------- | ---------- |
| `107.22.66.56`       | `22`     | `ubuntu`   |

> [!IMPORTANT]
> Use `Public Key` Authentication Method.
> Private Key enviada via e-mail.


4. **Execute as migrações para criação das tabelas:**

    ```bash
    dotnet ef database update
    ```

5. **Inicie a aplicação:**

    ```bash
    dotnet run
    ```

