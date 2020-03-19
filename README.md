# .NET CORE

## .Net EF comandos para criar o banco de dados.

Com o CMD na pasta \ProjAgil.Infra.Data> <br />
dotnet ef --startup-project ../ProjAgil.webapi/ migrations add Initial<br />
dotnet ef --startup-project ../ProjAgil.webapi/ database update<br />


## Comando para incluir referencias.

### WebAPI
DOTNETCORE\ProjAgil.WebAPI> dotnet add reference ..\ProjAgil.Infra.IoC\ProjAgil.Infra.IoC.csproj<br />
DOTNETCORE\ProjAgil.WebAPI> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj<br />
DOTNETCORE\ProjAgil.WebAPI> dotnet add reference ..\ProjAgil.Infra.Data\ProjAgil.Infra.Data.csproj<br />

### Data
DOTNETCORE\ProjAgil.Infra.Data> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj<br />

### Application
DOTNETCORE\ProjAgil.Application> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj<br />

### IoC
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj<br />
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Infra.Data\ProjAgil.Infra.Data.csproj<br />
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Application\ProjAgil.Application.csproj<br />
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj<br />

## Criação do .sln
DOTNETCORE> dotnet new sln -n ProAgil<br />

### Add referencias ao sln

DOTNETCORE dotnet sln ProAgil.sln add ProjAgil.Dominio/ProjAgil.Dominio.csproj<br />
DOTNETCORE dotnet sln ProAgil.sln add ProjAgil.Infra.Data/ProjAgil.Infra.Data.csproj<br />
DOTNETCORE dotnet sln ProAgil.sln add ProjAgil.Application/ProjAgil.Application.csproj<br />
DOTNETCORE dotnet sln ProAgil.sln add ProjAgil.Infra.IoC/ProjAgil.Infra.IoC.csproj<br />
DOTNETCORE dotnet sln ProAgil.sln add ProjAgil.WebAPI/ProjAgil.WebAPI.csproj<br />

