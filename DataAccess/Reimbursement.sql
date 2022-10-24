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

Create Table ReturnedForm(
    TicketNumber int,
    Amount money,
    Details nvarchar(Max),
    Comment nvarchar(Max),
    Status nvarchar(50),
    UserId nvarchar(200) foreign key references Employees(UserId)
);

select * from Employees;
select * from ReimbursementForm;
Insert into ReimbursementForm(UserId) values (@UserId);
Insert into ReimbursementForm(Amount, Details, UserId, Status) values (@Amount, @Details, @UserId,'Open');
Insert into Employees(UserName, Password, UserId) values (@UserName, @Password, @UserId);
Insert into ReturnedForm(TicketNumber, Amount, Details, Comment, Status, UserId) values (@TicketNumber, @Amount, @Details, @Comment, 'Open', @UserId);
SELECT * FROM ReimbursementForm where Status = 'Open' and UserName = @UserName;
SELECT UserName FROM ReimbursementForm,Employees where Status = 'Open' and ReimbursementForm.UserId = Employees.UserId;
SELECT UserName FROM Employees;
SELECT * FROM Employees;
SELECT * FROM ReturnedForm where UserId = @UserId and Status = 'Open';
SELECT TicketNumber from ReimbursementForm where UserId = @UserId and Status = 'Closed';
SELECT * from ReimbursementForm where TicketNumber = @TicketNumber;
SELECT UserName from Employees where UserId not like 'm+%';
Update ReimbursementForm set UserId = @NewUserId where UserId = @UserId; --manager promotion
Update ReimbursementForm set Amount = @Amount, Details = @Details, Status = 'Open';
Update ReimbursementForm set Amount = @Amount, Details = @Details where UserId = @UserId;
Update ReimbursementForm set Status = 'Closed' where UserId = @UserId;
Update ReturnedForm set Status = 'Closed' where UserId = @UserId;
Update ReimbursementForm set Status = 'Closed' where TicketNumber = @TicketNumber;
Update ReturnedForm set Status = 'Closed' where TicketNumber = @TicketNumber;
Update ReturnedForm set Comment = @Comment where UserId = @UserId;
Update Employee set UserId = CONCAT('m+', UserId) where UserName = @UserName;
 
 insert into employees values ('test', 'test', 'testtest');