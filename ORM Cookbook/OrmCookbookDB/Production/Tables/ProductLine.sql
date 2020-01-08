CREATE TABLE Production.ProductLine
(
    ProductLineKey INT NOT NULL IDENTITY(1000, 1)
        CONSTRAINT PK_ProductLine PRIMARY KEY,
    ProductLineName NVARCHAR(50) NOT NULL
        CONSTRAINT UX_ProductLine_ProductLineName
        UNIQUE
);
