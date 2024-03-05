To run the application.
You need to have an instance of PostgreSQL database running with table "Products".

CREATE TABLE Products
(
    Id SERIAL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);


Current setup is hardcoded for the following connection details: connectionString = "Host=localhost;Database=product_manager;Username=postgres;Password=password";

The Console application will 
Initially print out the data from API End point to console.
Backup the current database into ./products_{timestamp}.txt
Check if products.txt exists, if it does, it will create/update the records in the database.
It will then remove the first item in the database and and print out the final state of the database.
