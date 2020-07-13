use MonoBank;
Create Table Customers
(
ID int identity primary key not null,
FirstName nvarchar(20) not null,
SecondName nvarchar(20) not null,
PhoneNumber nvarchar(20) not null
);
Create Table CustomersLogs
(
ID int not null references Customers(ID),
Login nvarchar(20) not null,
Pass nvarchar(20) not null,
);
Create Table Chambers
(
ID int  not null references Customers(ID),
Money money not null,
);