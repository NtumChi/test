
Create Table ReimbursementForm(
    TicketNumber int,
    Amount money,
    Details nvarchar(Max),
    Status nvarchar(50),
    UserId nvarchar(100) primary key foreign key references ReimbursementForm(UserId)
);

Insert into ReimbursementForm(UserId) values (@UserId);
SELECT * FROM ReimbursementForm;
drop table ReimbursementForm;
Update ReimbursementForm(UserId) set UserId = @NewUserId where UserId = @UserId;
Update ReimbursementForm(TicketNumber, Amount, Details, Status) set TicketNumer = @TicketNumber, Amount = @Amount, Details = @Details, Status = 'Open';