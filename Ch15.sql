CREATE DATABASE ctci_db;
GO

USE ctci_db;
GO

CREATE TABLE Complexes
    (
      ComplexId INT PRIMARY KEY ,
      ComplexName VARCHAR(256)
    )

CREATE TABLE Buildings
    (
      BuildingId INT PRIMARY KEY ,
      ComplexId INT FOREIGN KEY REFERENCES dbo.Complexes ( ComplexId ) ,
      BuildingName VARCHAR(256) ,
      [Address] VARCHAR(256)
    )

CREATE TABLE Apartments
    (
      AptId INT PRIMARY KEY ,
      UnitNumber VARCHAR(256) ,
      BuildingId INT FOREIGN KEY REFERENCES dbo.Buildings ( BuildingId )
    )


CREATE TABLE Tenants
    (
      TenantId INT PRIMARY KEY ,
      TenantName VARCHAR(256)
    )


CREATE TABLE AptTenants
    (
      TenantId INT ,
      AptId INT CONSTRAINT pk_AptTenants PRIMARY KEY ( TenantId, AptId )
    )

CREATE TABLE Requests
    (
      RequestId INT PRIMARY KEY ,
      Status VARCHAR(256) ,
      AptId INT FOREIGN KEY REFERENCES dbo.Apartments ( AptId ) ,
      Description VARCHAR(256)
    )
GO

INSERT  INTO Complexes
VALUES  ( 1, 'Complex #1' )
INSERT  INTO Complexes
VALUES  ( 2, 'Complex #2' )
INSERT  INTO Complexes
VALUES  ( 3, 'Complex #3' )
INSERT  INTO Complexes
VALUES  ( 4, 'Complex #4' )

INSERT  INTO Buildings
VALUES  ( 1, 1, 'Building #1 Complex #1', 'Building Address 1' )
INSERT  INTO Buildings
VALUES  ( 2, 1, 'Building #2 Complex #1', 'Building Address 2' )
INSERT  INTO Buildings
VALUES  ( 3, 1, 'Building #3 Complex #1', 'Building Address 3' )
INSERT  INTO Buildings
VALUES  ( 4, 1, 'Building #4 Complex #1', 'Building Address 4' )

INSERT  INTO Buildings
VALUES  ( 5, 2, 'Building #1 Complex #2', 'Building Address 5' )
INSERT  INTO Buildings
VALUES  ( 6, 2, 'Building #2 Complex #2', 'Building Address 6' )
INSERT  INTO Buildings
VALUES  ( 7, 2, 'Building #3 Complex #2', 'Building Address 7' )
INSERT  INTO Buildings
VALUES  ( 8, 2, 'Building #4 Complex #2', 'Building Address 8' )

INSERT  INTO Buildings
VALUES  ( 9, 3, 'Building #1 Complex #3', 'Building Address 9' )
INSERT  INTO Buildings
VALUES  ( 10, 3, 'Building #2 Complex #3', 'Building Address 10' )
INSERT  INTO Buildings
VALUES  ( 11, 3, 'Building #3 Complex #3', 'Building Address 11' )
INSERT  INTO Buildings
VALUES  ( 12, 3, 'Building #4 Complex #3', 'Building Address 12' )

INSERT  INTO Buildings
VALUES  ( 13, 4, 'Building #1 Complex #4', 'Building Address 1' )
INSERT  INTO Buildings
VALUES  ( 14, 4, 'Building #2 Complex #4', 'Building Address 2' )
INSERT  INTO Buildings
VALUES  ( 15, 4, 'Building #3 Complex #4', 'Building Address 3' )
INSERT  INTO Buildings
VALUES  ( 16, 4, 'Building #4 Complex #4', 'Building Address 4' )

