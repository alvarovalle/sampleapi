# Running application step by step
## 01 - install docker in your local machine
## 02 - run the following command to setup the database
docker run --name mongodb -p 27018:27018 -p 27019:27019 -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=S@mpl3p@22word -d mongo
## 03 - run the application
dotnet run --project .\Api\Api.csproj
## 04 - Execute curl
-To get all products
curl -X GET http://localhost:5157/v1/product
-To create a new product
curl -X POST http://localhost:5157/v1/product/ -H 'Content-Type: application/json' -d '{"name": "Mango", "description": "A mango is an edible stone fruit produced by the tropical tree Mangifera","price": 3, "images":["photo path"],"sku": "MANGO003"}'
-To get one product 
curl -X GET http://localhost:5157/v1/product/{place product id here}
-To delete one product 
curl -X DELETE http://localhost:5157/v1/product/{place product id here}
-To update a product
curl -X POST  http://localhost:5157/v1/product/{place product id here} -H 'Content-Type: application/json' -d '{"name": "Mango", "description": "A mango is an edible stone fruit produced by the tropical tree Mangifera","price": 7,"images":["photo path"],"sku": "MANGO003"}'