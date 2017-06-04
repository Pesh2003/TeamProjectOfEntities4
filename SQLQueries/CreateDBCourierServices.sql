
CREATE DATABASE CourierServices



USE  CourierServices

CREATE TABLE Offices(
Id INT IDENTITY,
Address NVARCHAR(150) NOT NULL,
CityId INT NOT NULL,
CONSTRAINT PK_Offices PRIMARY KEY (Id))
----------------------------------------

CREATE TABLE Cities(
Id INT IDENTITY,
CityName NVARCHAR(50) NOT NULL
CONSTRAINT PK_Cities PRIMARY KEY (Id))
-----------------------------------------

ALTER TABLE Offices
ADD CONSTRAINT FK_Offices_Cities FOREIGN KEY (Id) REFERENCES Cities(Id)
-------------------------------------------------------------------------

CREATE TABLE ServicesTypes(
Id INT IDENTITY,
ServiceType NVARCHAR(30) NOT NULL UNIQUE,
CONSTRAINT PK_ServicesTypes PRIMARY KEY (Id))
---------------------------------------------

CREATE TABLE ServiceOptions(
Id INT IDENTITY,
ServiceTypeId INT NOT NULL,
Weight FLOAT NOT NULL,
Price MONEY NOT NULL,
Time DATE NOT NULL,
CONSTRAINT PK_ServiceOptions PRIMARY KEY (Id),
CONSTRAINT FK_ServiceOptions_ServicesTypes FOREIGN KEY (ServiceTypeId) REFERENCES ServicesTypes(Id))
----------------------------------------------------------------------------------------------------

CREATE TABLE Services(
Id INT IDENTITY,
ServiceOptionsId INT NOT NULL,
Details NTEXT NOT NULL,
IsTaken BIT,
CreateData DATE NOT NULL,
CityId INT NOT NULL,
CONSTRAINT PK_Services PRIMARY KEY (Id),
CONSTRAINT FK_Services_ServiceOptions FOREIGN KEY (ServiceOptionsId) REFERENCES ServiceOptions (Id),
CONSTRAINT FK_Services_Cities FOREIGN KEY (CityId) REFERENCES Cities (Id))
