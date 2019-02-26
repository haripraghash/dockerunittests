FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["dockerunittests/dockerunittests.csproj", "dockerunittests/"]
RUN dotnet restore "dockerunittests/dockerunittests.csproj"
COPY . .
WORKDIR "/src/dockerunittests"
RUN dotnet build "dockerunittests.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dockerunittests.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "dockerunittests.dll"]