
SELECT
  c.CategoryID,
  c.CategoryName,
  JSON_ARRAYAGG(JSON_OBJECT('SubCategoryID', sc.SubCategoryID, 'SubCategoryName', sc.SubCategoryName, 'CategoryID', sc.CategoryID)) AS SubCategories,
  c.CreatedBy,
  c.ModifiedBy,
  c.CreatedDate,
  c.ModifiedDate
FROM Category c
  INNER JOIN SubCategory sc
    ON c.CategoryID = sc.CategoryID
GROUP BY c.CategoryID;