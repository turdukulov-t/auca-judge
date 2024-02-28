FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

RUN apt-get update && apt-get install -y locales

# Locale
RUN sed -i -e \
  's/# ru_RU.UTF-8 UTF-8/ru_RU.UTF-8 UTF-8/' /etc/locale.gen \
   && locale-gen

ENV LANG ru_RU.UTF-8
ENV LANGUAGE ru_RU:ru
ENV LC_LANG ru_RU.UTF-8
ENV LC_ALL ru_RU.UTF-8

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AUCA/AUCA.csproj", "AUCA/"]
COPY ["AUCA.DAL/AUCA.DAL.csproj", "AUCA.DAL/"]
COPY ["AUCA.Domain/AUCA.Domain.csproj", "AUCA.Domain/"]
COPY ["AUCA.Interface/AUCA.Interface.csproj", "AUCA.Interface/"]
COPY ["AUCA.Repository/AUCA.Repository.csproj", "AUCA.Repository/"]
RUN dotnet restore "AUCA/AUCA.csproj"
COPY . .
WORKDIR "/src/AUCA"
RUN dotnet build "AUCA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AUCA.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AUCA.dll"]