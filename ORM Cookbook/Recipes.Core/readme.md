## Use Cases

Each use case should be written as a series of tests in an abstract base class. Each test will begin by asking for a repository specific to that test case.

Specific ORMs will inherit from the use case base class and override the `GetRepository` method.


## Repository Interface

In this context, a repository is a collection of methods needed to implement a use case or set of use cases. 

Repository interfaces should not expose ORM-specific concepts. From a practical standpoint, this is to ensure that all ORMs have a fair chance of implementing the use case. Philosophically, this is to demonstrate that you can create a clear separation between the storage logic and business logic in an application.

One class may implement multiple repository interfaces where appropriate. 

One ORM may implement the same repository interfaces multiple times to demonstrate different options.

## Model Interface

The model interface describes the properties and child-models needed for the test.
