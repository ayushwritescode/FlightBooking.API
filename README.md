## Intro

The project is built over multiple layers, each with a different reponsibility.

Presentation/Endpoints layer:
- Layer responsible for exposing data allowing third parties making calls to the endpoints and GET or POST data.

Mediator layer:
- Pattern used to make the communication between endpoints and services built on back-end having a cleaner and organized code.

Domain Layer:
- Layer responsible for having the models and the services such as Reservation service.

Infrastructure layer:
- Layer responsible for managing the data repositories making available the methods to add, remove or list the data.
  The Flight and Promotion repositories are seeded whenever you run the application, from JSON files.


## API Overview

 1. The API exposes the following operations (see appendixes for further details):
    * [GET /Flight](AppendixI.md): used to search for available flights on a certain date between two different locations.
    * [POST /Reservation](AppendixII.md): used to create a reservation in the system
    * [GET /Reservation](AppendixIII.md): used to retrieve a reservation previously made.
 2. System constraints:
    * There is a maximum of 50 bags per flight in total for all the passengers.
    * Each passenger can have a maximum of 5 bags per flight.
    * There are 50 seats available per flight, numbered sequentially: “01”, “02”… “50”.
 3. Every endpoint returns appropriate error messages when the operation cannot be achieved for some reason. 
 4. For storage, we use in-memory collections to avoid external dependencies. 
 5. For the initial data state, use the [provided json](InitialState.json/initialStatePromotion.json).



## Swagger Ui

http://localhost:5005/swagger/index.html


