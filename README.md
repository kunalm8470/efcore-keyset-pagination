# Keyset Pagination using EF Core

Offset based pagination (`Take().Skip()`) is bad for deep pagination. More details [`here`](http://use-the-index-luke.com/no-offset).

With Keyset pagination we can only move forwards or backwards, and random access to pages can't be done.

So the first request looks like -

`http://localhost:5266/api/v1/Students?limit=10000`


and the subsequent requests goes like -

`https://localhost:7164/api/v1/Students?searchAfter=637969461162041144&limit=10000`

and this continues on until we have not reached the end of the data.

This repository is an attempt to do Keyset pagination on 1 million students records using EF Core 6 and .NET 6 taking inspiration from [`here`](https://github.com/jasontaylordev/CleanArchitecture).

The data returned looks like this -
```json
{
  "data": [
     ...data
  ],
  "paging": {
    "self": "https://localhost:7164/api/v1/Students?limit=10000",
    "next": "https://localhost:7164/api/v1/Students?searchAfter=637969461162041144&limit=10000"
  }
}
```

<hr>

## To apply migrations -

1. Install the dotnet ef core CLI globally. More info [here](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools)<br/>
`dotnet tool install --global dotnet-ef`

2. Open a terminal in the Infrastructure directory (i.e the directory where the DbContext file resides).

3. Add the migration with an optional migration description <br/>
`dotnet ef migrations add InitialMigration --startup-project ../KeysetPagination.API/KeysetPagination.API.csproj`

4. Update the database <br/>
`dotnet ef database update --startup-project ../KeysetPagination.API/KeysetPagination.API.csproj`

## To generate the fake 1 million students

1. Run the console application `GenerateBulkFakeStudents` and copy the CSV file generated in the `bin > debug > net6.0` directory.

2. Copy the generated CSV into some shared directory like `C:\Temp`.

3. Open SSMS and point to the `StudentsDbKeysetPagination` database and open up a new query window.

4. Run the [`Bulk insert SQL`](https://www.mssqltips.com/sqlservertip/6109/bulk-insert-data-into-sql-server/) command in the SSMS.

```sql
BULK INSERT Students
FROM 'C:\Temp\students.csv'
WITH (FIRSTROW = 2,
    FIELDTERMINATOR = ',',
    ROWTERMINATOR='\n',
    BATCHSIZE=25000,
    MAXERRORS=2);
```
