# DataBase_First

## Project Type: ASP.Net Core MVC

* Created the Electricity Bill Scheme in SQL Server
* Used Entity Framework for ORM.

<br>

Scaffolding        | Command
------------- | -------------
Model \| View | dotnet ef dbcontext scaffold "Server=.\;Database=<DatabaseName>;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
Controller | dotnet-aspnet-codegenerator controller -name <ControllerName> -m <ModelName> -dc <DbContextName> --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
