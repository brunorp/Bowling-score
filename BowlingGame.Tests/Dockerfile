FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN mkdir -p /usr/share/man/man1 /usr/share/man/man2

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jre

RUN dotnet tool install --global dotnet-sonarscanner --version 4.10.0
ENV PATH="${PATH}:/root/.dotnet/tools"
ENV JAVA_TOOL_OPTIONS -Dfile.encoding=UTF8

COPY . ./BowlingGame.Tests
WORKDIR /BowlingGame.Tests

RUN dotnet restore

RUN dotnet sonarscanner begin /k:"BowlingGame" \
    /d:sonar.host.url="http://192.168.15.106:9000" \
    /d:sonar.verbose=true \
    /v:1.0.0 \
    /d:sonar.login="0ff8c7626514d6313e7342079fe0e4e8a7d37455"

RUN dotnet build
RUN dotnet sonarscanner end /d:sonar.login="0ff8c7626514d6313e7342079fe0e4e8a7d37455"