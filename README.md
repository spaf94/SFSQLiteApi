# SFSQLiteApi

SFSQLiteApi is an C# library to manage SQLite databases in a easy way in your C# projects.
The idea is that you create your data model with objects (each table is a class) and the heavy SQL work is made by the API.

## ​Features
- Create database 
- Open database connection
- Close database connection
- Create table
- Get rows total
- Insert row
- Update row
- Delete row
- Select all rows
- Select one row
- Get column max value
- Get key value list
- Get key value as string
- Get table name
- Activate or deactivate logs

## Issues
If you find any bugs, please submit an [issue](https://github.com/spaf94/SFSQLiteApi/issues/new/).

## How to use
Check the source code of the app test.

## Releases

### 1.17.12.23
First API version with the most of the features described above.

### 1.18.1.6
Added new features to the API:
- Added method GetColumnMaxValue to get the max value from a table column;
- Possibility of activate or deactivate logs;
- Log of the executed commands, queries, possible errors and exceptions in the API;
- Improvements and fixes;

### 1.18.1.29
- Updated log library;
- Performance improvements;
