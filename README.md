# CatalogService

We have a Catalog Service that handles the company’s
“Catalog” (ex: menu of items in a restaurant), We also have a
Service that sends Email notifications to users notifying them
that an item that was added to the catalog.
Here is what to do :
1. Define the Catalog Service and the Email Service using the
Microservices Architecture in a .Net Core Solution.
2. Implement the Controller Service Repository pattern
inside the catalog service.
3. Create CRUD (Create, Read, Update, Delete) Restful APIs
for the Catalog Service and store the data in a local
database.
4. The database will contain 1 table called Products.
5. Products will contain (Name, Price, Cost, Image base64)
6. Implement the Email Service to Send Email (random
address) when a new product is added by using RabbitMQ
between the services.
7. Add an API Gateway to route the requests to the Catalog Microservice
8. Add an XUnit Test for the catalog service.
9. Draw the Architecture Diagram of the structure.
10. Adding a Mediator
11. Adding a Custom Authorization Middleware

Catalog Service using Asp.net core 6.0 RabbitMq Sqlite
This solution is developed on an Ubuntu computer using Visual Studio code.

This solution contains four projects.

## 1. CatalogService.Service Project

I have controllers, service and repository classes in the same named folders.
I have CRUD Restful APIs in this project.
I have connectionstring in appsetting.json file.
I added following line to Program.cs file for connecting to a local Sqlite database.
builder.Services.AddDbContext<ProductDb>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProductDb")));  

ProducerHelper.NotifyForNewProduct method adds a message to RabbitMq queue when a new product is added to the catalog.

In CatalogService.Service folder in command prompt or terminal add the following packages with following commands.
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Rabbitmq.Client

dotnet add package MediatR
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

I used Mediator pattern in ProductController. I used Handler and Model classes for the same purpose.

I added a custom authorization in CustomAuthorization, UserLogin, UserModel classes.
I added lines for JWT Authentication, Authentication and Authorization to Program.cs file.

To run the project run the following console on command prompt in Windows or terminal in Linux/MAC 
dotnet run

### Postman project
Catalog Service.postman_collection.json file can be imported to Postman to run api requests.

## 2. CatalogService.Consumer Project

ProductContext.Send method reads the RabbitMq queue and sends fake e-mail message using a fake e-mail service.

In CatalogService.Consumer folder in command prompt or terminal add the following packages with following commands.
dotnet add package MailKit
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Binder
dotnet add package Microsoft.Extensions.Configuration.CommandLine
dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.Options
dotnet add package NETCore.MailKit
dotnet add package Rabbitmq.Client

### Run RabbitMq Docker Image
To use RabbitMq. Use Docker image with the following command.
docker run -d --hostname my-rabbit --name myrabbit -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=123456 -p 5672:5672 -p 15672:15672 rabbitmq:3-management

If you want to run this docker again later, you can run the following command.
docker run rabbitmq

### Run the consumer project
To run the project run the following console on command prompt in Windows or terminal in Linux/MAC 
dotnet run

## 3. CatalogService.WebApi Project

In Program.cs I added following line to use ocelot.
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

In ocelot.json file I added the routing settings

In CatalogService.WebApi folder in command prompt or terminal add the following packages with following commands.
dotnet add package Ocelot

To run the project run the following console on command prompt in Windows or terminal in Linux/MAC 
dotnet run

## 4. CatalogService.Tests Project

In CatalogService.WebApi folder in command prompt or terminal add the following packages with following commands.
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package coverlet.collector

To run the test run the following console on command prompt in Windows or terminal in Linux/MAC 
dotnet test


# Architecture Diagrams
Architecture Diagrams folder contains Context, Containers and Components architecture diagrams.