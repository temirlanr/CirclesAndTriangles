WITH ProductsWithCategories (productId, productName, categoryId) AS (
	SELECT Products.id AS productId, Products.name AS productName, ProductsCategories.categoryId AS categoryId
	FROM Products
	LEFT JOIN ProductsCategories
	ON Products.id = ProductsCategories.productId
)
SELECT productName, Categories.name AS categoryName
FROM ProductsWithCategories
LEFT JOIN Categories
ON ProductsWithCategories.categoryId = Categories.id;