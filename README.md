# Gerenciador de CEPs

Este projeto oferece uma API RESTful para consultar informações de CEP através da integração com a API ViaCEP, salvar os dados no banco de dados e retornar o histórico de consultas. A aplicação não permite consultas a CEPs previamente cadastrados. Toda consulta é registrada, e a documentação da API está disponível via Swagger.

## Funcionalidades

- **Consulta de CEP**: Realiza a consulta do CEP via API ViaCEP e retorna os dados de endereço.
- **Armazenamento no Banco de Dados**: Salva as informações do CEP consultado no banco de dados.
- **Swagger**: Documentação da API acessível para visualização e testes interativos.
- **Histórico de Consultas**: A API armazena o histórico de consultas realizadas.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para desenvolvimento da API.
- **HttpClient**: Para realizar requisições para a API ViaCEP.
- **Entity Framework Core (EF Core)**: Para interação com o banco de dados e gravação de logs.
- **SQL Server**: Banco de dados para persistência dos dados de consultas.
- **Swagger**: Para documentação da API.

## 1. Consultando um CEP
Para consultar um CEP, faça uma requisição GET para o seguinte endpoint:

GET /api/cep/{cep}

## Banco de Dados
A aplicação utiliza SQL Server para armazenar os logs de consulta de CEP. As consultas são registradas com os seguintes dados:

- CEP consultado
- Logradouro, bairro, cidade, estado, entre outras informações
- Data e hora da consulta

## Dependências

O projeto utiliza as seguintes dependências:

- **ASP.NET Core**: Framework principal para a criação da API RESTful.
- **Entity Framework Core**: ORM para interação com o banco de dados SQL Server.
  - **Microsoft.EntityFrameworkCore.SqlServer**: Pacote para trabalhar com o SQL Server.
  - **Microsoft.EntityFrameworkCore.Tools**: Ferramentas para migrações e gerenciamentos de banco de dados.
- **Swashbuckle.AspNetCore**: Pacote para integração do Swagger, que fornece a documentação interativa da API.
- **System.Net.Http**: Biblioteca para realizar requisições HTTP, utilizada para consultar a API ViaCEP.
- **Newtonsoft.Json**: Biblioteca para manipulação de JSON, utilizada para serialização e desserialização dos dados de CEP.
- **Microsoft.Extensions.Configuration**: Para a configuração de variáveis de ambiente e leitura do arquivo `appsettings.json`.

### Instalação das Dependências

Para instalar as dependências, execute os seguintes comandos no seu terminal:

1. **Instalar o Entity Framework Core e SQL Server:**

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

## **Aplicação dos Princípios SOLID**

**Os princípios SOLID foram cuidadosamente aplicados na arquitetura e no código da aplicação para garantir flexibilidade, manutenibilidade e extensibilidade. Abaixo estão os princípios e exemplos de como foram implementados:**

### **Single Responsibility Principle (SRP)**
Cada classe tem uma única responsabilidade, evitando sobrecarga de funções e facilitando a manutenção.

- **CepController**: Responsável apenas por expor os endpoints da API.
- **CepServiceImpl**: Contém toda a lógica de negócio para a consulta de CEP e manipulação de dados.
- **LogRepository**: Gerencia apenas as operações de persistência no banco de dados.

### **Open/Closed Principle (OCP)**
A aplicação foi projetada para ser aberta à extensão, mas fechada para modificações em código existente.

- A arquitetura permite adicionar novas funcionalidades sem modificar o código existente. A estrutura do projeto permite facilmente a adição de novos serviços ou features, sem alterar a implementação atual.

### **Liskov Substitution Principle (LSP)**
Subclasses ou implementações podem substituir suas classes ou interfaces base sem alterar o comportamento esperado.

- As classes que implementam a lógica de negócio podem ser substituídas sem que a funcionalidade da aplicação seja comprometida, desde que respeitem os contratos definidos pelas interfaces.

### **Interface Segregation Principle (ISP)**
Interfaces foram mantidas pequenas e específicas para evitar que classes sejam forçadas a implementar métodos que não utilizam.

- As interfaces no projeto são específicas para os requisitos de cada classe, sem exigir implementações de métodos que não sejam relevantes para o contexto da classe.

### **Dependency Inversion Principle (DIP)**
O código depende de abstrações em vez de implementações concretas, facilitando testes e extensões.

- **Injeção de Dependências**: O framework utilizado (ASP.NET Core, no caso) gerencia a injeção das dependências necessárias para os serviços, permitindo a troca de implementações sem impacto no código que utiliza essas dependências.
- **Configuração do HttpClient**: O cliente HTTP é configurado externamente e injetado nos serviços, promovendo a separação de responsabilidades e a independência do código.

**Esses princípios ajudam a garantir que o código seja facilmente extensível e mantenha alta qualidade ao longo do tempo, além de permitir a integração de novos recursos com mínimo impacto no código existente.**

## **Padrões de Design Adotados**

**A arquitetura da aplicação foi construída com base em vários padrões de design conhecidos, garantindo flexibilidade, manutenção e extensibilidade.**

### **Padrão Scoped**
O padrão **Scoped** foi utilizado para garantir que as instâncias dos serviços, como o **CepServiceImpl**, sejam criadas e gerenciadas dentro do escopo de uma requisição. Isso significa que uma nova instância do serviço será criada a cada requisição e será descartada ao final da requisição. Esse padrão oferece um bom equilíbrio entre reutilização de objetos e controle de ciclo de vida das instâncias, proporcionando uma melhor gestão de recursos durante a execução da aplicação.

### **Padrão Strategy**
O padrão **Strategy** foi aplicado para organizar a lógica de consulta ao CEP, permitindo que diferentes implementações da lógica de consulta possam ser selecionadas dinamicamente, sem impactar o código da aplicação. Embora o código sobre providers tenha sido removido, este padrão pode ser visto na flexibilidade de interação com diferentes fontes de dados de CEP, se necessário, sem mudanças no núcleo da aplicação.

### **Padrão Repository**
O padrão **Repository** foi utilizado para abstrair o acesso ao banco de dados. A persistência de logs de consultas é gerida por um repositório, garantindo que a manipulação e consulta de dados sejam realizadas de maneira centralizada e eficiente. A utilização do **Spring Data JPA** facilita a implementação das operações CRUD sem a necessidade de escrever código SQL manual.

### **Padrão Validation (Planejado)**
Embora ainda não tenha sido implementado, o padrão **Validation** será introduzido na aplicação para garantir que as entradas do usuário, como o CEP, sejam válidas antes de serem processadas. Isso ajudará a evitar problemas de integridade de dados e a melhorar a experiência do usuário ao garantir que apenas informações válidas sejam aceitas pela aplicação.

**Esses padrões de design ajudam a manter a arquitetura da aplicação organizada, permitindo a evolução do sistema sem grandes mudanças estruturais e mantendo a flexibilidade e a capacidade de adaptação a novos requisitos.**






