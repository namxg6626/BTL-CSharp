--
-- CREATE PROC
--
USE [Session5]

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

GO
ALTER FUNCTION func_GetReportByAmenityIDAndCabinID (@flightNumber nvarchar(10), @amenityID int, @cabinID int, @from date, @to date)
RETURNS @table TABLE (
	CabinTypeID int,
	Total int
)
BEGIN
	IF EXISTS (SELECT * FROM Amenities WHERE Price = 0 AND ID LIKE @amenityID)
	BEGIN
		INSERT @table 
			SELECT T.CabinTypeID, COUNT(*) AS Total
			FROM Tickets T LEFT JOIN AmenitiesCabinType A
				ON T.CabinTypeID = A.CabinTypeID
			WHERE ScheduleID in (SELECT ID 
								 FROM Schedules
								 WHERE FlightNumber like @flightNumber 
								 AND Date BETWEEN @from AND @to)
			AND a.AmenityID LIKE @amenityID
			AND t.CabinTypeID LIKE @cabinID
			GROUP BY t.CabinTypeID
		RETURN
	END

	ELSE
	BEGIN
		INSERT @table 
			SELECT t.CabinTypeID, COUNT(*) AS Total
			FROM Tickets t LEFT JOIN AmenitiesTickets a
				ON t.ID = a.TicketID
			WHERE ScheduleID in (SELECT ID 
								 FROM Schedules
								 WHERE FlightNumber like @flightNumber 
								 AND Date BETWEEN @from AND @to)
			AND a.AmenityID LIKE @amenityID
			AND t.CabinTypeID LIKE @cabinID
			GROUP BY t.CabinTypeID
		RETURN
	END
END
