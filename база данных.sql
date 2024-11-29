CREATE DATABASE ComputerShop;

USE ComputerShop;

CREATE TABLE Roles_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    RoleTitle VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Accounts_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Login VARCHAR(255) NOT NULL,
    Password VARBINARY NOT NULL,
    Role INT NOT NULL,
    FOREIGN KEY (Role) REFERENCES Roles_(ID) ON DELETE CASCADE ON UPDATE CASCADE,
	ImagePath NVARCHAR(255)
);

CREATE TABLE Clients_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    SecondName VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    SurName VARCHAR(255) NOT NULL,
    AccountID INT UNIQUE NOT NULL,
    FOREIGN KEY (AccountID) REFERENCES Accounts_(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Masters_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    SecondName VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255) NOT NULL,
    SurName VARCHAR(255) NOT NULL,
    WorkExperience TINYINT NOT NULL,
    Employment BIT NOT NULL,
    AccountID INT UNIQUE NOT NULL,
    FOREIGN KEY (AccountID) REFERENCES Accounts_(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Baskets_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ClientID INT NOT NULL,
    FOREIGN KEY (ClientID) REFERENCES Clients_(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Orders_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    BasketID INT NOT NULL,
    FOREIGN KEY (BasketID) REFERENCES Baskets_(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Products_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ProductName VARCHAR(255) NOT NULL,
    ProductCost INT NOT NULL,
	ImagePath NVARCHAR(255)
);

CREATE TABLE Services_
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    ServiceName VARCHAR(255) NOT NULL,
    ServiceCost INT NOT NULL,
	ImagePath NVARCHAR(255)
);

CREATE TABLE Masters_Services
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    MasterID INT NOT NULL,
    ServiceID INT NOT NULL,
    UNIQUE (MasterID, ServiceID),
    FOREIGN KEY (MasterID) REFERENCES Masters_(ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ServiceID) REFERENCES Services_(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Baskets_Services
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    BasketID INT NOT NULL,
    ServiceID INT NOT NULL,
    FOREIGN KEY (BasketID) REFERENCES Baskets_(ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ServiceID) REFERENCES Services_(ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Baskets_Products
(
    ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    BasketID INT NOT NULL,
    ProductID INT NOT NULL,
    FOREIGN KEY (BasketID) REFERENCES Baskets_(ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products_(ID) ON DELETE CASCADE ON UPDATE CASCADE
); 

INSERT INTO Roles_ (RoleTitle) VALUES ('User');
INSERT INTO Roles_ (RoleTitle) VALUES ('Moderator');
INSERT INTO Roles_ (RoleTitle) VALUES ('Administrator');

-- ������� 10 ������� � ������� Accounts_
INSERT INTO Accounts_ (Email, Login, Password, Role, ImagePath)
VALUES 
('user1@example.com', 'user1', 0x1234567890ABCDEF, 1, 'path/to/image1.jpg'),
('user2@example.com', 'user2', 0x1234567890ABCDEF, 1, 'path/to/image2.jpg'),
('user3@example.com', 'user3', 0x1234567890ABCDEF, 1, 'path/to/image3.jpg'),
('moderator1@example.com', 'mod1', 0x1234567890ABCDEF, 2, 'path/to/image4.jpg'),
('moderator2@example.com', 'mod2', 0x1234567890ABCDEF, 2, 'path/to/image5.jpg'),
('admin1@example.com', 'admin1', 0x1234567890ABCDEF, 3, 'path/to/image6.jpg'),
('admin2@example.com', 'admin2', 0x1234567890ABCDEF, 3, 'path/to/image7.jpg'),
('user4@example.com', 'user4', 0x1234567890ABCDEF, 1, 'path/to/image8.jpg'),
('moderator3@example.com', 'mod3', 0x1234567890ABCDEF, 2, 'path/to/image9.jpg'),
('admin3@example.com', 'admin3', 0x1234567890ABCDEF, 3, 'path/to/image10.jpg');
('user5@example.com', 'user5', 0x1234567890ABCDEF, 1, 'path/to/image11.jpg'),
('user6@example.com', 'user6', 0x1234567890ABCDEF, 1, 'path/to/image12.jpg'),
('user7@example.com', 'user7', 0x1234567890ABCDEF, 1, 'path/to/image13.jpg'),
('user8@example.com', 'user8', 0x1234567890ABCDEF, 1, 'path/to/image14.jpg'),
('moderator4@example.com', 'mod4', 0x1234567890ABCDEF, 2, 'path/to/image15.jpg'),
('moderator5@example.com', 'mod5', 0x1234567890ABCDEF, 2, 'path/to/image16.jpg'),
('admin4@example.com', 'admin4', 0x1234567890ABCDEF, 3, 'path/to/image17.jpg'),
('admin5@example.com', 'admin5', 0x1234567890ABCDEF, 3, 'path/to/image18.jpg'),
('user9@example.com', 'user9', 0x1234567890ABCDEF, 1, 'path/to/image19.jpg'),
('user10@example.com', 'user10', 0x1234567890ABCDEF, 1, 'path/to/image20.jpg');

-- ������� 10 ������� � ������� Clients_
INSERT INTO Clients_ (SecondName, FirstName, SurName, AccountID)
VALUES 
('�������', '�����', '����������', 20),
('�������', '�������', '����������', 21),
('���������', '�����', '�����������', 22),
('�����', '�������', '���������', 23),
('��������', '�����', '��������', 24),
('���������', '������', '��������', 25),
('���������', '��������', '�������������', 26),
('��������', '�������', 'Ը�������', 27),
('��������', '�������', '�����������', 28);

-- ������� 10 ������� � ������� Masters_
INSERT INTO Masters_ (SecondName, FirstName, SurName, WorkExperience, Employment, AccountID)
VALUES 
('�������', '������', '�������������', 5, 1, 29),
('�������', '�����', '������������', 8, 1, 30),
('��������', '���������', '����������', 10, 1, 31),
('�������', '�������', '��������', 3, 1, 32),
('�������', '������', '�����������', 4, 1, 33),
('�������', '����', '�������', 7, 1, 34),
('������', 'ϸ��', '�����������', 12, 1, 35),
('���������', '�����', '��������', 6, 1, 36),
('�����', '����', '����������', 2, 1, 37),
('������', '�����', '���������', 9, 1, 38);

SELECT * FROM Clients_;

-- ������� 10 ������� � ������� Baskets_
INSERT INTO Baskets_ (ClientID)
VALUES 
(3),
(6),
(7),
(8),
(9),
(10),
(11),
(12),
(13),
(14);

SELECT * FROM Baskets_;

-- ������� 10 ������� � ������� Orders_
INSERT INTO Orders_ (BasketID)
VALUES 
(11),
(12),
(13),
(14),
(15),
(16),
(17),
(18),
(19),
(20);

-- ������� 10 ������� � ������� Products_
INSERT INTO Products_ (ProductName, ProductCost, ImagePath)
VALUES 
('NVIDIA GeForce RTX 3080', 80000, 'path/to/rtx3080.jpg'),
('AMD Ryzen 7 5800X', 30000, 'path/to/ryzen7.jpg'),
('Corsair Vengeance LPX 16GB DDR4', 6000, 'path/to/ram16gb.jpg'),
('Samsung 970 EVO 1TB SSD', 12000, 'path/to/ssd970.jpg'),
('MSI MAG Z490 TOMAHAWK', 15000, 'path/to/msi-z490.jpg'),
('Cooler Master Hyper 212', 4000, 'path/to/hyper212.jpg'),
('Seagate Barracuda 2TB HDD', 5000, 'path/to/seagate2tb.jpg'),
('EVGA SuperNOVA 750W PSU', 9000, 'path/to/evga-psu.jpg'),
('Logitech G Pro X Superlight', 8000, 'path/to/logitech-mouse.jpg'),
('Asus ROG Strix XG27UQR Monitor', 35000, 'path/to/rog-monitor.jpg');

-- ������� 10 ������� � ������� Services_
INSERT INTO Services_ (ServiceName, ServiceCost, ImagePath)
VALUES 
('������ ����������', 1000, 'path/to/thermal-paste.jpg'),
('��������� ����������', 500, 'path/to/antivirus-install.jpg'),
('������ �� ����', 800, 'path/to/dust-cleaning.jpg'),
('��������� Windows 10', 1500, 'path/to/windows-install.jpg'),
('������ ����������', 2500, 'path/to/overclocking.jpg'),
('����� ����������', 2000, 'path/to/soldering-gpu.jpg'),
('������ ����� �������', 1200, 'path/to/psu-replacement.jpg'),
('���������� ���������', 600, 'path/to/drivers-update.jpg'),
('������ �� ��� �����', 4000, 'path/to/pc-build.jpg'),
('����������� �������', 700, 'path/to/system-diagnostics.jpg');

-- ������� 10 ������� � ������� Masters_Services
INSERT INTO Masters_Services (MasterID, ServiceID)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

-- ������� 10 ������� � ������� Baskets_Services
INSERT INTO Baskets_Services (BasketID, ServiceID)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

-- ������� 10 ������� � ������� Baskets_Products
INSERT INTO Baskets_Products (BasketID, ProductID)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);