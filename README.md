# Assignment
Test assignment for Fone Dynamics. In-memory cache 

## Folder Structure:
./code - this is the actual code folder. Includes ICache interface, Cache class that implements that interface, and simple console app (Program.cs) that uses that Cache.
./assignment_test - xUnit unit test that tests code functionality

## Instructions
This is a .Net Core app. So to build and run it make sure you have .Net Core installed on your computer. The application can be debugged using Visual Studio Code IDE.

### To run the console app 
Navigate to the code library:
```cd ./code``
Then restore dependencies and build it:
```dotnet restore
dotnet build```
Then run the app:
```dotnet run```
This should output something like this:
```Creating cache with maximum of 4 elements.
Found value 1: True
Found value 2: True
Found value : False
Found value : False
Found value 22: True
Found value 5: True
Press Enter...```

### To run the unit tests
Navigate to the test folder from the parent folder:
```cd ./assignment_test```
Restore and build:
```dotnet restore
dotnet build```
Run the test:
```dotnet test```
