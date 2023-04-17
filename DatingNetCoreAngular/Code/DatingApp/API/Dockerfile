#get SDK from microsoft
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR  /app

#copy csproj file tand restore nuget dependancies if missing
COPY *.csproj ./
RUN curl https://api.nuget.org/v3/index.json -v
RUN dotnet restore --verbosity diag

#copy project files and build in release mode
COPY . ./
RUN dotnet publish -c Release -o out

#generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","API.dll"]
