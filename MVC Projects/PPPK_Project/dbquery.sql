use [master]
go

create database pppkDB
go

use pppkDB
go

create table Driver
(
	DriverID int primary key identity,
	[Name] nvarchar(20),
	Surname nvarchar(20),
	PhoneNumber nvarchar(20),
	DriverLicenceNumber nvarchar(20)
)
go
create table Vehicle
(
	VehicleID int primary key identity,
	VehicleType nvarchar(20),
	VehicleBrand nvarchar(20),
	ProductionYear date,
	StartingKilometers int,
	CurrentKilometers int
)
go
create table [Status]
(
	StatusID int primary key identity,
	StatusType nvarchar(20)
)
go
create table TravelWarrant
(
	TravelWarrantID int primary key identity,
	DateCreated date,
	StartingDate date,
	EndingDate date,
	IDStatus int foreign key references [Status](StatusID),
	IDDriver int foreign key references Driver(DriverID),
	IDVehicle int foreign key references Vehicle(VehicleID)
)
go
create table [Service]
(
	ServiceID int primary key identity,
	PlaceOfService nvarchar(30),
	NameOfService nvarchar(30),
	CostOfService int,
	ServiceInfo nvarchar(400),
	IDVehicle int foreign key references Vehicle(VehicleID),
	IDTravelWarrant int foreign key references TravelWarrant(TravelWarrantID)
)
go
create table CostOfGasRefill
(
	CostOfGasRefillID int primary key identity,
	DateCreated date,
	RefillPlaceName nvarchar(30),
	AmountRefilledInLiters int,
	CostOfRefill int,
	IDTravelWarrant int foreign key references TravelWarrant(TravelWarrantID)
)
go
create table TravelRoute
(
	TravelRouteID int primary key identity,
	x_cordinate_ofDeparture decimal(20,10),
	y_cordinate_ofDeparture decimal(20,10),
	x_cordinate_ofArrival decimal(20,10),
	y_cordinate_ofArrival decimal(20,10),
	TotalTravelDistance decimal(10,2),
	AverageSpeed decimal(6,2),
	IDTravelWarrant int foreign key references TravelWarrant(TravelWarrantID)
)
go
create table OccupyingDriver
(
	OccupyingDriverID int primary key identity,
	DateOccupyingStarted date,
	IDDriver int foreign key references Driver(DriverID)
)
go
create table OccupyedVehicle
(
	OccupyedVehicleID int primary key identity,
	DateOccupyingStarted date,
	IDVehicle int foreign key references Vehicle(VehicleID)
)
go
create proc insert_driver
	@fname nvarchar(20),
	@lastname nvarchar(20),
	@phonenum nvarchar(30),
	@driverlicensenum nvarchar(20)
as
	insert into Driver ([Name], Surname, PhoneNumber, DriverLicenceNumber) values (@fname, @lastname, @phonenum, @driverlicensenum)
go

create proc insert_vehicle
	@type nvarchar(30),
	@model nvarchar(30),
	@prodyear date,
	@startingkilometers int,
	@currentkilometers int
as
	insert into Vehicle (VehicleType, VehicleBrand, ProductionYear, StartingKilometers, CurrentKilometers) values (@type, @model, @prodyear, @startingkilometers, @currentkilometers)
go
create proc insert_service
	@placeofservice nvarchar(30),
	@nameofservice nvarchar(30),
	@costofservice int,
	@info nvarchar(400),
	@vehicleID int
as
	insert into [Service] (PlaceOfService, NameOfService, CostOfService, ServiceInfo, IDVehicle) values (@placeofservice, @nameofservice, @costofservice, @info, @vehicleID)
go
create proc insert_costofgasrefill
	@datecreated date,
	@nameofplacerefilled nvarchar(30),
	@amountofgasrefilledinliters int,
	@costofgasrefilled int,
	@travelwarrantID int
