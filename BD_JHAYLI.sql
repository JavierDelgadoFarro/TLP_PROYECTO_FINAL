CREATE DATABASE DB_JHAYLI 
GO 
USE DB_JHAYLI
GO

CREATE TABLE Categoria (
idCategoria int primary key identity,
Cat_descripcion varchar(100),
Cat_estado bit default 1,
Cat_fechaRegistro datetime default getdate()
)
GO 

CREATE TABLE Marca(
idMarca int primary key identity,
Mar_descripcion varchar(100),
Mar_estado bit default 1,
Mar_fechaRegistro datetime default getdate()
)
GO

CREATE TABLE Producto(
idProducto int primary key identity,
Prod_nombre varchar(500),
Prod_descripcion varchar(500),
idMarca int references Marca(idMarca),
idCategoria int references Categoria(idCategoria),
Prod_precio decimal(10,2) default 0,
Prod_stock int,
Prod_rutaImagen varchar(100),
Prod_nombreImagen varchar(100),
Prod_estado bit default 1,
Prod_fechaRegistro datetime default getdate()
)
GO

CREATE TABLE Cliente(
idCliente int primary key identity,
Cli_nombres varchar(100),
Cli_apellidos varchar(100),
Cli_correo varchar(100),
Cli_contraseña varchar(150),
Cli_reestablecer bit default 0,
Cli_fechaRegistro datetime default getdate()
)
GO

CREATE TABLE Carrito(
idCarrito int primary key identity,
idCliente int references Cliente(idCliente),
idProducto int references Producto(idProducto),
Car_cantidad int
)
GO

CREATE TABLE Venta(
idVenta int primary key identity,
idCliente int references Cliente(idCliente),
Ven_totalProducto int, 
Ven_montoTotal decimal(10,2),
Ven_contacto varchar(50),
idDistrito varchar(10),
Ven_telefono varchar(50),
Ven_direccion varchar(500),
idTransaccion varchar(50),
Ven_fechaVenta datetime default getdate()
)
GO

CREATE TABLE DetalleVenta(
idDetalleventa int primary key identity,
idVenta int references Venta(idVenta),
idProducto int references Producto(idProducto),
DV_Cantidad int,
DV_Total decimal(10,2)
)
GO

CREATE TABLE Usuario(
idUsuario int primary key identity,
Usu_nombres varchar(100),
Usu_apellidos varchar(100),
Usu_correo varchar(100),
Usu_contraseña varchar(150),
Usu_reestablecer bit default 1,
Usu_estado bit default 1,
Usu_fechaRegistro datetime default getdate()
)
GO

CREATE TABLE Departamento(
idDepartamento varchar(2) NOT NULL,
Dep_descripcion varchar(45) NOT NULL
)
GO

CREATE TABLE Provincia(
idProvincia varchar(4) NOT NULL,
Prov_descripcion varchar(45) NOT NULL,
idDepartamento varchar(2) NOT NULL
)
GO

CREATE TABLE Distrito(
idDistrito varchar(6) NOT NULL,
Dis_descripcion varchar(45) NOT NULL,
idProvincia varchar(4) NOT NULL,
idDepartamento varchar(2) NOT NULL
)
GO