dotnet new sln
md UserAccess
md UserAccess.Tests
cd UserAccess
dotnet new classlib
cd ..
dotnet sln add UserAccess
cd UserAccess.Tests
dotnet new mstest
dotnet add reference ../UserAccess
cd ..
dotnet sln add UserAccess.Tests