# E-Learning API
This is a sample project of clean architecture implementation, the project exposes APIs related to an e-learning 
platform.


## Requirements
- An SQL Database ()
- Net core 7

## Libraries
- Entity framework core: to persist data into the database.
- Mediatr: for implementing CQRS pattern


## Run Database migrations
Before executing the app, we need first to update our DB
### Add Migration
If there were any changes in our ApplicationContext  then we need to add those changes in a migration, this action
won't make any changes in our DB, it will only create required files to bind in our db.
```bash
dotnet ef add migrations <NAME> --project src/Infrastructure --startup-project src/Web.Api
```

### Apply changes on Database
Once we are sure the changes of our migrations we need to apply those changes on the database.
```bash
dotnet ef database update  --project src/Infrastructure --startup-project src/Web.Api
```



## Run the application


### Build
```bash
  dotnet build src/Domain
  dotnet build src/Infrastructure
  dotnet build src/Application
  dotnet build src/Web.Api
```
### Run
```bash
dotnet run --project src/Web.Api
```



