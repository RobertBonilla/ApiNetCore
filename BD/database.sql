create database ApiNetCoreTest
go

use ApiNetCoreTest
go

create table customer(
ctmId int identity(1,1) primary key not null,
ctmName varchar(100) not null,
ctmLastName varchar(100) not null,
ctmDate date not null,
ctmDirection text not null,
ctmTelephone varchar(15) not null,
ctmEmail varchar(50) null,
createAt datetime DEFAULT GETDATE()
);
go