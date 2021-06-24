SELECT i.Id , u.Username + ' : ' + i.Title  AS IssueAssignee FROM Issues i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY I.Id DESC , i.AssigneeId