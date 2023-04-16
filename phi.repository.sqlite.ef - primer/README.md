# phi.repository.sqlite.ef - primer

Entity Framework application that defines SQLite model and generates database with migration supported.

To intialize SQLite database and connect to it:
$> dotnet run

## Creating

$> dotnet tool install --global dotnet-ef
$> dotnet add package Microsoft.EntityFrameworkCore.Design
$> dotnet ef migrations add InitialCreate
$> dotnet ef database update

## Database location

Database created at c:\Users\[USER]\AppData\Local\blogging.db

#Related links

https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/complex-data-model?view=aspnetcore-6.0
https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/migrations?view=aspnetcore-6.0
https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations

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

