Create Table Employees(
    UserName nvarchar(100),
    Password nvarchar(100),
    UserId nvarchar(200) primary key
);

Create Table ReimbursementForm(
    TicketNumber int identity,
    Amount money,
    Details nvarchar(Max),
    Status nvarchar(50),
    UserId nvarchar(200)foreign key references Employees(UserId)
);

Insert into ReimbursementForm(UserId) values (@UserId);
Insert into ReimbursementForm(Amount, Details, UserId, Status) values (@Amount, @Details, @UserId,'Open');
Insert into Employees(UserName, Password, UserId) values (@UserName, @Password, @UserId);
SELECT UserName FROM ReimbursementForm,Employees where Status = 'Open';
SELECT UserName FROM Employees;
drop table ReimbursementForm;
Update ReimbursementForm set UserId = @NewUserId where UserId = @UserId; --manager promotion
Update ReimbursementForm set Amount = @Amount, Details = @Details, Status = 'Open';