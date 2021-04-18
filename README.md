
[![author](https://img.shields.io/badge/author-leocosta-blue.svg)](https://www.instagram.com/leoccosta) [![](https://img.shields.io/badge/csharp-9.0+-purple.svg)](https://dotnet.microsoft.com/) [![GPLv3 license](https://img.shields.io/badge/License-GPLv3-red.svg)](http://perso.crans.org/besson/LICENSE.html) [![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/leocosta/jornada-do-programador/issues)

![Comece a hospedar e conecte-se a viajantes do mundo todo.](./doc/images/cover.png)

---

O objetivo do projeto é demonstrar como construir uma solução baseada em microsserviços utilizando as melhores práticas de arquitetura de serviços distribuídos.

# Contexto

**Landy** conecta anfitriões a viajantes pelo mundo todo. O projeto é baseado em microsserviços e possui as seguintes funções:

- Gestão de Usuários
- Gestão de Ofertas de Hospedagem
- Criação de Reservas
- Envio de Notificação

# Tecnologias

- **NET 5.0**
- **SQL Server Express**
- **Entity Framework Core**
- **ASP.NET Core Web API**
- **ASP.NET Core gRPC Service**
- **AutoMapper**
- **FluentValidation**
- **MediatR**
- **Redis**
- **Kafka**
- **Kafkadrop**
- **ElasticSearch**
- **Kibana**
- **Jaeger**
- **Ocelot**
- **Docker**

## Para inciar containers

```bash
docker-compose up
```

**Gateway**

| Serviço        | Url                     |
|----------------|-------------------------|
| Gateway.WebApi | <http://localhost:5000> |

**Microsserviços**

| Serviço                          | Url                      |
|----------------------------------|--------------------------|
| Gestão de Usuários (Identiy.Api) | <http://localhost:4000>  |
| Booking (Booking.Api)            | <http://localhost:4001>  |
| Ofertas (Offer.Api)              | <http://localhost:4002>  |
| Notificação (Notification.Grpc)  | <http://localhost:14000> |


**Ferramentas:**

| Serviço   | Url                      |
|-----------|--------------------------|
| Kafkadrop | <http://localhost:19000> |
| Kibana    | <http://localhost:5601>  |
| Jaeger UI | <http://localhost:16686> |

## Instalando EF tools

```bash
dotnet tool install --global dotnet-ef
```

## Aplicando migrations

```bash
cd src/Services.Identity/Landy.Services.Identity.Core
dotnet ef database update --startup-project ../Landy.Services.Identity.Api --context IdentityDbContext
```

---

## Visão geral dos Recursos

### Offers

| Verb | Route       |
|------|-------------|
| POST | /offers     |
| GET  | /offers     |
| GET  | /offers/:id |

### Booking

| Verb | Route     |
|------|-----------|
| POST | /book     |
| GET  | /book/:id |

### Identity

| Verb   | Route                               |
|--------|-------------------------------------|
| POST   | /users                              |
| GET    | /users/:id                          |
| PUT    | /users/:id                          |
| PUT    | /users/:id/password                 |
| DELETE | /users/:id                          |
| PUT    | /users/:id/passwordresetemail       |
| POST   | /users/:id/emailaddressconfirmation |

## Arquitetura

✅  CQRS

✅  Mediator

✅  Event Sourcing

✅  Search Indexer

✅  Persistence

✅  Mappers

✅  Validators

✅  Web API

✅  gRPC

✅  OpenTracing

✅  API Gateway

## Integrações

- Pagar.me
- SendGrid

> NOTA: Este projeto foi desenvolvido no curso [Jornada do Programador](https://growiz.com.br/jornada-do-programador). O objetivo foi demonstrar algumas técnicas de desenvolvimento e ferramentas disponíveis na plataforma .NET.
