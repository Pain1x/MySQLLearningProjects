Create Table Stash
(
ID int identity primary key,
Name nvarchar(50) unique not null,
Price money not null,
Quantity int not null
);

Create Table Sold
(
ID int identity primary key,
Name nvarchar(50) not null,
Price money not null,
Quantity int not null,
Date date not null
);

Create Table CurrentExchange
(
ID int identity primary key,
Name nvarchar(50) not null,
Price money not null,
Quantity int not null,
AllSum money not null
);
Create Table AceeptedGoods
(
ID int identity primary key,
Name nvarchar(50) unique not null,
Price money not null,
Quantity int not null,
Date date not null
)
