# Blog Posts REST API

This is an exemplary REST API made with .NET Core, Entity Framework, PostgreSQL storage and ASP.NET Core Identity, to serve as a backend for simple blog posting website. Currently configured to only serve JSON requests and responses.

## Installation

Simply clone the repo. In case of any problems with NuGet packages try:

```cmd
dotnet restore
```
to restore any non-present dependencies.



To setup a PostgreSQL database, simply create one according to connection string located in *appsettings.json*. If necessary, create migrations with

```cmd 
dotnet ef migrations add InitialCreate
```

 and perform 

```cmd 
dotnet ef database update
``` 
to let Entity Framework handle table creation.

###### For more information check out [EF Core Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli).

## Usage
### Register
 In order to modify, view or add/delete a blog post, an account is required. Create one by sending a JSON POST request to ```/api/authenticate/register``` like this:
```JSON
{
    "username": "username",
    "email": "name@domain",
    "password": "password",
    "name": "name",
    "surname": "surname"
}
```

### Login
Login by sending a JSON POST to ``` /api/authenticate/login ``` with given structure:
```JSON
{
    "username": "username",
    "password": "password"
}
```

## Contributing
This project is made purely for my personal use but any suggestions are welcome.
