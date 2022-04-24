# AlfaSoftTestDotNet
Develop a C#.NET console application to retrieve information regarding users in bitbucket

## How to run

For execution, it is necessary to run the following command in the location of the 'Program.cs' file:

`dotnet run 'C:\Users\dti Digital\source\repos\AlfaSoftTest\AlfaSoftTest\Users.txt'`

It is mandatory to pass a single argument, referring to the complete path of the users .txt file to be read.

> It is also possible to just run the console program in Visual Studio (launchSettings configured).

## Important remarks

All the necessary points were implemented, except for the need to wait 60 seconds to run each application. The application saves all logs in files in the same execution folder (project path / 'Program.cs' folder).

## Problem description

#### Application Features

The console application should have 5 features:

1 - Receive a mandatory parameter with a full path to a file

2 - Process the file, storing in a variable each username line contained in the file

3 - Retrieve from the bitbucket api information for each user

4 - Log the response from the API to a log file in the same folder as the executable

5 - Exit the application

#### Considerations

The configuration file sent as a parameter can have any amount of users. If multiple users exist in the file, each user should be in a separate line.

Each API request made to Bitbucket should have an interval of 5 seconds. An example URL of the API endpoint is https://api.bitbucket.org/2.0/users/alfasoftdev and requires no authentication. The last segment of the URL should be replaced for each user.

If we run the application multiple times, it should not make requests to the API if the application was ran the last time less than 60 seconds before.

The application should show in the console information regarding which user is being retrieved, as well as the URL being used and the output of the request.

Before exiting, the application should wait 5 seconds.
