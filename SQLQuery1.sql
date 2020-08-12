SELECT * FROM Tickets
SELECT * FROM Schedules
SELECT * FROM Aircrafts
SELECT * FROM Airports
SELECT * FROM Routes
SELECT * FROM Amenities
SELECT * FROM AmenitiesTickets
SELECT * FROM CabinTypes
SELECT * FROM AmenitiesCabinType

SELECT * FROM Tickets WHERE BookingReference like '12345E'
SELECT * FROM Schedules WHERE ID like 117

GO
CREATE PROC proc_GetFlightsByBookingReference @bookingReference varchar(6)
AS
SELECT t.ID AS TicketID, FlightNumber, b.IATACode AS DepartureAirportCode, a.IATACode AS ArrivalAirportCode, Date, Time
FROM Tickets t inner join Schedules s
	ON t.ScheduleID = s.ID
inner join Routes r
	ON s.RouteID = r.ID
inner join Airports a
	ON r.ArrivalAirportID = a.ID
inner join Airports b
	ON r.DepartureAirportID = b.ID
WHERE BookingReference like @bookingReference

GO
CREATE PROC proc_GetAmenitiesByCabinTypeID @cabinTypeID int
AS
SELECT AmenityID AS ID, Service, Price
FROM AmenitiesCabinType inner join Amenities
	ON AmenitiesCabinType.AmenityID = Amenities.ID
WHERE CabinTypeID like @cabinTypeID

GO
EXEC proc_GetAmenitiesByCabinTypeID 3

GO
EXEC proc_GetFlightsByBookingReference 'NDURRA'


