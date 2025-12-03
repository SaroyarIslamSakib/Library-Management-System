FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
RUN apt update && apt install -y nodejs

COPY ["LMS.Web/LMS.Web.csproj","LMS.Web/"]
COPY ["LMS.Domain/LMS.Domain.csproj","LMS.Domain/"]
COPY ["LMS.Application/LMS.Application.csproj","LMS.Application/"]
COPY ["LMS.Infrastructure/LMS.Infrastructure.csproj","LMS.Infrastructure/"]
RUN dotnet restore "LMS.Web/LMS.Web.csproj"

COPY . .

FROM build AS publish
RUN dotnet publish "LMS.Web/LMS.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT [ "dotnet", "LMS.Web.dll" ]