as
	insert into CostOfGasRefill (DateCreated, RefillPlaceName, AmountRefilledInLiters, CostOfRefill, IDTravelWarrant) values (@datecreated, @nameofplacerefilled, @amountofgasrefilledinliters, @costofgasrefilled, @travelwarrantID)
go
create proc insert_travelwarrant
	@datecreated date,
	@dateofstart date,
	@dateofending date,
	@IDstatus int,
	@IDDriver int,
	@IDVehicle int
as
	insert into TravelWarrant (DateCreated, StartingDate, EndingDate, IDStatus, IDDriver, IDVehicle) values (@datecreated, @dateofstart, @dateofending, @IDstatus, @IDDriver, @IDVehicle)
go
create proc insert_trevelroute
	@x_departure decimal(20,10),
	@y_departure decimal(20,10),
	@x_arrival decimal(20,10), 
	@y_arrival decimal(20,10),
	@distance decimal(10,2), 
	@speed decimal(6,2),
	@IDtravelwarrant int
as
	insert into TravelRoute (x_cordinate_ofDeparture, y_cordinate_ofDeparture, x_cordinate_ofArrival, y_cordinate_ofArrival, TotalTravelDistance, AverageSpeed, IDTravelWarrant) values (@x_departure, @y_departure, @x_arrival, @y_arrival, @distance, @speed, @IDtravelwarrant)
go
create proc delete_service
    @id int
as
    if exists(select ServiceID from [Service] where ServiceID=@id) begin
        delete from [Service] where ServiceID=@id
	end
	else begin
		select null
    end    
go
create proc delete_vehicle
    @id int
as
     if exists(select VehicleID from Vehicle where VehicleID=@id) begin
        begin try
            begin transaction
                delete from OccupyedVehicle where IDVehicle=@id
                delete from [Service] where IDVehicle=@id
                delete from TravelRoute where 
                    IDTravelWarrant in(
                        select TravelWarrantID from TravelWarrant where IDVehicle=@id
                    )
                delete from CostOfGasRefill where 
                    IDTravelWarrant in(
                        select TravelWarrantID from TravelWarrant where IDVehicle=@id
                    )
		        delete from TravelWarrant where IDVehicle=@id
                delete from Vehicle where VehicleID=@id
            commit tran
        end try
        begin catch
            if @@TRANCOUNT > 0
                rollback tran
            select null;
        end catch
	end
	else begin
		select null
    end
go
create proc delete_travelwarrant
    @id int
as
     if exists(select TravelWarrantID from TravelWarrant where TravelWarrantID=@id) begin
        begin try
            begin transaction
                delete from TravelRoute where IDTravelWarrant=@id
                delete from CostOfGasRefill where IDTravelWarrant=@id
                delete from TravelWarrant where TravelWarrantID=@id
            commit tran
        end try
        begin catch
            if @@TRANCOUNT > 0
                rollback tran
            select null;
        end catch
	end
	else begin
		select null
    end
go
create proc delete_travelroute
    @id int
as
   if exists(select TravelRouteID from TravelRoute where TravelRouteID=@id) begin
        begin try
            begin transaction
                delete from TravelRoute where TravelRouteID=@id
            commit tran
        end try
        begin catch
            if @@TRANCOUNT > 0
                rollback tran
            select null;
        end catch
	end
	else begin
		select null
    end  
go
create proc delete_driver
    @id int
as
    if exists(select DriverID from Driver where DriverID = @id) begin
        begin try
            begin transaction
                delete from OccupyingDriver where IDDriver = @id
                delete from TravelRoute where 
                    IDTravelWarrant in(
                        select TravelWarrantID from TravelWarrant where IDDriver = @id
                    )
                delete from CostOfGasRefill where 
                    IDTravelWarrant in(
                        select TravelWarrantID from TravelWarrant where IDDriver = @id
                    )
		        delete from TravelWarrant where IDDriver=@id
                delete from Driver where DriverID=@id
            commit tran
        end try
        begin catch
            if @@TRANCOUNT > 0
                rollback tran
            select null;
        end catch
	end
	else begin
		select null
    end
