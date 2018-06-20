# SampleWebAPI 
ASP.NET Core 2.1 Web API With Code First Approach

Swagger is active.

Sample urls for testing:

GET - User list by department - https://localhost:44333/api/users?departmentId=1

GET - Get a single user from a department - https://localhost:44333/api/departments/1?userId=1

POST - Login - https://localhost:44333/api/login?username=asd&password=vfd

POST - Register user - https://localhost:44333/api/users

PUT - Update user profile - https://localhost:44333/api/users/edit/2

Known Bugs:

-`Run all` in unit testing does not work due to an issue with initilization of mapping. Unit tests work if run one by one.
