UPDATE Rooms
SET Price += 0.14 * Price
WHERE HotelId = 5 OR HotelId = 7 OR HotelId = 9;

