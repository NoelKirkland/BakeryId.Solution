# Noel's Bakery

### By Noel Kirkland, 8/14/2020

•[Setup](#2)<br>
•[Bugs](#3)<br>
•[Contact](#4)<br>
•[Tech](#5)<br>
•[License](#6)

## Description

This is a web application for Noel's Bakery. The application will allow the Bakery owner to create custom treats and custom flavors. Any user can see the treats and flavors but only registered users can create, edit, or delete anything. 

## Setup/Installation Requirements <a name="2"></a>

* _Install the .NET framework_
  1. _This program utilizes .NET version 3.1, and requires [this framework to be pre-installed](https://dotnet.microsoft.com/download/dotnet-core/3.1)_

* _Install and configure MySQL_
  1. _This program utilizes MySQL Community Server version 8.0.15 and requires [this to be pre-installed](https://dev.mysql.com/downloads/file/?id=484914). Click the link at the bottom that reads "No thanks, just start my download"_
  2. _Use Legacy Password Encryption and set password to "epicodus"_
  3. _Click "Finish_

* _Download this application from HitHub_
  1. _Open the following web address in your browser: **`https://github.com/NoelKirkland`**_
  2. _Click on the button labeled_ Repositories
  3. _Navigate into the **`BakeryId.Solution`** repository and click the green button labeled "Clone or download" and download the zip to your computer_

* _Install the MySQL database_
  1. _Open the downloaded application in a text editor ([V.S. Code preferred](https://code.visualstudio.com/))_
  2. _Open a new terminal in your text editor (Ctrl+\` in V.S. Code) and run command `> echo 'export PATH="$PATH:/usr/local/mysql/bin"' >> ~/.zprofile`_
  3. _Enter the command `> source ~/.zprofile` to confirm MsSQL has been installed_
  4. _Connect to MySQL by running the command `> mysql -uroot -pepicodus`_
  5. _Install the necessary MySQL database by copying the code block below and entering it into your terminal_
  6. _Once the following code block has been entered you will close MySQL by running the command `> exit`_

```
      DROP DATABASE IF EXISTS `noel_kirkland`;
      CREATE DATABASE `noel_kirkland` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
      USE `noel_kirkland`;
      CREATE TABLE `Flavors` (
        `FlavorId` int(11) NOT NULL AUTO_INCREMENT,
        `Name` longtext,
        `UserId` varchar(255) DEFAULT NULL,
        PRIMARY KEY (`FlavorId`),
        KEY `IX_Flavors_UserId` (`UserId`),
        CONSTRAINT `FK_Flavors_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE RESTRICT
      ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
      CREATE TABLE `Treats` (
        `TreatId` int(11) NOT NULL AUTO_INCREMENT,
        `Name` longtext,
        `UserId` varchar(255) DEFAULT NULL,
        PRIMARY KEY (`TreatId`),
        KEY `IX_Treats_UserId` (`UserId`),
        CONSTRAINT `FK_Treats_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE RESTRICT
      ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
      CREATE TABLE `FlavorTreat` (
        `FlavorTreatId` int(11) NOT NULL AUTO_INCREMENT,
        `FlavorId` int(11) NOT NULL,
        `TreatId` int(11) NOT NULL,
        PRIMARY KEY (`FlavorTreatId`),
        KEY `IX_FlavorTreat_FlavorId` (`FlavorId`),
        KEY `IX_FlavorTreat_TreatId` (`TreatId`),
        CONSTRAINT `FK_FlavorTreat_Flavors_FlavorId` FOREIGN KEY (`FlavorId`) REFERENCES `flavors` (`FlavorId`) ON DELETE CASCADE,
        CONSTRAINT `FK_FlavorTreat_Treats_TreatId` FOREIGN KEY (`TreatId`) REFERENCES `treats` (`TreatId`) ON DELETE CASCADE
      ) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```

* _Run the application_
  1. _In the terminal, navigate to the project directory by running the command `> cd Bakery`_
  2. _Now that we are in the Bakery directory you will run the command `> dotnet restore`_
  3. _Once the "obj" folder has initialized you will run the command `> dotnet run`_
  4. _Go to http://localhost:5000/ in your preferred browser to use the application_


## Known Bugs <a name="2"></a>

There are no known bugs at this time

## Support and Contact Details <a name="3"></a>

If there are any issues or questions contact me at noelkirkland@gmail.com

## Technologies Used <a name="4"></a>

*  C#/.NET
*  MySQL
*  HTML
*  CSS
*  Markdown


### License <a name="5"></a>

*This project uses the following license: [MIT](https://opensource.org/licenses/MIT)*