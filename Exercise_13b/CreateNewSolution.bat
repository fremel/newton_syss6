dotnet new sln
md Webshop
md Webshop.Tests
cd Webshop
dotnet new classlib
cd ..
dotnet sln add Webshop
cd Webshop.Tests
dotnet new mstest
dotnet add reference ../Webshop
cd ..
dotnet sln add Webshop.Tests