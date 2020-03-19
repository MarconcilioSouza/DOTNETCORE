# .NET CORE

## .Net EF comandos para criar o banco de dados.

Com o CMD na pasta \ProjAgil.Infra.Data>

dotnet ef --startup-project ../ProjAgil.webapi/ migrations add Initial

dotnet ef --startup-project ../ProjAgil.webapi/ database update


Comando para incluir referencias.

## WebAPI
DOTNETCORE\ProjAgil.WebAPI> dotnet add reference ..\ProjAgil.Infra.IoC\ProjAgil.Infra.IoC.csproj
DOTNETCORE\ProjAgil.WebAPI> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj
DOTNETCORE\ProjAgil.WebAPI> dotnet add reference ..\ProjAgil.Infra.Data\ProjAgil.Infra.Data.csproj

## Data
DOTNETCORE\ProjAgil.Infra.Data> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj

## Application
DOTNETCORE\ProjAgil.Application> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj

## IoC
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Infra.Data\ProjAgil.Infra.Data.csproj
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Application\ProjAgil.Application.csproj
DOTNETCORE\ProjAgil.Infra.IoC> dotnet add reference ..\ProjAgil.Dominio\ProjAgil.Dominio.csproj