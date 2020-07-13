use [ClanWork.v1];
Create Table Members
(id int identity primary key not null,
FirstName nvarchar(20) not null,
LastName nvarchar(20) not null,
Position nvarchar(20) not null,
Job nvarchar(20) not null
);
Create Table Logins
(id int identity primary key not null,
Log nvarchar(20) unique not null,
Pass nvarchar(20) unique not null,
Memberid INT REFERENCES Members (id) ON DELETE CASCADE
);
Create Table Positions
(id int identity primary key not null,
PositionName nvarchar(20) not null,
Invite nvarchar(20) not null,
Kick nvarchar(20) not null,
ChangePosition nvarchar(20) not null,
PutMoney nvarchar(20) not null,
WithdrawMoney nvarchar(20) not null,
WatchLogs nvarchar(20) not null
);
Create Table NewMembTab
(id int identity primary key not null,
FirstName nvarchar(20) not null,
LastName nvarchar(20) not null,
WantedPosition nvarchar(20) not null,
Log nvarchar(20) unique not null,
Pass nvarchar(20) unique not null
);
Create Table History
(id int identity primary key not null,
Action nvarchar(20) not null,
DateOfAction Date not null
);
Create Table Bank
(id int identity primary key not null,
Money money null
);