rm -rf migrations
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
