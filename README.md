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


### Instalções
npm install -g @angular/cli <br />

#### Comandos CLI
Criando Guardião =>  ng g g nomeGuardiao

### Bibliotecas para usar com o Angular;

<a href="https://valor-software.com/ngx-bootstrap/#/">ngx-bootstrap</a> <br />
<a href="https://getbootstrap.com/">bootstrap</a> <br />
<a href="https://www.npmjs.com/package/ngx-toastr">ngx-toastr</a><br />
<a href="https://www.npmjs.com/package/ngx-mask">ngx-mask</a><br />
<a href="https://www.npmjs.com/package/ngx-currency">ngx-currency</a>
<a href="https://bootswatch.com/">bootswatch</a>
<a href="https://bootsnipp.com/snippets/aMp3k">bootsnipp amp3k</a>

### Configuração para Deploy do Angular

<a href="https://angular.io/guide/deployment#server-configuration">angular.io configuration</a> <br />
Instalar => npm install source-map-explorer --save-dev <br />
ng build --prod --source-map <br />
ls dist/*.bundle.js <br />
Após executar é criado a pasta ProAgil-App\dist\ProAgil-App , com os arquivos para deploy.

### Configuração para Deploy do >NET

Execultar => dotnet publish        --   Publicar um projeto do .NET para implantação. <br>
dotnet publish -o C:/Projetos/ProAgil ... caminho onde que salvar as dll <br> <br>
Para roda a aplicação <br>
C:\Projetos\ProAgil>dotnet ProjAgil.WebAPI.dll
