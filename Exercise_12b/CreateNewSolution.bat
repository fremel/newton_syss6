dotnet new sln
md TravelAdvisor
md TravelAdvisor.Tests
cd TravelAdvisor
dotnet new classlib
cd ..
dotnet sln add TravelAdvisor
cd TravelAdvisor.Tests
dotnet new mstest
dotnet add reference ../TravelAdvisor
cd ..
dotnet sln add TravelAdvisor.Tests