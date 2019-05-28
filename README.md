# TF
Steps to install
1. Clone the repository to your local repository.
2. Pull 
3. Open the Nuget package manager console
4. Run the following commands in the Nuget package manager console: 
  4.1 Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
  4.2 Enable-Migrations -ContextTypeName TFAPI.Providers.APIDbContext
  4.3 Update-Database

Open Command Prompt and run the following commands:
  1. SqlLocalDB.exe start "MSSQLLocalDB"
  2. SqlLocalDB.exe info "MSSQLLocalDB"
 
copy the instance pipe name starting with np:\\..

Using Server Explorer in visual studio, click on data connections and add another data connection:
  1. Select Microsoft SQL Server as data source and click continue
  2. paste the instance pipe name into the server name
  3. select the TFAPI.Providers.APIDbContext database
  4. Click ok

Navigate To the Solution Explorer
  Select the TFAPI project
  Go to the Migrations Folder
  Open the seed.sql file
  Connect the script file to the local db instance as described above
  Execute the script
  
  The database should now be pre-populated and the program can now be built.
  
 Select the solution in the solution explorer, set start up projects
 Select multiple projects and choose both projects to start up.
 
Run the application.
  
