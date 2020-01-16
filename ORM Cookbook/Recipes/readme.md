## Use Cases

Each scenario should be written as a series of tests in an abstract base class. Each test will begin by asking for a repository specific to that test case.

Specific ORMs will inherit from the scenario interface and override the `GetScenario` method.


## scenario Interface

In this context, a scenario interface is a collection of methods needed to implement a scenario or set of scenarios. 

Scenario interfaces should not expose ORM-specific concepts. From a practical standpoint, this is to ensure that all ORMs have a fair chance of implementing the scenario. Philosophically, this is to demonstrate that you can create a clear separation between the storage logic and business logic in an application.

One class may implement multiple repository interfaces where appropriate. 

One ORM may implement the same repository interfaces multiple times to demonstrate different options.

## Model Interface

The model interface describes the properties and child-models needed for the test.
