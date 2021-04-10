USE tempdb
go

--Crear la base de datos
CREATE DATABASE scmascotas
GO

--Usar la base de datos
Use scmascotas
GO

--Crear el schema de la base de datos
CREATE SCHEMA Veterinaria
GO

--Crear las Tablas
CREATE TABLE Veterinaria.Mascota(
	IdMascota INT NOT NULL IDENTITY(1,1),
	IdCliente INT NOT NULL,
	AliasMascota VARCHAR(50) NOT NULL,
	Especie VARCHAR(50) NOT NULL,
	Raza VARCHAR(50) NOT NULL,
	ColorPelo VARCHAR(50) NOT NULL,
	Fecha DATETIME NOT NULL
)
GO

CREATE TABLE Veterinaria.Cliente(
	IdCliente INT NOT NULL IDENTITY(1,1),
	NombreCliente VARCHAR(50) NOT NULL,
	Telefono VARCHAR(12) NOT NULL,
)
GO

CREATE TABLE Veterinaria.HistorialVacunacion(
	IdHistorialVacunacion INT NOT NULL IDENTITY(1,1),
	IdMascota INT NOT NULL,
	IdProducto INT NOT NULL,
	Fecha DATETIME NOT NULL,
)
GO

CREATE TABLE Veterinaria.Inventario(
	IdProducto INT NOT NULL IDENTITY(1,1),
	IdCategoria INT NOT NULL,
	NombreProducto VARCHAR(50) NOT NULL,
	PrecioCosto FLOAT NOT NULL,
	PrecioVenta FLOAT NOT NULL,
	Stock INT NOT NULL,
)
GO

CREATE TABLE Veterinaria.Categoria(
	IdCategoria INT NOT NULL IDENTITY(1,1),
	NombreCategoria VARCHAR(50) NOT NULL,
)
GO

CREATE TABLE Veterinaria.Venta(
	IdVenta INT NOT NULL IDENTITY(1,1),
	IdDetallesVentas INT NOT NULL,
	IdCliente VARCHAR(50) NOT NULL,
	Impuesto FLOAT NOT NULL,
	Total FLOAT NOT NULL,
	Fecha DATETIME NOT NULL,
)
GO

CREATE TABLE Veterinaria.DetallesVenta(
	IdDetallesVentas INT NOT NULL IDENTITY(1,1),
	IdProducto INT NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	Cantidad INT NOT NULL,
	PrecioUnitario FLOAT NOT NULL,
	Total FLOAT NOT NULL,
)
GO