export PATH=$PATH:/c/Users/'user-name'/.dotnet/tools
dotnet tool install --global dotnet-ef --version 7.0.15
dotnet ef migrations add FirstInitialize
dotnet ef database update





