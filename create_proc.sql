SELECT * FROM Schedules
SELECT * FROM Aircrafts
SELECT * FROM Airports
SELECT * FROM Routes
SELECT * FROM Amenities
SELECT * FROM AmenitiesTickets
--delete from AmenitiesTickets
SELECT * FROM CabinTypes
SELECT * FROM AmenitiesCabinType

SELECT * FROM Tickets WHERE BookingReference like '12345E'
SELECT * FROM Schedules WHERE ID like 117

--
-- CREATE PROC
--

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
CREATE PROC proc_InsertAmenitiesTickets @amenityID int, @ticketID int
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM 
				   AmenitiesTickets WHERE AmenityID LIKE @amenityID AND TicketID LIKE @ticketID)
	BEGIN
		DECLARE @price money
		SET @price = (SELECT Price From Amenities WHERE ID LIKE @amenityID)
		INSERT AmenitiesTickets VALUES (@amenityID, @ticketID, @price)
		PRINT 'Insert successfully'
	END
	ELSE PRINT 'Duplicate! No row affected'
END

GO
CREATE PROC proc_GetPurchasedAmenitiesByTicketID @ticketID int
AS
BEGIN
	SELECT * 
	FROM Amenities
	WHERE ID IN (SELECT AmenityID
			     FROM AmenitiesTickets
				 WHERE TicketID LIKE @ticketID)
END

select ID 
from Tickets 
where ScheduleID in (select ID 
					 from Schedules
					 where FlightNumber = 50 
						   and date between '2018-10-04' and '2018-10-08')

--
-- Test Phase
--

GO
EXEC proc_GetPurchasedAmenitiesByTicketID 437

GO
EXEC proc_InsertAmenitiesTickets @amenityID = 1, @ticketID = 8345

GO
EXEC proc_GetAmenitiesByCabinTypeID 3

GO
EXEC proc_GetFlightsByBookingReference 'NDURRA'
