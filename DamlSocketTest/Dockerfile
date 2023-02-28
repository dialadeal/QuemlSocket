FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WorkerServiceTest/WorkerServiceTest.csproj", "WorkerServiceTest/"]
RUN dotnet restore "WorkerServiceTest/WorkerServiceTest.csproj"
COPY . .
WORKDIR "/src/WorkerServiceTest"
RUN dotnet build "WorkerServiceTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerServiceTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerServiceTest.dll"]
