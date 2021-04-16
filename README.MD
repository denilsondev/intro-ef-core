# Curso EF Core

Project developed trough course of "Introducao ao EF Core" on desenvolvedor.io platform.

##Run App

Use docker to run SQL environment
```docker-compose up -d´´´

##Create and Run Migrations

Use docker to run SQL environment
```dotnet ef migrations add PrimeiraMigracao -p CursoEFCore.csproj -i
   dotnet ef database update -p cursoEFCore.csproj -v
´´´