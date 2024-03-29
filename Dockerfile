# Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443
EXPOSE 4003
EXPOSE 5003


# SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de proyecto al contenedor
COPY ["./BolsaEmpleo.Application/BolsaEmpleo.Application.csproj", "src/BolsaEmpleo.Application/"]
COPY ["./BolsaEmpleo.Domain/BolsaEmpleo.Domain.csproj", "src/BolsaEmpleo.Domain/"]
COPY ["./BolsaEmpleo.Web/BolsaEmpleo.Web.csproj", "src/BolsaEmpleo.Web/"]
COPY ["./BolsaEmpleo.Infrastructure/BolsaEmpleo.Infrastructure.csproj", "src/BolsaEmpleo.Infrastructure/"]



# Restaura las dependencias del proyecto
RUN dotnet restore "src/BolsaEmpleo.Web/BolsaEmpleo.Web.csproj"


# Copia el resto de los archivos al contenedor
COPY . .

# Compila los proyectos
WORKDIR "/src/BolsaEmpleo.Web/"
RUN dotnet build -c Release -o /app/build


# Publica los proyectos
FROM build AS publish

RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime

WORKDIR /app
COPY --from=publish /app/publish .
RUN ls -l

RUN echo "Swagger on http://localhost:8080/swagger/index.html"

ENTRYPOINT ["dotnet", "/app/BolsaEmpleo.Web.dll"]
