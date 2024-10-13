--use db_rondacordobesa

-- Tabla Clientes
CREATE TABLE Clientes (
    IDCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    CorreoElectronico NVARCHAR(100),
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(100),
    Ciudad NVARCHAR(50),
    Provincia NVARCHAR(50),
    CodigoPostal NVARCHAR(10),
    FechaRegistro DATE DEFAULT GETDATE()
);

-- Tabla Productos
CREATE TABLE Productos (
    IDProducto INT PRIMARY KEY IDENTITY(1,1),
    NombreProducto NVARCHAR(100),
    Descripcion NVARCHAR(255),
    Precio DECIMAL(10, 2),
    StockDisponible INT,
    IDCategoria INT,
    FechaIngreso DATE DEFAULT GETDATE(),
    FOREIGN KEY (IDCategoria) REFERENCES Categorias(IDCategoria)
);

-- Tabla Categorías
CREATE TABLE Categorias (
    IDCategoria INT PRIMARY KEY IDENTITY(1,1),
    NombreCategoria NVARCHAR(100),
    DescripcionCategoria NVARCHAR(255)
);

-- Tabla Proveedores
CREATE TABLE Proveedores (
    IDProveedor INT PRIMARY KEY IDENTITY(1,1),
    NombreProveedor NVARCHAR(100),
    Telefono NVARCHAR(20),
    CorreoElectronico NVARCHAR(100),
    Direccion NVARCHAR(100),
    Ciudad NVARCHAR(50),
    Provincia NVARCHAR(50),
    CodigoPostal NVARCHAR(10)
);

-- Tabla Ventas
CREATE TABLE Ventas (
    IDVenta INT PRIMARY KEY IDENTITY(1,1),
    FechaVenta DATE DEFAULT GETDATE(),
    IDCliente INT,
    TotalVenta DECIMAL(10, 2),
    FOREIGN KEY (IDCliente) REFERENCES Clientes(IDCliente)
);

-- Tabla DetalleVentas
CREATE TABLE DetalleVentas (
    IDDetalleVenta INT PRIMARY KEY IDENTITY(1,1),
    IDVenta INT,
    IDProducto INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Subtotal AS (Cantidad * PrecioUnitario),
    FOREIGN KEY (IDVenta) REFERENCES Ventas(IDVenta),
    FOREIGN KEY (IDProducto) REFERENCES Productos(IDProducto)
);

-- Tabla Compras
CREATE TABLE Compras (
    IDCompra INT PRIMARY KEY IDENTITY(1,1),
    FechaCompra DATE DEFAULT GETDATE(),
    IDProveedor INT,
    TotalCompra DECIMAL(10, 2),
    FOREIGN KEY (IDProveedor) REFERENCES Proveedores(IDProveedor)
);

-- Tabla DetalleCompras
CREATE TABLE DetalleCompras (
    IDDetalleCompra INT PRIMARY KEY IDENTITY(1,1),
    IDCompra INT,
    IDProducto INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Subtotal AS (Cantidad * PrecioUnitario),
    FOREIGN KEY (IDCompra) REFERENCES Compras(IDCompra),
    FOREIGN KEY (IDProducto) REFERENCES Productos(IDProducto)
);

-- Tabla Stock
CREATE TABLE Stock (
    IDProducto INT PRIMARY KEY,
    CantidadDisponible INT,
    FechaActualizacion DATE DEFAULT GETDATE(),
    FOREIGN KEY (IDProducto) REFERENCES Productos(IDProducto)
);

-- Insertar categorías
INSERT INTO Categorias (NombreCategoria, DescripcionCategoria)
VALUES 
('Mates', 'Mates tradicionales de diferentes materiales'),
('Bombillas', 'Bombillas de acero inoxidable y otros materiales'),
('Termos', 'Termos para bebidas calientes'),
('Accesorios', 'Accesorios para yerba mate'),
('Yerbas', 'Distintos tipos de yerba y sabores');

