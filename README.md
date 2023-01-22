# Rent-A-Car-Project
The aim of the project is coding rent car automation with enterprise architecture and .NETCore


# Layer
  * API
  * DataAcces
  * Entities
  * Core
  * Business

# Description
 * Project has a lot of controller for web api. All controllers have business service for connection and operation.
 
 * DataAcces has db connection and CRUD operation for entites.
    * Abstract has interface for kinda entites dal
    * Concerete has implement from that dals
    * Use Microsoft SQL Server for DataBase and use EntityFramework for relation class and database table
    
 * Entities has DataBase table's class and DTO
 
 * Core layer has Aspect structures, Caching and Validation operations, general defined CRUD operations, Dependency Resolvers, security operations with JWT, Extensions and related Utilities that can be used in all projects.
 
 * Business has a kinda service and Business rules
 
# How to Use It
  * First you have to clone `git clone https://github.com/tahapek5454/Rent-A-Car-Project.git`
  * You have to connect your local databaset connection string
  * After that go to project and you can test controllers with Postman

# Contact
  * Taha Pek = tahapek5454@gmail.com
