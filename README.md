# propay
Payment Processing

WebAPI with only 1 method called “ProcessPayment” that receives a request like this
- CreditCardNumber (mandatory, string, it should be a valid CCN)
- CardHolder: (mandatory, string)
- ExpirationDate (mandatory, DateTime, it cannot be in the past)
- SecurityCode (optional, string, 3 digits)
- Amount (mandatoy decimal, positive amount)



To generate new migrations 
Select ProPay.Infrastruction then run migration commands


API Documentation
Lauch and click on swagger Api Doc to view API Documentation
