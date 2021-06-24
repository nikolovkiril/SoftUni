SELECT DepositGroup , SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator LIKE '%Ollivander%'
GROUP BY DepositGroup 
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC