# ASP.NET DDD & REST API Clean Architecture

>[Reference: Github](https://github.com/amantinband)

>[Reference: Youtube](https://www.youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k)

>VS Code Debugger : `ProjectName.sln` should be in the root!

## Part 1 - Project Steup
```bash
dotnet new sln -o BuberDinner
cd BuberDinner
# This is the root!!! otherwise vscode debugger is not work with default settings
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
dotnet new gitignore
dotnet new editorconfig
dotnet new globaljson
git init
git flow init -d -f
```

```bash
# commands used to add Dependency Injection package
dotnet add BuberDinner.Application package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add BuberDinner.Infrastructure package Microsoft.Extensions.DependencyInjection.Abstractions
```

```bash
# build
dotnet build BuberDinner
```

```bash
# run api
dotnet run --project BuberDinner.Api
```

## Part 2 - Jwt
### JwtTokenGenerator
1. Application > Create IJwtTokenGenerator interface
2. Application > Update Service using IJwtTokenGenerator
3. Infrastructure > Create JwtTokenGenerator
4. Infrastructure > Update Dependency Injection
   
```bash
# commands used to add Jwt package
dotnet add BuberDinner.Infrastructure package System.IdentityModel.Tokens.Jwt
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
# commands used to add Configuration package
dotnet add BuberDinner.Infrastructure package Microsoft.Extensions.Configuration
otnet add BuberDinner.Infrastructure package Microsoft.Extensions.Options.ConfigurationExtensions
```
### Dotnet User secret
```bash
# commands used in user-secrets
dotnet user-secrets init --project BuberDinner.Api
dotnet user-secrets set --project BuberDinner.Api "JwtSettings:Secret" "super-secret-key-from-user-secrets"
dotnet user-secrets list --project BuberDinner.Api
```
