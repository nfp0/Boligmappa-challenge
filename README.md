# Boligmappa .NET skill test

This is my solution for the Boligmappa .NET skill test.
With this implementation, I've tried to fulfill the challenge requirements while keeping the solution as SOLID and DRY as possible.
I tried to keep the code as self-documenting as possible, but I've also left some comments in a few areas.

Some areas can still be improved, specially in the way JSON data is fetched from the API, which I can explain further, if desired.

## Application requirements
The only requirement for building and running this application are the .NET 7.0 SDK and a PostgreSQL instance.

## Deployment
As for a possible deployment solution for this project, I would use Docker containers on the AWS ECS cloud service.
By leveraging the Docker-compose feature, we could have separate .NET and PostgreSQL containers hosting our application and databases respectively, joined together by either an internal Docker network, or a virtual network such as Amazon VPC.
Depending on the scope of the project, the Amazon VPC would give us the flexibility of scaling our .NET and PostgreSQL instances independently, with the option of load balancing.
