

Create table Supplier(
	ID int primary key identity(1,1) not null,
	SupplierName varchar(50) not null,
	Phone varchar(20) not null,
	Email varchar(50) not null
);

Create table Lenguages(
	ID int primary key identity(1,1) not null,
	LenguageDescription varchar(50) not null
);

Create table TourType(
	ID int primary key identity(1,1) not null,
	TourName varchar(100) not null,
	TourDescription varchar(50) not null,
	Price decimal(14,2) not null
);

Create table Guide(
	ID int primary key identity(1,1) not null,
	GuideName varchar(50) not null,
	GuideLastName varchar(50) not null,
	Phone varchar(20) not null,
	Email varchar(50) not null,
	LenguagesID int not null,
	foreign key (LenguagesID) references Lenguages(ID)
);



Create table Reservation(
	ID int primary key identity(1,1) not null,
	TotalPAX int not null,
	TourTypeID int not null,
	CustomerName varchar(50) not null,
	GuideID int,
	ActivityDate date not null,
	SupplierID int not null,
	SellerName varchar(100) not null,
	UnitPrice decimal(14,2),
	Total decimal(14,2),
	foreign key (TourTypeID) references TourType(ID),
	foreign key (GuideID) references Guide(ID),
	foreign key (SupplierID) references Supplier(ID)
);
