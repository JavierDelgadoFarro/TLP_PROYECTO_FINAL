USE [DB_JHAYLI]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[idCarrito] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[idProducto] [int] NULL,
	[Car_cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Cat_descripcion] [varchar](100) NULL,
	[Cat_estado] [bit] NULL,
	[Cat_fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[Cli_nombres] [varchar](100) NULL,
	[Cli_apellidos] [varchar](100) NULL,
	[Cli_correo] [varchar](100) NULL,
	[Cli_contraseña] [varchar](150) NULL,
	[Cli_reestablecer] [bit] NULL,
	[Cli_fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[idDepartamento] [varchar](2) NOT NULL,
	[Dep_descripcion] [varchar](45) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[idDetalleventa] [int] IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NULL,
	[idProducto] [int] NULL,
	[DV_Cantidad] [int] NULL,
	[DV_Total] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[idDistrito] [varchar](6) NOT NULL,
	[Dis_descripcion] [varchar](45) NOT NULL,
	[idProvincia] [varchar](4) NOT NULL,
	[idDepartamento] [varchar](2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[Mar_descripcion] [varchar](100) NULL,
	[Mar_estado] [bit] NULL,
	[Mar_fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Prod_nombre] [varchar](500) NULL,
	[Prod_descripcion] [varchar](500) NULL,
	[idMarca] [int] NULL,
	[idCategoria] [int] NULL,
	[Prod_precio] [decimal](10, 2) NULL,
	[Prod_stock] [int] NULL,
	[Prod_rutaImagen] [varchar](100) NULL,
	[Prod_nombreImagen] [varchar](100) NULL,
	[Prod_estado] [bit] NULL,
	[Prod_fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[idProvincia] [varchar](4) NOT NULL,
	[Prov_descripcion] [varchar](45) NOT NULL,
	[idDepartamento] [varchar](2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usu_nombres] [varchar](100) NULL,
	[Usu_apellidos] [varchar](100) NULL,
	[Usu_correo] [varchar](100) NULL,
	[Usu_password] [varchar](150) NULL,
	[Usu_reestablecer] [bit] NULL,
	[Usu_estado] [bit] NULL,
	[Usu_fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NULL,
	[Ven_totalProducto] [int] NULL,
	[Ven_montoTotal] [decimal](10, 2) NULL,
	[Ven_contacto] [varchar](50) NULL,
	[idDistrito] [varchar](10) NULL,
	[Ven_telefono] [varchar](50) NULL,
	[Ven_direccion] [varchar](500) NULL,
	[idTransaccion] [varchar](50) NULL,
	[Ven_fechaVenta] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [Usu_nombres], [Usu_apellidos], [Usu_correo], [Usu_password], [Usu_reestablecer], [Usu_estado], [Usu_fechaRegistro]) VALUES (1, N'Harvy', N'Albarran', N'harvy@gmail.com', N'123456', 1, 1, CAST(N'2022-11-28T02:05:33.080' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [Usu_nombres], [Usu_apellidos], [Usu_correo], [Usu_password], [Usu_reestablecer], [Usu_estado], [Usu_fechaRegistro]) VALUES (2, N'Javier', N'Delgado', N'javier@gmail.com', N'987654', 1, 0, CAST(N'2022-11-29T18:14:24.973' AS DateTime))
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((1)) FOR [Cat_estado]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT (getdate()) FOR [Cat_fechaRegistro]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((0)) FOR [Cli_reestablecer]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (getdate()) FOR [Cli_fechaRegistro]
GO
ALTER TABLE [dbo].[Marca] ADD  DEFAULT ((1)) FOR [Mar_estado]
GO
ALTER TABLE [dbo].[Marca] ADD  DEFAULT (getdate()) FOR [Mar_fechaRegistro]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((0)) FOR [Prod_precio]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((1)) FOR [Prod_estado]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (getdate()) FOR [Prod_fechaRegistro]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Usu_reestablecer]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Usu_estado]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [Usu_fechaRegistro]
GO
ALTER TABLE [dbo].[Venta] ADD  DEFAULT (getdate()) FOR [Ven_fechaVenta]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([idVenta])
REFERENCES [dbo].[Venta] ([idVenta])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marca] ([idMarca])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
/****** Object:  StoredProcedure [dbo].[SP_EditarUsuario]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_EditarUsuario](
	 @idUsuario INT,
	 @nombres VARCHAR(100),
	 @apellidos VARCHAR(100),
	 @correo VARCHAR(100),
	 @estado BIT,
	 @mensaje VARCHAR(200) OUTPUT,
	 @resultado BIT OUTPUT
 )
 AS
 BEGIN
	SET @resultado = 0
	IF NOT EXISTS (SELECT * FROM Usuario WHERE Usu_correo = @correo AND idUsuario != @idUsuario)
	BEGIN
		UPDATE TOP (1) Usuario SET 
		Usu_nombres = @nombres, 
		Usu_apellidos = @apellidos, 
		Usu_correo = @correo,
		Usu_estado = @estado
		WHERE idUsuario = @idUsuario
		
		SET @resultado = 1
	END
	ELSE
		SET @mensaje = 'El correo del usuario ya existe'
 END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarUsuario]    Script Date: 02/12/2022 23:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_RegistrarUsuario](
	 @nombres VARCHAR(100),
	 @apellidos VARCHAR(100),
	 @correo VARCHAR(100),
	 @clave VARCHAR(100),
	 @estado BIT,
	 @mensaje VARCHAR(200) OUTPUT,
	 @resultado INT OUTPUT
 )
 AS
 BEGIN
	SET @resultado = 0
	IF NOT EXISTS (SELECT * FROM Usuario WHERE Usu_correo = @correo)
	BEGIN
		INSERT INTO Usuario (Usu_nombres, Usu_apellidos, Usu_correo, Usu_password, Usu_estado) 
		VALUES (@nombres, @apellidos, @correo, @clave, @estado)
		SET @resultado = SCOPE_IDENTITY()
	END
	ELSE
		SET @mensaje = 'El correo del usuario ya existe'
 END
GO
