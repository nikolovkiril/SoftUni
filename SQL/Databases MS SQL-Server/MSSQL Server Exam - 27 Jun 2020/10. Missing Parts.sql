SELECT p.PartId,
       p.[Description],
       pn.Quantity AS [Required],
       p.StockQty AS [In Stock],
       	   CASE
                  WHEN o.Delivered = 0
                  THEN op.Quantity
                  ELSE 0
				  END 
			AS Ordered
FROM Parts AS p
     LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
     LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
     LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
     LEFT JOIN Orders AS o ON o.JobId = j.JobId
WHERE pn.Quantity > p.StockQty + 
					CASE
                      WHEN o.Delivered = 0
                      THEN op.Quantity
                      ELSE 0
                    END
      AND j.FinishDate IS NULL
ORDER BY p.PartId;