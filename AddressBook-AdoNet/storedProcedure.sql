CREATE Procedure spGetAllContacts
as
Begin

select a.firstname,a.lastname,a.phonenumber,a.email,c.address,c.city,c.state,c.zip,t.TypeName,a.addressBookName
from address_book_table a
join AddressBookAndTypeData ad 
on a.AddressBookId=ad.AddressBookId
join TypeOfContacts t
on ad.TypeId=t.TypeId
join complete_address c 
on a.CompleteAddressId = c.CompleteAddressId
end