CREATE database LpProducts
GO

USE LpProducts

--CRAMOS LA TABLA DONDE SE ALMACENE LOS DATOS DEL PRODUCTO.
CREATE TABLE Products
(
ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Name_Product VARCHAR(150),
Price_Product DECIMAL(14,2),
Fch_Movto DATETIME,
Activo BIT
)
GO


--CREAMOS PROCEDIMIENTOS PARA INSERTAR, MODIFICAR, ELIMINAR Y MOSTRAR LOS DATOS DE LOS PRODUCTOS.
CREATE PROC SP_Get_AllProduct
AS
BEGIN

	SELECT
		ID As IdProducto
		,Name_Product AS NameProduct
		,Price_Product AS PriceProduct
		,CONVERT(varchar, Fch_Movto, 3) AS FchMovt
	FROM Products WHERE Activo != 1

END
GO

CREATE PROC SP_Post_Product
(
@nameProduct varchar(150),
@priceProduct decimal(14,2)
)
AS
BEGIN

	--Obtenemos la fecha actual del sistema.
	DECLARE @Fch DATETIME = GETDATE();

	--Activamos el precio por primera vez.
	DECLARE @Act BIT = 0;

	--INSERTAMOS LOS DATOS A LA TABLA DE PRODUCTO.
	INSERT INTO Products(Name_Product, Price_Product, Fch_Movto, Activo)
	VALUES(@nameProduct, @priceProduct, @Fch, @Act);

END
GO

CREATE PROC SP_Update_ByIdProduct
(
@priceProduct DECIMAL(14,2),
@id_Product int
)
AS
BEGIN
	
	--Obtenemos la fecha actual del sistema.
	DECLARE @Fch DATETIME = GETDATE();

	--Modificamos el precio del producto seleccionado.
	UPDATE Products SET Price_Product = @priceProduct, Fch_Movto = @Fch
	WHERE ID = @id_Product

END
GO