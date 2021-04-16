# Curso EF Core

Project developed trough course of "Introducao ao EF Core" on desenvolvedor.io platform.

##Run App

Use docker to run SQL environment
``` bash
docker-compose up -d
```bash
docker-compose up -d
´´´

##Create and Run Migrations

Use docker to run SQL environment
```bash
dotnet ef migrations add PrimeiraMigracao -p CursoEFCore.csproj -i
dotnet ef database update -p cursoEFCore.csproj -v
´´´