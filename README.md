# ASP.NET DDD & REST API Clean Architecture
>[Reference: Github](https://github.com/amantinband)
>[Reference: Youtube](https://www.youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k)

## Part 1 - Project Steup
```bash
dotnet new sln -o BuberDinner
cd BuberDinner
dotnet new webapi -o BuberDinner.Api
dotnet new classlib -o BuberDinner.Contracts
dotnet new classlib -o BuberDinner.Infrastructure
dotnet new classlib -o BuberDinner.Application
dotnet new classlib -o BuberDinner.Domain
dotnet sln add **/*.csproj
dotnet add BuberDinner.Api reference BuberDinner.Contracts BuberDinner.Application
dotnet add BuberDinner.Infrastructure reference BuberDinner.Application
dotnet add BuberDinner.Application reference BuberDinner.Domain
dotnet add BuberDinner.Api reference BuberDinner.Infrastructure
```