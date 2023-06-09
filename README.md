# Phi.Storage

The idea is to get flexibility and full control in ways to initialize and migrate databases using various DB engines: SQL Server and SQLite supported.

To create SQLServer database, initialize it with some data, then connect to it and run tests:
```bash
$> cd phi.database.sqlserver
$> dotnet run
$> cd phi.repository.sqlserver.ef-scaffolded-model
$> dotnet run
```

To create SQLite database and initialize it with some test data, then connect to it and run tests:
```bash
$> cd phi.database.sqlite
$> dotnet run
$> cd phi.repository.sqlite.ef
$> dotnet run
```

The main different between two models is that [PhiUser] table in SQL Server is using [string] Identity Field, while SQLite model is using simple [integer] Identity.
This is done so due to performance reasons (in SQLite) and different use cases for those two engines (enterprise for sharding/partitioning vs. lightweight microservices).

## SQLServer storage (for future use)

### phi.database.sqlserver

A set of T-SQL scripts together with DbUp console application for initializing SQL Server-based database and control migration with simple SQL scripts.

### phi.repository.sqlserver.ef-scaffolded-model

Scaffoled (i.e. reverse-engineered) database model (POCO classes) using Entity Framework utilities and live SQL Server database generated with [phi.database.sqlserver] mentioned above.

### phi.repository.sqlite.ef - primer

Simple Entity Framework application that defines SQLite model and generates database with migration supported.

## SQLite storage (for decentralized and language-agnostic microservices)

### phi.database.sqlite

A set of SQL scripts together with DbUp console application for initializing SQLite-based database and control migration with simple SQL scripts.

### phi.repository.sqlite.ef

Entity Framework application that defines SQLite model and generates database with migration supported. It also able to connect to the database generated by [phi.database.sqlite] mentioned above.

# Follow

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