INSERT  INTO Apartments
VALUES  ( 1, 'Apartment #1 Building #1', 1 )
INSERT  INTO Apartments
VALUES  ( 2, 'Apartment #2 Building #1', 1 )
INSERT  INTO Apartments
VALUES  ( 3, 'Apartment #3 Building #1', 1 )
INSERT  INTO Apartments
VALUES  ( 4, 'Apartment #1 Building #2', 2 )
INSERT  INTO Apartments
VALUES  ( 5, 'Apartment #2 Building #2', 2 )
INSERT  INTO Apartments
VALUES  ( 6, 'Apartment #3 Building #2', 2 )
INSERT  INTO Apartments
VALUES  ( 7, 'Apartment #1 Building #3', 3 )
INSERT  INTO Apartments
VALUES  ( 8, 'Apartment #2 Building #3', 3 )
INSERT  INTO Apartments
VALUES  ( 9, 'Apartment #3 Building #3', 3 )
INSERT  INTO Apartments
VALUES  ( 10, 'Apartment #1 Building #4', 4 )
INSERT  INTO Apartments
VALUES  ( 11, 'Apartment #2 Building #4', 4 )
INSERT  INTO Apartments
VALUES  ( 12, 'Apartment #3 Building #4', 4 )
INSERT  INTO Apartments
VALUES  ( 13, 'Apartment #3 Building #4', 4 )
INSERT  INTO Apartments
VALUES  ( 14, 'Apartment #3 Building #4', 4 )

INSERT  INTO Tenants
VALUES  ( 1, 'Tenant #1' )
INSERT  INTO Tenants
VALUES  ( 2, 'Tenant #2' )
INSERT  INTO Tenants
VALUES  ( 3, 'Tenant #3' )
INSERT  INTO Tenants
VALUES  ( 4, 'Tenant #4' )

INSERT  INTO AptTenants
VALUES  ( 1, 1 )
INSERT  INTO AptTenants
VALUES  ( 2, 3 )
INSERT  INTO AptTenants
VALUES  ( 2, 4 )
INSERT  INTO AptTenants
VALUES  ( 3, 5 )
INSERT  INTO AptTenants
VALUES  ( 3, 6 )
INSERT  INTO AptTenants
VALUES  ( 4, 7 )
INSERT  INTO AptTenants
VALUES  ( 4, 8 )

INSERT  INTO Requests
VALUES  ( 1, 'Initial', 9, 'Request Desc #1' )
INSERT  INTO Requests
VALUES  ( 2, 'Initial', 10, 'Request Desc #2' )
INSERT  INTO Requests
VALUES  ( 3, 'Initial', 11, 'Request Desc #3' )
INSERT  INTO Requests
VALUES  ( 4, 'Open', 12, 'Request Desc #4' )
INSERT  INTO Requests
VALUES  ( 5, 'Open', 13, 'Request Desc #5' )
INSERT  INTO Requests
VALUES  ( 6, 'Open', 14, 'Request Desc #6' )
INSERT  INTO Requests
VALUES  ( 7, 'Open', 1, 'Request Desc #7' )
INSERT  INTO Requests
VALUES  ( 8, 'Open', 2, 'Request Desc #7' )
INSERT  INTO Requests
VALUES  ( 9, 'Open', 3, 'Request Desc #7' )

/*
 Task 15.1
 Write a SQL query to get a list 
 of tenants who are renting more 
 than one apartment
*/

SELECT  at.TenantId ,
        t.TenantName
FROM    AptTenants AS at
        LEFT JOIN dbo.Tenants AS t ON t.TenantId = at.TenantId
GROUP BY at.TenantId ,
        t.TenantName
HAVING  COUNT(*) > 1

/* Task 15.2 
 Write a SQL query 
 to get a list of all buildings and 
 the number of open requests
 (Requests in which 
  status equals 'Open')
*/
SELECT  b.BuildingName ,
        COUNT(r.AptId)
FROM    dbo.Requests AS r
        INNER JOIN dbo.Apartments AS a ON a.AptId = r.AptId
        INNER JOIN dbo.Buildings AS b ON b.BuildingId = a.BuildingId
WHERE   r.Status = 'Open'
GROUP BY b.BuildingName


/* Task 15.3 
 Building #11 is undergoing a major renovation. 
 Implement a query to close all requests from 
 apartments in this building.
*/

SELECT * FROM Requests WHERE Status = 'Closed'

UPDATE  r
SET     Status = 'Closed'
FROM    Requests AS r
        INNER JOIN Apartments AS a ON a.AptId = r.AptId
        INNER JOIN Buildings AS b ON b.BuildingId = a.BuildingId
WHERE b.BuildingId = 1

SELECT * FROM Requests WHERE Status = 'Closed'




USE master
GO

DROP DATABASE ctci_db;