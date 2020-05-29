# Demo DotNet Selenium Cross Browser 

## About:
Demo project to have some models about how to implement cross browser tests using NUnit and xUnit.

### NUnit examples:
- Using TestFixture to get the browser name and version (strings).  
The driver will open ("Setup" from NUnit) and close ("TearDown" from NUnit) for each test method.  
**Running in parallel "[Parallelizable(ParallelScope.Fixtures)]"**

### xUnit examples:
- Using Theory with InLineData ClassData and MemberData to get the browser name and version (strings).  
The driver will open and close (IDisposable interface from xUnit) for each test method.

## Setup Selenium environment:
Command to execute the docker compose and create the selenium containers:
~~~~
docker-compose --file ./Docker/Docker-compose.yml up -d 
~~~~