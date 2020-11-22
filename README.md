#Proyecto sisvent
##sistema de inventarios/ventas

###Herramientas:
- ASP.net Core 3.1
- Entity Framework.Core 
- JwtBearer para tokens

- React js
- Redux
- Ant design


dotnet new sln
dotnet new classlib -o StringLibrary -f netcoreapp3.1
dotnet sln add StringLibrary/StringLibrary.csproj
dotnet add app/app.csproj reference lib/lib.csproj
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef migrations add InitialCreate  --project ..\Services.Entity
dotnet ef database update
dotnet tool update --global dotnet-ef --version 3.1.0

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
.......................................