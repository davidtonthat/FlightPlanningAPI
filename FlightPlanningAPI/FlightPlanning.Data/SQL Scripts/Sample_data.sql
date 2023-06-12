USE FlightPlanning

INSERT INTO Countries(Name) VALUES('United Kingdom');
INSERT INTO Countries(Name) VALUES('Spain');
INSERT INTO Countries(Name) VALUES('United States');
INSERT INTO Countries(Name) VALUES('Turkey');
INSERT INTO Countries(Name) VALUES('Italy');
INSERT INTO Countries(Name) VALUES('Mexico');
INSERT INTO Countries(Name) VALUES('Brazil');
INSERT INTO Countries(Name) VALUES('Singapore');
INSERT INTO Countries(Name) VALUES('China');
INSERT INTO Countries(Name) VALUES('Japan');
Go

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('LGW', 1, 'Departure and Arrival');

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('PMI', 2, 'Arrival Only');

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('LAX', 3, 'Arrival Only');

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('ATL', 3, 'Departure and Arrival');

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('FCO', 5, 'Departure and Arrival');      -- Rome Fiumicino airport

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('MEX', 6, 'Arrival Only');               -- Mexico city

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('GRU', 7, 'Departure and Arrival');      -- Sao Paulo/Guarulhos airport

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('SIN', 8, 'Departure and Arrival');      -- Singapore

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('SZX', 9, 'Arrival Only');               -- Shenzen

INSERT INTO Airports(IATACode, GeographyLevel1ID, Type)
            VALUES('HND', 10, 'Departure and Arrival');     -- Haneda airport
Go

INSERT INTO Routes(DepartureAirportID, ArrivalAirportID) VALUES(1, 2);
INSERT INTO Routes(DepartureAirportID, ArrivalAirportID) VALUES(1, 3);
Go

INSERT INTO AirportGroups(Name) VALUES('European airport group');
INSERT INTO AirportGroups(Name) VALUES('North American airport group');
INSERT INTO AirportGroups(Name) VALUES('South American airport group');
INSERT INTO AirportGroups(Name) VALUES('East Asian airport group');
Go

INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(1, 1);  -- LGW
INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(1, 2);  -- PMI
INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(1, 5);  -- FCO

INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(2, 3);  -- LAX
INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(2, 4);  -- ATL
INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(3, 6);  -- MEX
INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(3, 7);  -- GRU

INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(4, 8);  -- SIN
INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(4, 9);  -- SZX
INSERT INTO AirportGroupAirportsLinks(AirportGroupID, AirportID) VALUES(4, 10); -- HND
Go
