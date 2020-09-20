# Geotab
Joke Generator Application

This application takes user input from console and generates jokes based on user selection.
I have divided the project into following pieces to improve readability and increase modularity

•	Program – this is where the application begins to run and all the services and clients are registered in the application here. I have used dependency injection in order to create loosely coupled code. Adding new services or clients do not require major changes in the application and can help achieve additional functionality with little effort.

•	Generator – This class acts as the main program where the user interacts with various options in the app

•	ClientAPI - Provides the different Http client API sources from which we can get data
- ChuckNorris API defines all the endpoints required for the application from the base address under the client.
- NameGenaratorAPI defines the PrivServ API end point to get the name of a person.

•	ConsoleOperations - This provides the console operations required for the current application to perform its tasks.
- ConsoleReader class defines the read operations of the application. The current application requires only readline and readkey operations
- ConsolePrinter class defines the printing operations which are specific to application requirement. Application requires printing single line and list object.

•	DTO
- ApplicationVariables DTO has all the variables that are required while the generator class is running. 

•	Services
- JokeService class has the functions that provide data to the user. It has each function to perform single task based on user input. 

I have created the above architecture which in order to improve readability as well as providing scope for future extension. It also supports easy maintenance as the program is divided into multiple parts and each part performs its own function.

References:
I have reviewed the following articles while considering various aspects in building the application.
1.	https://www.talkingdotnet.com/3-ways-to-use-httpclientfactory-in-asp-net-core-2-1/
2.	https://josef.codes/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/
3.	https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
