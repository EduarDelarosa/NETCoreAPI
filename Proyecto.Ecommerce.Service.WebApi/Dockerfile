#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Proyecto.Ecommerce.Service.WebApi/Proyecto.Ecommerce.Service.WebApi.csproj", "Proyecto.Ecommerce.Service.WebApi/"]
COPY ["Proyecto.Ecomerce.Application.DTO/Proyecto.Ecommerce.Application.DTO.csproj", "Proyecto.Ecomerce.Application.DTO/"]
COPY ["Proyecto.Ecommerce.Application.Interface/Proyecto.Ecommerce.Application.Interface.csproj", "Proyecto.Ecommerce.Application.Interface/"]
COPY ["Proyecto.Ecommerce.Transversal.Common/Proyecto.Ecommerce.Transversal.Common.csproj", "Proyecto.Ecommerce.Transversal.Common/"]
COPY ["Proyecto.Ecommerce.Application.Main/Proyecto.Ecommerce.Application.Main.csproj", "Proyecto.Ecommerce.Application.Main/"]
COPY ["Proyecto.Ecommerce.Domain.Entity/Proyecto.Ecommerce.Domain.Entity.csproj", "Proyecto.Ecommerce.Domain.Entity/"]
COPY ["Proyecto.Ecommerce.Domain.Interface/Proyecto.Ecommerce.Domain.Interface.csproj", "Proyecto.Ecommerce.Domain.Interface/"]
COPY ["Proyecto.Ecommerce.Domain.Core/Proyecto.Ecommerce.Domain.Core.csproj", "Proyecto.Ecommerce.Domain.Core/"]
COPY ["Proyecto.Ecommerce.Infraestrutura.Interface/Proyecto.Ecommerce.Infraestructura.Interface.csproj", "Proyecto.Ecommerce.Infraestrutura.Interface/"]
COPY ["Proyecto.Ecommerce.Infraestructura.Data/Proyecto.Ecommerce.Infraestructura.Data.csproj", "Proyecto.Ecommerce.Infraestructura.Data/"]
COPY ["Proyecto.Ecommerce.Infraestructura.Repository/Proyecto.Ecommerce.Infraestructura.Repository.csproj", "Proyecto.Ecommerce.Infraestructura.Repository/"]
COPY ["Proyecto.Ecommerce.Transversal.Logging/Proyecto.Ecommerce.Transversal.Logging.csproj", "Proyecto.Ecommerce.Transversal.Logging/"]
COPY ["Proyecto.Ecommerce.Transversal.Mapper/Proyecto.Ecommerce.Transversal.Mapper.csproj", "Proyecto.Ecommerce.Transversal.Mapper/"]
RUN dotnet restore "Proyecto.Ecommerce.Service.WebApi/Proyecto.Ecommerce.Service.WebApi.csproj"
COPY . .
WORKDIR "/src/Proyecto.Ecommerce.Service.WebApi"
RUN dotnet build "Proyecto.Ecommerce.Service.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Proyecto.Ecommerce.Service.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Proyecto.Ecommerce.Service.WebApi.dll"]