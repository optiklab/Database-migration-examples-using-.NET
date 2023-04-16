# phi.repository.sqlite.ef

Entity Framework application with scaffoled (i.e. reverse-engineered) database model (POCO classes) using Entity Framework utilities and live SQL Server database generated with [phi.database.sqlserver] (see related projects).

To connect to SQL Server database (it should be already created by [phi.database.sqlserver] and running):
$> dotnet run

## Creating

$> dotnet new console -o ProjectName
$> cd ProjectName
$> dotnet add package Microsoft.EntityFrameworkCore.SqlServer
$> dotnet tool install --global dotnet-ef
$> dotnet add package Microsoft.EntityFrameworkCore.Design
$> dotnet ef dbcontext scaffold "Server=ANTONPC; Database=Phi; Integrated Security=SSPI;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models --namespace Phi.Repository.SqlServer.Models --context-namespace Phi.Repository.SqlServer.Data --force

#Related links

https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli

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

