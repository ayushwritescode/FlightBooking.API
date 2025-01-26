## FlightBooking Reservation Test - TravelLabs

## Intro
The airline **EtlBlue** is creating a brand new API to expose its reservation mechanism to other inhouse systems as well as potentially interested third parties. 

To allow this a successful candidate must implement an API with the following features:

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

## What we are looking for?
You're allowed to add any particular framework you want and keep in mind that we are looking for clean and maintainable code which follows good programming principles.

    - Clean Code
    - SOLID Principles
    - Coding in english
    - Follow the requirements that will be shared in the interview

## Swagger Ui

http://localhost:5005/swagger/index.html


## Tech interview

1. Clone the repository
2. Make sure you have VS + SDK installed
3. Build and run the API
4. Import the postman collection on postman

---

Thanks for your time, we look forward to hearing from you!

FlightBooking Reservation Team
