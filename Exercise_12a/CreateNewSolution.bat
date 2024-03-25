dotnet new sln
md LoyaltyServiceProject
md LoyaltyServiceProject.Tests
cd LoyaltyServiceProject
dotnet new classlib
cd ..
dotnet sln add LoyaltyServiceProject
cd LoyaltyServiceProject.Tests
dotnet new mstest
dotnet add reference ../LoyaltyServiceProject
cd ..
dotnet sln add LoyaltyServiceProject.Tests