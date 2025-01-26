## FlightBooking Reservation Test - Leandro Candido

## Packages Included:
* Mediator
* AutoMapper
* Swagger

## Validations
* Email CreditCard Key and passengers fields could not be null or empty.
* Just bag information could be null or empty.
* Flight Information is mandatory.
* Passenger Information is mandatory.
* Passenger could have at max 5 bags.
* The flight could have at max 50 bags.
* Verify if seat are in 1-50 range.
* Verifiy if seat already is in used for required flight.
* Verify is flight is full.


## Swagger Ui

http://localhost:5000/swagger/index.html

## Unit Tests
All defined test case are ok:

* Flight Domain
* Reservation Domain
* Reservation Service
* Mediator Requests

## Conlusion

For expceptionn I add a exception middleware on mvc pipe.

All request and response could be done either by json and xml.

There are a message folder inside test showing how to make a request in both formats.

There are an option to change header in swagger Ui(application/json or application/xml).

For postmand user you nedd to change request header information, to choose between two messages formats.

Add Accept Key with application/json or application/xml

