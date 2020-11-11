CREATE procedure spUpdateContactDetails
(
@firstname varchar(150),
@lastname varchar(150),
@phonenumber float,
@email varchar(150),
@addressBookName varchar(150)
)
as
begin
update address_book_table 
set address_book_table.email=@email , address_book_table.phonenumber=@phonenumber
from address_book_table a
where  a.addressBookName=@addressBookName and a.firstname=@firstname and a.lastname=@lastname and a.phonenumber=@phonenumber
end