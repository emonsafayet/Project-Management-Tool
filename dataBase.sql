CREATE TABLE tblDesignation (
    designationId int IDENTITY(1,1) PRIMARY KEY,
    designationName varchar (50) NULL

)

CREATE TABLE tblUser (
    userId int IDENTITY(1,1) PRIMARY KEY,
    userName varchar (50) NULL,
	userEmail varchar(50) NULL,
	userPassword varchar(50) NULL,
	status bit,
	isDeleted bit,
	 designationId int FOREIGN KEY REFERENCES tblDesignation(designationId)
)




CREATE TABLE tblProject (
    projectId int IDENTITY(1,1) PRIMARY KEY,
    projectName varchar (50) NULL,
	projectCode varchar(50) NULL,
	description varchar(512) NULL,
	possibleStartDate datetime,
	possibleEndDate datetime,
	filePath varchar(256),
	status varchar(10)

)
