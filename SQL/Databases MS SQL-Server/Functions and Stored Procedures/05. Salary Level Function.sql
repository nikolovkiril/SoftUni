CREATE FUNCTION  ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @Result VARCHAR(10)
	 IF	@salary IS NULL
		SET @Result = NULL
	 IF @salary < 30000  
		SET @Result = 'Low'
	ELSE IF @salary between 30000 and 50000  
		SET @Result = 'Average'
	ELSE IF  @salary > 50000  
		SET @Result = 'High'
	RETURN @Result
END


SELECT LOWER(FirstName) ,Salary ,  [dbo].[ufn_GetSalaryLevel](10000) AS [Salary Level] FROM Employees