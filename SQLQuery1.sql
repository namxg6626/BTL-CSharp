select * from Tickets
select * from Schedules
select * from Aircrafts
select * from Airports
select * from Routes
select * from Amenities
select * from AmenitiesTickets
select * from CabinTypes
select * from AmenitiesCabinType

select * from Tickets where BookingReference like '12345E'
select * from Schedules where ID like 117

go
create proc proc_GetFlightsByBookingReference @bookingReference varchar(6)
as
select t.ID as TicketID, FlightNumber, b.IATACode as DepartureAirportCode, a.IATACode as ArrivalAirportCode, Date, Time
from Tickets t inner join Schedules s
	on t.ScheduleID = s.ID
inner join Routes r
	on s.RouteID = r.ID
inner join Airports a
	on r.ArrivalAirportID = a.ID
inner join Airports b
	on r.DepartureAirportID = b.ID
where BookingReference like @bookingReference

go
create proc proc_GetAmenitiesByCabinTypeID @cabinTypeID int
as
select AmenityID, Service, Price
from AmenitiesCabinType inner join Amenities
	on AmenitiesCabinType.AmenityID = Amenities.ID
where CabinTypeID like @cabinTypeID

go
exec proc_GetAmenitiesByCabinTypeID 3

exec proc_GetFlightsByBookingReference '12345E'
