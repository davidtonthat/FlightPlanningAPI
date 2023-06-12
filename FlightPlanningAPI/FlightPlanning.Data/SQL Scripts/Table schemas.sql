USE FlightPlanning

Create Table Countries
(
    CountryID  INT IDENTITY(1,1) NOT NULL,
    Name       VARCHAR(50) NOT NULL,
    CONSTRAINT PK_CountryID PRIMARY KEY(CountryID)
);

Create Table Airports
(
    AirportID  INT IDENTITY(1,1) NOT NULL,
    IATACode   VARCHAR(30) NOT NULL,
    GeographyLevel1ID INT  NOT NULL,
    Type       VARCHAR(50) NOT NULL,
    CONSTRAINT PK_AirportID PRIMARY KEY(AirportID),
               FK_GeographyLevelID INT FOREIGN KEY(GeographyLevel1ID) REFERENCES Countries(CountryID)
);

Create Table Routes
(
    RouteID  INT IDENTITY(1,1) NOT NULL,
    DepartureAirportID INT NOT NULL,
    ArrivalAirportID   INT NOT NULL,
    CONSTRAINT PK_RouteID PRIMARY KEY(RouteID),
               FK_DepartAirportID INT FOREIGN KEY(DepartureAirportID) REFERENCES Airports(AirportID),
               FK_ArriveAirportID INT FOREIGN KEY(ArrivalAirportID)   REFERENCES Airports(AirportID)
);

Create Table AirportGroups
(
    AirportGroupID INT IDENTITY(1,1) NOT NULL,
    Name           VARCHAR(60) NOT NULL,
    CONSTRAINT PK_AirportGroupID PRIMARY KEY(AirportGroupID)
);

Create Table AirportGroupAirportsLinks
(
    LinkID  INT IDENTITY(1,1) NOT NULL,
    AirportGroupID INT NOT NULL,
    AirportID      INT NOT NULL,
    CONSTRAINT PK_LinkID PRIMARY KEY(LinkID),
               FK_AirportGroupID INT FOREIGN KEY(AirportGroupID) REFERENCES AirportGroups(AirportGroupID),
               FK_AirportID      INT FOREIGN KEY(AirportID)      REFERENCES Airports(AirportID)
);

Go
