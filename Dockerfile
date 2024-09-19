# Verwende ein Basis-Image, das SQL Server-Tools enthält
FROM mcr.microsoft.com/mssql-tools

# Setze das Arbeitsverzeichnis
WORKDIR /usr/src/app

# Kopiere das SQL-Skript in das Arbeitsverzeichnis
COPY scripts/create-database.sql /usr/src/app/create-database.sql

# Führe das SQL-Skript aus und halte den Container aktiv
CMD /opt/mssql-tools/bin/sqlcmd -S host.docker.internal -U sa -P YourStrong@Password -d master -i /usr/src/app/create-database.sql && tail -f /dev/null
