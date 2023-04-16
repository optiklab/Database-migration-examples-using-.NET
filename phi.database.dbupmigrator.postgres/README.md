# phi.database.sqlite

A set of SQL scripts together with DbUp console application for initializing Postgres-based database and control migration with simple SQL scripts.

## Database instantiation

$> docker-compose up -d
$> docker ps

Connect to the container and execute some internal commands to database engine:
$> docker exec -it [CONTAINER_ID_HERE] bash
$> psql -U postgres

List databases:
$> \l
$> CREATE DATABASE mytestdb;
$> \l

Exit:
$> \q

To intialize database and connect to it:
$> cd phi.database.dbupmigrator.postgres
$> dotnet run

## See results

$> docker ps
$> docker exec -it [CONTAINER_ID_HERE] bash
$> psql -U postgres
$> \c PhiDatabase
$> \dt
$> SELECT * FROM schemaversions;

Everything you have to do is [$>docker-compose up -d] and you are ready to go with all your databases + schema up to date! 
Also when I write integration tests I tend to play with database causing some rubbish data. It is really easy to [$>docker-compose down] and [$>docker-compose up] and have everyting fresh. 

See logs by [$> docker-compose logs].

# Links

https://mcode.it/blog/2020-03-05-database_development_with_docker_and_dbup/

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
