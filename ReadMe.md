# ReadMe
This solution uses expression trees to evaluate business cases at runtime.

The solution is built as a .NET Core 2.1 console application. The business rule itself is built in .NET standard since the business rules project does not have any dependency on .NET Core or .NET Framework specific libraries/ API.

Projects in solution:
- paymentprocessor - This is the starting point of the project. It is a console application.
- BusinessRuleEngine - Houses the rule engine implementatin code
- Entities - project entities
- Service - The service layer implemetation of the rule engine. This service layer calls the rule engine internally
- Tests - Please use the test runner in Visual Studio to test the project. All tests are written using MSTest. The test code is identical to the payment processor code because initially this designed as the only starting point of the application, but later code was added to paymentprocessor project to make running the code easier.

# Scope
The intention of the project is to make a rules engine, where the rules for payment types can be stored in the database. The database schema I have designed the solution around is as follows:

| RuleID | objectProperty | ComparisonOperator |   TargetValue    |    RuleInstance     |
|--------|----------------|--------------------|------------------|---------------------|
|      1 | PaymentFor     | Equal              | Physical Product | PhysicalProductRule |
|      2 | PaymentFor     | Equal              | Book             | BookRule            |
|      3 | PaymentFor     | Equal              | Membership       | MembershipRule      |

- object property is the name of the corresponding property in the payment instance
- TargetValue means the rule that is applied to
- RuleInstance is the name of the class that implements an IRule interface and implements custom rules for each of the cases

#### Extensibility
To extend the solution in the future, we can add new target values with new Rule Instances. We will need to implement the class in the solution by the same name as the RuleInstace we have used, but that is better than adding if-else solutions to the business logic. This also helps to reuse code as we can reuse rule instances if two rules need the same logic to be executed.

#### Doing things better
A few things can be done better
- Use null object pattern instead of retuning null objects
- Design the entities better depending on complete business use cases
- Use an interface for the Service layer to make the service layer more loosely coupled
- Using proper enums instead of loose strings for mapping database columns to code
- Better null checks and exception handling
- Instead of calling objects directly, we can implement a simple mediator class that does the same for us, this will help to keep the code clean
