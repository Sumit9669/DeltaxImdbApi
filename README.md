# DeltaXImdbApi
Scaffold template for a Web API with PostgreSQL on Heroku

## Deploy To Heroku
[![Deploy](https://www.herokucdn.com/deploy/button.svg)](https://heroku.com/deploy)

## Connecting to the database

* While developing locally, you can change the PostgreSQL connection string in `DeltaxImdbApi\Program.cs`
    *   ```
        public static void Main(string[] args)
        {
            // While developing locally, set your Heroku database connection string here.
            // When ready to deploy to Heroku, remove this code.
            DeltaxImdbApiConfiguration.ConnectionString = "PUT_HEROKU_DATABSE_CONNECTION_STRING_HERE";

            CreateHostBuilder(args).Build().Run();
        }
        ```

    * When finished with local development, remove this. Heroku’s database credentials can change anytime - hence, it is recommended to always read the connection string from the environment variable. The `DeltaxImdbApiConfiguration` class handles this for you.
        * Please see this [SO answer](https://stackoverflow.com/a/53292619).
* If you are using Migrations for the database, please read [these instructions](https://github.com/jincod/dotnetcore-buildpack#entity-framework-core-migrations).

* Example code in `C#`
    *   ```
        // This automatically gives you a connection to the heroku database
        using (var connection = DeltaxImdbApiConfiguration.GetConnection())
        {
            connection.Open();
            
            // Do some meaningful work with connection
            
            connection.Close();
        }
        ```