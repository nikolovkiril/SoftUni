CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
BEGIN
	DECLARE @index INT = 1
	DECLARE @currentChar CHAR(1)
	DECLARE @isComprised INT

	WHILE(@index <= LEN(@word))
	BEGIN
		SET @currentChar = SUBSTRING(@word,@index,1)
		SET @isComprised = CHARINDEX(@currentChar,@setOfLetters)
		IF(@isComprised = 0)
			RETURN 0
  
		SET @index += 1
	END
	RETURN 1
END