# RdStationApi Client
[![Build status](https://ci.appveyor.com/api/projects/status/a88qv14kqynn6b7x?svg=true)](https://ci.appveyor.com/project/FortesTecnologia/rsstationapi)
[![Nuget count](http://img.shields.io/nuget/v/RdStationApi.Client.svg)](http://www.nuget.org/packages/RdStationApi.Client/)
[![Nuget downloads](http://img.shields.io/nuget/dt/RdStationApi.Client.svg)](http://www.nuget.org/packages/RdStationApi.Client/)
[![Coverage Status](https://coveralls.io/repos/fortesinformatica/RdStationApi/badge.svg?branch=master&service=github)](https://coveralls.io/github/fortesinformatica/RdStationApi?branch=master)

Simple C# client to send leads to RdStation

## Instaling

````
PM> Install-Package RdStationApi.Client
````

## Sending Lead Async

````csharp
IRdStationApiClient client = new RdStationApiClient();
ILead lead = new Lead("token", "identificador", "email@fulano.com");
var sent = await client.SendLead(lead);
````

## Sending Lead Sync

````csharp
IRdStationApiClient client = new RdStationApiClient();
ILead lead = new Lead("token", "identificador", "email@fulano.com");
var sent = client.SendLeadSync(lead);
````

## Chaning Lead Status Async

````csharp
IRdStationApiClient client = new RdStationApiClient();
var leadStatus = new LeadStatusRoot("authPrivateToken", new LeadStatus(LifeCycleLeadStage.LeadQualificado, true));
var sent = await client.ChangeLeadStatus("lead@email.com.br", leadStatus);
````

## Chaning Lead Status Sync

````csharp
IRdStationApiClient client = new RdStationApiClient();
var leadStatus = new LeadStatusRoot("authPrivateToken", new LeadStatus(LifeCycleLeadStage.LeadQualificado, true));
var sent = client.ChangeLeadStatusSync("lead@email.com.br", leadStatus);
````


## Source links to RDStation REST API

- [Integrar sistema próprio para Criação de Leads no RD Station (API)](http://ajuda.rdstation.com.br/hc/pt-br/articles/200310589--Integrar-sistema-pr%C3%B3prio-para-Cria%C3%A7%C3%A3o-de-Leads-no-RD-Station-API-)
- [Alterar estágio do Lead no funil do RD Station (API)](http://ajuda.rdstation.com.br/hc/pt-br/articles/200310699-Alterar-est%C3%A1gio-do-Lead-no-funil-do-RD-Station-API-)
[Integrar sistema próprio para Criação de Leads no RD Station (API)](http://ajuda.rdstation.com.br/hc/pt-br/articles/200310589--Integrar-sistema-pr%C3%B3prio-para-Cria%C3%A7%C3%A3o-de-Leads-no-RD-Station-API-)
