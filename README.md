# booking-admin-app
This application is home to managing configurations that control aspects of the smart meter booking journey

## Tech Stack
1. Server side: ASP.Net Core (CRUD APIs)
2. Client side: REACT served from Node.js
3. ORM: EF Core
4. Database: Sql Server hosted on-Premise
5. Container: DOCKER linux

## Build and deploy commands
```
\BookingAdminSolution\BookingAdminUi> docker build -t bookingmanagementapp .
\BookingAdminSolution\BookingAdminUi> docker run -d -p 8080:80 --name bookingadminapp bookingmanagementapp
```
