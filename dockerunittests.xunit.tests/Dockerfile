FROM microsoft/dotnet:2.2.104-sdk-stretch AS build
WORKDIR /src
COPY ["/dockerunittests.dataaccess/dockerunittests.dataaccess.csproj", "dockerunittests/dockerunittests.dataaccess/"]
COPY ["/dockerunittests.domain/dockerunittests.domain.csproj", "dockerunittests/dockerunittests.domain/"]
COPY ["/dockerunittests.dto/dockerunittests.dto.csproj", "dockerunittests/dockerunittests.dto/"]
COPY ["/dockerunittests.services/dockerunittests.services.csproj", "dockerunittests/dockerunittests.services/"]
COPY ["/dockerunittests.xunit.tests/dockerunittests.xunit.tests.csproj", "dockerunittests/dockerunittests.xunit.tests/"]

RUN dotnet restore "dockerunittests/dockerunittests.xunit.tests/dockerunittests.xunit.tests.csproj"
COPY . .
WORKDIR /src/dockerunittests/dockerunittests.xunit.tests/
#ENTRYPOINT dotnet test --logger trx --results-directory /out/testresults