go
create proc select_travelwarrant
    @id int
as
    if exists(select TravelWarrantID from TravelWarrant where TravelWarrantID=@id) begin
        select tw.*,s.StatusType,d.[Name],d.Surname,v.VehicleType,v.VehicleBrand,v.VehicleType from TravelWarrant as tw
            left join Driver as d on tw.IDDriver = d.DriverID
            left join Vehicle as v on tw.IDVehicle = v.VehicleID
            left join [Status] as s on tw.IDStatus = s.StatusID
        where tw.TravelWarrantID = @id
    end
    else begin
        select null
    end
go
create proc select_all_travelwarrants
as
    select tw.*,s.StatusType,d.[Name],d.Surname,v.VehicleType,v.VehicleBrand,v.VehicleType from TravelWarrant as tw
		left join Driver as d on tw.IDDriver = d.DriverID
		left join Vehicle as v on tw.IDVehicle = v.VehicleID
		left join [Status] as s on tw.IDStatus = s.StatusID
go
create proc enable_id_insert
as
    exec sp_MSForEachTable 'SET IDENTITY_INSERT ? ON'
go

create proc disable_id_insert
as
    exec sp_MSForEachTable 'SET IDENTITY_INSERT ? OFF'
go
--Dummy data
create proc insert_dummy_data
as
    insert into [Status]
    values ('In progress'),('Ended')
    insert into Driver
    values 
    ('Pero','Peric','+385912345678','12345678'),
    ('Ivo','Ivic','+385912345678', '87654321'),
	('Matea','Mateic','+38594234234', '83682638')
    insert into Vehicle
    values
    ('Kupe','Tesla Model S','01/01/2012',10000,10010),
    ('Karavan','Golf 7','01/01/2010',143215,153215),
	('Hatchback','Audi A6', '01/01/2016', 2000,2100)
    insert into TravelWarrant
    values
    ('1/10/2020','1/10/2020','1/11/2020',1,1,1),
    ('12/10/2019','12/10/2019','12/13/2020',2,2,2),
	('04/19/2015','04/19/2015','04/21/2015',2,3,3)
    insert into OccupyingDriver
    values
    ('1/10/2020',1),
    ('1/11/2020',1),
    ('12/10/2019',2),
    ('12/11/2019',2),
    ('04/19/2015',3),
    ('04/21/2015',3)
    insert into OccupyedVehicle
    values
    ('1/10/2020',1),
    ('1/11/2020',1),
    ('12/10/2019',2),
    ('12/11/2019',2),
    ('04/19/2015',3),
    ('04/21/2015',3)
    insert into [Service]
    values
    ('Zagreb','Zamjena diskova',1500,'AutolimarZagreb',1,1)
    insert into CostOfGasRefill
    values
    ('1/10/2020','Autocesta A1',50,500,1),
    ('1/10/2020','Autocesta A1',100,1000,2),
    ('04/21/2020','Autocesta A1',25,250,3)
    insert into TravelRoute
    values
    (50.1241241,40.1241251,40.5215121,50.512411,20.1,110.2,3),
    (60.1241241,10.1241251,40.5215121,90.512411,30.21,90.2,3),
    (70.1241241,30.1241251,30.5215121,60.512411,40.31,70.2,3),
    (80.1241241,40.1241251,20.5215121,70.512411,50.41,70.2,3)
go
create proc clean_database
as
    delete from OccupyingDriver
    delete from OccupyedVehicle
    delete from TravelRoute
    delete from CostOfGasRefill
    delete from [Service]
    delete from TravelWarrant
    delete from [Status]
    delete from Vehicle
    delete from Driver
    exec sp_MSforeachtable 'DBCC CHECKIDENT ([?], reseed, 0)'
go

exec insert_dummy_data