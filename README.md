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
## Part 3 - Repository Pattern
1. Separation benefits (Real DB, InMemory DB)
2. Query optimization (Specification Pattern?) 
   1. eg: ConfirmedCounts, PendingCounts, DeclinedCounts등을 호출 할때 모든 Records를 불러 온 뒤 Counts 보다는 single SQL로 처리하는게 효율적이다. 그러나 그렇게 되면 너무 많은 Methods들이 생긴다

### User Entity and UserRepository
1. Domain > Create User Entity
2. Application > Create IUserRepository Interface (Define methods)
3. Application > Update Authentication Service 
4. Infrastructure > Create UserRepository
5. Refactor using User Entity
   1. Application > AuthenticationResult
   2. Api > AuthenticationController
   3. Application > IJwtTokenGenerator
   4. Infrastructure >  JwtTokenGenerator

## Part 4 - Error Handling
1. via Middleware
2. via exception filter attribute
3. Problem Details
4. via error endpoint
5. Custom Problem Details Factory
> 4 + 5 Works great! (from Amichai Mantinband)

### via Middleware
1. Api > Create ErrorHandlingMiddleware
2. Api > Update Program.cs > app.UseMiddleWare<ErrorHandlingMiddleware>
> JsonConvert.SerializeObject(Newtonsoft.Json) >> JsonSerializer.Serialize(System.Text.Json)

### via FilterAttribute
1. Api > Create ErrorHandlingFilterAttribute
2. Api > Update Program.cs > builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>())
### Problem Details
>[RFC 7231](https://tools.ietf.org/html/rfc7231#section-6.6.1)

use ProblemDetail Object
### via ErrorEndpoint
1. Api > Create ErrorsController
2. Api > Update Program.cs > app.UseExceptionHandler("/error");
### using Custom Problem Details Factory
1. Api > Create ProblemDetailFactory
2. Api > Update Program.cs > builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
> Question?? What should I use for aws lambda route per function??

## Part 5 - Flow Control
1. via Exceptions (not recommended)
   1. Decouple이 쉽지 않다! Infrastructure Layer에서 발생한 Exception이 Application Layer에서 정의가 되어 있지 않다면 바로 Presentation으로 나간다. Application에서 Exception들을 만들고 관리 해야 하는데 구멍이 생길 수 있다.
   2. Expected Exception인가 UnExpected Exception인가?
   3. Exception을 사용하면 관리가 쉽지 않다!.
2. via OneOf
3. via FluentResults
4. via ErrorOr & Domain Errors

### via OneOf
```bash
dotnet add BuberDinner.Application package oneof
dotnet add BuberDinner.Api package oneof
```
1. Application > Create DuplicateEmailError
2. Application > Update IAuthenticationService
3. Application > Update AuthenticationService
4. Api > Update AuthenticationController
>Rust의 Result<Result, Error>와 매우 유사함

Need interface to handle more than one errors

### via fluentResults
```bash
dotnet add BuberDinner.Application package fluentResults
dotnet add BuberDinner.Api package fluentResults
```
1. Application > Update DuplicateEmailError inherit from FluentResults
2. Application > Update IAuthenticationService
3. Application > Update AuthenticationService
4. Api > Update Api

### via ErrorOr
```bash
dotnet add BuberDinner.Domain package ErrorOr
```
1. Domain > Create Common/Errors Errors.User & Errors.Authentication
2. Application > Update IAuthenticationService & AuthenticationService
3. Api > Update AuthenticationContoller
4. Api > Create ApiController (Only Handle Errors)
5. Api > Update ProblemDetailsFactory (Inject ErrorCodes)

## Part 6 - CQRS + MediatR
