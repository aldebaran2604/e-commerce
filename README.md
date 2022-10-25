# e-commerce

dotnet ef database drop -p Infrastructure -s API

dotnet ef migrations remove -p Infrastructure -s API

dotnet tool update --global dotnet-ef --version 6.0.10

dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations