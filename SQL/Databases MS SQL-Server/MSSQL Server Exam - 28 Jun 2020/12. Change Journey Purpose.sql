CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
	AS 
	BEGIN
			IF((SELECT COUNT(*) FROM Journeys WHERE Id = @JourneyId) = 0)
				BEGIN
					THROW 50001, 'The journey does not exist!',1;
				END

			IF((SELECT Purpose FROM Journeys WHERE Id = @JourneyId) LIKE @NewPurpose)
				BEGIN
					THROW 50002, 'You cannot change the purpose!',1;
				END
		UPDATE Journeys
			SET Purpose = @NewPurpose
		WHERE Id = @JourneyId
	END