-- Insertar productos
INSERT INTO Productos (NombreProducto, Descripcion, Precio, StockDisponible, IDCategoria)
VALUES 
('Imperial Premium', 'Premium de primera mano, hecho de cuero y calabaza, con base y detalles en virola', 30600, 5, 1),
('Mate Camionero Croco', 'Premium de primera mano, hecho con textura croco y liso', 16200, 4, 1),
('Torpedo Virola Cincelada', 'Hecho con cuero vacuno, de calabaza de primera mano, detalles en virola', 23800, 3, 1),
('Bombilla de acero inox.', 'Bombilla pico de loro, hecha de acero inoxidable', 4760, 20, 2),
('Termo 1 litro', 'Termo de acero inoxidable de 1 litro, media manija', 20400, 8, 3),
('Porta mate', 'Porta mate de cuero', 2000, 12, 4);

-- Insertar proveedores
INSERT INTO Proveedores (NombreProveedor, Telefono, CorreoElectronico, Direccion, Ciudad, Provincia, CodigoPostal)
VALUES 
('Mates Misioneros', '1156783456', 'contacto@mates.com', 'Calle Arguello 123', 'Misiones', 'MisionesAlCubo', '1000');

-- Insertar clientes
INSERT INTO Clientes (Nombre, Apellido, CorreoElectronico, Telefono, Direccion, Ciudad, Provincia, CodigoPostal)
VALUES 
('Juan', 'Pérez', 'juan.perez@mail.com', '1122334455', 'Calle 1', 'Buenos Aires', 'Buenos Aires', '1000'),
('Mauro', 'Viveros', 'mauroviveros@gmail.com', '1133445566', 'Calle 2', 'Paraguay', 'Chacarita', '2000'),
('Isabella', 'Rivarola', 'isita121212@mail.com', '1144556677', 'Calle 3', 'Córdoba', 'Córdoba', '5000');

-- Insertar compras (sin detalles aún)
INSERT INTO Compras (IDProveedor, TotalCompra)
VALUES 
(1, 250000);

-- Insertar detalles de compras
INSERT INTO DetalleCompras (IDCompra, IDProducto, Cantidad, PrecioUnitario)
VALUES 
(1, 1, 5, 30600),  -- Compra de Mates Imperiales Premium :)
(1, 2, 4, 16200),  -- Compra de Mates Croco
(1, 3, 2, 23800),  -- Compra de Mate Torpedo
(1, 4, 20, 4760),  -- Compra de Bombillas
(1,5, 8, 20400), -- Compra de Termos
(1,6, 12, 2000); --Compra Accesorios

-- Insertar ventas (sin detalles aún)
/* INSERT INTO Ventas (IDCliente, TotalVenta)
VALUES 
(1, 3500.00),
(2, 2000.00),
(3, 4000.00);

*/
-- Insertar detalles de ventas
/*INSERT INTO DetalleVentas (IDVenta, IDProducto, Cantidad, PrecioUnitario)
VALUES 
(1, 1, 2, 1500.00),  -- Juan compra 2 Mates de madera
(1, 3, 1, 500.00),   -- Juan compra 1 Bombilla de acero
(2, 2, 1, 1800.00),  -- María compra 1 Mate de vidrio
(2, 5, 1, 800.00),   -- María compra 1 Porta mate
(3, 4, 2, 2500.00);  -- Carlos compra 2 Termos
*/

-- Insertar stock
INSERT INTO Stock (IDProducto, CantidadDisponible)
VALUES 
(1, 5),  -- STOCK IMPERIAL PREMIUM
(2, 4),  -- STOCK CAMIONERO CROCO
(3, 3),  -- STOCK TORPEDO
(4, 20),  -- STOCK BOMBILLAS
(5, 8),  -- STOCK TERMOS
(6, 12); --STOCK ACCESORIOS

