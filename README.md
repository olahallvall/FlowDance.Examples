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
Install Docker Desktop and start it up.
Download the file https://github.com/olahallvall/FlowDance/blob/master/DockerExternalDep/docker-compose.yml to local folder
Open a command prompt in that folder and run the commands: 
 
**docker-compose up -d**

Wait until both RabbitMQ and SQL Server has started.

Run the commands below in the same command prompt window: 

**docker exec rabbitmq rabbitmq-plugins enable rabbitmq_stream**

**docker exec rabbitmq rabbitmqadmin declare queue --vhost=/ name=FlowDance.SpanCommands durable=true**

**docker exec rabbitmq rabbitmqadmin declare queue --vhost=/ name=FlowDance.SpanEvents durable=true**
 
**docker exec -d mssql /opt/mssql-tools/bin/sqlcmd -S . -U SA -P "Admin@123" -Q "CREATE DATABASE [DurableDB] COLLATE Latin1_General_100_BIN2_UTF8"**

**docker exec -it mssql /opt/mssql-tools/bin/sqlcmd -S . -U sa -P "Admin@123" -Q "SELECT name FROM sys.databases"**
 
Restart the container **flowdance** in Docker Desktop. 

Download and install [Azure Functions Core Tools](https://go.microsoft.com/fwlink/?linkid=2174087)

Pull the FlowDance.Examples repo to our computer

Open the [FlowDance.Examples.REST solution](https://github.com/olahallvall/FlowDance.Examples/blob/main/FlowDance.Examples.REST.sln)  
