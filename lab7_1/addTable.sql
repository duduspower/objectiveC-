create database lab7_1

create table client(
	id int Primary Key NOT NULL, --autoIncrement not working in sqlserver :(
	name varchar(36) NOT NULL,
	surname varchar(36) NOT NULL,
	email varchar(64) NOT NULL,
	phone varchar(12) NOT NULL,
	registerTime datetime NOT NULL
);

select * from client;
