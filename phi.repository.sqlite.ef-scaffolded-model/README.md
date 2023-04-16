# phi.repository.sqlite.ef-scaffolded-model

Entity Framework application with scaffoled (i.e. reverse-engineered) database model (POCO classes) using Entity Framework utilities and live SQLite database generated with [phi.database.sqlite] (see related projects).

To connect to SQL Server database (it should be already created and initalized with data by [phi.database.sqlserver] and running) and run some tests:
$> dotnet run

## Creating

$> dotnet new console -o ProjectName
$> cd ProjectName
$> dotnet add package Microsoft.EntityFrameworkCore.Sqlite
$> dotnet tool install --global dotnet-ef
$> dotnet add package Microsoft.EntityFrameworkCore.Design
$> dotnet ef dbcontext scaffold "Data Source=C:\Users\anton\AppData\Local\phi.db" Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models --namespace Phi.Repository.Sqlite.Models --context-namespace Phi.Repository.Sqlite.Data --force

#Related links

https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli (EF Core mapper for .NET Core)
https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki  (ADO.NET based recommended as it use most recent SQLite engine and provides access to SQLite functions)

## Follow

Author's other projects and personal page can be found here [Anton Yarkov](https://optiklab.github.io/)

## Copyright

Copyright © 2022 Anton Yarkov. All rights reserved.
Contacts: anton.yarkov@gmail.com

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.


