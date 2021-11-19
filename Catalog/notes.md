# Fundations

## Part 1

* Entity/Domain/Models - represents the itens in catalog ( via c# record types)
* Repository - resposible for all itens storage related operations (in memory)
* Controller - controls the requests to the api

## Part 2

* Dependenct injection is technique a technique to properly inject our
repository instance with items controller.

* Data transfer objects are used to establish our peer contract with 
out api consumers (DTOs)

* Classes should not be dependents of other objects, but of interfaces.


![alt text](./img/1.png)



* Data Transfer Object: "an object that carries data between processes in order to reduce the number of method calls.

![alt text](https://martinfowler.com/eaaCatalog/dtoSketch.gif)

How do we validate DTOs?


então: a gente cria o model

depois vai fazendo: repo, add na interface, dto, controller
















This is only my studyng repo. I do not own this content.
