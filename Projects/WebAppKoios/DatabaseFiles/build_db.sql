use [master]
go

create database [Naselja]
go

use [Naselja]
go

create table [Drzava] 
(
	DrzavaID int primary key identity,
	Naziv nvarchar(200)
)
go
create table [Naselje]
(
	NaseljeID int primary key identity,
	Naziv nvarchar(200),
	PostanskiBroj nvarchar(200),
	IDDrzava int foreign key references Drzava(DrzavaID) on delete cascade

)
go

select * from [Drzava]
select * from [Naselje]
go

create proc delete_naselje
	@naselje_id int
as 
	delete from [Naselje] where NaseljeID = @naselje_id
go

create proc insert_naselje
	@naziv nvarchar(200),
	@postanski_broj nvarchar(200),
	@id_drzava int
as
	insert into [Naselje] (Naziv, PostanskiBroj, IDDrzava) values (@naziv, @postanski_broj, @id_drzava)
go

create proc insert_dummy_data
as
	insert into [Drzava] 
	values ('Hrvatska'),('Srbija'),('Slovenija'), ('Italija'), ('Bosna i Hercegovina')
	insert into [Naselje] (Naziv, PostanskiBroj, IDDrzava) 
	values ('Dubrava', '10040', 1), ('Malesnica', '10090', 1), ('Tresnjevka', '10090', 1),
	('Vozdovac', '11010', 2), ('Palilula', '11000', 2), ('Rakovica', '47245', 2), 
	('Ucak', '1222', 3), ('Udje', '1290', 3), ('Ukanc', '4265', 3), 
	('Baia', '80070', 4), ('Ostia', '06', 4), ('Repentabor', '34016', 4), 
	('Brda', '73263', 5), ('Dervisi', '78000', 5), ('Kladovo Polje', '72243', 5)
go

exec insert_dummy_data
go
