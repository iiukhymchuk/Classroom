FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Classroom.Api/Classroom.Api.csproj", "Classroom.Api/"]
RUN dotnet restore "Classroom.Api/Classroom.Api.csproj"
COPY . .
WORKDIR "/src/Classroom.Api"
RUN dotnet build "Classroom.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Classroom.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Classroom.Api.dll"]