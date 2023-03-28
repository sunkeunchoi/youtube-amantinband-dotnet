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

```bash
# commands used to add Dependency Injection package
dotnet add BuberDinner/BuberDinner.Application package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add BuberDinner/BuberDinner.Infrastructure package Microsoft.Extensions.DependencyInjection.Abstractions
```

```bash
# build
dotnet build BuberDinner
```

```bash
# run api
dotnet run --project BuberDinner/BuberDinner.Api
```

## Part 2 - Jwt
### JwtTokenGenerator
1. Application > Create IJwtTokenGenerator interface
2. Application > Update Service using IJwtTokenGenerator
3. Infrastructure > Create JwtTokenGenerator
4. Infrastructure > Update Dependency Injection
   
```bash
dotnet add BuberDinner/BuberDinner.Infrastructure package System.IdentityModel.Tokens.Jwt
```
### DateTimeProvider
1. Application > Create IDateTimeProvider
2. Infrastructure > Create DateTimeProvider
3. Infrastructure > Update JwtTokenGenerator
4. Infrastructure > Update Dependency Injection

### JwtSettings
1. Api > Update appsettings.json 
2. Infrastructure > Create JwtSettings
3. Api > Update Program
4. Infrastructure > Update DependencyInjection
5. Infrastructure > Update JwtTokenGenerator
```bash
dotnet add BuberDinner/BuberDinner.Infrastructure package Microsoft.Extensions.Configuration
otnet add BuberDinner/BuberDinner.Infrastructure package Microsoft.Extensions.Options.ConfigurationExtensions
```