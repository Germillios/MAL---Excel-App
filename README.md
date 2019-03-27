# MAL-Excel-App
ver 1.0
Application is created on WPF template. It aims at synchronization between two databases. One, bigger database is table in Excel. The second database is XML file, which is generated from own account on MAL.
SQL-code is generated manually on website sqlizer.io, because both files contain a large amount of data. Next, SQL Server is used to create four databases, two for anime list, two for manga list. Model of all databases was created using Entity Framework 6.
The main goal is update "Excel database" with "MAL database".
This version is still unfinished.

It is necessary to run this project:
1. Create the database "MalAppDB" on SQL Server.
2. Run .sql files from folder named "Databases" to create the required tables.
3. Update the connection string in app.config file ("datasource").
4. The project should run fine.
