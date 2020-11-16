FROM mcr.microsoft.com/dotnet/aspnet:5.0

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /usr/local/bin

ADD publish/ ./

EXPOSE 80

ENTRYPOINT [ "dotnet", "MachineStream.Web.dll" ]
