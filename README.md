# FlowDance.Examples
Contains examples of FlowDance applications.

For more info about FlowDance, please see [FlowDance.Documentation](https://olahallvall.github.io/FlowDance.Documentation/)

# You need
* Visual Studio 2022 or later
* Azure Functions Core Tools (Azure Functions Core Tools lets you develop and test your functions on your local computer)
* RabbitMQ with Streams activted

# Inspiration
* Compensating Action - https://learn.microsoft.com/en-us/azure/architecture/patterns/compensating-transaction
* Distributed Transactions with the Saga Pattern - https://dev.to/willvelida/the-saga-pattern-3o7p

# Get started
* Install Docker Desktop and start it up.
* Open a command prompt in the root folder of the repo (where the docker-compose.yml file is) and run the command: **docker-compose up -d**
* Wait until both RabbitMQ and SQL Server has started.
* Run the command: **docker exec rabbitmq rabbitmq-plugins enable rabbitmq_stream**
* Download and install [Azure Functions Core Tools](https://go.microsoft.com/fwlink/?linkid=2174087)
