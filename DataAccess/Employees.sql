Create Table Employees(
    UserName nvarchar(100),
    Password nvarchar(100),
    UserId nvarchar(100) primary key,
);
Create Table Managers(
    UserName nvarchar(100),
    Password nvarchar(100),
    UserId nvarchar(100) primary key,
);
Create Table ReimbursementForm(
    TicketNumber int,
    Amount money,
    Details nvarchar(Max),
    UserId nvarchar(100) foreign key references Employees(UserId)
);

Insert into Employees values (UserName, Password);
Insert into Managers values (UserName, Password);
