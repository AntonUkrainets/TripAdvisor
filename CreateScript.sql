CREATE DATABASE TripAdvisor;
GO

USE TripAdvisor;
GO

CREATE TABLE Trips (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    TpepPickupDatetime DATETIME NOT NULL, 
    TpepDropoffDatetime DATETIME NOT NULL, 
    PassengerCount INT NULL, 
    TripDistance FLOAT NOT NULL, 
    StoreAndFwdFlag NVARCHAR(3) NOT NULL, 
    PULocationID INT NOT NULL, 
    DOLocationID INT NOT NULL, 
    FareAmount DECIMAL(10, 2) NOT NULL, 
    TipAmount DECIMAL(10, 2) NOT NULL 
);
GO

CREATE INDEX IX_Trips_PULocationID
ON Trips (PULocationID);
GO

CREATE INDEX IX_Trips_TripDistance
ON Trips (TripDistance);
GO

CREATE INDEX IX_Trips_TripDuration
ON Trips (TpepPickupDatetime, TpepDropoffDatetime);
GO

