# Running application step by step
## 01 - install docker in your local machine
## 02 - run the following command to setup the database
docker run --name mongodb -p 27018:27018 -p 27019:27019 -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=S@mpl3p@22word -d mongo
## 03 - run the application
dotnet run --project .\Api\Api.csproj
## 04 - Execute curl
curl http://localhost:5157
