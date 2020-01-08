CREATE TABLE Production.Product
(
    ProductKey INT NOT NULL IDENTITY(1000, 1)
        CONSTRAINT PK_Product PRIMARY KEY,
    ProductName NVARCHAR(50) NOT NULL,
    ProductLineKey INT NOT NULL
        CONSTRAINT FK_Product_ProductLineKey
        REFERENCES Production.ProductLine (ProductLineKey),
    ShippingWeight NUMERIC(10, 4) NULL,
    ProductWeight NUMERIC(10, 4) NULL,
    CONSTRAINT C_Product_Weight CHECK (ShippingWeight IS NULL
                                       OR ProductWeight IS NULL
                                       OR ShippingWeight <= ProductWeight
                                      )
);
