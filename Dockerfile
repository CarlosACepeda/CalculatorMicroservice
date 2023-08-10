#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CalculatorMicroservice/CalculatorMicroservice.csproj", "CalculatorMicroservice/"]
RUN dotnet restore "CalculatorMicroservice/CalculatorMicroservice.csproj"
COPY . .
WORKDIR "/src/CalculatorMicroservice"
RUN dotnet build "CalculatorMicroservice.csproj" -c Release -o /app/build

FROM build as test
WORKDIR /src
RUN echo "testing"
COPY ["PruebasUnitarias/PruebasUnitarias.csproj", "PruebasUnitarias/"]
WORKDIR "/src/PruebasUnitarias"
RUN dotnet test "PruebasUnitarias.csproj"


FROM test AS publish
WORKDIR /src
RUN dotnet publish "CalculatorMicroservice/CalculatorMicroservice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatorMicroservice.dll"]