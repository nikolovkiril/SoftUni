CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,4), @interestRate FLOAT, @years INT)
RETURNS DECIMAL(15,4) AS
BEGIN
	RETURN @sum * POWER((1 + @interestRate), @years)
END