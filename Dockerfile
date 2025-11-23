FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY Laboratorio14.sln .
COPY Laboratorio14/Laboratorio14.csproj Laboratorio14/
COPY Laboratorio14.Application/Laboratorio14.Application.csproj Laboratorio14.Application/
COPY Laboratorio14.Domain/Laboratorio14.Domain.csproj Laboratorio14.Domain/
COPY Laboratorio14.Infrastructure/Laboratorio14.Infrastructure.csproj Laboratorio14.Infrastructure/
RUN dotnet restore
COPY . .
RUN dotnet publish Laboratorio14/Laboratorio14.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_ENVIRONMENT=Production
COPY entrypoint.sh /entrypoint.sh
EXPOSE 8080
ENTRYPOINT ["bash","/entrypoint.sh"]