USE SoftUni
GO
CREATE PROC usp_AssignProject(@emloyeeId INT, @projectId INt)
AS
BEGIN TRANSACTION
DECLARE @employee INT = (SELECT EmployeeId FROM Employees WHERE EmployeeID = @emloyeeId)
DECLARE @project INT = (SELECT ProjectId FROM Projects WHERE ProjectID = @projectId)

IF(@emloyeeId IS NULL OR @project IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid employees id or project id!',16,1)
	RETURN
END

DECLARE @employeeProjects INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

IF(@employeeProjects >= 3)
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!',16,2)
	RETURN
END

INSERT INTO EmployeesProjects(EmployeeID,ProjectID) VALUES (@emloyeeId,@projectId)

COMMIT