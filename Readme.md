# Communication Tracking System (CTS)

Formerly known as Helpline. This application was orginally made for the Helpline team to document their phone calls through tickets, 
however this application has envolved to where it keeps all communication from the outside. This application is currently owned by the 
DPI communication group.

-----

## About Helpline Project

This solution only consist of one project labled as Helpline. This is a ASP.NET MVC 5 project. The bootstrap library was upgraded from 
version 3 to version 4. ASP.NET API 2 was also added into this project in order for users to work the images view under the Ticket 
Controller. The back end design also involves using the [Generic Repository Design Pattern](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application) 
along with the MVC pattern.

The data approach was through Code First Entity Framework 6. This application connects to a internal SQL Server database within the 
department of agriculture called **HelplineDB**. 

### User Authorization and Identity

Orginally the intention was to use ASP.NET Framework Identity, however due to the limitations of the departments server, 
the windows active directory had to be used. The `User.Identity.Name` object in the controllers contains the active directory user name.
That user name is matched with the user name entries in the Users table to determine the user of the application.

------

## Coding and Debuging

The following are steps to download, debug, and code on this project:

1. Use Visual Studios Team Explorer to connect to the TFS Server PI_Applications.
2. Target the Helpline Solution folder.
3. Once the Helpline Solution is downloaded to your local computer. Clear all contents under the local Packages folder.
4. Build your Helpline Project. By building your Helpline Project, it should generate all required nugget packages. 

### Database Connection

This application can only run on the FDACS internal network and connect to the development **Helpline_DB**. located at **TLHSQL17DEV**

  ## SQL Server Databases

*It is recommended to use SQL Server Management Studio or Azure Data Studio*

**Database:** CTS

**Development Connection String** 

`Data Source=TLHSQL17DEV\DPI;Initial Catalog=HelplineDB; User Id=helpline_dau;Password=florida#1" providerName="System.Data.SqlClient`


 1. **Development:** TLHSQL17DEV
 2. **Test:** TLHSQL17TEST
 3. **Production:** TLHSQL17

 -----

 ## Deloying Application

>  ### **NOTICE:** This application was designed where this can only work on the interal department network.

 This application is deloyed through an windows server owned by the department. The following are steps to deloy this application on 
 the department's development server:

 1. Make sure all code is up to date on DevOps. 
 2. Open the publish menu under Visual Studios. 
 3. Select the folder option for publishing the application. 
 4. The target designation should be \\tlhintappdev02\helpline
 5. Set Delete existing files to true and the configuration should be set to release.

 >  *Any push to the testing or production should needs to be done through the infastructure under Office of Agriculture Technology Services.*
 



 <sub>*Last updated on 02/14/2023*</sub>
