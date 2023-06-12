USE master
Go

Create Database FlightPlanning
ON PRIMARY
(Name = Flight_Data,
 Filename = "C:\Temp\Flight_Data.mdf",
 Size = 100MB,
 MaxSize = Unlimited,
 FileGrowth = 10%
)
Go
